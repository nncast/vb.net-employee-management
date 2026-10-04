Public Class frmAttendance

    Public adding As Boolean = False
    Public updating As Boolean = False
    Public attid As Integer = Nothing

    Private Shared ReadOnly Statuses As String() = {"Present", "Absent", "Late", "On Leave"}

    Private Sub frmAttendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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


    Public Sub fillEmployeeList()
        Dim search As String = txtsearchemp.Text.Trim()
        Dim query As String = "SELECT e.id, CONCAT(e.firstname, ' ', e.lastname) AS fullname, d.deptname, p.positiontitle FROM tblemployee e " &
                              "LEFT JOIN tbldepartment d ON e.departmentid = d.id " &
                              "LEFT JOIN tblposition p ON e.positionid = p.id"

        If search <> "" Then
            query &= " WHERE e.firstname LIKE @s OR e.lastname LIKE @s"
        End If

        GetQuery(query, "emp", P("@s", "%" & search & "%"))
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
            query &= " WHERE (e.firstname LIKE @s OR e.lastname LIKE @s OR a.date LIKE @s OR a.status LIKE @s OR a.timein LIKE @s OR a.timeout LIKE @s)"
        End If

        query &= " ORDER BY ABS(DATEDIFF(CURDATE(), a.date)), a.date DESC"

        GetQuery(query, "att", P("@s", "%" & search & "%"))
        lvattendance.Items.Clear()

        For Each row As DataRow In ds.Tables("att").Rows
            Dim item As ListViewItem = lvattendance.Items.Add(row("id").ToString())
            item.SubItems.Add(row("employeeid").ToString())
            item.SubItems.Add(row("fullname").ToString())
            item.SubItems.Add(CDate(row("date")).ToShortDateString())
            item.SubItems.Add(row("status").ToString())
            item.SubItems.Add(If(IsDBNull(row("timein")), "00:00:00", row("timein").ToString()))
            item.SubItems.Add(If(IsDBNull(row("timeout")), "00:00:00", row("timeout").ToString()))
            item.Tag = CDate(row("date"))

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
        attid = Nothing
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
        If Not (adding Or updating) Then Exit Sub

        If txtempid.Text.Trim() = "" Or cmbstatus.Text.Trim() = "" Then
            MsgBox("Employee and status are required!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim empid As Integer
        If Not Integer.TryParse(txtempid.Text.Trim(), empid) OrElse CInt(GetValue("SELECT COUNT(*) FROM tblemployee WHERE id = @id", P("@id", empid))) = 0 Then
            MsgBox("Employee ID " & txtempid.Text.Trim() & " was not found. Double-click an employee in the list to select one.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim status As String = Array.Find(Statuses, Function(s) String.Equals(s, cmbstatus.Text.Trim(), StringComparison.OrdinalIgnoreCase))
        If status Is Nothing Then
            MsgBox("Status must be Present, Absent, Late or On Leave.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim attendanceDate As Date = dtpdate.Value.Date
        If attendanceDate > Today And status <> "On Leave" Then
            MsgBox("Attendance can't be recorded for a future date.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim hasTimes As Boolean = (status = "Present" Or status = "Late")
        Dim timeIn As TimeSpan = If(hasTimes, dtptimein.Value.TimeOfDay, TimeSpan.Zero)
        Dim timeOut As TimeSpan = If(hasTimes, dtptimeout.Value.TimeOfDay, TimeSpan.Zero)
        timeIn = New TimeSpan(timeIn.Hours, timeIn.Minutes, timeIn.Seconds)
        timeOut = New TimeSpan(timeOut.Hours, timeOut.Minutes, timeOut.Seconds)

        ' A time out of 00:00 means the employee hasn't clocked out yet.
        If hasTimes AndAlso timeOut <> TimeSpan.Zero AndAlso timeOut < timeIn Then
            MsgBox("Time out can't be earlier than time in.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        ' One record per employee per day (also enforced by the database).
        If CInt(GetValue("SELECT COUNT(*) FROM tblattendance WHERE employeeid = @e AND date = @d AND id <> @id",
                         P("@e", empid), P("@d", attendanceDate.ToString("yyyy-MM-dd")), P("@id", If(updating, attid, -1)))) > 0 Then
            MsgBox("This employee already has an attendance record for this date!", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim params As MySqlParameter() = {P("@e", empid), P("@d", attendanceDate.ToString("yyyy-MM-dd")), P("@s", status),
                                          P("@in", timeIn.ToString("hh\:mm\:ss")), P("@out", timeOut.ToString("hh\:mm\:ss")), P("@id", attid)}

        If adding Then
            If Not SetQuery("INSERT INTO tblattendance (employeeid, date, status, timein, timeout) VALUES (@e, @d, @s, @in, @out)", params) Then Exit Sub
            adding = False
            MsgBox("Attendance added successfully!", MsgBoxStyle.Information)
        Else
            If Not SetQuery("UPDATE tblattendance SET employeeid = @e, date = @d, status = @s, timein = @in, timeout = @out WHERE id = @id", params) Then Exit Sub
            updating = False
            MsgBox("Attendance updated successfully!", MsgBoxStyle.Information)
        End If

        attid = Nothing
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
            If SetQuery("DELETE FROM tblattendance WHERE id = @id", P("@id", attid)) Then
                attid = Nothing
                fill()
                clearfields()
                MsgBox("Record deleted.", MsgBoxStyle.Information)
            End If
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
        If adding Or updating Or lvattendance.SelectedItems.Count = 0 Then Exit Sub

        Dim item As ListViewItem = lvattendance.SelectedItems(0)
        Dim baseDate As Date = CDate(item.Tag)

        attid = CInt(item.SubItems(0).Text)
        txtempid.Text = item.SubItems(1).Text
        dtpdate.Value = baseDate
        cmbstatus.Text = item.SubItems(4).Text

        dtptimein.Value = baseDate.Date.Add(TimeSpan.Parse(item.SubItems(5).Text))
        dtptimeout.Value = baseDate.Date.Add(TimeSpan.Parse(item.SubItems(6).Text))

        btnupdate.Enabled = True
        btndelete.Enabled = True

        lockupdate.Visible = False
        lockdelete.Visible = False
    End Sub

    Private Sub lvemp_DoubleClick(sender As Object, e As EventArgs) Handles lvemp.DoubleClick
        If lvemp.SelectedItems.Count = 0 Then Exit Sub
        txtempid.Text = lvemp.SelectedItems(0).SubItems(0).Text
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
        cmbstatus.Text = ""
        dtpdate.Value = Today
        dtptimein.Value = dtpdate.Value.Date.AddHours(0)
        dtptimeout.Value = dtpdate.Value.Date.AddHours(0)
        txtempid.Clear()
    End Sub

End Class
