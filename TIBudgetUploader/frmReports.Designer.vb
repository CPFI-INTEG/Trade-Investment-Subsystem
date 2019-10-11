<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetMovementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListOfBusinessPartnersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetClassificationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetVSActualNonFinFianlizedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetVSActualSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetVSActualDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ExceededBudgetSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExceededBudgetDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ReportsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1022, 24)
        Me.MenuStrip1.TabIndex = 0
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
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BudgetMovementToolStripMenuItem, Me.ToolStripMenuItem1, Me.ListOfBusinessPartnersToolStripMenuItem, Me.BudgetClassificationsToolStripMenuItem, Me.BudgetVSActualNonFinFianlizedToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "&Reports"
        '
        'BudgetMovementToolStripMenuItem
        '
        Me.BudgetMovementToolStripMenuItem.Name = "BudgetMovementToolStripMenuItem"
        Me.BudgetMovementToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.BudgetMovementToolStripMenuItem.Text = "Budget &Movement"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(271, 22)
        Me.ToolStripMenuItem1.Text = "Budget &Per Month"
        '
        'ListOfBusinessPartnersToolStripMenuItem
        '
        Me.ListOfBusinessPartnersToolStripMenuItem.Name = "ListOfBusinessPartnersToolStripMenuItem"
        Me.ListOfBusinessPartnersToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.ListOfBusinessPartnersToolStripMenuItem.Text = "&List of Business Partners"
        '
        'BudgetClassificationsToolStripMenuItem
        '
        Me.BudgetClassificationsToolStripMenuItem.Name = "BudgetClassificationsToolStripMenuItem"
        Me.BudgetClassificationsToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.BudgetClassificationsToolStripMenuItem.Text = "Budget &Classifications"
        '
        'BudgetVSActualNonFinFianlizedToolStripMenuItem
        '
        Me.BudgetVSActualNonFinFianlizedToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BudgetVSActualSummaryToolStripMenuItem, Me.BudgetVSActualDetailToolStripMenuItem, Me.ExceededBudgetSummaryToolStripMenuItem, Me.ExceededBudgetDetailToolStripMenuItem})
        Me.BudgetVSActualNonFinFianlizedToolStripMenuItem.Name = "BudgetVSActualNonFinFianlizedToolStripMenuItem"
        Me.BudgetVSActualNonFinFianlizedToolStripMenuItem.Size = New System.Drawing.Size(271, 22)
        Me.BudgetVSActualNonFinFianlizedToolStripMenuItem.Text = "Budget VS Actual (Non-Fin/Fianlized)"
        '
        'BudgetVSActualSummaryToolStripMenuItem
        '
        Me.BudgetVSActualSummaryToolStripMenuItem.Name = "BudgetVSActualSummaryToolStripMenuItem"
        Me.BudgetVSActualSummaryToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.BudgetVSActualSummaryToolStripMenuItem.Text = "Budget VS Actual (Summary)"
        '
        'BudgetVSActualDetailToolStripMenuItem
        '
        Me.BudgetVSActualDetailToolStripMenuItem.Name = "BudgetVSActualDetailToolStripMenuItem"
        Me.BudgetVSActualDetailToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.BudgetVSActualDetailToolStripMenuItem.Text = "Budget VS Actual (Detail)"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(1022, 688)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'ExceededBudgetSummaryToolStripMenuItem
        '
        Me.ExceededBudgetSummaryToolStripMenuItem.Name = "ExceededBudgetSummaryToolStripMenuItem"
        Me.ExceededBudgetSummaryToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ExceededBudgetSummaryToolStripMenuItem.Text = "Exceeded Budget - Summary"
        '
        'ExceededBudgetDetailToolStripMenuItem
        '
        Me.ExceededBudgetDetailToolStripMenuItem.Name = "ExceededBudgetDetailToolStripMenuItem"
        Me.ExceededBudgetDetailToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ExceededBudgetDetailToolStripMenuItem.Text = "Exceeded Budget - Detail"
        '
        'frmReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1022, 712)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmReports"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Reports"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetMovementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ListOfBusinessPartnersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetClassificationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetVSActualNonFinFianlizedToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetVSActualSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetVSActualDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExceededBudgetSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExceededBudgetDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
