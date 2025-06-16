Public Class frmAttendance_e

    Private Sub frmAttendance_e_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")

    End Sub

    Public Sub clearfields()
        txtsearch.Clear()
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT * FROM tblattendance WHERE employeeid = " & loggedinemployeeid

        If search <> "" Then
            query &= " AND (status LIKE '%" & search & "%' OR date LIKE '%" & search & "%')"
        End If

        query &= " ORDER BY date ASC"

        GetQuery(query, "attendance")
        lvattendance.Items.Clear()

        Dim count As Integer = 1
        For Each row As DataRow In ds.Tables("attendance").Rows
            Dim item As New ListViewItem(count.ToString())
            item.SubItems.Add(Convert.ToDateTime(row("date")).ToString("yyyy-MM-dd"))
            item.SubItems.Add(If(IsDBNull(row("timein")), "-", row("timein").ToString()))
            item.SubItems.Add(If(IsDBNull(row("timeout")), "-", row("timeout").ToString()))

            Dim statusSubItem = item.SubItems.Add(row("status").ToString())

            item.SubItems.Add(row("id").ToString())
            lvattendance.Items.Add(item)
            count += 1

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

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

End Class