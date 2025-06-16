Public Class frmDashboard_e

    Private ReadOnly timer As New Timer()

    Private Sub frmDashboard_e_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")
        switchPanel(frmHome_e)
        UpdateDateTime()

        timer.Interval = 1000
        AddHandler timer.Tick, AddressOf Timer_Tick
        timer.Start()
        LoadEmployeeInfo()
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
        labelclickedE(lblhome)
        switchPanel(frmHome_e)
        lbltitle.Text = "Dashboard"
        frmHome_e.fill()
    End Sub

    Private Sub lblprofile_Click(sender As Object, e As EventArgs) Handles lblprofile.Click
        labelclickedE(lblprofile)
        switchPanel(frmProfile)
        lbltitle.Text = "Profile"
        frmProfile.clearfields()
    End Sub

    Private Sub lblleave_Click(sender As Object, e As EventArgs) Handles lblleave.Click
        labelclickedE(lblleave)
        switchPanel(frmLeave_e)
        lbltitle.Text = "Leave"
        frmLeave_e.clearfields()
        frmLeave_e.loadform()
        frmLeave_e.fill()
        frmLeave_e.loadform()
    End Sub

    Private Sub lblattendance_Click(sender As Object, e As EventArgs) Handles lblattendance.Click
        labelclickedE(lblattendance)
        switchPanel(frmAttendance_e)
        lbltitle.Text = "Attendance"
        frmAttendance_e.clearfields()
        frmAttendance_e.fill()
    End Sub

    Private Sub lbllogout_Click(sender As Object, e As EventArgs) Handles lbllogout.Click
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Me.Hide()
            LoginForm.Show()
        Else
            Exit Sub
        End If
    End Sub

    Public Sub LoadEmployeeInfo()
        GetQuery("SELECT e.firstname, e.lastname, p.positiontitle FROM tblemployee e INNER JOIN tblposition p ON e.positionid = p.id WHERE e.id = " & loggedinemployeeid, "tblemployee")

        If ds.Tables("tblemployee").Rows.Count > 0 Then
            Dim row = ds.Tables("tblemployee").Rows(0)
            lblempname.Text = row("firstname").ToString() & " " & row("lastname").ToString()
            lblempp.Text = row("positiontitle").ToString()
        End If
    End Sub
    
End Class