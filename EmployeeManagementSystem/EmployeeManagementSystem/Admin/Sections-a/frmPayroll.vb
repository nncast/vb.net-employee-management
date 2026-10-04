Public Class frmPayroll
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedPayrollID As Integer = -1

    Private Sub frmPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect()

        loadform()
        fillEmployeeList()
        fill()
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
        Dim query As String = "SELECT e.id, CONCAT(e.firstname, ' ', e.lastname) AS fullname, d.deptname, e.salary " &
                              "FROM tblemployee e LEFT JOIN tbldepartment d ON e.departmentid = d.id"
        If search <> "" Then
            query &= " WHERE e.firstname LIKE @s OR e.lastname LIKE @s"
        End If
        GetQuery(query, "emp", P("@s", "%" & search & "%"))
        lvemp.Items.Clear()
        For Each r As DataRow In ds.Tables("emp").Rows
            With lvemp.Items.Add(r("id").ToString())
                .SubItems.Add(r("fullname").ToString())
                .SubItems.Add(r("deptname").ToString())
                .SubItems.Add(r("salary").ToString())
            End With
        Next
    End Sub

    Public Sub fill()
        Dim search As String = txtsearch.Text.Trim()
        Dim query As String = "SELECT p.id, p.employeeid, CONCAT(e.firstname, ' ', e.lastname) AS fullname, d.deptname, e.salary, " &
                              "p.allowance, p.tax, p.netsalary, p.paymentdate " &
                              "FROM tblpayroll p LEFT JOIN tblemployee e ON p.employeeid = e.id " &
                              "LEFT JOIN tbldepartment d ON e.departmentid = d.id"
        If search <> "" Then
            query &= " WHERE e.firstname LIKE @s OR e.lastname LIKE @s"
        End If
        query &= " ORDER BY p.paymentdate DESC"
        GetQuery(query, "pay", P("@s", "%" & search & "%"))
        lvpayroll.Items.Clear()
        For Each r As DataRow In ds.Tables("pay").Rows
            With lvpayroll.Items.Add(r("id").ToString())
                .SubItems.Add(r("fullname").ToString())
                .SubItems.Add(r("deptname").ToString())
                .SubItems.Add(r("salary").ToString())
                .SubItems.Add(r("allowance").ToString())
                .SubItems.Add(r("tax").ToString())
                .SubItems.Add(r("netsalary").ToString())
                .SubItems.Add(CDate(r("paymentdate")).ToShortDateString())
                ' The employee's id (column 0 is the payroll record's id).
                .Tag = r("employeeid").ToString()
            End With
        Next
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearFields()
        adding = True
        pnlinput.Enabled = True
    End Sub

    ' Reads an amount box; blank counts as 0.
    Private Function TryReadAmount(box As TextBox, label As String, ByRef value As Decimal) As Boolean
        Dim raw As String = box.Text.Trim()
        If raw = "" Then value = 0 : Return True
        If Decimal.TryParse(raw, value) AndAlso value >= 0 Then Return True
        MsgBox(label & " must be a number (0 or more).", MsgBoxStyle.Exclamation)
        Return False
    End Function

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If Not (adding Or updating) Then Exit Sub

        If txtempid.Text.Trim() = "" Then
            MsgBox("Please select an employee.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim empid As Integer
        If Not Integer.TryParse(txtempid.Text.Trim(), empid) OrElse CInt(GetValue("SELECT COUNT(*) FROM tblemployee WHERE id = @id", P("@id", empid))) = 0 Then
            MsgBox("Employee ID " & txtempid.Text.Trim() & " was not found. Double-click an employee in the list to select one.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim salary, allowance, tax As Decimal
        If Not TryReadAmount(txtsalary, "Salary", salary) Then Exit Sub
        If Not TryReadAmount(txtallowance, "Allowance", allowance) Then Exit Sub
        If Not TryReadAmount(txttax, "Tax", tax) Then Exit Sub

        Dim netsalary As Decimal = salary + allowance - tax
        If netsalary < 0 Then
            MsgBox("Tax can't be more than the salary plus allowance.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If
        Dim paydate As String = dtppaymentdate.Value.ToString("yyyy-MM-dd")

        If adding Then
            If Not SetQuery("INSERT INTO tblpayroll (employeeid, paymentdate, allowance, tax, netsalary) VALUES (@e, @d, @a, @t, @n)",
                            P("@e", empid), P("@d", paydate), P("@a", allowance), P("@t", tax), P("@n", netsalary)) Then Exit Sub
            adding = False
            MsgBox("Payroll record added successfully!", MsgBoxStyle.Information)
        Else
            If Not SetQuery("UPDATE tblpayroll SET employeeid = @e, paymentdate = @d, allowance = @a, tax = @t, netsalary = @n WHERE id = @id",
                            P("@e", empid), P("@d", paydate), P("@a", allowance), P("@t", tax), P("@n", netsalary), P("@id", selectedPayrollID)) Then Exit Sub
            updating = False
            MsgBox("Payroll record updated successfully!", MsgBoxStyle.Information)
        End If

        fill()
        clearFields()
        disablebuttons()
        pnlinput.Enabled = False
    End Sub

    Private Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        If selectedPayrollID = -1 Then
            MsgBox("Select a payroll record first.", MsgBoxStyle.Information)
            Exit Sub
        End If

        enablebuttons()
        updating = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If selectedPayrollID = -1 Then
            MsgBox("Select a payroll record to delete.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If MsgBox("Are you sure you want to delete this record?", MsgBoxStyle.YesNo + MsgBoxStyle.Question) = MsgBoxResult.Yes Then
            If SetQuery("DELETE FROM tblpayroll WHERE id = @id", P("@id", selectedPayrollID)) Then
                fill()
                clearFields()
                selectedPayrollID = -1
                MsgBox("Record deleted.", MsgBoxStyle.Information)
            End If
        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        If adding Then
            If MsgBox("Are you sure you want to cancel adding new payroll information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                adding = False
            Else
                Exit Sub
            End If
        ElseIf updating Then
            If MsgBox("Are you sure you want to cancel updating payroll information?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Cancel") = MsgBoxResult.Yes Then
                updating = False
            Else
                Exit Sub
            End If
        End If


        disablebuttons()
        clearFields()
        pnlinput.Enabled = False
        selectedPayrollID = -1
    End Sub

    Private Sub lvemp_DoubleClick(sender As Object, e As EventArgs) Handles lvemp.DoubleClick
        If lvemp.SelectedItems.Count = 0 Then Exit Sub
        txtempid.Text = lvemp.SelectedItems(0).SubItems(0).Text
        txtsalary.Text = lvemp.SelectedItems(0).SubItems(3).Text
    End Sub

    Private Sub lvpayroll_DoubleClick(sender As Object, e As EventArgs) Handles lvpayroll.DoubleClick
        If adding Or updating Or lvpayroll.SelectedItems.Count = 0 Then Exit Sub

        Dim item As ListViewItem = lvpayroll.SelectedItems(0)
        selectedPayrollID = Integer.Parse(item.SubItems(0).Text)
        txtempid.Text = item.Tag.ToString()
        txtsalary.Text = item.SubItems(3).Text
        txtallowance.Text = item.SubItems(4).Text
        txttax.Text = item.SubItems(5).Text
        dtppaymentdate.Value = CDate(item.SubItems(7).Text)

        pnlinput.Enabled = False

        btnupdate.Enabled = True
        btndelete.Enabled = True

        lockupdate.Visible = False
        lockdelete.Visible = False
    End Sub

    Private Sub txtsearch_TextChanged(sender As Object, e As EventArgs) Handles txtsearch.TextChanged
        fill()
    End Sub

    Private Sub txtsearchemp_TextChanged(sender As Object, e As EventArgs) Handles txtsearchemp.TextChanged
        fillEmployeeList()
    End Sub

    Public Sub clearFields()
        txtempid.Clear()
        txtsalary.Clear()
        txtallowance.Clear()
        txttax.Clear()
        dtppaymentdate.Value = Today
        selectedPayrollID = -1
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
