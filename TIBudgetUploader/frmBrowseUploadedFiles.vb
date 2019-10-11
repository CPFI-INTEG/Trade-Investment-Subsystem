Public Class frmBrowseUploadedFiles
    Public Shared thisForm As frmBrowseUploadedFiles
    Private Sub frmBrowseUploadedFiles_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim di As New IO.DirectoryInfo("\\10.10.1.84\Docs\Uploaded Files")
        Dim diar1 As IO.FileInfo() = di.GetFiles()
        Dim dra As IO.FileInfo

        'list the names of all files in the specified directory
        For Each dra In diar1
            listFiles.Items.Add(dra)
        Next

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnPreview_Click(sender As System.Object, e As System.EventArgs) Handles btnPreview.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        BULibrary.openOleCon("\\10.10.1.84\Docs\Uploaded Files\" & listFiles.SelectedItem.ToString())


        Dim dtExcelData As New DataTable()
        Try
            'dtExcelData = BULibrary.OleDataTable("SELECT '' as [RowNo], * FROM [FullYrBudget$]") 'use 1 SheetName for excel upload                
            'dtExcelData = BULibrary.OleDataTable("SELECT '' as [RowNo], [Year], [BU], [Budget], " &
            '                                     "[BPCode], [Frozen], ROUND([Amount],2) as Amount " &
            '                                     "FROM [FullYrBudget$]") 'use 1 SheetName for excel upload

            dtExcelData = BULibrary.OleDataTable("SELECT [Year],[BU],[Budget],[BPCode] AS CustomerCode,[Customer Name],[Frozen],ROUND(SUM([Amount])) AS Amount " &
                                                     "FROM [FullYrBudget$] " &
                                               "GROUP BY [Year],[BU],[Budget],[BPCode],[Customer Name],[Frozen] ") 'use 1 SheetName for excel upload 

            Me.grdData.DataSource = dtExcelData

            Me.grdData.Columns("Amount").DefaultCellStyle.Format = "#,###"
            Me.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.grdData.Enabled = True
        Catch ex As Exception
            MsgBox("Can't browse file", MsgBoxStyle.Exclamation)

        End Try

        BULibrary.closeOleCon()
    End Sub

    Private Sub grdData_ColumnHeaderMouseDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdData.ColumnHeaderMouseDoubleClick
        Dim frmSearch As New frmSearch(grdData.SortedColumn.Index, grdData.Columns(grdData.SortedColumn.Index).HeaderText.ToString, 2)
        frmSearch.Show()
    End Sub

    Private Sub listFiles_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles listFiles.MouseDoubleClick
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        BULibrary.openOleCon("\\10.10.1.84\Docs\Uploaded Files\" & listFiles.SelectedItem.ToString())


        Dim dtExcelData As New DataTable()
        Try
            'dtExcelData = BULibrary.OleDataTable("SELECT '' as [RowNo], * FROM [FullYrBudget$]") 'use 1 SheetName for excel upload                
            'dtExcelData = BULibrary.OleDataTable("SELECT '' as [RowNo], [Year], [BU], [Budget], " &
            '                                     "[BPCode], [Frozen], ROUND([Amount],2) as Amount " &
            '                                     "FROM [FullYrBudget$]") 'use 1 SheetName for excel upload

            dtExcelData = BULibrary.OleDataTable("SELECT [Year],[BU],[Budget],[BPCode] AS CustomerCode,[Customer Name],[Frozen],ROUND(SUM([Amount])) AS Amount " &
                                                     "FROM [FullYrBudget$] " &
                                               "GROUP BY [Year],[BU],[Budget],[BPCode],[Customer Name],[Frozen] ") 'use 1 SheetName for excel upload 

            Me.grdData.DataSource = dtExcelData

            Me.grdData.Columns("Amount").DefaultCellStyle.Format = "#,###"
            Me.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.grdData.Enabled = True
        Catch ex As Exception
            MsgBox("Can't browse file", MsgBoxStyle.Exclamation)

        End Try

        BULibrary.closeOleCon()
    End Sub
End Class