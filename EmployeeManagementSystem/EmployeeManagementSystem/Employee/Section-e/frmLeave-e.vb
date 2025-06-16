Public Class frmLeave_e
    Private adding As Boolean = False
    Private updating As Boolean = False
    Private selectedRequestId As Integer = -1

    Private Sub frmLeave_e_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")

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
        Dim query As String = "SELECT * FROM tblleaverequests WHERE employeeid = " & loggedinemployeeid

        If search <> "" Then
            query &= " AND (reason LIKE '%" & search & "%' OR status LIKE '%" & search & "%' OR datefrom LIKE '%" & search & "%' OR dateto LIKE '%" & search & "%')"
        End If

        query &= " ORDER BY datefrom ASC"

        GetQuery(query, "leaverequests")
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
        Dim dateFrom As DateTime = dtpdatefrom.Value
        Dim dateTo As DateTime = dtpdateto.Value
        Dim reason As String = txtreason.Text.Trim()

        If reason = "" Then
            MsgBox("Please provide a reason for the leave request.", MsgBoxStyle.Exclamation, "Missing Information")
            Exit Sub
        End If

        If dateFrom > dateTo Then
            MsgBox("'From' date cannot be greater than 'To' date.", MsgBoxStyle.Critical, "Date Error")
            Exit Sub
        End If

        If adding Then
            SetQuery("INSERT INTO tblleaverequests (employeeid, datefrom, dateto, reason, status) VALUES (" & loggedinemployeeid & ", '" & dateFrom.ToString("yyyy-MM-dd") & "', '" & dateTo.ToString("yyyy-MM-dd") & "', '" & reason & "', 'Pending')")
            MsgBox("Your leave request has been submitted successfully!", MsgBoxStyle.Information, "Leave Request Submitted")
            MsgBox("Leave request saved successfully!")

        ElseIf updating Then
            SetQuery("UPDATE tblleaverequests SET datefrom = '" & dateFrom.ToString("yyyy-MM-dd") & "', dateto = '" & dateTo.ToString("yyyy-MM-dd") & "', reason = '" & reason & "' WHERE id = " & selectedRequestId)
            MsgBox("Leave request updated successfully!", MsgBoxStyle.Information, "Update Successful")
            MsgBox("Leave request updated successfully!")
        End If

        clearfields()
        fill()
        disablebuttons()
        pnlinput.Enabled = False
        updating = False
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
        If lvleavereq.SelectedItems.Count > 0 Then
            enablebuttons()
            updating = True
            pnlinput.Enabled = True
        Else
            MsgBox("Please select a leave request to update.", MsgBoxStyle.Exclamation, "No Request Selected")
        End If

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If lvleavereq.SelectedItems.Count > 0 Then
            Dim selectedRequestId As Integer = Convert.ToInt32(lvleavereq.SelectedItems(0).Text)

            If MsgBox("Are you sure you want to delete this leave request?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Delete Confirmation") = MsgBoxResult.Yes Then
                SetQuery("DELETE FROM tblleaverequests WHERE id = " & selectedRequestId)

                fill()

                MsgBox("Leave request deleted successfully!", MsgBoxStyle.Information, "Deletion Successful")
            End If
        Else
            MsgBox("Please select a leave request to delete.", MsgBoxStyle.Exclamation, "No Request Selected")
        End If
    End Sub

    Private Sub lvleavereq_DoubleClick(sender As Object, e As EventArgs) Handles lvleavereq.DoubleClick
        If lvleavereq.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = lvleavereq.SelectedItems(0)
            selectedRequestId = CInt(item.SubItems(0).Text)
            Dim status As String = item.SubItems(4).Text

            dtpdatefrom.Value = Convert.ToDateTime(item.SubItems(1).Text)
            dtpdateto.Value = Convert.ToDateTime(item.SubItems(2).Text)
            txtreason.Text = item.SubItems(3).Text

            If status = "Approved" Or status = "Rejected" Then
                btnupdate.Enabled = False
                btndelete.Enabled = False
                lockupdate.Visible = True
                lockdelete.Visible = True
            Else
                btnupdate.Enabled = True
                btndelete.Enabled = True
                lockupdate.Visible = False
                lockdelete.Visible = False
            End If


            btnsave.Enabled = False
            btncancel.Enabled = True
            pnlinput.Enabled = False

            locksave.Visible = True
        End If
    End Sub


    Public Sub clearfields()
        txtreason.Clear()
        dtpdatefrom.Value = DateTime.Now
        dtpdateto.Value = DateTime.Now
        txtsearch.Clear()
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub


End Class
