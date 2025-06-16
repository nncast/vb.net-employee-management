<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeave
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
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtsearchleave = New System.Windows.Forms.TextBox()
        Me.lvpendingleave = New System.Windows.Forms.ListView()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.pnlinput = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtreason = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpdatefrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpdateto = New System.Windows.Forms.DateTimePicker()
        Me.ShapeContainer3 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lvleavehistory = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.btnreject = New System.Windows.Forms.Button()
        Me.btnapprove = New System.Windows.Forms.Button()
        Me.txtsearch = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lockreject = New System.Windows.Forms.PictureBox()
        Me.lockapprove = New System.Windows.Forms.PictureBox()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlinput.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.lockreject, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lockapprove, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(13, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1100, 310)
        Me.Panel1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.txtsearchleave)
        Me.Panel4.Controls.Add(Me.lvpendingleave)
        Me.Panel4.Controls.Add(Me.ShapeContainer1)
        Me.Panel4.Location = New System.Drawing.Point(581, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(516, 300)
        Me.Panel4.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(21, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 32)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Pending Leave"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(283, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 28)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Search:"
        '
        'txtsearchleave
        '
        Me.txtsearchleave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearchleave.Location = New System.Drawing.Point(357, 13)
        Me.txtsearchleave.Name = "txtsearchleave"
        Me.txtsearchleave.Size = New System.Drawing.Size(145, 34)
        Me.txtsearchleave.TabIndex = 35
        '
        'lvpendingleave
        '
        Me.lvpendingleave.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvpendingleave.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
        Me.lvpendingleave.FullRowSelect = True
        Me.lvpendingleave.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvpendingleave.Location = New System.Drawing.Point(13, 61)
        Me.lvpendingleave.Name = "lvpendingleave"
        Me.lvpendingleave.Size = New System.Drawing.Size(489, 221)
        Me.lvpendingleave.TabIndex = 0
        Me.lvpendingleave.UseCompatibleStateImageBehavior = False
        Me.lvpendingleave.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "ID"
        Me.ColumnHeader6.Width = 40
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Name"
        Me.ColumnHeader7.Width = 145
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Date From"
        Me.ColumnHeader8.Width = 100
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Date To"
        Me.ColumnHeader9.Width = 100
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Reason"
        Me.ColumnHeader10.Width = 100
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape3})
        Me.ShapeContainer1.Size = New System.Drawing.Size(516, 300)
        Me.ShapeContainer1.TabIndex = 1
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape3
        '
        Me.RectangleShape3.CornerRadius = 20
        Me.RectangleShape3.FillColor = System.Drawing.Color.White
        Me.RectangleShape3.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape3.Location = New System.Drawing.Point(3, 2)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.Size = New System.Drawing.Size(508, 293)
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.pnlinput)
        Me.Panel3.Controls.Add(Me.ShapeContainer3)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(575, 304)
        Me.Panel3.TabIndex = 4
        '
        'pnlinput
        '
        Me.pnlinput.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.pnlinput.Controls.Add(Me.Label3)
        Me.pnlinput.Controls.Add(Me.Label2)
        Me.pnlinput.Controls.Add(Me.txtreason)
        Me.pnlinput.Controls.Add(Me.Label5)
        Me.pnlinput.Controls.Add(Me.dtpdatefrom)
        Me.pnlinput.Controls.Add(Me.dtpdateto)
        Me.pnlinput.Location = New System.Drawing.Point(11, 16)
        Me.pnlinput.Name = "pnlinput"
        Me.pnlinput.Size = New System.Drawing.Size(553, 269)
        Me.pnlinput.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(260, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 28)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Reason"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label2.Location = New System.Drawing.Point(12, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 28)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Date To:"
        '
        'txtreason
        '
        Me.txtreason.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtreason.Location = New System.Drawing.Point(265, 40)
        Me.txtreason.Multiline = True
        Me.txtreason.Name = "txtreason"
        Me.txtreason.Size = New System.Drawing.Size(274, 218)
        Me.txtreason.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label5.Location = New System.Drawing.Point(12, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 28)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Date From:"
        '
        'dtpdatefrom
        '
        Me.dtpdatefrom.Location = New System.Drawing.Point(17, 40)
        Me.dtpdatefrom.Name = "dtpdatefrom"
        Me.dtpdatefrom.Size = New System.Drawing.Size(226, 34)
        Me.dtpdatefrom.TabIndex = 1
        '
        'dtpdateto
        '
        Me.dtpdateto.Location = New System.Drawing.Point(17, 133)
        Me.dtpdateto.Name = "dtpdateto"
        Me.dtpdateto.Size = New System.Drawing.Size(226, 34)
        Me.dtpdateto.TabIndex = 2
        '
        'ShapeContainer3
        '
        Me.ShapeContainer3.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer3.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer3.Name = "ShapeContainer3"
        Me.ShapeContainer3.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2})
        Me.ShapeContainer3.Size = New System.Drawing.Size(575, 304)
        Me.ShapeContainer3.TabIndex = 4
        Me.ShapeContainer3.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.CornerRadius = 20
        Me.RectangleShape2.FillColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(209, Byte), Integer), CType(CType(203, Byte), Integer))
        Me.RectangleShape2.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape2.Location = New System.Drawing.Point(2, 3)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.Size = New System.Drawing.Size(569, 296)
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.lvleavehistory)
        Me.Panel2.Controls.Add(Me.ShapeContainer2)
        Me.Panel2.Location = New System.Drawing.Point(13, 406)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1100, 253)
        Me.Panel2.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(16, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(147, 32)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "List of Leave"
        '
        'lvleavehistory
        '
        Me.lvleavehistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lvleavehistory.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader11})
        Me.lvleavehistory.FullRowSelect = True
        Me.lvleavehistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lvleavehistory.Location = New System.Drawing.Point(22, 68)
        Me.lvleavehistory.Name = "lvleavehistory"
        Me.lvleavehistory.Size = New System.Drawing.Size(1061, 162)
        Me.lvleavehistory.TabIndex = 1
        Me.lvleavehistory.UseCompatibleStateImageBehavior = False
        Me.lvleavehistory.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Name"
        Me.ColumnHeader2.Width = 220
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date From"
        Me.ColumnHeader3.Width = 200
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Date To"
        Me.ColumnHeader4.Width = 200
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Reason"
        Me.ColumnHeader5.Width = 200
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Status"
        Me.ColumnHeader11.Width = 200
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer2.Size = New System.Drawing.Size(1100, 253)
        Me.ShapeContainer2.TabIndex = 0
        Me.ShapeContainer2.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.CornerRadius = 20
        Me.RectangleShape1.FillColor = System.Drawing.Color.White
        Me.RectangleShape1.FillStyle = Microsoft.VisualBasic.PowerPacks.FillStyle.Solid
        Me.RectangleShape1.Location = New System.Drawing.Point(3, 5)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(1094, 246)
        '
        'btnreject
        '
        Me.btnreject.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnreject.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnreject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnreject.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnreject.Location = New System.Drawing.Point(981, 358)
        Me.btnreject.Name = "btnreject"
        Me.btnreject.Size = New System.Drawing.Size(129, 45)
        Me.btnreject.TabIndex = 5
        Me.btnreject.Text = "Reject"
        Me.btnreject.UseVisualStyleBackColor = False
        '
        'btnapprove
        '
        Me.btnapprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnapprove.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btnapprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnapprove.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btnapprove.Location = New System.Drawing.Point(846, 358)
        Me.btnapprove.Name = "btnapprove"
        Me.btnapprove.Size = New System.Drawing.Size(129, 45)
        Me.btnapprove.TabIndex = 4
        Me.btnapprove.Text = "Approve"
        Me.btnapprove.UseVisualStyleBackColor = False
        '
        'txtsearch
        '
        Me.txtsearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtsearch.Location = New System.Drawing.Point(93, 369)
        Me.txtsearch.Name = "txtsearch"
        Me.txtsearch.Size = New System.Drawing.Size(227, 34)
        Me.txtsearch.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(13, 372)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 28)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Search:"
        '
        'lockreject
        '
        Me.lockreject.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lockreject.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.lockreject.Location = New System.Drawing.Point(1021, 366)
        Me.lockreject.Name = "lockreject"
        Me.lockreject.Size = New System.Drawing.Size(50, 30)
        Me.lockreject.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.lockreject.TabIndex = 37
        Me.lockreject.TabStop = False
        Me.lockreject.Visible = False
        '
        'lockapprove
        '
        Me.lockapprove.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.lockapprove.Image = Global.EmployeeManagementSystem.My.Resources.Resources.locked
        Me.lockapprove.Location = New System.Drawing.Point(887, 366)
        Me.lockapprove.Name = "lockapprove"
        Me.lockapprove.Size = New System.Drawing.Size(50, 30)
        Me.lockapprove.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.lockapprove.TabIndex = 36
        Me.lockapprove.TabStop = False
        Me.lockapprove.Visible = False
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btncancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btncancel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.btncancel.Location = New System.Drawing.Point(711, 358)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(129, 45)
        Me.btncancel.TabIndex = 38
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'frmLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 28.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(250, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(228, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1125, 683)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.lockreject)
        Me.Controls.Add(Me.lockapprove)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtsearch)
        Me.Controls.Add(Me.btnreject)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.btnapprove)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(3, Byte), Integer), CType(CType(29, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmLeave"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmLeave"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.pnlinput.ResumeLayout(False)
        Me.pnlinput.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.lockreject, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lockapprove, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtreason As System.Windows.Forms.TextBox
    Friend WithEvents dtpdateto As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpdatefrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnreject As System.Windows.Forms.Button
    Friend WithEvents btnapprove As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents lvpendingleave As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lvleavehistory As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents txtsearch As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer3 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtsearchleave As System.Windows.Forms.TextBox
    Friend WithEvents pnlinput As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lockreject As System.Windows.Forms.PictureBox
    Friend WithEvents lockapprove As System.Windows.Forms.PictureBox
    Friend WithEvents btncancel As System.Windows.Forms.Button
End Class
