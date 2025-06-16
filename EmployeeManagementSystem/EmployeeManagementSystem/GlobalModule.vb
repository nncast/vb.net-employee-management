Module GlobalModule
    Public loggedinadminid As Integer = 0
    Public loggedinemployeeid As Integer = 0

    Public Sub labelclickedA(lbl As Label)
        Dim labels As Label() = {frmDashboard_a.lblhome, frmDashboard_a.lblemployee, frmDashboard_a.lbldepartment,
                                 frmDashboard_a.lblposition, frmDashboard_a.lblattendance,
                                 frmDashboard_a.lblleave, frmDashboard_a.lblpayroll}

        For Each label In labels
            label.BackColor = Color.FromArgb(27, 3, 29)
            label.ForeColor = Color.FromArgb(250, 244, 228)
        Next

        lbl.BackColor = Color.FromArgb(250, 244, 228)
        lbl.ForeColor = Color.FromArgb(27, 3, 29)
    End Sub

    Public Sub labelclickedE(lbl As Label)
        Dim labels As Label() = {frmDashboard_e.lblhome, frmDashboard_e.lblprofile, frmDashboard_e.lblleave,
                                 frmDashboard_e.lblattendance}

        For Each label In labels
            label.BackColor = Color.FromArgb(27, 3, 29)
            label.ForeColor = Color.FromArgb(250, 244, 228)
        Next

        lbl.BackColor = Color.FromArgb(250, 244, 228)
        lbl.ForeColor = Color.FromArgb(27, 3, 29)
    End Sub
End Module





































