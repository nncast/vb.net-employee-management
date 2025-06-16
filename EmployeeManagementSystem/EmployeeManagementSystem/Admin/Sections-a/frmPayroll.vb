Public Class frmPayroll
    Public adding As Boolean = False
    Public updating As Boolean = False
    Public selectedPayrollID As Integer = -1

    Private Sub frmPayroll_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Connect("localhost", "dbemployee", "3306", "root", "")

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
        Dim query As String = "SELECT e.id, CONCAT(e.firstname, ' ', e.lastname) AS fullname, d.deptname, e.salary " &
                              "FROM tblemployee e LEFT JOIN tbldepartment d ON e.departmentid = d.id"
        If txtsearchemp.Text.Trim() <> "" Then
            query &= " WHERE e.firstname LIKE '%" & txtsearchemp.Text & "%' OR e.lastname LIKE '%" & txtsearchemp.Text & "%'"
        End If
        GetQuery(query, "emp")
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
        Dim query As String = "SELECT p.id, CONCAT(e.firstname, ' ', e.lastname) AS fullname, d.deptname, e.salary, " &
                              "p.allowance, p.tax, p.netsalary, p.paymentdate " &
                              "FROM tblpayroll p LEFT JOIN tblemployee e ON p.employeeid = e.id " &
                              "LEFT JOIN tbldepartment d ON e.departmentid = d.id"
        If txtsearch.Text.Trim() <> "" Then
            query &= " WHERE e.firstname LIKE '%" & txtsearch.Text & "%' OR e.lastname LIKE '%" & txtsearch.Text & "%'"
        End If
        query &= " ORDER BY p.paymentdate DESC"
        GetQuery(query, "pay")
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
            End With
        Next
    End Sub

    Private Sub btnnew_Click(sender As Object, e As EventArgs) Handles btnnew.Click
        enablebuttons()
        clearFields()
        adding = True
        pnlinput.Enabled = True
    End Sub

    Private Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If txtempid.Text = "" Then
            MsgBox("Please select an employee.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim empid As Integer = Integer.Parse(txtempid.Text)
        Dim salary As Decimal = Decimal.Parse(txtsalary.Text)
        Dim allowance As Decimal = Decimal.Parse(txtallowance.Text)
        Dim tax As Decimal = Decimal.Parse(txttax.Text)
        Dim netsalary As Decimal = salary + allowance - tax
        Dim paydate As String = dtppaymentdate.Value.ToString("yyyy-MM-dd")

        If adding Then
            SetQuery("INSERT INTO tblpayroll (employeeid, paymentdate, allowance, tax, netsalary) VALUES (" &
                     empid & ", '" & paydate & "', " & allowance & ", " & tax & ", " & netsalary & ")")
            adding = False
            MsgBox("Payroll record added successfully!", MsgBoxStyle.Information)
        ElseIf updating Then
            SetQuery("UPDATE tblpayroll SET employeeid = " & empid &
                     ", paymentdate = '" & paydate & "', allowance = " & allowance &
                     ", tax = " & tax & ", netsalary = " & netsalary & " WHERE id = " & selectedPayrollID)
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
            SetQuery("DELETE FROM tblpayroll WHERE id = " & selectedPayrollID)
            fill()
            clearFields()
            selectedPayrollID = -1
            MsgBox("Record deleted.", MsgBoxStyle.Information)
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
        selectedPayrollID = Nothing
    End Sub

    Private Sub lvemp_DoubleClick(sender As Object, e As EventArgs) Handles lvemp.DoubleClick
        txtempid.Text = lvemp.FocusedItem.SubItems(0).Text
        txtsalary.Text = lvemp.FocusedItem.SubItems(3).Text
    End Sub

    Private Sub lvpayroll_DoubleClick(sender As Object, e As EventArgs) Handles lvpayroll.DoubleClick
        selectedPayrollID = Integer.Parse(lvpayroll.FocusedItem.SubItems(0).Text)
        txtempid.Text = selectedPayrollID.ToString()
        txtsalary.Text = lvpayroll.FocusedItem.SubItems(3).Text
        txtallowance.Text = lvpayroll.FocusedItem.SubItems(4).Text
        txttax.Text = lvpayroll.FocusedItem.SubItems(5).Text
        dtppaymentdate.Value = CDate(lvpayroll.FocusedItem.SubItems(7).Text)

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
