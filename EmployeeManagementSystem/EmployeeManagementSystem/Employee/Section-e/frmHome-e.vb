Public Class frmHome_e
    Private Sub frmHome_e_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")
        LoadAttendanceStatus()
        LoadLeaveCounts()
    End Sub

    Public Sub fill()
        LoadAttendanceStatus()
        LoadLeaveCounts()
    End Sub

    Public Sub LoadAttendanceStatus()
        If loggedinemployeeid = 0 Then
            lbltodayattendance.Text = "Pending"
            Exit Sub
        End If

        Dim query As String = "SELECT status FROM tblattendance " & _
                             "WHERE employeeid = " & loggedinemployeeid & " " & _
                             "AND date = CURDATE() " & _
                             "ORDER BY id DESC LIMIT 1"

        GetQuery(query, "attstatus")

        If ds.Tables("attstatus").Rows.Count > 0 Then
            Dim status As String = ds.Tables("attstatus").Rows(0)("status").ToString()
            lbltodayattendance.Text = status
        Else
            lbltodayattendance.Text = "Pending"
        End If
    End Sub

    Public Sub LoadLeaveCounts()
        Dim query As String = "SELECT " & _
                             "(SELECT COUNT(*) FROM tblleaverequests WHERE employeeid = " & loggedinemployeeid & " AND status = 'Pending') AS pending, " & _
                             "(SELECT COUNT(*) FROM tblleaverequests WHERE employeeid = " & loggedinemployeeid & " AND status = 'Approved') AS approved, " & _
                             "(SELECT COUNT(*) FROM tblleaverequests WHERE employeeid = " & loggedinemployeeid & " AND status = 'Rejected') AS rejected"

        GetQuery(query, "leavecounts")

        If ds.Tables("leavecounts").Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables("leavecounts").Rows(0)
            lblpendingleave.Text = row("pending").ToString()
            lblapprovedleave.Text = row("approved").ToString()
            lblrejectedleave.Text = row("rejected").ToString()
        End If
    End Sub
End Class