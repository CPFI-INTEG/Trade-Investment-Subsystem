Public Class frmDetailBudget
    Dim strBPCode As String
    Public Sub New(ByVal strBudgetID As String, ByVal strBP As String, ByVal strBPCode As String, ByVal strDivision As String, ByVal strBudget As String)
        InitializeComponent()
        lblBudgetID.Text = strBudgetID
        lblCustomer.Text = strBPCode
        lblCustomerName.Text = strBP
        lblDivision.Text = strDivision
        lblBudget.Text = strBudget
    End Sub
    Private Sub frmDetailBudget_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim BULibrary As TIBudgetUploader.BULibrary = New TIBudgetUploader.BULibrary()
        Dim intTotal As Decimal

        Me.Text = "Detailed Budget"
        Me.grdDetailData.DataSource = BULibrary.GetDetailBudget("spgetDetailBudget", lblBudgetID.Text)
        Me.grdDetailData.Columns("Amount").DefaultCellStyle.Format = "#,###"
        Me.grdDetailData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        For i As Integer = 0 To grdDetailData.Rows.Count - 1

            intTotal = intTotal + Decimal.Parse(grdDetailData.Rows.Item(i).Cells("Amount").Value().ToString())

        Next        
        txtTotal.Text = Math.Round(intTotal).ToString("N0")
        'txtTotal.Text = Format("#,###")
    End Sub


End Class