Public Class frmHome

    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")

        fill()
    End Sub

    Public Sub fill()
        GetQuery("SELECT COUNT(*) FROM tblemployee", "totalemp")
        lblemp.Text = ds.Tables("totalemp").Rows(0)(0).ToString()

        GetQuery("SELECT COUNT(*) FROM tblattendance WHERE date = CURDATE() AND status = 'present'", "presenttoday")
        lblpresent.Text = ds.Tables("presenttoday").Rows(0)(0).ToString()

        GetQuery("SELECT COUNT(*) FROM tblleaverequests WHERE CURDATE() BETWEEN datefrom AND dateto AND status = 'approved'", "onleave")
        lblonleave.Text = ds.Tables("onleave").Rows(0)(0).ToString()

        GetQuery("SELECT COUNT(*) FROM tblleaverequests WHERE status = 'pending'", "pendingleave")
        lblpendingleave.Text = ds.Tables("pendingleave").Rows(0)(0).ToString()

        GetQuery("SELECT p.id, p.positiontitle, COUNT(e.id) AS total " & _
                 "FROM tblposition p LEFT JOIN tblemployee e ON p.id = e.positionid " & _
                 "GROUP BY p.id, p.positiontitle", "perposition")
        lvposition.Items.Clear()
        For Each row As DataRow In ds.Tables("perposition").Rows
            Dim item As New ListViewItem(row("id").ToString())
            item.SubItems.Add(row("positiontitle").ToString())
            item.SubItems.Add(row("total").ToString())
            lvposition.Items.Add(item)
        Next

        GetQuery("SELECT d.id, d.deptname, COUNT(e.id) AS total " & _
                 "FROM tbldepartment d LEFT JOIN tblemployee e ON d.id = e.departmentid " & _
                 "GROUP BY d.id, d.deptname", "perdepartment")
        lvdepartment.Items.Clear()
        For Each row As DataRow In ds.Tables("perdepartment").Rows
            Dim item As New ListViewItem(row("id").ToString())
            item.SubItems.Add(row("deptname").ToString())
            item.SubItems.Add(row("total").ToString())
            lvdepartment.Items.Add(item)
        Next

        GetQuery("SELECT h.id, CONCAT(e.firstname, ' ', e.lastname) AS name, " & _
                 "IFNULL(p.positiontitle, 'N/A') AS old_position, IFNULL(d.deptname, 'N/A') AS old_department, " & _
                 "IFNULL(np.positiontitle, 'N/A') AS new_position, IFNULL(nd.deptname, 'N/A') AS new_department, " & _
                 "h.datechanged " & _
                 "FROM tblemployeehistory h " & _
                 "INNER JOIN tblemployee e ON h.employeeid = e.id " & _
                 "LEFT JOIN tblposition p ON h.oldpositionid = p.id " & _
                 "LEFT JOIN tbldepartment d ON h.olddepartmentid = d.id " & _
                 "LEFT JOIN tblposition np ON h.newpositionid = np.id " & _
                 "LEFT JOIN tbldepartment nd ON h.newdepartmentid = nd.id " & _
                 "ORDER BY h.datechanged DESC LIMIT 10", "recentactivity")

        lvrecentactivity.Items.Clear()
        For Each row As DataRow In ds.Tables("recentactivity").Rows
            Dim item As New ListViewItem(row("id").ToString())
            item.SubItems.Add(row("name").ToString())
            item.SubItems.Add(row("old_position").ToString())
            item.SubItems.Add(row("old_department").ToString())
            item.SubItems.Add(row("new_position").ToString())
            item.SubItems.Add(row("new_department").ToString())
            item.SubItems.Add(CDate(row("datechanged")).ToString("yyyy-MM-dd"))
            lvrecentactivity.Items.Add(item)
        Next
    End Sub

End Class
