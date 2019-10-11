Public Class rptViewBudgetClass

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub rptViewBudgetClass_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtBClass As New DataTable()

        dtBClass = BULibrary.SqlDataTable("SELECT * FROM tblBudgetClass ORDER BY Active DESC")

        Me.grdBClass.DataSource = dtBClass
        Me.grdBClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub
End Class