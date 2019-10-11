Public Class frmReports
    Dim strUserIDH, strUserBUH, strUserPermissionH As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        'IsInitialH = IsInitial
        strUserIDH = strUserID
        strUserBUH = strUserBU
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub BudgetMovementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetMovementToolStripMenuItem.Click
        Dim frmRptBudgetMovement As New rptBdgtMvmnt(strUserIDH, strUserBUH)
        frmRptBudgetMovement.ShowDialog()
    End Sub

    Private Sub frmReports_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'PictureBox1.Image = My.Resources.resTIBUploader.Reports
        PictureBox1.Image = My.Resources.resTIBUploader.ReportsV2
    End Sub

    Private Sub ListOfBusinessPartnersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListOfBusinessPartnersToolStripMenuItem.Click
        Dim rptViewAllBP As New rptViewAllBP()
        rptViewAllBP.ShowDialog()
    End Sub

    Private Sub BudgetClassificationsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetClassificationsToolStripMenuItem.Click
        Dim rptViewBudgetClass As New rptViewBudgetClass()
        rptViewBudgetClass.ShowDialog()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Dim rptBudgetPerMonth As New rptBudgetPerMonth(strUserIDH, strUserBUH)
        rptBudgetPerMonth.ShowDialog()
    End Sub

    Private Sub SummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetVSActualSummaryToolStripMenuItem.Click

        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDH, "Summary", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub

    Private Sub DetailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetVSActualDetailToolStripMenuItem.Click
        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDH, "Detail", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub

    Private Sub ExceededBudgetSummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExceededBudgetSummaryToolStripMenuItem.Click
        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDH, "Exceeded Budget/No Budget (Summary)", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub

    Private Sub ExceededBudgetDetailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExceededBudgetDetailToolStripMenuItem.Click
        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDH, "Exceeded Budget/No Budget (Detail)", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub
End Class