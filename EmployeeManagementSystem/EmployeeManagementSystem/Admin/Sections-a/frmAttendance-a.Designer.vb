<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendance
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlinput = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtempid = New System.Windows.Forms.TextBox()
        Me.dtpdate = New System.Windows.Forms.DateTimePicker()
        Me.dtptimeout = New System.Windows.Forms.DateTimePicker()
        Me.dtptimein = New System.Windows.Forms.DateTimePicker()
        Me.cmbstatus = New System.Windows.Forms.ComboBox()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtsearchemp = New System.Windows.Forms.TextBox()
        Me.lvemp = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lvattendance = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.locksave = New System.Windows.Forms.PictureBox()
        Me.lockdelete = New System.Windows.Forms.PictureBox()
        Me.lockupdate = New System.Windows.Forms.PictureBox()
        Me.locknew = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.pnlinput.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.locksave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lockdelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lockupdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.locknew, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.pnlinput)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(13, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1109, 316)
        Me.Panel1.TabIndex = 0
        '
        'pnlinput
        '
        Me.pnlinput.Controls.Add(Me.Panel4)
        Me.pnlinput.Controls.Add(Me.ShapeContainer2)
        Me.pnlinput.Location = New System.Drawing.Point(452, 3)
        Me.pnlinput.Name = "pnlinput"
        Me.pnlinput.Size = New System.Drawing.Size(645, 307)
        Me.pnlinput.TabIndex = 17
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.txtempid)
        Me.Panel4.Controls.Add(Me.dtpdate)
        Me.Panel4.Controls.Add(Me.dtptimeout)
        Me.Panel4.Controls.Add(Me.dtptimein)
        Me.Panel4.Controls.Add(Me.cmbstatus)
        Me.Panel4.Location = New System.Drawing.Point(18, 23)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(604, 267)
        Me.Panel4.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(418, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 28)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Time Out:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label4.Location = New System.Drawing.Point(418, 91)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 28)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Time In:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(23, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 28)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(178, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 28)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Status:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(23, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 28)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Employee ID:"
        '
        'txtempid
        '
        Me.txtempid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtempid.Location = New System.Drawing.Point(28, 43)
        Me.txtempid.Name = "txtempid"
        Me.txtempid.Size = New System.Drawing.Size(101, 34)
        Me.txtempid.TabIndex = 18
        '
        'dtpdate
        '
        Me.dtpdate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dtpdate.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(CType(CType(245, Byte), Integer), CType(CType(184, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.dtpdate.Location = New System.Drawing.Point(28, 122)
        Me.dtpdate.Name = "dtpdate"
        Me.dtpdate.Size = New System.Drawing.Size(355, 34)
        Me.dtpdate.TabIndex = 3
        '
        'dtptimeout
        '
        Me.dtptimeout.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtptimeout.Location = New System.Drawing.Point(419, 204)
        Me.dtptimeout.Name = "dtptimeout"
        Me.dtptimeout.Size = New System.Drawing.Size(168, 34)
        Me.dtptimeout.TabIndex = 5
        '
        'dtptimein
        '
        Me.dtptimein.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtptimein.Location = New System.Drawing.Point(419, 122)
        Me.dtptimein.Name = "dtptimein"
        Me.dtptimein.Size = New System.Drawing.Size(168, 34)
        Me.dtptimein.TabIndex = 4
        '
        'cmbstatus
        '
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.Items.AddRange(New Object() {"Present", "Absent", "Late"})
        Me.cmbstatus.Location = New System.Drawing.Point(183, 41)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(182, 36)
        Me.cmbstatus.TabIndex = 2
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer2.Size = New System.Drawing.Size(645, 307)
        Me.ShapeContainer2.TabIndex = 17
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 20
        Me.RectangleShape2.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.RectangleShape2.FillColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(2, 6)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(639, 298)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtsearchemp)
        Me.Panel2.Controls.Add(Me.lvemp)
        Me.Panel2.Controls.Add(Me.ShapeContainer1)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(443, 298)
        Me.Panel2.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(210, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 28)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Search:"
        '
        'txtsearchemp
        '
        Me.txtsearchemp.Location = New System.Drawing.Point(284, 12)
        Me.txtsearchemp.Name = "txtsearchemp"
        Me.txtsearchemp.Size = New System.Drawing.Size(145, 34)
        Me.txtsearchemp.TabIndex = 25
        '
        'lvemp
        '
        Me.lvemp.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvemp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lvemp.FullRowSelect = True
        Me.lvemp.Location = New System.Drawing.Point(14, 52)
        Me.lvemp.Name = "lvemp"
        Me.lvemp.Size = New System.Drawing.Size(383, 238)
        Me.lvemp.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvemp.TabIndex = 0
        Me.lvemp.UseCompatibleStateImageBehavior = False
        Me.lvemp.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 120
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Department"
        Me.ColumnHeader3.Width = 134
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Position"
        Me.ColumnHeader4.Width = 100
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(443, 298)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.White
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(4, 6)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(436, 291)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.lvattendance)
        Me.Panel3.Controls.Add(Me.ShapeContainer3)
        Me.Panel3.Location = New System.Drawing.Point(13, 399)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1100, 272)
        Me.Panel3.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(39, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(219, 32)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Attendance History"
        '
        'lvattendance
        '
        Me.lvattendance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvattendance.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.lvattendance.FullRowSelect = True
        Me.lvattendance.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvattendance.Location = New System.Drawing.Point(45, 63)
        Me.lvattendance.Name = "lvattendance"
        Me.lvattendance.Size = New System.Drawing.Size(1012, 184)
        Me.lvattendance.TabIndex = 2
        Me.lvattendance.UseCompatibleStateImageBehavior = False
        Me.lvattendance.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "#"
        Me.ColumnHeader5.Width = 40
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ID"
        Me.ColumnHeader6.Width = 0
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 300
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Date"
        Me.ColumnHeader8.Width = 200
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Status"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Time In"
        Me.ColumnHeader10.Width = 185
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Time Out"
        Me.ColumnHeader11.Width = 185
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape3})
        Me.ShapeContainer3.Size = New System.Drawing.Size(1100, 272)
        Me.ShapeContainer3.TabIndex = 0
        Me.ShapeContainer3.TabStop = False
        '
        'RectangleShape3
        '
        Me.RectangleShape3.CornerRadius = 20
        Me.RectangleShape3.FillColor = System.Drawing.Color.White
        Me.RectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape3.Location = New System.Drawing.Point(8, 4)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(1078, 252)
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnsave.Location = New System.Drawing.Point(970, 348)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(129, 45)
        Me.btnsave.TabIndex = 22
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btncancel.Location = New System.Drawing.Point(829, 348)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(129, 45)
        Me.btncancel.TabIndex = 21
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btndelete.Location = New System.Drawing.Point(694, 348)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(129, 45)
        Me.btndelete.TabIndex = 20
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnnew
        '
        Me.btnnew.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnnew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnew.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnnew.Location = New System.Drawing.Point(424, 348)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(129, 45)
        Me.btnnew.TabIndex = 18
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnupdate.Location = New System.Drawing.Point(559, 348)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(129, 45)
        Me.btnupdate.TabIndex = 19
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'txtsearch
        '
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(105, 362)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(203, 34)
        Me.txtsearch.TabIndex = 24
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(25, 365)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 28)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Search:"
        '
        'locksave
        '
        Me.locksave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.locksave.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.locksave.Location = New System.Drawing.Point(1007, 357)
        Me.locksave.Name = "locksave"
        Me.locksave.Size = New System.Drawing.Size(50, 30)
        Me.locksave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.locksave.TabIndex = 37
        Me.locksave.TabStop = False
        '
        'lockdelete
        '
        Me.lockdelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lockdelete.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.lockdelete.Location = New System.Drawing.Point(737, 357)
        Me.lockdelete.Name = "lockdelete"
        Me.lockdelete.Size = New System.Drawing.Size(50, 30)
        Me.lockdelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.lockdelete.TabIndex = 36
        Me.lockdelete.TabStop = False
        Me.lockdelete.Visible = False
        '
        'lockupdate
        '
        Me.lockupdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lockupdate.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.lockupdate.Location = New System.Drawing.Point(600, 357)
        Me.lockupdate.Name = "lockupdate"
        Me.lockupdate.Size = New System.Drawing.Size(50, 30)
        Me.lockupdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.lockupdate.TabIndex = 35
        Me.lockupdate.TabStop = False
        Me.lockupdate.Visible = False
        '
        'locknew
        '
        Me.locknew.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.locknew.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.locknew.Location = New System.Drawing.Point(466, 357)
        Me.locknew.Name = "locknew"
        Me.locknew.Size = New System.Drawing.Size(50, 30)
        Me.locknew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.locknew.TabIndex = 34
        Me.locknew.TabStop = False
        Me.locknew.Visible = False
        '
        'frmAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.locksave)
        Me.Controls.Add(Me.lockdelete)
        Me.Controls.Add(Me.lockupdate)
        Me.Controls.Add(Me.locknew)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.btnupdate)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmAttendance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmAttendance"
        Me.Panel1.ResumeLayout(False)
        Me.pnlinput.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.locksave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lockdelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lockupdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.locknew, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents dtptimeout As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtptimein As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbstatus As System.Windows.Forms.ComboBox
    Friend WithEvents lvemp As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents pnlinput As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents lvattendance As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents txtempid As System.Windows.Forms.TextBox
    Friend WithEvents txtsearchemp As System.Windows.Forms.TextBox
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents locksave As System.Windows.Forms.PictureBox
    Friend WithEvents lockdelete As System.Windows.Forms.PictureBox
    Friend WithEvents lockupdate As System.Windows.Forms.PictureBox
    Friend WithEvents locknew As System.Windows.Forms.PictureBox
End Class
