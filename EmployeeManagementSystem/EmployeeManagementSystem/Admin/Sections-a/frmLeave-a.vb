Public Class frmLeave
    Private selectedRequestId As Integer = -1

    Private Sub frmLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()

        loadform()
    End Sub

    Public Sub loadform()
        pnlinput.Enabled = False
        clearfields()
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim searchLeave As String = txtsearchleave.Text.Trim()

        Dim pendingQuery As String = "SELECT lr.id, CONCAT(e.lastname, ', ', e.firstname) AS employeename, lr.datefrom, lr.dateto, lr.reason " & _
                                      "FROM tblleaverequests lr " & _
                                      "INNER JOIN tblemployee e ON lr.employeeid = e.id " & _
                                      "WHERE lr.status = 'Pending'"

        If searchLeave <> "" Then
            pendingQuery &= " AND (e.firstname LIKE @s OR e.lastname LIKE @s OR lr.reason LIKE @s)"
        End If

        pendingQuery &= " ORDER BY lr.datefrom ASC"

        GetQuery(pendingQuery, "pending", P("@s", "%" & searchLeave & "%"))
        lvpendingleave.Items.Clear()
        For Each row As DataRow In ds.Tables("pending").Rows
            Dim item As New ListViewItem(row("id").ToString())
            item.SubItems.Add(row("employeename").ToString())
            item.SubItems.Add(Convert.ToDateTime(row("datefrom")).ToString("yyyy-MM-dd"))
            item.SubItems.Add(Convert.ToDateTime(row("dateto")).ToString("yyyy-MM-dd"))
            item.SubItems.Add(row("reason").ToString())
            lvpendingleave.Items.Add(item)
        Next

        Dim historyQuery As String = "SELECT lr.id, CONCAT(e.lastname, ', ', e.firstname) AS employeename, lr.datefrom, lr.dateto, lr.reason, lr.status " & _
                                     "FROM tblleaverequests lr " & _
                                     "INNER JOIN tblemployee e ON lr.employeeid = e.id " & _
                                     "WHERE lr.status IN ('Approved', 'Rejected')"

        If search <> "" Then
            historyQuery &= " AND (e.firstname LIKE @s OR e.lastname LIKE @s OR lr.reason LIKE @s)"
        End If

        historyQuery &= " ORDER BY lr.datefrom DESC"

        GetQuery(historyQuery, "history", P("@s", "%" & search & "%"))
        lvleavehistory.Items.Clear()
        For Each row As DataRow In ds.Tables("history").Rows
            Dim item As New ListViewItem(row("id").ToString())
            item.SubItems.Add(row("employeename").ToString())
            item.SubItems.Add(Convert.ToDateTime(row("datefrom")).ToString("yyyy-MM-dd"))
            item.SubItems.Add(Convert.ToDateTime(row("dateto")).ToString("yyyy-MM-dd"))
            item.SubItems.Add(row("reason").ToString())
            item.SubItems.Add(row("status").ToString())
            lvleavehistory.Items.Add(item)

            Select Case row("status").ToString()
                Case "Approved"
                    item.ForeColor = Color.Green
                Case "Rejected"
                    item.ForeColor = Color.Red
                Case Else
                    item.ForeColor = Color.Black
            End Select
        Next
    End Sub

    Private Sub btnapprove_Click(sender As Object, e As EventArgs) Handles btnapprove.Click
        If selectedRequestId = -1 Then Exit Sub

        Dim dateFrom As Date = dtpdatefrom.Value.Date
        Dim dateTo As Date = dtpdateto.Value.Date
        If dateTo < dateFrom Then
            MsgBox("'To' date can't be earlier than the 'From' date.", MsgBoxStyle.Critical, "Date Error")
            Exit Sub
        End If

        Dim marked As Integer = 0
        Try
            BeginTransaction()
            If Execute("UPDATE tblleaverequests SET datefrom = @f, dateto = @t, status = 'Approved' WHERE id = @id AND status = 'Pending'",
                       P("@f", dateFrom.ToString("yyyy-MM-dd")), P("@t", dateTo.ToString("yyyy-MM-dd")), P("@id", selectedRequestId)) = 0 Then
                RollbackTransaction()
                MsgBox("This leave request is no longer pending.", MsgBoxStyle.Exclamation, "Status Updated")
                clearfields()
                fill()
                Exit Sub
            End If

            Dim employeeId As Integer = CInt(GetValue("SELECT employeeid FROM tblleaverequests WHERE id = @id", P("@id", selectedRequestId)))

            ' Mark each day On Leave. An Absent day becomes On Leave; days the employee
            ' actually worked (Present/Late) or already marked On Leave are left alone.
            For day As Integer = 0 To CInt(DateDiff(DateInterval.Day, dateFrom, dateTo))
                Dim attendanceDate As String = dateFrom.AddDays(day).ToString("yyyy-MM-dd")
                Dim current As Object = GetValue("SELECT status FROM tblattendance WHERE employeeid = @e AND date = @d", P("@e", employeeId), P("@d", attendanceDate))

                If current Is Nothing Then
                    Execute("INSERT INTO tblattendance (employeeid, date, status, timein, timeout) VALUES (@e, @d, 'On Leave', '00:00:00', '00:00:00')",
                            P("@e", employeeId), P("@d", attendanceDate))
                    marked += 1
                ElseIf current.ToString() = "Absent" Then
                    Execute("UPDATE tblattendance SET status = 'On Leave', timein = '00:00:00', timeout = '00:00:00' WHERE employeeid = @e AND date = @d",
                            P("@e", employeeId), P("@d", attendanceDate))
                    marked += 1
                End If
            Next
            CommitTransaction()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Could not approve the leave request: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        MsgBox("Leave request approved and attendance updated (" & marked & " day(s) marked On Leave).", MsgBoxStyle.Information, "Status Updated")
        clearfields()
        fill()
    End Sub

    Private Sub btnreject_Click(sender As Object, e As EventArgs) Handles btnreject.Click
        If selectedRequestId = -1 Then Exit Sub

        If SetQuery("UPDATE tblleaverequests SET status = 'Rejected' WHERE id = @id AND status = 'Pending'", P("@id", selectedRequestId)) Then
            MsgBox("Leave request rejected.", MsgBoxStyle.Information, "Status Updated")
            clearfields()
            fill()
        End If
    End Sub

    Public Sub clearfields()
        selectedRequestId = -1
        dtpdatefrom.Value = DateTime.Now
        dtpdateto.Value = DateTime.Now
        txtreason.Clear()
        btnapprove.Enabled = False
        btnreject.Enabled = False

        lockapprove.Visible = True
        lockreject.Visible = True
    End Sub

    Private Sub lvpendingleave_DoubleClick(sender As Object, e As EventArgs) Handles lvpendingleave.DoubleClick
        If lvpendingleave.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = lvpendingleave.SelectedItems(0)
            selectedRequestId = CInt(item.SubItems(0).Text)
            dtpdatefrom.Value = Date.Parse(item.SubItems(2).Text)
            dtpdateto.Value = Date.Parse(item.SubItems(3).Text)
            txtreason.Text = item.SubItems(4).Text

            btnapprove.Enabled = True
            btnreject.Enabled = True

            pnlinput.Enabled = True
            lockapprove.Visible = False
            lockreject.Visible = False
        End If

    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

    Private Sub txtsearchleave_TextChanged(sender As Object, e As EventArgs) Handles txtsearchleave.TextChanged
        fill()
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        clearfields()
        pnlinput.Enabled = False
        selectedRequestId = -1
    End Sub
End Class
