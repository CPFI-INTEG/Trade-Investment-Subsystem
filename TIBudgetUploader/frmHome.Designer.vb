<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpecificToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadFullBudgetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SearchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetClassMaintenanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryAnalyzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UploadBudgetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReUploadBudgetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevisedBudgetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccrualsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownloadAccrualsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InititalAccrualsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevisedAccrualsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ValidateAccrualsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetMovementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetPerMonthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListOfBusinessPartnersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetClassificationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetVSToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetVSActualSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetVSActualDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExceededBudgetSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExceededBudgetDetailToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MMaintainanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserMaintainanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BudgetClassMaintainanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QueryAnalayzerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevertBudgetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserAccountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VersionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdatesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.Menu
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.SpecificToolStripMenuItem, Me.BudgetToolStripMenuItem, Me.AccrualsToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.MMaintainanceToolStripMenuItem, Me.UserAccountToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(870, 24)
        Me.MenuStrip1.TabIndex = 0
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
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(112, 22)
        Me.LogoutToolStripMenuItem.Text = "&Logout"
        '
        'SpecificToolStripMenuItem
        '
        Me.SpecificToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadFullBudgetToolStripMenuItem, Me.DownloadsToolStripMenuItem, Me.SearchToolStripMenuItem, Me.UserMaintenanceToolStripMenuItem, Me.BudgetClassMaintenanceToolStripMenuItem, Me.QueryAnalyzerToolStripMenuItem})
        Me.SpecificToolStripMenuItem.Name = "SpecificToolStripMenuItem"
        Me.SpecificToolStripMenuItem.Size = New System.Drawing.Size(60, 20)
        Me.SpecificToolStripMenuItem.Text = "&Specific"
        Me.SpecificToolStripMenuItem.Visible = False
        '
        'UploadFullBudgetToolStripMenuItem
        '
        Me.UploadFullBudgetToolStripMenuItem.Name = "UploadFullBudgetToolStripMenuItem"
        Me.UploadFullBudgetToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.UploadFullBudgetToolStripMenuItem.Text = "&Upload Full Budget"
        Me.UploadFullBudgetToolStripMenuItem.Visible = False
        '
        'DownloadsToolStripMenuItem
        '
        Me.DownloadsToolStripMenuItem.Name = "DownloadsToolStripMenuItem"
        Me.DownloadsToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.DownloadsToolStripMenuItem.Text = "&Downloads"
        Me.DownloadsToolStripMenuItem.Visible = False
        '
        'SearchToolStripMenuItem
        '
        Me.SearchToolStripMenuItem.Name = "SearchToolStripMenuItem"
        Me.SearchToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.SearchToolStripMenuItem.Text = "&Reports"
        Me.SearchToolStripMenuItem.Visible = False
        '
        'UserMaintenanceToolStripMenuItem
        '
        Me.UserMaintenanceToolStripMenuItem.Name = "UserMaintenanceToolStripMenuItem"
        Me.UserMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.UserMaintenanceToolStripMenuItem.Text = "U&ser Maintenance"
        Me.UserMaintenanceToolStripMenuItem.Visible = False
        '
        'BudgetClassMaintenanceToolStripMenuItem
        '
        Me.BudgetClassMaintenanceToolStripMenuItem.Name = "BudgetClassMaintenanceToolStripMenuItem"
        Me.BudgetClassMaintenanceToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.BudgetClassMaintenanceToolStripMenuItem.Text = "&Budget Class Maintenance"
        Me.BudgetClassMaintenanceToolStripMenuItem.Visible = False
        '
        'QueryAnalyzerToolStripMenuItem
        '
        Me.QueryAnalyzerToolStripMenuItem.Name = "QueryAnalyzerToolStripMenuItem"
        Me.QueryAnalyzerToolStripMenuItem.Size = New System.Drawing.Size(214, 22)
        Me.QueryAnalyzerToolStripMenuItem.Text = "&Query Analyzer"
        Me.QueryAnalyzerToolStripMenuItem.Visible = False
        '
        'BudgetToolStripMenuItem
        '
        Me.BudgetToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UploadBudgetToolStripMenuItem, Me.ReUploadBudgetToolStripMenuItem, Me.RevisedBudgetToolStripMenuItem})
        Me.BudgetToolStripMenuItem.Name = "BudgetToolStripMenuItem"
        Me.BudgetToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.BudgetToolStripMenuItem.Text = "&Budget"
        Me.BudgetToolStripMenuItem.Visible = False
        '
        'UploadBudgetToolStripMenuItem
        '
        Me.UploadBudgetToolStripMenuItem.Name = "UploadBudgetToolStripMenuItem"
        Me.UploadBudgetToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.UploadBudgetToolStripMenuItem.Text = "&Upload Budget"
        '
        'ReUploadBudgetToolStripMenuItem
        '
        Me.ReUploadBudgetToolStripMenuItem.Name = "ReUploadBudgetToolStripMenuItem"
        Me.ReUploadBudgetToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ReUploadBudgetToolStripMenuItem.Text = "&Re-Upload Budget"
        Me.ReUploadBudgetToolStripMenuItem.Visible = False
        '
        'RevisedBudgetToolStripMenuItem
        '
        Me.RevisedBudgetToolStripMenuItem.Name = "RevisedBudgetToolStripMenuItem"
        Me.RevisedBudgetToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RevisedBudgetToolStripMenuItem.Text = "Rev&ised Budget"
        '
        'AccrualsToolStripMenuItem
        '
        Me.AccrualsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DownloadAccrualsToolStripMenuItem, Me.ValidateAccrualsToolStripMenuItem})
        Me.AccrualsToolStripMenuItem.Name = "AccrualsToolStripMenuItem"
        Me.AccrualsToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.AccrualsToolStripMenuItem.Text = "&Accruals"
        Me.AccrualsToolStripMenuItem.Visible = False
        '
        'DownloadAccrualsToolStripMenuItem
        '
        Me.DownloadAccrualsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InititalAccrualsToolStripMenuItem, Me.RevisedAccrualsToolStripMenuItem})
        Me.DownloadAccrualsToolStripMenuItem.Name = "DownloadAccrualsToolStripMenuItem"
        Me.DownloadAccrualsToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.DownloadAccrualsToolStripMenuItem.Text = "&Download Accruals"
        '
        'InititalAccrualsToolStripMenuItem
        '
        Me.InititalAccrualsToolStripMenuItem.Name = "InititalAccrualsToolStripMenuItem"
        Me.InititalAccrualsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.InititalAccrualsToolStripMenuItem.Text = "Initital Accruals"
        '
        'RevisedAccrualsToolStripMenuItem
        '
        Me.RevisedAccrualsToolStripMenuItem.Name = "RevisedAccrualsToolStripMenuItem"
        Me.RevisedAccrualsToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.RevisedAccrualsToolStripMenuItem.Text = "Revised Accruals"
        '
        'ValidateAccrualsToolStripMenuItem
        '
        Me.ValidateAccrualsToolStripMenuItem.Name = "ValidateAccrualsToolStripMenuItem"
        Me.ValidateAccrualsToolStripMenuItem.Size = New System.Drawing.Size(176, 22)
        Me.ValidateAccrualsToolStripMenuItem.Text = "&Validate Accruals"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReportsToolStripMenuItem1, Me.BudgetMovementToolStripMenuItem, Me.BudgetPerMonthToolStripMenuItem, Me.ListOfBusinessPartnersToolStripMenuItem, Me.BudgetClassificationsToolStripMenuItem, Me.BudgetVSToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "&Reports"
        Me.ReportsToolStripMenuItem.Visible = False
        '
        'ReportsToolStripMenuItem1
        '
        Me.ReportsToolStripMenuItem1.Name = "ReportsToolStripMenuItem1"
        Me.ReportsToolStripMenuItem1.Size = New System.Drawing.Size(267, 22)
        Me.ReportsToolStripMenuItem1.Text = "R&eports.."
        Me.ReportsToolStripMenuItem1.Visible = False
        '
        'BudgetMovementToolStripMenuItem
        '
        Me.BudgetMovementToolStripMenuItem.Name = "BudgetMovementToolStripMenuItem"
        Me.BudgetMovementToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.BudgetMovementToolStripMenuItem.Text = "Budget Movement"
        '
        'BudgetPerMonthToolStripMenuItem
        '
        Me.BudgetPerMonthToolStripMenuItem.Name = "BudgetPerMonthToolStripMenuItem"
        Me.BudgetPerMonthToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.BudgetPerMonthToolStripMenuItem.Text = "Budget Per Month"
        '
        'ListOfBusinessPartnersToolStripMenuItem
        '
        Me.ListOfBusinessPartnersToolStripMenuItem.Name = "ListOfBusinessPartnersToolStripMenuItem"
        Me.ListOfBusinessPartnersToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.ListOfBusinessPartnersToolStripMenuItem.Text = "List of Business Partners"
        '
        'BudgetClassificationsToolStripMenuItem
        '
        Me.BudgetClassificationsToolStripMenuItem.Name = "BudgetClassificationsToolStripMenuItem"
        Me.BudgetClassificationsToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.BudgetClassificationsToolStripMenuItem.Text = "Budget Classifications"
        '
        'BudgetVSToolStripMenuItem
        '
        Me.BudgetVSToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BudgetVSActualSummaryToolStripMenuItem, Me.BudgetVSActualDetailToolStripMenuItem, Me.ExceededBudgetSummaryToolStripMenuItem, Me.ExceededBudgetDetailToolStripMenuItem})
        Me.BudgetVSToolStripMenuItem.Name = "BudgetVSToolStripMenuItem"
        Me.BudgetVSToolStripMenuItem.Size = New System.Drawing.Size(267, 22)
        Me.BudgetVSToolStripMenuItem.Text = "Budget VS Actual (Non-Fin/Finalized"
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
        'MMaintainanceToolStripMenuItem
        '
        Me.MMaintainanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserMaintainanceToolStripMenuItem, Me.BudgetClassMaintainanceToolStripMenuItem, Me.QueryAnalayzerToolStripMenuItem, Me.RevertBudgetToolStripMenuItem})
        Me.MMaintainanceToolStripMenuItem.Name = "MMaintainanceToolStripMenuItem"
        Me.MMaintainanceToolStripMenuItem.Size = New System.Drawing.Size(91, 20)
        Me.MMaintainanceToolStripMenuItem.Text = "&Maintainance"
        Me.MMaintainanceToolStripMenuItem.Visible = False
        '
        'UserMaintainanceToolStripMenuItem
        '
        Me.UserMaintainanceToolStripMenuItem.Name = "UserMaintainanceToolStripMenuItem"
        Me.UserMaintainanceToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.UserMaintainanceToolStripMenuItem.Text = "&User Maintainance"
        Me.UserMaintainanceToolStripMenuItem.Visible = False
        '
        'BudgetClassMaintainanceToolStripMenuItem
        '
        Me.BudgetClassMaintainanceToolStripMenuItem.Name = "BudgetClassMaintainanceToolStripMenuItem"
        Me.BudgetClassMaintainanceToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.BudgetClassMaintainanceToolStripMenuItem.Text = "&Budget Class Maintainance"
        Me.BudgetClassMaintainanceToolStripMenuItem.Visible = False
        '
        'QueryAnalayzerToolStripMenuItem
        '
        Me.QueryAnalayzerToolStripMenuItem.Name = "QueryAnalayzerToolStripMenuItem"
        Me.QueryAnalayzerToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.QueryAnalayzerToolStripMenuItem.Text = "&Query Analayzer"
        Me.QueryAnalayzerToolStripMenuItem.Visible = False
        '
        'RevertBudgetToolStripMenuItem
        '
        Me.RevertBudgetToolStripMenuItem.Name = "RevertBudgetToolStripMenuItem"
        Me.RevertBudgetToolStripMenuItem.Size = New System.Drawing.Size(217, 22)
        Me.RevertBudgetToolStripMenuItem.Text = "Rev&ert Budget"
        '
        'UserAccountToolStripMenuItem
        '
        Me.UserAccountToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem})
        Me.UserAccountToolStripMenuItem.Name = "UserAccountToolStripMenuItem"
        Me.UserAccountToolStripMenuItem.Size = New System.Drawing.Size(90, 20)
        Me.UserAccountToolStripMenuItem.Text = "&User Account"
        Me.UserAccountToolStripMenuItem.Visible = False
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "&Change Password"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VersionToolStripMenuItem, Me.UpdatesToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "A&bout"
        '
        'VersionToolStripMenuItem
        '
        Me.VersionToolStripMenuItem.Name = "VersionToolStripMenuItem"
        Me.VersionToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.VersionToolStripMenuItem.Text = "&Version"
        '
        'UpdatesToolStripMenuItem
        '
        Me.UpdatesToolStripMenuItem.Name = "UpdatesToolStripMenuItem"
        Me.UpdatesToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.UpdatesToolStripMenuItem.Text = "&Updates"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.ToolStripSeparator1, Me.ToolStripLabel2, Me.ToolStripLabel3, Me.ToolStripSeparator2, Me.ToolStripLabel4, Me.ToolStripSeparator3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 340)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(870, 25)
        Me.ToolStrip1.TabIndex = 8
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripLabel1.Text = "ToolStripLabel1"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripLabel2.Text = "ToolStripLabel2"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripLabel3.Text = "ToolStripLabel2"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(96, 22)
        Me.ToolStripLabel4.Text = "ToolStripLabel4"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(870, 341)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(870, 365)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmHome"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TIBS - Home"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SpecificToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadFullBudgetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents UserMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetClassMaintenanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents QueryAnalyzerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BudgetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UploadBudgetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReUploadBudgetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AccrualsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownloadAccrualsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MMaintainanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserMaintainanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetClassMaintainanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QueryAnalayzerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserAccountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VersionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdatesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetMovementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetPerMonthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListOfBusinessPartnersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetClassificationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetVSToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetVSActualSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BudgetVSActualDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExceededBudgetSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExceededBudgetDetailToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevisedBudgetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevertBudgetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ValidateAccrualsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InititalAccrualsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RevisedAccrualsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
