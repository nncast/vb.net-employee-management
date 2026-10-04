Public Class frmEmployee
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public employeeid As Integer = Nothing
    Private ReadOnly passwordTip As New ToolTip()

    Private Sub EmployeeForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()

        passwordTip.SetToolTip(txtpassword, "New employees get a random temporary password. When updating, leave blank to keep the current password.")
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

        GetQuery("SELECT id, deptname FROM tbldepartment ORDER BY deptname", "department")
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
            GetQuery("SELECT id, positiontitle FROM tblposition WHERE departmentid = @d ORDER BY positiontitle", "position", P("@d", selectedDeptId))
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
        ' Passwords are hashed: they are neither listed nor searchable.
        Dim query As String = "SELECT e.id, e.firstname, e.lastname, e.sex, e.maritalstatus, e.dob, p.positiontitle, d.deptname, e.salary, l.username, l.role " & _
                              "FROM tblemployee e " & _
                              "JOIN tblposition p ON e.positionid = p.id " & _
                              "JOIN tbldepartment d ON e.departmentid = d.id " & _
                              "LEFT JOIN tbllogin l ON e.id = l.employeeid"

        If search <> "" Then
            query &= " WHERE (e.id LIKE @s OR e.firstname LIKE @s OR e.lastname LIKE @s OR e.sex LIKE @s OR e.maritalstatus LIKE @s OR e.dob LIKE @s OR " & _
                     "p.positiontitle LIKE @s OR d.deptname LIKE @s OR e.salary LIKE @s OR l.username LIKE @s OR l.role LIKE @s)"
        End If

        GetQuery(query, "tblemployee", P("@s", "%" & search & "%"))

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
        employeeid = Nothing
        adding = True
        pnlinput.Enabled = True
        ' Random temporary password (shown so the admin can give it to the employee).
        txtpassword.Text = GenerateTemporaryPassword()
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
        If Not (adding Or updating) Then Exit Sub

        If txtfname.Text.Trim() = Nothing Or txtlname.Text.Trim() = Nothing Or cmbsex.SelectedIndex = -1 Or cmbmaritalstatus.SelectedIndex = -1 Or cmbdept.SelectedIndex = -1 Or cmbposition.SelectedIndex = -1 Or txtsalary.Text.Trim() = Nothing Or cmbrole.SelectedIndex = -1 Then
            MsgBox("Please complete all selections: sex, marital status, department, position, and role.", MsgBoxStyle.Critical, "Validation Error")
            Return
        End If

        Dim salary As Decimal
        If Not Decimal.TryParse(txtsalary.Text.Trim(), salary) OrElse salary < 0 Then
            MsgBox("Salary must be a number (0 or more)!", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        If dtbdob.Value.Date >= Today Then
            MsgBox("Date of birth must be in the past.", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        Dim username As String = txtusername.Text.Trim()
        Dim password As String = txtpassword.Text.Trim()

        If username = "" Then
            MsgBox("Username is required!", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        Dim hasLogin As Boolean = updating AndAlso CInt(GetValue("SELECT COUNT(*) FROM tbllogin WHERE employeeid = @id", P("@id", employeeid))) > 0
        If password = "" And Not hasLogin Then
            MsgBox("A password is required for a new account.", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If
        If password <> "" And password.Length < MinPasswordLength Then
            MsgBox("Password must be at least " & MinPasswordLength & " characters.", MsgBoxStyle.Critical, "Validation Error")
            Exit Sub
        End If

        If CInt(GetValue("SELECT COUNT(*) FROM tbllogin WHERE username = @u AND employeeid <> @id", P("@u", username), P("@id", If(updating, employeeid, -1)))) > 0 Then
            MsgBox("Username is already in use. Please choose a different username.", MsgBoxStyle.Critical, "Username Error")
            Exit Sub
        End If

        Dim role As String = cmbrole.SelectedItem.ToString()
        If updating AndAlso role <> "Admin" Then
            If employeeid = loggedinadminid Then
                MsgBox("You can't remove the Admin role from your own account.", MsgBoxStyle.Critical, "Not Allowed")
                Exit Sub
            End If
            If AdminCount(employeeid) = 0 Then
                MsgBox("At least one account must keep the Admin role.", MsgBoxStyle.Critical, "Not Allowed")
                Exit Sub
            End If
        End If

        Dim departmentid As Integer = cmbdept.SelectedValue
        Dim positionid As Integer = cmbposition.SelectedValue
        Dim dob As String = dtbdob.Value.ToString("yyyy-MM-dd")
        Dim changedOn As String = Now.ToString("yyyy-MM-dd")

        Dim question As String = If(adding, "Are you sure you want to add a new employee?", "Are you sure you want to update this employee?")
        If MsgBox(question, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm") <> MsgBoxResult.Yes Then Exit Sub

        Dim wasAdding As Boolean = adding
        Try
            BeginTransaction()
            If adding Then
                Execute("INSERT INTO tblemployee (firstname, lastname, sex, maritalstatus, dob, positionid, departmentid, salary) VALUES (@f, @l, @sex, @ms, @dob, @pos, @dept, @salary)",
                        P("@f", txtfname.Text.Trim()), P("@l", txtlname.Text.Trim()), P("@sex", cmbsex.SelectedItem.ToString()), P("@ms", cmbmaritalstatus.SelectedItem.ToString()),
                        P("@dob", dob), P("@pos", positionid), P("@dept", departmentid), P("@salary", salary))
                employeeid = GetLastInsertedID()

                Execute("INSERT INTO tbllogin (employeeid, username, password, role) VALUES (@id, @u, @p, @r)",
                        P("@id", employeeid), P("@u", username), P("@p", HashPassword(password)), P("@r", role))

                Execute("INSERT INTO tblemployeehistory (employeeid, oldpositionid, olddepartmentid, newpositionid, newdepartmentid, datechanged) VALUES (@id, NULL, NULL, @pos, @dept, @d)",
                        P("@id", employeeid), P("@pos", positionid), P("@dept", departmentid), P("@d", changedOn))
            Else
                ' Record a history entry only for a confirmed change of position or department.
                GetQuery("SELECT positionid, departmentid FROM tblemployee WHERE id = @id", "prev", P("@id", employeeid))
                If ds.Tables("prev").Rows.Count > 0 Then
                    Dim oldPosId As Integer = CInt(ds.Tables("prev").Rows(0)("positionid"))
                    Dim oldDeptId As Integer = CInt(ds.Tables("prev").Rows(0)("departmentid"))
                    If oldPosId <> positionid Or oldDeptId <> departmentid Then
                        Execute("INSERT INTO tblemployeehistory (employeeid, oldpositionid, olddepartmentid, newpositionid, newdepartmentid, datechanged) VALUES (@id, @op, @od, @np, @nd, @d)",
                                P("@id", employeeid), P("@op", oldPosId), P("@od", oldDeptId), P("@np", positionid), P("@nd", departmentid), P("@d", changedOn))
                    End If
                End If

                Execute("UPDATE tblemployee SET firstname = @f, lastname = @l, sex = @sex, maritalstatus = @ms, dob = @dob, positionid = @pos, departmentid = @dept, salary = @salary WHERE id = @id",
                        P("@f", txtfname.Text.Trim()), P("@l", txtlname.Text.Trim()), P("@sex", cmbsex.SelectedItem.ToString()), P("@ms", cmbmaritalstatus.SelectedItem.ToString()),
                        P("@dob", dob), P("@pos", positionid), P("@dept", departmentid), P("@salary", salary), P("@id", employeeid))

                If hasLogin Then
                    Execute("UPDATE tbllogin SET username = @u, role = @r WHERE employeeid = @id", P("@u", username), P("@r", role), P("@id", employeeid))
                    ' A blank password box keeps the current password.
                    If password <> "" Then
                        Execute("UPDATE tbllogin SET password = @p WHERE employeeid = @id", P("@p", HashPassword(password)), P("@id", employeeid))
                    End If
                Else
                    Execute("INSERT INTO tbllogin (employeeid, username, password, role) VALUES (@id, @u, @p, @r)",
                            P("@id", employeeid), P("@u", username), P("@p", HashPassword(password)), P("@r", role))
                End If
            End If
            CommitTransaction()
        Catch ex As Exception
            RollbackTransaction()
            MsgBox("Could not save the employee: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try

        adding = False
        updating = False
        If wasAdding Then
            MsgBox("Employee added successfully!" & vbCrLf & vbCrLf & "Username: " & username & vbCrLf & "Temporary password: " & password & vbCrLf & vbCrLf &
                   "Give these to the employee and ask them to change the password under Profile.", MsgBoxStyle.Information, "Success")
        Else
            MsgBox("Employee updated successfully!", MsgBoxStyle.Information, "Success")
        End If

        employeeid = Nothing
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

        If employeeid = loggedinadminid Then
            MsgBox("You can't delete your own account while logged in.", MsgBoxStyle.Critical, "Not Allowed")
            Exit Sub
        End If

        Dim isAdmin As Boolean = CInt(GetValue("SELECT COUNT(*) FROM tbllogin WHERE employeeid = @id AND role = 'Admin'", P("@id", employeeid))) > 0
        If isAdmin AndAlso AdminCount(employeeid) = 0 Then
            MsgBox("This is the last Admin account and can't be deleted.", MsgBoxStyle.Critical, "Not Allowed")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this employee? Their login, attendance, leave and payroll records will also be deleted.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirm Delete") = MsgBoxResult.Yes Then
            If SetQuery("DELETE FROM tblemployee WHERE id = @id", P("@id", employeeid)) Then
                employeeid = Nothing
                fill()
                clearfields()
                MsgBox("Employee deleted successfully!", MsgBoxStyle.Information, "Success")
            End If
        End If
    End Sub

    Private Sub lvemployee_DoubleClick(sender As Object, e As EventArgs) Handles lvemployee.DoubleClick
        If adding Or updating Or lvemployee.SelectedItems.Count = 0 Then Exit Sub

        employeeid = CInt(lvemployee.SelectedItems(0).SubItems(0).Text)

        GetQuery("SELECT e.id, e.firstname, e.lastname, e.sex, e.maritalstatus, e.dob, e.salary, l.username, l.role, e.departmentid, e.positionid " & _
                 "FROM tblemployee e " & _
                 "LEFT JOIN tbllogin l ON e.id = l.employeeid " & _
                 "WHERE e.id = @id", "tblemployee", P("@id", employeeid))
        If ds.Tables("tblemployee").Rows.Count = 0 Then Exit Sub

        Dim row As DataRow = ds.Tables("tblemployee").Rows(0)
        Dim deptid As Integer = row.Item("departmentid")
        Dim positionid As Integer = row.Item("positionid")

        txtfname.Text = row.Item("firstname").ToString()
        txtlname.Text = row.Item("lastname").ToString()
        cmbsex.SelectedItem = row.Item("sex").ToString()
        cmbmaritalstatus.SelectedItem = row.Item("maritalstatus").ToString()
        dtbdob.Value = CDate(row.Item("dob"))
        txtsalary.Text = row.Item("salary").ToString()

        txtusername.Text = row.Item("username").ToString()
        txtpassword.Clear()
        cmbrole.SelectedItem = row.Item("role").ToString()

        fillDepartments()
        cmbdept.SelectedValue = deptid
        fillPositions()
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

        employeeid = Nothing
        disablebuttons()
        clearfields()
        pnlinput.Enabled = False
    End Sub

    ' Suggests a username from the name; the password is a random one set in btnnew_Click.
    Public Sub newaccount()
        txtusername.Text = (txtlname.Text & txtfname.Text).Replace(" ", "").ToLower()
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
