Public Class frmLeave
    Private selectedRequestId As Integer = -1

    Private Sub frmLeave_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")

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
            pendingQuery &= " AND (e.firstname LIKE '%" & searchLeave & "%' OR e.lastname LIKE '%" & searchLeave & "%' OR lr.reason LIKE '%" & searchLeave & "%')"
        End If

        pendingQuery &= " ORDER BY lr.datefrom ASC"

        GetQuery(pendingQuery, "pending")
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
            historyQuery &= " AND (e.firstname LIKE '%" & search & "%' OR e.lastname LIKE '%" & search & "%' OR lr.reason LIKE '%" & search & "%')"
        End If

        historyQuery &= " ORDER BY lr.datefrom DESC"

        GetQuery(historyQuery, "history")
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
        If selectedRequestId <> -1 Then
            SetQuery("UPDATE tblleaverequests SET datefrom = '" & dtpdatefrom.Value.ToString("yyyy-MM-dd") &
                  "', dateto = '" & dtpdateto.Value.ToString("yyyy-MM-dd") &
                  "', status = 'Approved' WHERE id = " & selectedRequestId)

            Dim query As String = "SELECT employeeid, datefrom, dateto FROM tblleaverequests WHERE id = " & selectedRequestId
            GetQuery(query, "leaveDetails")

            If ds.Tables("leaveDetails").Rows.Count > 0 Then
                Dim row As DataRow = ds.Tables("leaveDetails").Rows(0)
                Dim employeeId As Integer = row("employeeid")
                Dim dateFrom As Date = row("datefrom")
                Dim dateTo As Date = row("dateto")

                For day As Integer = 0 To DateDiff(DateInterval.Day, dateFrom, dateTo)
                    Dim attendanceDate As Date = dateFrom.AddDays(day)
                    Dim insertAttendanceQuery As String = "INSERT INTO tblattendance (employeeid, date, status, timein, timeout) " & _
                                                           "VALUES (" & employeeId & ", '" & attendanceDate.ToString("yyyy-MM-dd") & "', 'On Leave', '00:00:00', '00:00:00')"
                    SetQuery(insertAttendanceQuery)
                Next
            End If

            MsgBox("Leave request approved and attendance updated.", MsgBoxStyle.Information, "Status Updated")
            clearfields()
            fill()
        End If
    End Sub

    Private Sub btnreject_Click(sender As Object, e As EventArgs) Handles btnreject.Click
        If selectedRequestId <> -1 Then
            SetQuery("UPDATE tblleaverequests SET status = 'Rejected' WHERE id = " & selectedRequestId)
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
        selectedRequestId = Nothing
    End Sub
End Class