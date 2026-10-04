Public Class frmLeave_e
    Private adding As Boolean = False
    Private updating As Boolean = False
    Private selectedRequestId As Integer = -1

    Private Sub frmLeave_e_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()

        loadform()
    End Sub

    Public Sub loadform()
        btnnew.Enabled = True
        btnsave.Enabled = False
        pnlinput.Enabled = False

        locknew.Visible = False
        lockupdate.Visible = False
        lockdelete.Visible = False
        locksave.Visible = True
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT * FROM tblleaverequests WHERE employeeid = @e"

        If search <> "" Then
            query &= " AND (reason LIKE @s OR status LIKE @s OR datefrom LIKE @s OR dateto LIKE @s)"
        End If

        query &= " ORDER BY datefrom ASC"

        GetQuery(query, "leaverequests", P("@e", loggedinemployeeid), P("@s", "%" & search & "%"))
        lvleavereq.Items.Clear()

        For Each row As DataRow In ds.Tables("leaverequests").Rows
            Dim item As New ListViewItem(row("id").ToString())
            item.SubItems.Add(Convert.ToDateTime(row("datefrom")).ToString("yyyy-MM-dd"))
            item.SubItems.Add(Convert.ToDateTime(row("dateto")).ToString("yyyy-MM-dd"))
            item.SubItems.Add(row("reason").ToString())
            item.SubItems.Add(row("status").ToString())

            Select Case row("status").ToString()
                Case "Pending"
                    item.ForeColor = Color.Orange
                Case "Approved"
                    item.ForeColor = Color.Green
                Case "Rejected"
                    item.ForeColor = Color.Red
                Case Else
                    item.ForeColor = Color.Black
            End Select

            lvleavereq.Items.Add(item)
        Next
    End Sub



    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Not (adding Or updating) Then Exit Sub

        Dim dateFrom As Date = dtpdatefrom.Value.Date
        Dim dateTo As Date = dtpdateto.Value.Date
        Dim reason As String = txtreason.Text.Trim()

        If reason = "" Then
            MsgBox("Please provide a reason for the leave request.", MsgBoxStyle.Exclamation, "Missing Information")
            Exit Sub
        End If

        If reason.Length > 255 Then
            MsgBox("The reason can be at most 255 characters.", MsgBoxStyle.Exclamation, "Too Long")
            Exit Sub
        End If

        If dateFrom > dateTo Then
            MsgBox("'From' date cannot be greater than 'To' date.", MsgBoxStyle.Critical, "Date Error")
            Exit Sub
        End If

        Dim excludeId As Integer = If(updating, selectedRequestId, -1)
        If CInt(GetValue("SELECT COUNT(*) FROM tblleaverequests WHERE employeeid = @e AND status IN ('Pending', 'Approved') AND id <> @id AND datefrom <= @t AND dateto >= @f",
                         P("@e", loggedinemployeeid), P("@id", excludeId), P("@f", dateFrom.ToString("yyyy-MM-dd")), P("@t", dateTo.ToString("yyyy-MM-dd")))) > 0 Then
            MsgBox("These dates overlap another pending or approved leave request.", MsgBoxStyle.Exclamation, "Overlapping Leave")
            Exit Sub
        End If

        If adding Then
            If Not SetQuery("INSERT INTO tblleaverequests (employeeid, datefrom, dateto, reason, status) VALUES (@e, @f, @t, @r, 'Pending')",
                            P("@e", loggedinemployeeid), P("@f", dateFrom.ToString("yyyy-MM-dd")), P("@t", dateTo.ToString("yyyy-MM-dd")), P("@r", reason)) Then Exit Sub
            MsgBox("Your leave request has been submitted successfully!", MsgBoxStyle.Information, "Leave Request Submitted")
        Else
            ' Only the employee's own request, and only while it is still pending.
            Dim changed As Integer
            Try
                changed = Execute("UPDATE tblleaverequests SET datefrom = @f, dateto = @t, reason = @r WHERE id = @id AND employeeid = @e AND status = 'Pending'",
                                  P("@f", dateFrom.ToString("yyyy-MM-dd")), P("@t", dateTo.ToString("yyyy-MM-dd")), P("@r", reason), P("@id", selectedRequestId), P("@e", loggedinemployeeid))
            Catch ex As Exception
                MsgBox("Could not update the leave request: " & ex.Message, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try

            If changed = 0 Then
                MsgBox("This leave request has already been reviewed, so it can no longer be changed.", MsgBoxStyle.Exclamation, "Not Pending")
            Else
                MsgBox("Leave request updated successfully!", MsgBoxStyle.Information, "Update Successful")
            End If
        End If

        clearfields()
        fill()
        disablebuttons()
        pnlinput.Enabled = False
        adding = False
        updating = False
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If updating Then
            If MsgBox("Are you sure you want to cancel updating leave request information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                updating = False
                disablebuttons()
                clearfields()
                pnlinput.Enabled = False
            End If
        ElseIf adding Then
            If MsgBox("Are you sure you want to cancel adding new leave request information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
                disablebuttons()
                clearfields()
                pnlinput.Enabled = False
            End If
        Else
            adding = False
            updating = False
            disablebuttons()
            clearfields()
            pnlinput.Enabled = False
        End If
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearfields()
        adding = True
        pnlinput.Enabled = True
    End Sub

    Public Sub enablebuttons()
        btnnew.Enabled = 0
        btnupdate.Enabled = 0
        btndelete.Enabled = 0
        btncancel.Enabled = 1
        btnsave.Enabled = 1

        locknew.Visible = True
        lockupdate.Visible = True
        lockdelete.Visible = True
        locksave.Visible = False
    End Sub

    Public Sub disablebuttons()
        btnnew.Enabled = 1
        btnupdate.Enabled = 1
        btndelete.Enabled = 1
        btncancel.Enabled = 1
        btnsave.Enabled = 0

        locknew.Visible = False
        lockupdate.Visible = False
        lockdelete.Visible = False
        locksave.Visible = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If selectedRequestId <> -1 Then
            enablebuttons()
            updating = True
            pnlinput.Enabled = True
        Else
            MsgBox("Please select a leave request to update.", MsgBoxStyle.Exclamation, "No Request Selected")
        End If

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If selectedRequestId = -1 Then
            MsgBox("Please select a leave request to delete.", MsgBoxStyle.Exclamation, "No Request Selected")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this leave request?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Confirmation") = MsgBoxResult.Yes Then
            Dim deleted As Integer
            Try
                deleted = Execute("DELETE FROM tblleaverequests WHERE id = @id AND employeeid = @e AND status = 'Pending'", P("@id", selectedRequestId), P("@e", loggedinemployeeid))
            Catch ex As Exception
                MsgBox("Could not delete the leave request: " & ex.Message, MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try

            clearfields()
            disablebuttons()
            fill()

            If deleted = 0 Then
                MsgBox("This leave request has already been reviewed, so it can't be deleted.", MsgBoxStyle.Exclamation, "Not Pending")
            Else
                MsgBox("Leave request deleted successfully!", MsgBoxStyle.Information, "Deletion Successful")
            End If
        End If
    End Sub

    Private Sub lvleavereq_DoubleClick(sender As Object, e As EventArgs) Handles lvleavereq.DoubleClick
        If adding Or updating Then Exit Sub

        If lvleavereq.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = lvleavereq.SelectedItems(0)
            Dim status As String = item.SubItems(4).Text

            dtpdatefrom.Value = Convert.ToDateTime(item.SubItems(1).Text)
            dtpdateto.Value = Convert.ToDateTime(item.SubItems(2).Text)
            txtreason.Text = item.SubItems(3).Text

            If status = "Pending" Then
                selectedRequestId = CInt(item.SubItems(0).Text)
                btnupdate.Enabled = True
                btndelete.Enabled = True
                lockupdate.Visible = False
                lockdelete.Visible = False
            Else
                ' Reviewed requests are view-only.
                selectedRequestId = -1
                btnupdate.Enabled = False
                btndelete.Enabled = False
                lockupdate.Visible = True
                lockdelete.Visible = True
            End If


            btnsave.Enabled = False
            btncancel.Enabled = True
            pnlinput.Enabled = False

            locksave.Visible = True
        End If
    End Sub


    Public Sub clearfields()
        selectedRequestId = -1
        txtreason.Clear()
        dtpdatefrom.Value = DateTime.Now
        dtpdateto.Value = DateTime.Now
        txtsearch.Clear()
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub


End Class
