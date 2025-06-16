Public Class frmPosition
    Public positionid As Integer = 0
    Public adding As Boolean = False
    Public updating As Boolean = False

    Private Sub frmPosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Dim dtDept As New DataTable()

    Public Sub fillDepartments()
        dtDept.Clear()

        GetQuery("SELECT id, deptname FROM tbldepartment", "department")
        dtDept = ds.Tables("department").Copy()

        cmbdept.DataSource = dtDept
        cmbdept.DisplayMember = "deptname"
        cmbdept.ValueMember = "id"
        cmbdept.SelectedIndex = -1
    End Sub


    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT p.id, p.positiontitle, d.deptname, p.departmentid " &
                              "FROM tblposition p " &
                              "INNER JOIN tbldepartment d ON p.departmentid = d.id"

        If search <> "" Then
            query &= " WHERE p.positiontitle LIKE '%" & search & "%' " &
                     "OR d.deptname LIKE '%" & search & "%'"
        End If

        GetQuery(query, "positions")
        lvposition.Items.Clear()

        For Each row As DataRow In ds.Tables("positions").Rows
            With lvposition.Items.Add(row("id").ToString())
                .SubItems.Add(row("positiontitle").ToString())
                .SubItems.Add(row("deptname").ToString())
                .Tag = row("departmentid")
            End With
        Next
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearFields()
        adding = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If positionid = 0 Then
            MsgBox("Please select a position to update.", MsgBoxStyle.Information, "Validation")
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtposition.Text.Trim = "" Or cmbdept.SelectedIndex = -1 Then
            MsgBox("Please complete the required fields.", MsgBoxStyle.Information, "Validation")
            Exit Sub
        End If

        Dim positionTitle As String = txtposition.Text.Trim
        Dim departmentId As Integer = cmbdept.SelectedValue

        If adding Then
            SetQuery("INSERT INTO tblposition (positiontitle, departmentid) VALUES ('" & positionTitle & "', " & departmentId & ")")
            adding = False
            MsgBox("Position added successfully!", MsgBoxStyle.Information, "Saved")
        ElseIf updating Then
            SetQuery("UPDATE tblposition SET positiontitle = '" & positionTitle & "', departmentid = " & departmentId & " WHERE id = " & positionid)
            updating = False
            MsgBox("Position updated successfully!", MsgBoxStyle.Information, "Updated")
        End If

        fill()
        clearFields()
        disableButtons()
        pnlinput.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If positionid = 0 Then
            MsgBox("Please select a position to delete.", MsgBoxStyle.Information, "Validation")
            Exit Sub
        End If

        Dim confirm = MsgBox("Are you sure you want to delete this position?", MsgBoxStyle.YesNo, "Confirm")
        If confirm = MsgBoxResult.No Then Exit Sub

        SetQuery("DELETE FROM tblposition WHERE id = " & positionid)
        MsgBox("Position deleted successfully.", MsgBoxStyle.Information, "Deleted")
        fill()
        clearFields()
    End Sub

    Private Sub lvposition_DoubleClick(sender As Object, e As EventArgs) Handles lvposition.DoubleClick
        If lvposition.SelectedItems.Count = 0 Then Exit Sub

        Dim selectedItem As ListViewItem = lvposition.SelectedItems(0)

        positionid = CInt(selectedItem.SubItems(0).Text)
        txtposition.Text = selectedItem.SubItems(1).Text
        cmbdept.SelectedValue = selectedItem.Tag

        btnupdate.Enabled = True
        btndelete.Enabled = True

        lockupdate.Visible = False
        lockdelete.Visible = False
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Are you sure you want to cancel adding new position information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        ElseIf updating Then
            If MsgBox("Are you sure you want to cancel updating position information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                updating = False
            Else
                Exit Sub
            End If
        End If

        disableButtons()
        clearFields()
        pnlinput.Enabled = False
        positionid = Nothing
    End Sub

    Public Sub clearFields()
        txtposition.Clear()
        cmbdept.SelectedIndex = -1
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

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs)
        fill()
    End Sub
End Class
