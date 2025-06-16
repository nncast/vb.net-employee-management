Public Class frmAttendance

    Public adding As Boolean = False
    Public updating As Boolean = False
    Public attid As Integer = Nothing

    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


    Public Sub fillEmployeeList()
        Dim search As String = txtsearchemp.Text.Trim()
        Dim query As String = "SELECT e.id, CONCAT(e.firstname, ' ', e.lastname) AS fullname, d.deptname, p.positiontitle FROM tblemployee e " &
                              "LEFT JOIN tbldepartment d ON e.departmentid = d.id " &
                              "LEFT JOIN tblposition p ON e.positionid = p.id"

        If search <> "" Then
            query &= " WHERE e.firstname LIKE '%" & search & "%' OR e.lastname LIKE '%" & search & "%'"
        End If

        GetQuery(query, "emp")
        lvemp.Items.Clear()

        For Each row As DataRow In ds.Tables("emp").Rows
            With lvemp.Items.Add(row("id").ToString())
                .SubItems.Add(row("fullname").ToString())
                .SubItems.Add(row("deptname").ToString())
                .SubItems.Add(row("positiontitle").ToString())
            End With
        Next
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT a.id, a.employeeid, CONCAT(e.firstname, ' ', e.lastname) AS fullname, " & _
                             "a.date, a.status, a.timein, a.timeout " & _
                             "FROM tblattendance a " & _
                             "LEFT JOIN tblemployee e ON a.employeeid = e.id"

        If search <> "" Then
            query &= " WHERE (e.firstname LIKE '%" & search & "%' " & _
                     "OR e.lastname LIKE '%" & search & "%' " & _
                     "OR a.date LIKE '%" & search & "%' " & _
                     "OR a.status LIKE '%" & search & "%' " & _
                     "OR a.timein LIKE '%" & search & "%' " & _
                     "OR a.timeout LIKE '%" & search & "%')"
        End If

        query &= " ORDER BY ABS(DATEDIFF(CURDATE(), a.date)), a.date DESC"

        GetQuery(query, "att")
        lvattendance.Items.Clear()

        For Each row As DataRow In ds.Tables("att").Rows
            Dim item As ListViewItem = lvattendance.Items.Add(row("id").ToString())
            item.SubItems.Add(row("employeeid").ToString())
            item.SubItems.Add(row("fullname").ToString())
            item.SubItems.Add(CDate(row("date")).ToShortDateString())
            item.SubItems.Add(row("status").ToString())
            item.SubItems.Add(If(IsDBNull(row("timein")), "00:00:00", row("timein").ToString()))
            item.SubItems.Add(If(IsDBNull(row("timeout")), "00:00:00", row("timeout").ToString()))

            Select Case row("status").ToString()
                Case "Present"
                    item.ForeColor = Color.Green
                Case "Late"
                    item.ForeColor = Color.Orange
                Case "Absent"
                    item.ForeColor = Color.Red
                Case "On Leave"
                    item.ForeColor = Color.Blue
                Case Else
                    item.ForeColor = Color.Black
            End Select
        Next
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbstatus.SelectedIndexChanged
        If cmbstatus.Text = "Present" Or cmbstatus.Text = "Late" Then
            dtptimein.Enabled = True
            dtptimeout.Enabled = True
        Else
            dtptimein.Enabled = False
            dtptimeout.Enabled = False

            dtptimein.Value = dtpdate.Value.Date.AddHours(0)
            dtptimeout.Value = dtpdate.Value.Date.AddHours(0)
        End If
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearfields()
        adding = True
        pnlinput.Enabled = True
        lvemp.Enabled = True

        cmbstatus.SelectedIndex = 1
        dtptimein.Enabled = False
        dtptimeout.Enabled = False

        dtptimein.Value = dtpdate.Value.Date.AddHours(7)
        dtptimeout.Value = dtpdate.Value.Date.AddHours(0)
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If attid = Nothing Then
            MsgBox("Select an attendance record to update.", MsgBoxStyle.Information)
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
        lvemp.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtempid.Text = "" Or cmbstatus.Text = "" Then
            MsgBox("Employee and status are required!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If adding Then
            Dim checkQuery As String = "SELECT COUNT(*) FROM tblattendance " &
                                      "WHERE employeeid = " & txtempid.Text &
                                      " AND date = '" & dtpdate.Value.ToString("yyyy-MM-dd") & "'"
            GetQuery(checkQuery, "check")

            If ds.Tables("check").Rows(0)(0) > 0 Then
                MsgBox("This employee already has an attendance record for this date!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If
        End If

        Dim timein As String = If(cmbstatus.Text = "Present" Or cmbstatus.Text = "Late",
                                dtptimein.Value.ToString("HH:mm:ss"),
                                "00:00:00")
        Dim timeout As String = If(cmbstatus.Text = "Present" Or cmbstatus.Text = "Late",
                                 dtptimeout.Value.ToString("HH:mm:ss"),
                                 "00:00:00")

        If adding Then
            SetQuery("INSERT INTO tblattendance (employeeid, date, status, timein, timeout) VALUES (" & _
            txtempid.Text & ", '" & dtpdate.Value.ToString("yyyy-MM-dd") & "', '" & cmbstatus.Text & "', '" & timein & "', '" & timeout & "')")

            adding = False
            MsgBox("Attendance added successfully!", MsgBoxStyle.Information)
        ElseIf updating Then
            SetQuery("UPDATE tblattendance SET employeeid = " & txtempid.Text & ", date = '" & dtpdate.Value.ToString("yyyy-MM-dd") & _
            "', status = '" & cmbstatus.Text & "', timein = '" & timein & "', timeout = '" & timeout & "' WHERE id = " & attid)

            updating = False
            MsgBox("Attendance updated successfully!", MsgBoxStyle.Information)
        End If

        fill()
        clearfields()
        disablebuttons()
        pnlinput.Enabled = False
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If attid = Nothing Then
            MsgBox("Select a record to delete.", MsgBoxStyle.Information)
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete this attendance record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            SetQuery("DELETE FROM tblattendance WHERE id = " & attid)
            fill()
            clearfields()
            MsgBox("Record deleted.", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Are you sure you want to cancel adding new attendance information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        ElseIf updating Then
            If MsgBox("Are you sure you want to cancel updating attendance information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                updating = False
            Else
                Exit Sub
            End If
        End If

        disablebuttons()
        clearfields()
        pnlinput.Enabled = False
        attid = Nothing
    End Sub

    Private Sub lvattendance_DoubleClick(sender As Object, e As EventArgs) Handles lvattendance.DoubleClick
        attid = CInt(lvattendance.FocusedItem.SubItems(0).Text)
        txtempid.Text = lvattendance.FocusedItem.SubItems(1).Text
        dtpdate.Value = CDate(lvattendance.FocusedItem.SubItems(3).Text)

        Dim baseDate As Date = CDate(lvattendance.FocusedItem.SubItems(3).Text) '

        cmbstatus.Text = lvattendance.FocusedItem.SubItems(4).Text


        Dim timeInStr As String = lvattendance.FocusedItem.SubItems(5).Text
        Dim timeOutStr As String = lvattendance.FocusedItem.SubItems(6).Text
        dtptimein.Value = baseDate.Date.Add(TimeSpan.Parse(timeInStr))
        dtptimeout.Value = baseDate.Date.Add(TimeSpan.Parse(timeOutStr))

        btnupdate.Enabled = True
        btndelete.Enabled = True

        lockupdate.Visible = False
        lockdelete.Visible = False
    End Sub

    Private Sub lvemp_DoubleClick(sender As Object, e As EventArgs) Handles lvemp.DoubleClick
        txtempid.Text = lvemp.FocusedItem.SubItems(0).Text
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

    Private Sub txtsearchemp_TextChanged(sender As Object, e As EventArgs) Handles txtsearchemp.TextChanged
        fillEmployeeList()
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
        cmbstatus.SelectedIndex = -1
        dtpdate.Value = Today
        dtptimein.Value = dtpdate.Value.Date.AddHours(0)
        dtptimeout.Value = dtpdate.Value.Date.AddHours(0)
        txtempid.Clear()
    End Sub

End Class
