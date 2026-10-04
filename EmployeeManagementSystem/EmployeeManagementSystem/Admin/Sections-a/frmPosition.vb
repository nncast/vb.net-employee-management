Public Class frmPosition
    Public positionid As Integer = 0
    Public adding As Boolean = False
    Public updating As Boolean = False

    Private Sub frmPosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Dim dtDept As New DataTable()

    Public Sub fillDepartments()
        dtDept.Clear()

        GetQuery("SELECT id, deptname FROM tbldepartment ORDER BY deptname", "department")
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
            query &= " WHERE p.positiontitle LIKE @s OR d.deptname LIKE @s"
        End If

        GetQuery(query, "positions", P("@s", "%" & search & "%"))
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
        positionid = 0
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
        If Not (adding Or updating) Then Exit Sub

        If txtposition.Text.Trim = "" Or cmbdept.SelectedIndex = -1 Then
            MsgBox("Please complete the required fields.", MsgBoxStyle.Information, "Validation")
            Exit Sub
        End If

        Dim positionTitle As String = txtposition.Text.Trim
        Dim departmentId As Integer = cmbdept.SelectedValue
        Dim excludeId As Integer = If(updating, positionid, -1)

        If CInt(GetValue("SELECT COUNT(*) FROM tblposition WHERE positiontitle = @t AND departmentid = @d AND id <> @id", P("@t", positionTitle), P("@d", departmentId), P("@id", excludeId))) > 0 Then
            MsgBox("This department already has a position with that title.", MsgBoxStyle.Exclamation, "Validation")
            Exit Sub
        End If

        If updating Then
            ' Employees store the position's department too; moving it would leave them mismatched.
            Dim holders As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblemployee WHERE positionid = @id AND departmentid <> @d", P("@id", positionid), P("@d", departmentId)))
            If holders > 0 Then
                MsgBox("This position is held by " & holders & " employee(s) in its current department. Move them to another position before changing its department.", MsgBoxStyle.Exclamation, "Position In Use")
                Exit Sub
            End If
        End If

        If adding Then
            If Not SetQuery("INSERT INTO tblposition (positiontitle, departmentid) VALUES (@t, @d)", P("@t", positionTitle), P("@d", departmentId)) Then Exit Sub
            adding = False
            MsgBox("Position added successfully!", MsgBoxStyle.Information, "Saved")
        Else
            If Not SetQuery("UPDATE tblposition SET positiontitle = @t, departmentid = @d WHERE id = @id", P("@t", positionTitle), P("@d", departmentId), P("@id", positionid)) Then Exit Sub
            updating = False
            MsgBox("Position updated successfully!", MsgBoxStyle.Information, "Updated")
        End If

        positionid = 0
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

        Dim employees As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblemployee WHERE positionid = @id", P("@id", positionid)))
        If employees > 0 Then
            MsgBox("This position is held by " & employees & " employee(s). Move them to another position before deleting it.", MsgBoxStyle.Exclamation, "Position In Use")
            Exit Sub
        End If

        Dim confirm = MsgBox("Are you sure you want to delete this position?", MsgBoxStyle.YesNo, "Confirm")
        If confirm = MsgBoxResult.No Then Exit Sub

        If SetQuery("DELETE FROM tblposition WHERE id = @id", P("@id", positionid)) Then
            positionid = 0
            MsgBox("Position deleted successfully.", MsgBoxStyle.Information, "Deleted")
            fill()
            clearFields()
        End If
    End Sub

    Private Sub lvposition_DoubleClick(sender As Object, e As EventArgs) Handles lvposition.DoubleClick
        If adding Or updating Or lvposition.SelectedItems.Count = 0 Then Exit Sub

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
        positionid = 0
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

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub
End Class
