<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptViewAllBP
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptViewAllBP))
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.txtBP = New System.Windows.Forms.TextBox()
        Me.txtBPCode = New System.Windows.Forms.TextBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.lblBPCode = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdBP = New System.Windows.Forms.DataGridView()
        Me.grpFilters.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.grdBP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.Button1)
        Me.grpFilters.Controls.Add(Me.btnRefresh)
        Me.grpFilters.Controls.Add(Me.txtBP)
        Me.grpFilters.Controls.Add(Me.txtBPCode)
        Me.grpFilters.Controls.Add(Me.btnOK)
        Me.grpFilters.Controls.Add(Me.lblDivision)
        Me.grpFilters.Controls.Add(Me.lblBPCode)
        Me.grpFilters.Location = New System.Drawing.Point(130, 27)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(270, 103)
        Me.grpFilters.TabIndex = 3
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Report Filters"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(160, 74)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(90, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "&Download All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(6, 74)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(71, 23)
        Me.btnRefresh.TabIndex = 19
        Me.btnRefresh.Text = "&Refresh Form"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'txtBP
        '
        Me.txtBP.Location = New System.Drawing.Point(97, 49)
        Me.txtBP.Name = "txtBP"
        Me.txtBP.Size = New System.Drawing.Size(146, 20)
        Me.txtBP.TabIndex = 18
        '
        'txtBPCode
        '
        Me.txtBPCode.Location = New System.Drawing.Point(97, 15)
        Me.txtBPCode.Name = "txtBPCode"
        Me.txtBPCode.Size = New System.Drawing.Size(146, 20)
        Me.txtBPCode.TabIndex = 17
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(83, 74)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(71, 23)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "R&un Report"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(9, 49)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(57, 13)
        Me.lblDivision.TabIndex = 4
        Me.lblDivision.Text = "Customer :"
        '
        'lblBPCode
        '
        Me.lblBPCode.AutoSize = True
        Me.lblBPCode.Location = New System.Drawing.Point(9, 22)
        Me.lblBPCode.Name = "lblBPCode"
        Me.lblBPCode.Size = New System.Drawing.Size(82, 13)
        Me.lblBPCode.TabIndex = 2
        Me.lblBPCode.Text = "CustomerCode :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1156, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(35, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.ExitToolStripMenuItem.Text = "&Exit"
        '
        'grdBP
        '
        Me.grdBP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdBP.Location = New System.Drawing.Point(0, 143)
        Me.grdBP.Name = "grdBP"
        Me.grdBP.ReadOnly = True
        Me.grdBP.Size = New System.Drawing.Size(1192, 557)
        Me.grdBP.TabIndex = 6
        '
        'rptViewAllBP
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1156, 696)
        Me.Controls.Add(Me.grdBP)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "rptViewAllBP"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View Business Partners"
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.grdBP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtBP As System.Windows.Forms.TextBox
    Friend WithEvents txtBPCode As System.Windows.Forms.TextBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents lblBPCode As System.Windows.Forms.Label
    Friend WithEvents grdBP As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
