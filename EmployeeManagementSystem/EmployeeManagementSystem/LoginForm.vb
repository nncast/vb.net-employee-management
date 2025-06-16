Public Class LoginForm
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")
    End Sub

    Public Sub clearfields()
        txtusername.Clear()
        txtpassword.Clear()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnlogin.Click
        Dim username As String = txtusername.Text.Trim
        Dim password As String = txtpassword.Text.Trim

        If username = "" Or password = "" Then
            MsgBox("Please enter both username and password.", MsgBoxStyle.Exclamation, "Missing Information")
            Exit Sub
        End If

        GetQuery("SELECT * FROM tbllogin WHERE username = '" & username & "' AND password = '" & password & "'", "tbllogin")

        If ds.Tables("tbllogin").Rows.Count > 0 Then
            Dim row = ds.Tables("tbllogin").Rows(0)
            Dim status As String = row("role").ToString()
            Dim employeeid As Integer = row("employeeid")

            clearfields()
            txtpassword.UseSystemPasswordChar = False

            If status = "Admin" Then
                loggedinadminid = employeeid
                MsgBox("Welcome, Admin!", MsgBoxStyle.Information, "Login Successful")
                Me.Hide()
                frmDashboard_a.Show()
                frmDashboard_a.LoadAdminInfo()
                frmDashboard_a.switchPanel(frmHome)
                labelclickedE(frmDashboard_a.lblhome)
                frmHome.fill()
            ElseIf status = "Employee" Then
                loggedinemployeeid = employeeid
                MsgBox("Welcome, Employee!", MsgBoxStyle.Information, "Login Successful")
                Me.Hide()
                frmDashboard_e.Show()
                frmDashboard_e.LoadEmployeeInfo()
                frmDashboard_e.switchPanel(frmHome_e)
                labelclickedE(frmDashboard_e.lblhome)
                frmHome_e.fill()
            Else
                MsgBox("Invalid user role detected.", MsgBoxStyle.Critical, "Login Error")
                clearfields()
            End If
        Else
            MsgBox("Incorrect username or password.", MsgBoxStyle.Critical, "Login Failed")
            clearfields()
        End If
    End Sub

    Private Sub eyeview_Click(sender As Object, e As EventArgs) Handles piceyeview.Click
        txtpassword.UseSystemPasswordChar = False
        piceyeview.Visible = False
        piceyehide.Visible = True
    End Sub

    Private Sub eyehide_Click(sender As Object, e As EventArgs) Handles piceyehide.Click
        txtpassword.UseSystemPasswordChar = True
        piceyeview.Visible = True
        piceyehide.Visible = False
    End Sub

End Class
