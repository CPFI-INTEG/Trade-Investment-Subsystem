<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownloads
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDownloads))
        Me.combxSeries = New System.Windows.Forms.ComboBox()
        Me.grpBoxR = New System.Windows.Forms.GroupBox()
        Me.combxInstance = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.combxTransType = New System.Windows.Forms.ComboBox()
        Me.chkboxInstructions = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.combxYear = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.grdPrev2 = New System.Windows.Forms.DataGridView()
        Me.lblDownloadR = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpBoxR.SuspendLayout()
        CType(Me.grdPrev2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'combxSeries
        '
        Me.combxSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxSeries.FormattingEnabled = True
        Me.combxSeries.Location = New System.Drawing.Point(112, 52)
        Me.combxSeries.Name = "combxSeries"
        Me.combxSeries.Size = New System.Drawing.Size(65, 21)
        Me.combxSeries.TabIndex = 8
        '
        'grpBoxR
        '
        Me.grpBoxR.Controls.Add(Me.combxInstance)
        Me.grpBoxR.Controls.Add(Me.Label3)
        Me.grpBoxR.Controls.Add(Me.Label1)
        Me.grpBoxR.Controls.Add(Me.combxTransType)
        Me.grpBoxR.Controls.Add(Me.chkboxInstructions)
        Me.grpBoxR.Controls.Add(Me.Label2)
        Me.grpBoxR.Controls.Add(Me.combxYear)
        Me.grpBoxR.Controls.Add(Me.Button1)
        Me.grpBoxR.Controls.Add(Me.grdPrev2)
        Me.grpBoxR.Controls.Add(Me.lblDownloadR)
        Me.grpBoxR.Controls.Add(Me.Label5)
        Me.grpBoxR.Controls.Add(Me.combxSeries)
        Me.grpBoxR.Location = New System.Drawing.Point(12, 49)
        Me.grpBoxR.Name = "grpBoxR"
        Me.grpBoxR.Size = New System.Drawing.Size(1000, 645)
        Me.grpBoxR.TabIndex = 1
        Me.grpBoxR.TabStop = False
        Me.grpBoxR.Text = "Download Accruals"
        '
        'combxInstance
        '
        Me.combxInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxInstance.FormattingEnabled = True
        Me.combxInstance.Items.AddRange(New Object() {"CPG", "BU1", "BU2"})
        Me.combxInstance.Location = New System.Drawing.Point(281, 19)
        Me.combxInstance.Name = "combxInstance"
        Me.combxInstance.Size = New System.Drawing.Size(85, 21)
        Me.combxInstance.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(196, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Instance :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(196, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "JV Trans Type:"
        '
        'combxTransType
        '
        Me.combxTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxTransType.FormattingEnabled = True
        Me.combxTransType.Location = New System.Drawing.Point(281, 52)
        Me.combxTransType.Name = "combxTransType"
        Me.combxTransType.Size = New System.Drawing.Size(59, 21)
        Me.combxTransType.TabIndex = 25
        '
        'chkboxInstructions
        '
        Me.chkboxInstructions.AutoSize = True
        Me.chkboxInstructions.Checked = True
        Me.chkboxInstructions.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkboxInstructions.Enabled = False
        Me.chkboxInstructions.Location = New System.Drawing.Point(128, 620)
        Me.chkboxInstructions.Name = "chkboxInstructions"
        Me.chkboxInstructions.Size = New System.Drawing.Size(118, 17)
        Me.chkboxInstructions.TabIndex = 22
        Me.chkboxInstructions.Text = "Include Instructions"
        Me.chkboxInstructions.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(61, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Year : "
        '
        'combxYear
        '
        Me.combxYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combxYear.FormattingEnabled = True
        Me.combxYear.Location = New System.Drawing.Point(112, 25)
        Me.combxYear.Name = "combxYear"
        Me.combxYear.Size = New System.Drawing.Size(65, 21)
        Me.combxYear.TabIndex = 20
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 82)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "&Preview"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grdPrev2
        '
        Me.grdPrev2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdPrev2.Location = New System.Drawing.Point(18, 111)
        Me.grdPrev2.Name = "grdPrev2"
        Me.grdPrev2.ReadOnly = True
        Me.grdPrev2.Size = New System.Drawing.Size(964, 499)
        Me.grdPrev2.TabIndex = 17
        '
        'lblDownloadR
        '
        Me.lblDownloadR.Enabled = False
        Me.lblDownloadR.Location = New System.Drawing.Point(18, 616)
        Me.lblDownloadR.Name = "lblDownloadR"
        Me.lblDownloadR.Size = New System.Drawing.Size(104, 23)
        Me.lblDownloadR.TabIndex = 16
        Me.lblDownloadR.Text = "&Download Flat File"
        Me.lblDownloadR.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(61, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Series : "
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1024, 24)
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
        'frmDownloads
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 714)
        Me.Controls.Add(Me.grpBoxR)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDownloads"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Download Accruals"
        Me.grpBoxR.ResumeLayout(False)
        Me.grpBoxR.PerformLayout()
        CType(Me.grdPrev2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents combxSeries As System.Windows.Forms.ComboBox
    Friend WithEvents grpBoxR As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblDownloadR As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grdPrev2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents combxYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents chkboxInstructions As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents combxTransType As System.Windows.Forms.ComboBox
    Friend WithEvents combxInstance As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
