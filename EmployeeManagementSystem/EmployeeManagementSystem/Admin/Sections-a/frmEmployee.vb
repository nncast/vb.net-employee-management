Public Class frmEmployee
        Public adding As Boolean = False
        Public updating As Boolean = False
        Public employeeid As Integer = Nothing

    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Dim dtPosition As New DataTable()

    Public Sub fillDepartments()
        dtDept.Clear()

        GetQuery("SELECT id, deptname FROM tbldepartment", "department")
        dtDept = ds.Tables("department").Copy()

        cmbdept.DataSource = dtDept
        cmbdept.DisplayMember = "deptname"
        cmbdept.ValueMember = "id"
        cmbdept.SelectedIndex = -1
    End Sub

    Public Sub fillPositions()
        dtPosition.Clear()

        If cmbdept.SelectedIndex <> -1 Then
            Dim selectedDeptId As Integer = CType(cmbdept.SelectedValue, Integer)
            GetQuery("SELECT id, positiontitle FROM tblposition WHERE departmentid = " & selectedDeptId, "position")
            dtPosition = ds.Tables("position").Copy()

            cmbposition.DataSource = dtPosition
            cmbposition.DisplayMember = "positiontitle"
            cmbposition.ValueMember = "id"
            cmbposition.SelectedIndex = -1
        End If
    End Sub

        Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
            fill()
        End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT e.id, e.firstname, e.lastname, e.sex, e.maritalstatus, e.dob, p.positiontitle, d.deptname, e.salary, l.username, l.password, l.role " & _
                              "FROM tblemployee e " & _
                              "JOIN tblposition p ON e.positionid = p.id " & _
                              "JOIN tbldepartment d ON e.departmentid = d.id " & _
                              "LEFT JOIN tbllogin l ON e.id = l.employeeid"

        If search <> "" Then
            query &= " WHERE (" & _
                     "e.id LIKE '%" & search & "%' OR " & _
                     "e.firstname LIKE '%" & search & "%' OR " & _
                     "e.lastname LIKE '%" & search & "%' OR " & _
                     "e.sex LIKE '%" & search & "%' OR " & _
                     "e.maritalstatus LIKE '%" & search & "%' OR " & _
                     "e.dob LIKE '%" & search & "%' OR " & _
                     "p.positiontitle LIKE '%" & search & "%' OR " & _
                     "d.deptname LIKE '%" & search & "%' OR " & _
                     "e.salary LIKE '%" & search & "%' OR " & _
                     "l.username LIKE '%" & search & "%' OR " & _
                     "l.password LIKE '%" & search & "%' OR " & _
                     "l.role LIKE '%" & search & "%')"
        End If

        GetQuery(query, "tblemployee")

        lvemployee.Items.Clear()

        If ds.Tables("tblemployee").Rows.Count > 0 Then
            For Each row As DataRow In ds.Tables("tblemployee").Rows
                With lvemployee.Items.Add(row("id").ToString())
                    .SubItems.Add(row("firstname").ToString())
                    .SubItems.Add(row("lastname").ToString())
                    .SubItems.Add(row("sex").ToString())
                    .SubItems.Add(row("maritalstatus").ToString())
                    .SubItems.Add(CDate(row("dob")).ToString("yyyy-MM-dd"))
                    .SubItems.Add(row("positiontitle").ToString())
                    .SubItems.Add(row("deptname").ToString())
                    .SubItems.Add(row("salary").ToString())
                    .SubItems.Add(row("username").ToString())
                    .SubItems.Add(row("password").ToString())
                    .SubItems.Add(row("role").ToString())
                End With
            Next
        End If
    End Sub

    Public Sub clearfields()
        txtfname.Clear()
        txtlname.Clear()
        cmbsex.SelectedIndex = -1
        cmbmaritalstatus.SelectedIndex = -1
        dtbdob.Value = New DateTime(2000, 1, 1)
        cmbdept.SelectedIndex = -1
        cmbposition.SelectedIndex = -1
        txtsalary.Clear()
        txtusername.Clear()
        txtpassword.Clear()
        cmbrole.SelectedIndex = -1
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearfields()
        adding = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If employeeid = Nothing Then
            MsgBox("Select an employee to update.", MsgBoxStyle.Information, "No Selection")
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtfname.Text.Trim() = Nothing Or txtlname.Text.Trim() = Nothing Or cmbsex.SelectedIndex = -1 Or cmbmaritalstatus.SelectedIndex = -1 Or cmbdept.SelectedIndex = -1 Or cmbposition.SelectedIndex = -1 Or txtsalary.Text.Trim() = Nothing Or cmbrole.SelectedIndex = -1 Then
            MsgBox("Please complete all selections: sex, marital status, department, position, and role.", MsgBoxStyle.Critical, "Validation Error")
            Return
        End If

        If Not IsNumeric(txtsalary.Text.Trim()) Then
            MsgBox("Salary must be a number!", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        If txtusername.Text.Trim() = "" Or txtpassword.Text.Trim() = "" Then
            MsgBox("Username and password are required!", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        Dim username As String = txtusername.Text.Trim()
        Dim checkQuery As String = Nothing

        If adding Then
            checkQuery = "SELECT COUNT(*) FROM tbllogin WHERE username = '" & username & "'"
        ElseIf updating Then
            checkQuery = "SELECT COUNT(*) FROM tbllogin WHERE username = '" & username & "' AND employeeid <> " & employeeid
        End If

        GetQuery(checkQuery, "username_check")
        Dim count As Integer = CInt(ds.Tables("username_check").Rows(0)(0))

        If count > 0 Then
            MsgBox("Username is already in use. Please choose a different username.", MsgBoxStyle.Critical, "Username Error")
            Exit Sub
        End If

        Dim departmentid As Integer = cmbdept.SelectedValue
        Dim positionid As Integer = cmbposition.SelectedValue
        Dim salary As Decimal = CDec(txtsalary.Text.Trim())

        If adding Then
            If MsgBox("Are you sure you want to add a new employee?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then
                SetQuery("INSERT INTO tblemployee (firstname, lastname, sex, maritalstatus, dob, positionid, departmentid, salary) " & _
                         "VALUES ('" & txtfname.Text.Trim() & "', '" & txtlname.Text.Trim() & "', '" & cmbsex.SelectedItem.ToString() & "', '" & cmbmaritalstatus.SelectedItem.ToString() & "', '" & dtbdob.Value.ToString("yyyy-MM-dd") & "', " & positionid & ", " & departmentid & ", " & salary & ")")

                Dim employeeid As Integer = GetLastInsertedID()

                SetQuery("INSERT INTO tbllogin (employeeid, username, password, role) " & _
                         "VALUES (" & employeeid & ", '" & txtusername.Text.Trim() & "', '" & txtpassword.Text.Trim() & "', '" & cmbrole.SelectedItem.ToString() & "')")

                SetQuery("INSERT INTO tblemployeehistory (employeeid, oldpositionid, olddepartmentid, newpositionid, newdepartmentid, datechanged) " & _
                         "VALUES (" & employeeid & ", NULL, NULL, " & positionid & ", " & departmentid & ", '" & Now.ToString("yyyy-MM-dd") & "')")

                adding = False
                MsgBox("Employee added successfully!", MsgBoxStyle.Information, "Success")
            End If
        ElseIf updating Then
            GetQuery("SELECT positionid, departmentid FROM tblemployee WHERE id = " & employeeid, "prev")
            If ds.Tables("prev").Rows.Count > 0 Then
                Dim oldPosId As Integer = CInt(ds.Tables("prev").Rows(0)("positionid"))
                Dim oldDeptId As Integer = CInt(ds.Tables("prev").Rows(0)("departmentid"))
                Dim newPosId As Integer = CInt(cmbposition.SelectedValue)
                Dim newDeptId As Integer = CInt(cmbdept.SelectedValue)

                If oldPosId <> newPosId Or oldDeptId <> newDeptId Then
                    SetQuery("INSERT INTO tblemployeehistory (employeeid, oldpositionid, olddepartmentid, newpositionid, newdepartmentid, datechanged) " & _
                             "VALUES (" & employeeid & ", " & oldPosId & ", " & oldDeptId & ", " & newPosId & ", " & newDeptId & ", '" & Now.ToString("yyyy-MM-dd") & "')")
                End If
            End If

            If MsgBox("Are you sure you want to update this employee?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") = MsgBoxResult.Yes Then

                SetQuery("UPDATE tblemployee SET firstname = '" & txtfname.Text.Trim() & "', lastname = '" & txtlname.Text.Trim() & "', " & _
                         "sex = '" & cmbsex.SelectedItem.ToString() & "', maritalstatus = '" & cmbmaritalstatus.SelectedItem.ToString() & "', dob = '" & dtbdob.Value.ToString("yyyy-MM-dd") & "', " & _
                         "positionid = " & positionid & ", departmentid = " & departmentid & ", salary = " & salary & " WHERE id = " & employeeid)

                SetQuery("UPDATE tbllogin SET username = '" & txtusername.Text.Trim() & "', password = '" & txtpassword.Text.Trim() & "', " & _
                         "role = '" & cmbrole.SelectedItem.ToString() & "' WHERE employeeid = " & employeeid)

                updating = False
                MsgBox("Employee updated successfully!", MsgBoxStyle.Information, "Success")
            End If
        End If
        fill()
        clearfields()
        disablebuttons()
        pnlinput.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If employeeid = Nothing Then
            MsgBox("Select an employee to delete.", MsgBoxStyle.Information, "No Selection")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this employee?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
            SetQuery("DELETE FROM tblemployee WHERE id = " & employeeid)
            fill()
            clearfields()
            MsgBox("Employee deleted successfully!", MsgBoxStyle.Information, "Success")
        End If
    End Sub

    Private Sub lvemployee_DoubleClick(sender As Object, e As EventArgs) Handles lvemployee.DoubleClick
        employeeid = CInt(lvemployee.FocusedItem.SubItems(0).Text)

        GetQuery("SELECT e.id, e.firstname, e.lastname, e.sex, e.maritalstatus, e.dob, " & _
                 "p.positiontitle, d.deptname, e.salary, l.username, l.password, l.role, " & _
                 "e.departmentid, e.positionid " & _
                 "FROM tblemployee e " & _
                 "JOIN tblposition p ON e.positionid = p.id " & _
                 "JOIN tbldepartment d ON e.departmentid = d.id " & _
                 "LEFT JOIN tbllogin l ON e.id = l.employeeid " & _
                 "WHERE e.id = " & employeeid, "tblemployee")


        Dim deptid As Integer = ds.Tables("tblemployee").Rows(0).Item("departmentid")
        Dim positionid As Integer = ds.Tables("tblemployee").Rows(0).Item("positionid")

        txtfname.Text = ds.Tables("tblemployee").Rows(0).Item("firstname").ToString()
        txtlname.Text = ds.Tables("tblemployee").Rows(0).Item("lastname").ToString()
        cmbsex.SelectedItem = ds.Tables("tblemployee").Rows(0).Item("sex").ToString()
        cmbmaritalstatus.SelectedItem = ds.Tables("tblemployee").Rows(0).Item("maritalstatus").ToString()
        dtbdob.Value = CDate(ds.Tables("tblemployee").Rows(0).Item("dob").ToString())
        txtsalary.Text = ds.Tables("tblemployee").Rows(0).Item("salary").ToString()

        txtusername.Text = ds.Tables("tblemployee").Rows(0).Item("username").ToString()
        txtpassword.Text = ds.Tables("tblemployee").Rows(0).Item("password").ToString()
        cmbrole.SelectedItem = ds.Tables("tblemployee").Rows(0).Item("role").ToString()

        fillDepartments()
        fillPositions()

        cmbdept.SelectedValue = deptid
        cmbposition.SelectedValue = positionid

        btnupdate.Enabled = True
        btndelete.Enabled = True


        lockupdate.Visible = False
        lockdelete.Visible = False
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Are you sure you want to cancel adding new employee?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        ElseIf updating Then
            If MsgBox("Are you sure you want to cancel updating employee information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                updating = False
            Else
                Exit Sub
            End If
        End If

        disablebuttons()
        clearfields()
        pnlinput.Enabled = False
    End Sub

    Public Sub newaccount()
        txtusername.Text = (txtlname.Text + txtfname.Text).ToLower
        txtpassword.Text = (txtlname.Text + txtfname.Text + DateTime.Now.Year.ToString()).ToLower
    End Sub

    Private Sub txtfname_TextChanged(sender As Object, e As EventArgs) Handles txtfname.TextChanged
        If adding Then
            newaccount()
        End If
    End Sub

    Private Sub txtlname_TextChanged(sender As Object, e As EventArgs) Handles txtlname.TextChanged
        If adding Then
            newaccount()
        End If
    End Sub

    Private Sub cmbdept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbdept.SelectedIndexChanged
        If cmbdept.SelectedIndex <> -1 AndAlso cmbdept.SelectedValue IsNot Nothing Then
            Dim deptId As Integer
            If Integer.TryParse(cmbdept.SelectedValue.ToString(), deptId) Then
                fillPositions()
            End If
            cmbposition.Enabled = True
        Else
            cmbposition.DataSource = Nothing
            cmbposition.Enabled = False
        End If
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

End Class