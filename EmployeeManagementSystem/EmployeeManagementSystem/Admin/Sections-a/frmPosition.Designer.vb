<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPosition
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
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lvposition = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnsave = New System.Windows.Forms.Button()
        Me.pnlinput = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbdept = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtposition = New System.Windows.Forms.TextBox()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.btndelete = New System.Windows.Forms.Button()
        Me.btnnew = New System.Windows.Forms.Button()
        Me.btnupdate = New System.Windows.Forms.Button()
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
        'txtsearch
        '
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(810, 24)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(265, 34)
        Me.txtsearch.TabIndex = 19
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Location = New System.Drawing.Point(465, 61)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(623, 561)
        Me.Panel2.TabIndex = 26
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lvposition)
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
        Me.Label2.Size = New System.Drawing.Size(184, 32)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "List of Positions"
        '
        'lvposition
        '
        Me.lvposition.BackColor = System.Drawing.Color.White
        Me.lvposition.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvposition.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvposition.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lvposition.FullRowSelect = True
        Me.lvposition.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvposition.Location = New System.Drawing.Point(21, 73)
        Me.lvposition.Name = "lvposition"
        Me.lvposition.Size = New System.Drawing.Size(523, 405)
        Me.lvposition.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvposition.TabIndex = 0
        Me.lvposition.UseCompatibleStateImageBehavior = False
        Me.lvposition.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Position Name"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Department Name"
        Me.ColumnHeader3.Width = 200
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
        Me.btnsave.TabIndex = 25
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
        Me.pnlinput.TabIndex = 20
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.cmbdept)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtposition)
        Me.Panel3.Location = New System.Drawing.Point(29, 24)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(336, 249)
        Me.Panel3.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(19, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 28)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Department Name:"
        '
        'cmbdept
        '
        Me.cmbdept.FormattingEnabled = True
        Me.cmbdept.Location = New System.Drawing.Point(24, 80)
        Me.cmbdept.Name = "cmbdept"
        Me.cmbdept.Size = New System.Drawing.Size(227, 36)
        Me.cmbdept.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label1.Location = New System.Drawing.Point(19, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Position Name:"
        '
        'txtposition
        '
        Me.txtposition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtposition.Location = New System.Drawing.Point(24, 160)
        Me.txtposition.Name = "txtposition"
        Me.txtposition.Size = New System.Drawing.Size(227, 34)
        Me.txtposition.TabIndex = 1
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
        Me.btncancel.TabIndex = 24
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
        Me.btndelete.TabIndex = 23
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
        Me.btnnew.TabIndex = 21
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
        Me.btnupdate.TabIndex = 22
        Me.btnupdate.Text = "Update"
        Me.btnupdate.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(733, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 28)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Search:"
        '
        'locksave
        '
        Me.locksave.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.locksave.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.locksave.Location = New System.Drawing.Point(350, 426)
        Me.locksave.Name = "locksave"
        Me.locksave.Size = New System.Drawing.Size(50, 30)
        Me.locksave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.locksave.TabIndex = 41
        Me.locksave.TabStop = False
        '
        'lockdelete
        '
        Me.lockdelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lockdelete.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.lockdelete.Location = New System.Drawing.Point(79, 426)
        Me.lockdelete.Name = "lockdelete"
        Me.lockdelete.Size = New System.Drawing.Size(50, 30)
        Me.lockdelete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.lockdelete.TabIndex = 40
        Me.lockdelete.TabStop = False
        Me.lockdelete.Visible = False
        '
        'lockupdate
        '
        Me.lockupdate.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lockupdate.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.lockupdate.Location = New System.Drawing.Point(213, 375)
        Me.lockupdate.Name = "lockupdate"
        Me.lockupdate.Size = New System.Drawing.Size(50, 30)
        Me.lockupdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.lockupdate.TabIndex = 39
        Me.lockupdate.TabStop = False
        Me.lockupdate.Visible = False
        '
        'locknew
        '
        Me.locknew.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.locknew.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.locknew.Location = New System.Drawing.Point(79, 375)
        Me.locknew.Name = "locknew"
        Me.locknew.Size = New System.Drawing.Size(50, 30)
        Me.locknew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.locknew.TabIndex = 38
        Me.locknew.TabStop = False
        Me.locknew.Visible = False
        '
        'frmPosition
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmPosition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmPosition"
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
        Me.PerformLayout

End Sub
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lvposition As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents btnsave As System.Windows.Forms.Button
    Friend WithEvents pnlinput As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtposition As System.Windows.Forms.TextBox
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents btncancel As System.Windows.Forms.Button
    Friend WithEvents btndelete As System.Windows.Forms.Button
    Friend WithEvents btnnew As System.Windows.Forms.Button
    Friend WithEvents btnupdate As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbdept As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents locksave As System.Windows.Forms.PictureBox
    Friend WithEvents lockdelete As System.Windows.Forms.PictureBox
    Friend WithEvents lockupdate As System.Windows.Forms.PictureBox
    Friend WithEvents locknew As System.Windows.Forms.PictureBox
End Class
