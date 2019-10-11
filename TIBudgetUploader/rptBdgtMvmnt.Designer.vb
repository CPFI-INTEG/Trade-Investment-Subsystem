<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptBdgtMvmnt
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptBdgtMvmnt))
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FIleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.combxBU = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTtyp = New System.Windows.Forms.CheckedListBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.datePckrT = New System.Windows.Forms.DateTimePicker()
        Me.datePckrF = New System.Windows.Forms.DateTimePicker()
        Me.lblDateT = New System.Windows.Forms.Label()
        Me.lblDateF = New System.Windows.Forms.Label()
        Me.combxDivision = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.combxChannel = New System.Windows.Forms.ComboBox()
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.spgetReportMvmntBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TradeInvDBDataSet = New Global.TIBudgetUploader.TradeInvDBDataSet()
        Me.spgetFilterReportMvmntBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.spgetFilterBdgtReportMvmntBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.spgetReportMvmntTableAdapter = New Global.TIBudgetUploader.TradeInvDBDataSetTableAdapters.spgetReportMvmntTableAdapter()
        Me.MenuStrip1.SuspendLayout()
        Me.grpFilters.SuspendLayout()
        CType(Me.spgetReportMvmntBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TradeInvDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spgetFilterReportMvmntBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spgetFilterBdgtReportMvmntBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.DocumentMapWidth = 98
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 181)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1150, 512)
        Me.ReportViewer1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FIleToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1038, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FIleToolStripMenuItem
        '
        Me.FIleToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoutToolStripMenuItem})
        Me.FIleToolStripMenuItem.Name = "FIleToolStripMenuItem"
        Me.FIleToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FIleToolStripMenuItem.Text = "&File"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.LogoutToolStripMenuItem.Text = "&Exit"
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.combxBU)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.chkTtyp)
        Me.grpFilters.Controls.Add(Me.btnOK)
        Me.grpFilters.Controls.Add(Me.datePckrT)
        Me.grpFilters.Controls.Add(Me.datePckrF)
        Me.grpFilters.Controls.Add(Me.lblDateT)
        Me.grpFilters.Controls.Add(Me.lblDateF)
        Me.grpFilters.Controls.Add(Me.combxDivision)
        Me.grpFilters.Controls.Add(Me.lblDivision)
        Me.grpFilters.Controls.Add(Me.combxChannel)
        Me.grpFilters.Controls.Add(Me.lblChannel)
        Me.grpFilters.Location = New System.Drawing.Point(126, 33)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(873, 142)
        Me.grpFilters.TabIndex = 2
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Report Filters"
        '
        'combxBU
        '
        Me.combxBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxBU.FormattingEnabled = True
        Me.combxBU.Location = New System.Drawing.Point(563, 49)
        Me.combxBU.Name = "combxBU"
        Me.combxBU.Size = New System.Drawing.Size(192, 21)
        Me.combxBU.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(529, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "BU :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(196, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Transactions :"
        '
        'chkTtyp
        '
        Me.chkTtyp.FormattingEnabled = True
        Me.chkTtyp.Location = New System.Drawing.Point(273, 41)
        Me.chkTtyp.Name = "chkTtyp"
        Me.chkTtyp.Size = New System.Drawing.Size(243, 94)
        Me.chkTtyp.TabIndex = 18
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(12, 113)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(71, 23)
        Me.btnOK.TabIndex = 16
        Me.btnOK.Text = "&Run Report"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'datePckrT
        '
        Me.datePckrT.Location = New System.Drawing.Point(555, 11)
        Me.datePckrT.Name = "datePckrT"
        Me.datePckrT.Size = New System.Drawing.Size(200, 20)
        Me.datePckrT.TabIndex = 15
        '
        'datePckrF
        '
        Me.datePckrF.Location = New System.Drawing.Point(263, 9)
        Me.datePckrF.Name = "datePckrF"
        Me.datePckrF.Size = New System.Drawing.Size(200, 20)
        Me.datePckrF.TabIndex = 14
        '
        'lblDateT
        '
        Me.lblDateT.AutoSize = True
        Me.lblDateT.Location = New System.Drawing.Point(487, 11)
        Me.lblDateT.Name = "lblDateT"
        Me.lblDateT.Size = New System.Drawing.Size(52, 13)
        Me.lblDateT.TabIndex = 13
        Me.lblDateT.Text = "Date To :"
        '
        'lblDateF
        '
        Me.lblDateF.AutoSize = True
        Me.lblDateF.Location = New System.Drawing.Point(196, 13)
        Me.lblDateF.Name = "lblDateF"
        Me.lblDateF.Size = New System.Drawing.Size(62, 13)
        Me.lblDateF.TabIndex = 12
        Me.lblDateF.Text = "Date From :"
        '
        'combxDivision
        '
        Me.combxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxDivision.FormattingEnabled = True
        Me.combxDivision.Location = New System.Drawing.Point(67, 46)
        Me.combxDivision.Name = "combxDivision"
        Me.combxDivision.Size = New System.Drawing.Size(114, 21)
        Me.combxDivision.TabIndex = 5
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(9, 49)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(50, 13)
        Me.lblDivision.TabIndex = 4
        Me.lblDivision.Text = "Division :"
        '
        'combxChannel
        '
        Me.combxChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxChannel.FormattingEnabled = True
        Me.combxChannel.Location = New System.Drawing.Point(67, 19)
        Me.combxChannel.Name = "combxChannel"
        Me.combxChannel.Size = New System.Drawing.Size(114, 21)
        Me.combxChannel.TabIndex = 3
        '
        'lblChannel
        '
        Me.lblChannel.AutoSize = True
        Me.lblChannel.Location = New System.Drawing.Point(9, 22)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(52, 13)
        Me.lblChannel.TabIndex = 2
        Me.lblChannel.Text = "Channel :"
        '
        'spgetReportMvmntBindingSource
        '
        Me.spgetReportMvmntBindingSource.DataMember = "spgetReportMvmnt"
        Me.spgetReportMvmntBindingSource.DataSource = Me.TradeInvDBDataSet
        '
        'TradeInvDBDataSet
        '
        Me.TradeInvDBDataSet.DataSetName = "TradeInvDBDataSet"
        Me.TradeInvDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'spgetFilterReportMvmntBindingSource
        '
        Me.spgetFilterReportMvmntBindingSource.DataMember = "spgetFilterReportMvmnt"
        Me.spgetFilterReportMvmntBindingSource.DataSource = Me.TradeInvDBDataSet
        '
        'spgetFilterBdgtReportMvmntBindingSource
        '
        Me.spgetFilterBdgtReportMvmntBindingSource.DataMember = "spgetFilterBdgtReportMvmnt"
        Me.spgetFilterBdgtReportMvmntBindingSource.DataSource = Me.TradeInvDBDataSet
        '
        'spgetReportMvmntTableAdapter
        '
        Me.spgetReportMvmntTableAdapter.ClearBeforeFill = True
        '
        'rptBdgtMvmnt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1038, 698)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimizeBox = False
        Me.Name = "rptBdgtMvmnt"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Budget Movement"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        CType(Me.spgetReportMvmntBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TradeInvDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spgetFilterReportMvmntBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spgetFilterBdgtReportMvmntBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spgetReportMvmntBindingSource As Global.System.Windows.Forms.BindingSource
    Friend WithEvents spgetFilterReportMvmntBindingSource As Global.System.Windows.Forms.BindingSource
    Friend WithEvents spgetFilterBdgtReportMvmntBindingSource As Global.System.Windows.Forms.BindingSource
    Friend WithEvents TradeInvDBDataSet As Global.TIBudgetUploader.TradeInvDBDataSet
    Friend WithEvents spgetReportMvmntTableAdapter As Global.TIBudgetUploader.TradeInvDBDataSetTableAdapters.spgetReportMvmntTableAdapter
    Friend WithEvents spgetFilterReportMvmntTableAdapter As New Global.TIBudgetUploader.TradeInvDBDataSetTableAdapters.spgetFilterReportMvmntTableAdapter
    Friend WithEvents spgetFilterBdgtReportMvmntTableAdapter As New Global.TIBudgetUploader.TradeInvDBDataSetTableAdapters.spgetFilterBdgtReportMvmntTableAdapter
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FIleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents combxChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblChannel As System.Windows.Forms.Label
    Friend WithEvents combxDivision As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents datePckrT As System.Windows.Forms.DateTimePicker
    Friend WithEvents datePckrF As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDateT As System.Windows.Forms.Label
    Friend WithEvents lblDateF As System.Windows.Forms.Label
    Friend WithEvents chkTtyp As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents combxBU As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
