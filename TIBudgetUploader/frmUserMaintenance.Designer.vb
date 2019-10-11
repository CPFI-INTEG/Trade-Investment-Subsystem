<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUserMaintenance
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUserMaintenance))
        Me.grdDataUsers = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpSearch = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkPermissions = New System.Windows.Forms.CheckedListBox()
        Me.btnActivate = New System.Windows.Forms.Button()
        Me.btnDeactivate = New System.Windows.Forms.Button()
        Me.lblDept = New System.Windows.Forms.Label()
        Me.lblBUnit = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblUserFullName = New System.Windows.Forms.Label()
        Me.labell = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblEmpCode = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAll = New System.Windows.Forms.Button()
        Me.btnInserUser = New System.Windows.Forms.Button()
        Me.btnInsertBulk = New System.Windows.Forms.Button()
        CType(Me.grdDataUsers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.grpSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdDataUsers
        '
        Me.grdDataUsers.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        Me.grdDataUsers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdDataUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDataUsers.Location = New System.Drawing.Point(12, 269)
        Me.grdDataUsers.Name = "grdDataUsers"
        Me.grdDataUsers.ReadOnly = True
        Me.grdDataUsers.Size = New System.Drawing.Size(865, 259)
        Me.grdDataUsers.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(889, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.LogoutToolStripMenuItem.Text = "&Exit"
        '
        'grpSearch
        '
        Me.grpSearch.Controls.Add(Me.Label3)
        Me.grpSearch.Controls.Add(Me.chkPermissions)
        Me.grpSearch.Controls.Add(Me.btnActivate)
        Me.grpSearch.Controls.Add(Me.btnDeactivate)
        Me.grpSearch.Controls.Add(Me.lblDept)
        Me.grpSearch.Controls.Add(Me.lblBUnit)
        Me.grpSearch.Controls.Add(Me.Label6)
        Me.grpSearch.Controls.Add(Me.Label5)
        Me.grpSearch.Controls.Add(Me.lblFullName)
        Me.grpSearch.Controls.Add(Me.lblUserFullName)
        Me.grpSearch.Controls.Add(Me.labell)
        Me.grpSearch.Controls.Add(Me.btnReset)
        Me.grpSearch.Controls.Add(Me.btnSave)
        Me.grpSearch.Controls.Add(Me.lblEmpCode)
        Me.grpSearch.Controls.Add(Me.lblUserName)
        Me.grpSearch.Controls.Add(Me.Label2)
        Me.grpSearch.Controls.Add(Me.Label1)
        Me.grpSearch.Location = New System.Drawing.Point(178, 27)
        Me.grpSearch.Name = "grpSearch"
        Me.grpSearch.Size = New System.Drawing.Size(507, 207)
        Me.grpSearch.TabIndex = 2
        Me.grpSearch.TabStop = False
        Me.grpSearch.Text = "User Details"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(304, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Permissions :"
        '
        'chkPermissions
        '
        Me.chkPermissions.FormattingEnabled = True
        Me.chkPermissions.Location = New System.Drawing.Point(307, 34)
        Me.chkPermissions.Name = "chkPermissions"
        Me.chkPermissions.Size = New System.Drawing.Size(163, 124)
        Me.chkPermissions.TabIndex = 19
        '
        'btnActivate
        '
        Me.btnActivate.Location = New System.Drawing.Point(367, 177)
        Me.btnActivate.Name = "btnActivate"
        Me.btnActivate.Size = New System.Drawing.Size(75, 23)
        Me.btnActivate.TabIndex = 18
        Me.btnActivate.Text = "&Activate"
        Me.btnActivate.UseVisualStyleBackColor = True
        '
        'btnDeactivate
        '
        Me.btnDeactivate.Location = New System.Drawing.Point(287, 178)
        Me.btnDeactivate.Name = "btnDeactivate"
        Me.btnDeactivate.Size = New System.Drawing.Size(75, 23)
        Me.btnDeactivate.TabIndex = 17
        Me.btnDeactivate.Text = "&Deactivate"
        Me.btnDeactivate.UseVisualStyleBackColor = True
        '
        'lblDept
        '
        Me.lblDept.AutoSize = True
        Me.lblDept.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDept.Location = New System.Drawing.Point(90, 121)
        Me.lblDept.Name = "lblDept"
        Me.lblDept.Size = New System.Drawing.Size(0, 13)
        Me.lblDept.TabIndex = 16
        '
        'lblBUnit
        '
        Me.lblBUnit.AutoSize = True
        Me.lblBUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBUnit.Location = New System.Drawing.Point(102, 76)
        Me.lblBUnit.Name = "lblBUnit"
        Me.lblBUnit.Size = New System.Drawing.Size(0, 13)
        Me.lblBUnit.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Department :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(22, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Business Unit :"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullName.Location = New System.Drawing.Point(111, 99)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(0, 13)
        Me.lblFullName.TabIndex = 12
        '
        'lblUserFullName
        '
        Me.lblUserFullName.AutoSize = True
        Me.lblUserFullName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserFullName.Location = New System.Drawing.Point(112, 99)
        Me.lblUserFullName.Name = "lblUserFullName"
        Me.lblUserFullName.Size = New System.Drawing.Size(0, 13)
        Me.lblUserFullName.TabIndex = 11
        '
        'labell
        '
        Me.labell.AutoSize = True
        Me.labell.Location = New System.Drawing.Point(22, 99)
        Me.labell.Name = "labell"
        Me.labell.Size = New System.Drawing.Size(90, 13)
        Me.labell.TabIndex = 10
        Me.labell.Text = "Employee Name :"
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(175, 178)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(106, 23)
        Me.btnReset.TabIndex = 9
        Me.btnReset.Text = "R&eset Password"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(62, 178)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(108, 23)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Update Permission"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lblEmpCode
        '
        Me.lblEmpCode.AutoSize = True
        Me.lblEmpCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpCode.Location = New System.Drawing.Point(109, 53)
        Me.lblEmpCode.Name = "lblEmpCode"
        Me.lblEmpCode.Size = New System.Drawing.Size(0, 13)
        Me.lblEmpCode.TabIndex = 3
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserName.Location = New System.Drawing.Point(109, 34)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(0, 13)
        Me.lblUserName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(22, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Employee No. :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User Name :"
        '
        'btnAll
        '
        Me.btnAll.Location = New System.Drawing.Point(284, 240)
        Me.btnAll.Name = "btnAll"
        Me.btnAll.Size = New System.Drawing.Size(99, 23)
        Me.btnAll.TabIndex = 3
        Me.btnAll.Text = "&Refresh Data"
        Me.btnAll.UseVisualStyleBackColor = True
        '
        'btnInserUser
        '
        Me.btnInserUser.Location = New System.Drawing.Point(389, 240)
        Me.btnInserUser.Name = "btnInserUser"
        Me.btnInserUser.Size = New System.Drawing.Size(70, 23)
        Me.btnInserUser.TabIndex = 4
        Me.btnInserUser.Text = "&Add User.."
        Me.btnInserUser.UseVisualStyleBackColor = True
        '
        'btnInsertBulk
        '
        Me.btnInsertBulk.Location = New System.Drawing.Point(465, 240)
        Me.btnInsertBulk.Name = "btnInsertBulk"
        Me.btnInsertBulk.Size = New System.Drawing.Size(107, 23)
        Me.btnInsertBulk.TabIndex = 5
        Me.btnInsertBulk.Text = "Add &Bulk Users..."
        Me.btnInsertBulk.UseVisualStyleBackColor = True
        '
        'frmUserMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(889, 540)
        Me.Controls.Add(Me.btnInsertBulk)
        Me.Controls.Add(Me.btnInserUser)
        Me.Controls.Add(Me.btnAll)
        Me.Controls.Add(Me.grpSearch)
        Me.Controls.Add(Me.grdDataUsers)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserMaintenance"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Maintenance"
        CType(Me.grdDataUsers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpSearch.ResumeLayout(False)
        Me.grpSearch.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grdDataUsers As System.Windows.Forms.DataGridView
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpSearch As System.Windows.Forms.GroupBox
    Friend WithEvents lblEmpCode As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnAll As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents lblUserFullName As System.Windows.Forms.Label
    Friend WithEvents labell As System.Windows.Forms.Label
    Friend WithEvents btnInserUser As System.Windows.Forms.Button
    Friend WithEvents btnInsertBulk As System.Windows.Forms.Button
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblDept As System.Windows.Forms.Label
    Friend WithEvents lblBUnit As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDeactivate As System.Windows.Forms.Button
    Friend WithEvents btnActivate As System.Windows.Forms.Button
    Friend WithEvents chkPermissions As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
