<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rptBudgetPerMonth
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(rptBudgetPerMonth))
        Me.spgetRptBudgetPerMonthBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TradeInvDBDataSet = New Global.TIBudgetUploader.TradeInvDBDataSet()
        Me.grpFilters = New System.Windows.Forms.GroupBox()
        Me.combxBU = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkTtyp = New System.Windows.Forms.CheckedListBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.combxDivision = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.spgetRptBudgetPerMonthTableAdapter = New Global.TIBudgetUploader.TradeInvDBDataSetTableAdapters.spgetRptBudgetPerMonthTableAdapter()
        CType(Me.spgetRptBudgetPerMonthBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TradeInvDBDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpFilters.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'spgetRptBudgetPerMonthBindingSource
        '
        Me.spgetRptBudgetPerMonthBindingSource.DataMember = "spgetRptBudgetPerMonth"
        Me.spgetRptBudgetPerMonthBindingSource.DataSource = Me.TradeInvDBDataSet
        '
        'TradeInvDBDataSet
        '
        Me.TradeInvDBDataSet.DataSetName = "TradeInvDBDataSet"
        Me.TradeInvDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'grpFilters
        '
        Me.grpFilters.Controls.Add(Me.combxBU)
        Me.grpFilters.Controls.Add(Me.Label2)
        Me.grpFilters.Controls.Add(Me.Label1)
        Me.grpFilters.Controls.Add(Me.chkTtyp)
        Me.grpFilters.Controls.Add(Me.btnOK)
        Me.grpFilters.Controls.Add(Me.combxDivision)
        Me.grpFilters.Controls.Add(Me.lblDivision)
        Me.grpFilters.Location = New System.Drawing.Point(74, 27)
        Me.grpFilters.Name = "grpFilters"
        Me.grpFilters.Size = New System.Drawing.Size(637, 153)
        Me.grpFilters.TabIndex = 3
        Me.grpFilters.TabStop = False
        Me.grpFilters.Text = "Report Filters"
        '
        'combxBU
        '
        Me.combxBU.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxBU.FormattingEnabled = True
        Me.combxBU.Location = New System.Drawing.Point(84, 21)
        Me.combxBU.Name = "combxBU"
        Me.combxBU.Size = New System.Drawing.Size(192, 21)
        Me.combxBU.TabIndex = 21
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Business Unit :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(282, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Transactions :"
        '
        'chkTtyp
        '
        Me.chkTtyp.FormattingEnabled = True
        Me.chkTtyp.Location = New System.Drawing.Point(359, 19)
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
        'combxDivision
        '
        Me.combxDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxDivision.FormattingEnabled = True
        Me.combxDivision.Location = New System.Drawing.Point(84, 63)
        Me.combxDivision.Name = "combxDivision"
        Me.combxDivision.Size = New System.Drawing.Size(114, 21)
        Me.combxDivision.TabIndex = 5
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(26, 66)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(50, 13)
        Me.lblDivision.TabIndex = 4
        Me.lblDivision.Text = "Division :"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1150, 24)
        Me.MenuStrip1.TabIndex = 4
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
        'ReportViewer1
        '
        Me.ReportViewer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReportViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ReportViewer1.DocumentMapWidth = 98
        ReportDataSource1.Name = "dsBudgetPerMonth"
        ReportDataSource1.Value = Me.spgetRptBudgetPerMonthBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "TIBudgetUploader.rptBudgetPerMonth.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 186)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(1150, 512)
        Me.ReportViewer1.TabIndex = 5
        '
        'spgetRptBudgetPerMonthTableAdapter
        '
        Me.spgetRptBudgetPerMonthTableAdapter.ClearBeforeFill = True
        '
        'rptBudgetPerMonth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1150, 696)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.grpFilters)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "rptBudgetPerMonth"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Budget Per Month"
        CType(Me.spgetRptBudgetPerMonthBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TradeInvDBDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpFilters.ResumeLayout(False)
        Me.grpFilters.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpFilters As System.Windows.Forms.GroupBox
    Friend WithEvents combxBU As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkTtyp As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents combxDivision As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents spgetRptBudgetPerMonthBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TradeInvDBDataSet As Global.TIBudgetUploader.TradeInvDBDataSet
    Friend WithEvents spgetRptBudgetPerMonthTableAdapter As Global.TIBudgetUploader.TradeInvDBDataSetTableAdapters.spgetRptBudgetPerMonthTableAdapter
End Class
