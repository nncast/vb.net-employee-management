Public Class frmDashboard_a
    Private ReadOnly timer As New Timer()

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")
        switchPanel(frmHome)
        UpdateDateTime()

        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
        LoadAdminInfo()
    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs)
        UpdateDateTime()
    End Sub

    Private Sub UpdateDateTime()
        lbldate.Text = DateTime.Now.ToString("dddd, MMMM d, yyyy")
        lbltime.Text = DateTime.Now.ToString("h:mm:ss tt")
    End Sub

    Public Sub switchPanel(frm As Form)
        Panel2.Controls.Clear()
        frm.TopLevel = False
        Panel2.Controls.Add(frm)
        frm.Dock = DockStyle.Fill
        frm.Show()
    End Sub

    Private Sub lblhome_Click(sender As Object, e As EventArgs) Handles lblhome.Click
        labelclickedA(lblhome)
        switchPanel(frmHome)
        lbltitle.Text = "Dashboard"
        frmHome.fill()
    End Sub

    Private Sub lblemployee_Click(sender As Object, e As EventArgs) Handles lblemployee.Click
        labelclickedA(lblemployee)
        switchPanel(frmEmployee)
        lbltitle.Text = "Employee"
        frmEmployee.clearfields()
        frmEmployee.fill()
        frmEmployee.fillDepartments()
        frmEmployee.loadform()
    End Sub

    Private Sub lbldepartment_Click(sender As Object, e As EventArgs) Handles lbldepartment.Click
        labelclickedA(lbldepartment)
        switchPanel(frmDepartment)
        lbltitle.Text = "Department"
        frmDepartment.clearfields()
        frmDepartment.fill()
        frmDepartment.loadform()
    End Sub

    Private Sub lblposition_Click(sender As Object, e As EventArgs) Handles lblposition.Click
        labelclickedA(lblposition)
        switchPanel(frmPosition)
        lbltitle.Text = "Position"
        frmPosition.clearFields()
        frmPosition.fillDepartments()
        frmPosition.fill()
        frmPosition.loadform()
    End Sub

    Private Sub lblattendance_Click(sender As Object, e As EventArgs) Handles lblattendance.Click
        labelclickedA(lblattendance)
        switchPanel(frmAttendance)
        lbltitle.Text = "Attendance"
        frmAttendance.clearfields()
        frmAttendance.fillEmployeeList()
        frmAttendance.fill()
    End Sub

    Private Sub lblleave_Click(sender As Object, e As EventArgs) Handles lblleave.Click
        labelclickedA(lblleave)
        switchPanel(frmLeave)
        lbltitle.Text = "Leave"
        frmLeave.clearfields()
        frmLeave.fill()
        frmLeave.loadform()
    End Sub

    Private Sub lblpayroll_Click(sender As Object, e As EventArgs) Handles lblpayroll.Click
        labelclickedA(lblpayroll)
        switchPanel(frmPayroll)
        lbltitle.Text = "Payroll"
        frmPayroll.clearFields()
        frmPayroll.fillEmployeeList()
        frmPayroll.fill()
        frmPayroll.loadform()
    End Sub

    Private Sub lbllogout_Click(sender As Object, e As EventArgs) Handles lbllogout.Click
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Hide()
            LoginForm.Show()
            loggedinadminid = 0
        Else
            Exit Sub
        End If
    End Sub

    Public Sub LoadAdminInfo()
    GetQuery("SELECT e.firstname, e.lastname, p.positiontitle FROM tblemployee e INNER JOIN tblposition p ON e.positionid = p.id WHERE e.id = " & loggedinadminid, "admininfo")

        If ds.Tables("admininfo").Rows.Count > 0 Then
            Dim row = ds.Tables("admininfo").Rows(0)
            lbladminname.Text = row("firstname").ToString() & " " & row("lastname").ToString()
            lbladminp.Text = row("positiontitle").ToString()
        End If
    End Sub

End Class