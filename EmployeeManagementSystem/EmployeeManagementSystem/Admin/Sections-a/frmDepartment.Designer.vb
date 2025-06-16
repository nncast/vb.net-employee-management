<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDepartment
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvdept = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.pnlinput = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtdeptname = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.locksave = New System.Windows.Forms.PictureBox()
        Me.lockdelete = New System.Windows.Forms.PictureBox()
        Me.lockupdate = New System.Windows.Forms.PictureBox()
        Me.locknew = New System.Windows.Forms.PictureBox()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlinput.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.locksave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lockdelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lockupdate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.locknew, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Location = New System.Drawing.Point(465, 61)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(623, 561)
        Me.Panel2.TabIndex = 18
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lvdept)
        Me.Panel1.Location = New System.Drawing.Point(36, 29)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(556, 513)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "List of Departments"
        '
        'lvdept
        '
        Me.lvdept.BackColor = System.Drawing.Color.White
        Me.lvdept.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvdept.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvdept.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lvdept.FullRowSelect = True
        Me.lvdept.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvdept.Location = New System.Drawing.Point(21, 73)
        Me.lvdept.Name = "lvdept"
        Me.lvdept.Size = New System.Drawing.Size(523, 424)
        Me.lvdept.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvdept.TabIndex = 0
        Me.lvdept.UseCompatibleStateImageBehavior = False
        Me.lvdept.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Department Name"
        Me.ColumnHeader2.Width = 202
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer2.Size = New System.Drawing.Size(623, 561)
        Me.ShapeContainer2.TabIndex = 1
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.RectangleShape2.CornerRadius = 20
        Me.RectangleShape2.FillColor = System.Drawing.Color.White
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(12, 11)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(597, 539)
        '
        'btnsave
        '
        Me.btnsave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnsave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnsave.Location = New System.Drawing.Point(308, 418)
        Me.btnsave.Name = "btnsave"
        Me.btnsave.Size = New System.Drawing.Size(129, 45)
        Me.btnsave.TabIndex = 17
        Me.btnsave.Text = "Save"
        Me.btnsave.UseVisualStyleBackColor = False
        '
        'pnlinput
        '
        Me.pnlinput.Controls.Add(Me.Panel3)
        Me.pnlinput.Controls.Add(Me.ShapeContainer1)
        Me.pnlinput.Location = New System.Drawing.Point(37, 61)
        Me.pnlinput.Name = "pnlinput"
        Me.pnlinput.Size = New System.Drawing.Size(400, 286)
        Me.pnlinput.TabIndex = 12
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtdeptname)
        Me.Panel3.Location = New System.Drawing.Point(29, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(336, 249)
        Me.Panel3.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(20, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Department Name:"
        '
        'txtdeptname
        '
        Me.txtdeptname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtdeptname.Location = New System.Drawing.Point(25, 109)
        Me.txtdeptname.Name = "txtdeptname"
        Me.txtdeptname.Size = New System.Drawing.Size(246, 34)
        Me.txtdeptname.TabIndex = 1
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(400, 286)
        Me.ShapeContainer1.TabIndex = 4
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.FillColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(5, 6)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(391, 275)
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btncancel.Location = New System.Drawing.Point(308, 367)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(129, 45)
        Me.btncancel.TabIndex = 16
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'btndelete
        '
        Me.btndelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btndelete.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btndelete.Location = New System.Drawing.Point(37, 418)
        Me.btndelete.Name = "btndelete"
        Me.btndelete.Size = New System.Drawing.Size(129, 45)
        Me.btndelete.TabIndex = 15
        Me.btndelete.Text = "Delete"
        Me.btndelete.UseVisualStyleBackColor = False
        '
        'btnnew
        '
        Me.btnnew.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnnew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnnew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnnew.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnnew.Location = New System.Drawing.Point(37, 367)
        Me.btnnew.Name = "btnnew"
        Me.btnnew.Size = New System.Drawing.Size(129, 45)
        Me.btnnew.TabIndex = 13
        Me.btnnew.Text = "New"
        Me.btnnew.UseVisualStyleBackColor = False
        '
        'btnupdate
        '
        Me.btnupdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnupdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnupdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnupdate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnupdate.Location = New System.Drawing.Point(173, 367)
        Me.btnupdate.Name = "btnupdate"
        Me.btnupdate.Size = New System.Drawing.Size(129, 45)
        Me.btnupdate.TabIndex = 14
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'txtsearch
        '
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(810, 21)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(265, 34)
        Me.txtsearch.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(730, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 28)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Search:"
        '
        'locksave
        '
        Me.locksave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.locksave.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.locksave.Location = New System.Drawing.Point(349, 427)
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
        Me.lockdelete.Location = New System.Drawing.Point(78, 427)
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
        Me.lockupdate.Location = New System.Drawing.Point(212, 376)
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
        Me.locknew.Location = New System.Drawing.Point(78, 376)
        Me.locknew.Name = "locknew"
        Me.locknew.Size = New System.Drawing.Size(50, 30)
        Me.locknew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.locknew.TabIndex = 34
        Me.locknew.TabStop = False
        Me.locknew.Visible = False
        '
        'frmDepartment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.locksave)
        Me.Controls.Add(Me.lockdelete)
        Me.Controls.Add(Me.lockupdate)
        Me.Controls.Add(Me.locknew)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnsave)
        Me.Controls.Add(Me.pnlinput)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.btndelete)
        Me.Controls.Add(Me.btnnew)
        Me.Controls.Add(Me.btnupdate)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmDepartment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDepartment"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.pnlinput.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.locksave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lockdelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lockupdate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.locknew, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lvdept As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents pnlinput As System.Windows.Forms.Panel
    Friend WithEvents txtdeptname As System.Windows.Forms.TextBox
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents locksave As System.Windows.Forms.PictureBox
    Friend WithEvents lockdelete As System.Windows.Forms.PictureBox
    Friend WithEvents lockupdate As System.Windows.Forms.PictureBox
    Friend WithEvents locknew As System.Windows.Forms.PictureBox
End Class
