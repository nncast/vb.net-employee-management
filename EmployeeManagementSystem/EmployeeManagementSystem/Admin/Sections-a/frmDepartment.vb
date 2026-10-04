Public Class frmDepartment
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public deptid As Integer = Nothing

    Private Sub frmDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT id, deptname FROM tbldepartment"
        If search <> "" Then query &= " WHERE id LIKE @s OR deptname LIKE @s"

        GetQuery(query, "tbldepartment", P("@s", "%" & search & "%"))
        lvdept.Items.Clear()

        For Each row As DataRow In ds.Tables("tbldepartment").Rows
            With lvdept.Items.Add(row("id").ToString())
                .SubItems.Add(row("deptname").ToString())
            End With
        Next
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearfields()
        deptid = Nothing
        adding = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If deptid = Nothing Then
            MsgBox("Select a department to update.", MsgBoxStyle.Information, "No Selection")
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Not (adding Or updating) Then Exit Sub

        Dim deptname As String = txtdeptname.Text.Trim()
        If deptname = "" Then
            MsgBox("Department name is required!", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tbldepartment WHERE deptname = @n AND id <> @id", P("@n", deptname), P("@id", If(updating, deptid, -1)))) > 0 Then
            MsgBox("A department with this name already exists.", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        If adding Then
            If MsgBox("Are you sure you want to add a new department?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") <> MsgBoxResult.Yes Then Exit Sub
            If Not SetQuery("INSERT INTO tbldepartment (deptname) VALUES (@n)", P("@n", deptname)) Then Exit Sub
            adding = False
            MsgBox("Department added successfully!", MsgBoxStyle.Information, "Success")
        Else
            If MsgBox("Are you sure you want to update this department?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") <> MsgBoxResult.Yes Then Exit Sub
            If Not SetQuery("UPDATE tbldepartment SET deptname = @n WHERE id = @id", P("@n", deptname), P("@id", deptid)) Then Exit Sub
            updating = False
            MsgBox("Department updated successfully!", MsgBoxStyle.Information, "Success")
        End If

        deptid = Nothing
        fill()
        clearfields()
        disablebuttons()
        pnlinput.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If deptid = Nothing Then
            MsgBox("Select a department to delete.", MsgBoxStyle.Information, "No Selection")
            Exit Sub
        End If

        ' Positions and employees keep their department (the foreign keys refuse the delete).
        Dim positions As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblposition WHERE departmentid = @id", P("@id", deptid)))
        Dim employees As Integer = CInt(GetValue("SELECT COUNT(*) FROM tblemployee WHERE departmentid = @id", P("@id", deptid)))
        If positions > 0 Or employees > 0 Then
            MsgBox("This department still has " & positions & " position(s) and " & employees & " employee(s). Move or delete them before deleting the department.", MsgBoxStyle.Exclamation, "Department In Use")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this department?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
            If SetQuery("DELETE FROM tbldepartment WHERE id = @id", P("@id", deptid)) Then
                deptid = Nothing
                fill()
                clearfields()
                MsgBox("Department deleted successfully!", MsgBoxStyle.Information, "Success")
            End If
        End If
    End Sub

    Private Sub lvdept_DoubleClick(sender As Object, e As EventArgs) Handles lvdept.DoubleClick
        If adding Or updating Or lvdept.SelectedItems.Count = 0 Then Exit Sub

        deptid = CInt(lvdept.SelectedItems(0).SubItems(0).Text)
        txtdeptname.Text = lvdept.SelectedItems(0).SubItems(1).Text

        btnupdate.Enabled = True
        btndelete.Enabled = True

        lockupdate.Visible = False
        lockdelete.Visible = False
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Are you sure you want to cancel adding new department information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        ElseIf updating Then
            If MsgBox("Are you sure you want to cancel updating department information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                updating = False
            Else
                Exit Sub
            End If
        End If

        disablebuttons()
        clearfields()
        pnlinput.Enabled = False
        deptid = Nothing
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

    Public Sub clearfields()
        txtdeptname.Clear()
    End Sub

End Class
