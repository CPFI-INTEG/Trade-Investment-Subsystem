<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBClassMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBClassMaintenance))
        Me.grdBClass = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBudgetCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTtyp = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.txtBClass = New System.Windows.Forms.TextBox()
        Me.lblBudgetClass = New System.Windows.Forms.Label()
        Me.combxGroup = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.combxUploadType = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TasksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaskToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.grdBClass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdBClass
        '
        Me.grdBClass.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.grdBClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBClass.Location = New System.Drawing.Point(12, 190)
        Me.grdBClass.Name = "grdBClass"
        Me.grdBClass.ReadOnly = True
        Me.grdBClass.Size = New System.Drawing.Size(816, 337)
        Me.grdBClass.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBudgetCode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtTtyp)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txtBClass)
        Me.GroupBox1.Controls.Add(Me.lblBudgetClass)
        Me.GroupBox1.Controls.Add(Me.combxGroup)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.combxUploadType)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(142, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(524, 146)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Budget Class Details"
        '
        'txtBudgetCode
        '
        Me.txtBudgetCode.Location = New System.Drawing.Point(99, 55)
        Me.txtBudgetCode.Name = "txtBudgetCode"
        Me.txtBudgetCode.Size = New System.Drawing.Size(55, 20)
        Me.txtBudgetCode.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Budget Code :"
        '
        'txtTtyp
        '
        Me.txtTtyp.Location = New System.Drawing.Point(416, 30)
        Me.txtTtyp.Name = "txtTtyp"
        Me.txtTtyp.Size = New System.Drawing.Size(45, 20)
        Me.txtTtyp.TabIndex = 19
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(37, 117)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(106, 23)
        Me.Button3.TabIndex = 17
        Me.Button3.Text = "&REFRESH DATA"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'txtBClass
        '
        Me.txtBClass.Location = New System.Drawing.Point(99, 82)
        Me.txtBClass.Name = "txtBClass"
        Me.txtBClass.Size = New System.Drawing.Size(181, 20)
        Me.txtBClass.TabIndex = 14
        '
        'lblBudgetClass
        '
        Me.lblBudgetClass.AutoSize = True
        Me.lblBudgetClass.Location = New System.Drawing.Point(99, 87)
        Me.lblBudgetClass.Name = "lblBudgetClass"
        Me.lblBudgetClass.Size = New System.Drawing.Size(0, 13)
        Me.lblBudgetClass.TabIndex = 12
        '
        'combxGroup
        '
        Me.combxGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxGroup.FormattingEnabled = True
        Me.combxGroup.Location = New System.Drawing.Point(99, 28)
        Me.combxGroup.Name = "combxGroup"
        Me.combxGroup.Size = New System.Drawing.Size(218, 21)
        Me.combxGroup.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(305, 117)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(184, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "A&CTIVATE OR DEACTIVATE"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(227, 117)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "&UPDATE"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Location = New System.Drawing.Point(149, 117)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(72, 23)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "&ADD"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'combxUploadType
        '
        Me.combxUploadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxUploadType.FormattingEnabled = True
        Me.combxUploadType.Location = New System.Drawing.Point(405, 62)
        Me.combxUploadType.Name = "combxUploadType"
        Me.combxUploadType.Size = New System.Drawing.Size(111, 21)
        Me.combxUploadType.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(325, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Upload Type :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(323, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Transaction Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Budget Class :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Budget Group :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.TasksToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(840, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'TasksToolStripMenuItem
        '
        Me.TasksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TaskToolStripMenuItem})
        Me.TasksToolStripMenuItem.Name = "TasksToolStripMenuItem"
        Me.TasksToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.TasksToolStripMenuItem.Text = "&Specific"
        '
        'TaskToolStripMenuItem
        '
        Me.TaskToolStripMenuItem.Name = "TaskToolStripMenuItem"
        Me.TaskToolStripMenuItem.Size = New System.Drawing.Size(98, 22)
        Me.TaskToolStripMenuItem.Text = "&Task"
        '
        'frmBClassMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(840, 539)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grdBClass)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBClassMaintenance"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Budget Class Maintenance"
        CType(Me.grdBClass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdBClass As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents combxUploadType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lblBudgetClass As System.Windows.Forms.Label
    Friend WithEvents combxGroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtBClass As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents txtTtyp As System.Windows.Forms.TextBox
    Friend WithEvents txtBudgetCode As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TasksToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TaskToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
