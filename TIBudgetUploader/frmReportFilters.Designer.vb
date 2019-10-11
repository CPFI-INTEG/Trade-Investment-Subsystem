<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportFilters
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
        Me.lblChannel = New System.Windows.Forms.Label()
        Me.combxChannel = New System.Windows.Forms.ComboBox()
        Me.lblDivision = New System.Windows.Forms.Label()
        Me.combxDivision = New System.Windows.Forms.ComboBox()
        Me.lblDateF = New System.Windows.Forms.Label()
        Me.lblDateT = New System.Windows.Forms.Label()
        Me.datePckrF = New System.Windows.Forms.DateTimePicker()
        Me.datePckrT = New System.Windows.Forms.DateTimePicker()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.chklistTtyp = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'lblChannel
        '
        Me.lblChannel.AutoSize = True
        Me.lblChannel.Location = New System.Drawing.Point(34, 34)
        Me.lblChannel.Name = "lblChannel"
        Me.lblChannel.Size = New System.Drawing.Size(52, 13)
        Me.lblChannel.TabIndex = 0
        Me.lblChannel.Text = "Channel :"
        '
        'combxChannel
        '
        Me.combxChannel.FormattingEnabled = True
        Me.combxChannel.Location = New System.Drawing.Point(92, 31)
        Me.combxChannel.Name = "combxChannel"
        Me.combxChannel.Size = New System.Drawing.Size(114, 21)
        Me.combxChannel.TabIndex = 1
        '
        'lblDivision
        '
        Me.lblDivision.AutoSize = True
        Me.lblDivision.Location = New System.Drawing.Point(34, 72)
        Me.lblDivision.Name = "lblDivision"
        Me.lblDivision.Size = New System.Drawing.Size(50, 13)
        Me.lblDivision.TabIndex = 2
        Me.lblDivision.Text = "Division :"
        '
        'combxDivision
        '
        Me.combxDivision.FormattingEnabled = True
        Me.combxDivision.Location = New System.Drawing.Point(92, 69)
        Me.combxDivision.Name = "combxDivision"
        Me.combxDivision.Size = New System.Drawing.Size(114, 21)
        Me.combxDivision.TabIndex = 3
        '
        'lblDateF
        '
        Me.lblDateF.AutoSize = True
        Me.lblDateF.Location = New System.Drawing.Point(12, 238)
        Me.lblDateF.Name = "lblDateF"
        Me.lblDateF.Size = New System.Drawing.Size(62, 13)
        Me.lblDateF.TabIndex = 5
        Me.lblDateF.Text = "Date From :"
        '
        'lblDateT
        '
        Me.lblDateT.AutoSize = True
        Me.lblDateT.Location = New System.Drawing.Point(11, 263)
        Me.lblDateT.Name = "lblDateT"
        Me.lblDateT.Size = New System.Drawing.Size(52, 13)
        Me.lblDateT.TabIndex = 6
        Me.lblDateT.Text = "Date To :"
        '
        'datePckrF
        '
        Me.datePckrF.Location = New System.Drawing.Point(79, 234)
        Me.datePckrF.Name = "datePckrF"
        Me.datePckrF.Size = New System.Drawing.Size(200, 20)
        Me.datePckrF.TabIndex = 7
        '
        'datePckrT
        '
        Me.datePckrT.Location = New System.Drawing.Point(79, 263)
        Me.datePckrT.Name = "datePckrT"
        Me.datePckrT.Size = New System.Drawing.Size(200, 20)
        Me.datePckrT.TabIndex = 8
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(15, 292)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(71, 23)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'chklistTtyp
        '
        Me.chklistTtyp.FormattingEnabled = True
        Me.chklistTtyp.Location = New System.Drawing.Point(36, 105)
        Me.chklistTtyp.Name = "chklistTtyp"
        Me.chklistTtyp.Size = New System.Drawing.Size(191, 94)
        Me.chklistTtyp.TabIndex = 10
        '
        'frmReportFilters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(285, 320)
        Me.Controls.Add(Me.chklistTtyp)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.datePckrT)
        Me.Controls.Add(Me.datePckrF)
        Me.Controls.Add(Me.lblDateT)
        Me.Controls.Add(Me.lblDateF)
        Me.Controls.Add(Me.combxDivision)
        Me.Controls.Add(Me.lblDivision)
        Me.Controls.Add(Me.combxChannel)
        Me.Controls.Add(Me.lblChannel)
        Me.Name = "frmReportFilters"
        Me.Text = "frmReportFilters"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblChannel As System.Windows.Forms.Label
    Friend WithEvents combxChannel As System.Windows.Forms.ComboBox
    Friend WithEvents lblDivision As System.Windows.Forms.Label
    Friend WithEvents combxDivision As System.Windows.Forms.ComboBox
    Friend WithEvents lblDateF As System.Windows.Forms.Label
    Friend WithEvents lblDateT As System.Windows.Forms.Label
    Friend WithEvents datePckrF As System.Windows.Forms.DateTimePicker
    Friend WithEvents datePckrT As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents chklistTtyp As System.Windows.Forms.CheckedListBox
End Class
