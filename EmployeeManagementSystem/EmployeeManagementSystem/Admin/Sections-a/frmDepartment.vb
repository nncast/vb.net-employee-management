Public Class frmDepartment
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public deptid As Integer = Nothing

    Private Sub frmDepartment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT id, deptname FROM tbldepartment"
        If search <> "" Then query &= " WHERE id LIKE '%" & search & "%' OR deptname LIKE '%" & search & "%'"

        GetQuery(query, "tbldepartment")
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
        If txtdeptname.Text.Trim = "" Then
            MsgBox("Department name is required!", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        If adding Then
            If MsgBox("Are you sure you want to add a new department?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                SetQuery("INSERT INTO tbldepartment (deptname) VALUES ('" & txtdeptname.Text.Trim() & "')")
                adding = False
                MsgBox("Department added successfully!", MsgBoxStyle.Information, "Success")
            End If
        ElseIf updating Then
            If MsgBox("Are you sure you want to update this department?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                SetQuery("UPDATE tbldepartment SET deptname = '" & txtdeptname.Text.Trim() & "' WHERE id = " & deptid)
                updating = False
                MsgBox("Department updated successfully!", MsgBoxStyle.Information, "Success")
            End If
        End If
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

        If MsgBox("Are you sure you want to delete this department?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
            SetQuery("DELETE FROM tbldepartment WHERE id = " & deptid)
            fill()
            clearfields()
            MsgBox("Department deleted successfully!", MsgBoxStyle.Information, "Success")
        End If
    End Sub

    Private Sub lvdept_DoubleClick(sender As Object, e As EventArgs) Handles lvdept.DoubleClick
        deptid = CInt(lvdept.FocusedItem.SubItems(0).Text)
        txtdeptname.Text = lvdept.FocusedItem.SubItems(1).Text

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