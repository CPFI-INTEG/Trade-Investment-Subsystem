Public Class frmTasks

    Private Sub frmTasks_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtTables As New DataTable()

        dtTables = BULibrary.SqlDataTable("USE TradeInvDB" &
                                            " SELECT 'Upload ' + name AS Display_Name, name as name  FROM sys.tables" &
                                            " where name <> 'sysdiagrams' " &
                                            " and name in ('tblBudgetClass', 'tblBClassMapping', 'tblDim3', 'tblDim4', 'tblDim5') " &
                                            "ORDER BY name")

        combxTask.DataSource = dtTables
        combxTask.DisplayMember = "Display_Name"
        combxTask.ValueMember = "name"

    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim fDialog As New OpenFileDialog()

        With fDialog
            .Title = "Select file to be uploaded"
            .Filter = "Excel files (*.xls or *.xlsx)|*.xls;*.xlsx"
            If .ShowDialog() = DialogResult.OK Then
                'If .FileName.ToString() = .InitialDirectory Then
                txtFileLocation.Text = .FileName.ToString()                
                'Else
                '    MsgBox("Invalid directory!", MsgBoxStyle.Exclamation)
                '    Return 
                'End If

            Else
                Return
            End If
        End With

        BULibrary.openOleCon(txtFileLocation.Text)        

        Dim dtExcelData As New DataTable()
        Try
            If (combxTask.SelectedValue.ToString() = "tblBudgetClass") Then
                dtExcelData = BULibrary.OleDataTable("SELECT * " &
                             "FROM [tblBudgetClass$] ")
            ElseIf (combxTask.SelectedValue.ToString() = "tblBClassMapping") Then
                dtExcelData = BULibrary.OleDataTable("SELECT * " &
                             "FROM [tblBClassMapping$] ")
            ElseIf (combxTask.SelectedValue.ToString() = "tblDim3") Then
                dtExcelData = BULibrary.OleDataTable("SELECT * " &
                             "FROM [tblDim3$] ")
            ElseIf (combxTask.SelectedValue.ToString() = "tblDim4") Then
                dtExcelData = BULibrary.OleDataTable("SELECT * " &
                             "FROM [tblDim4$] ")
            ElseIf (combxTask.SelectedValue.ToString() = "tblDim5") Then
                dtExcelData = BULibrary.OleDataTable("SELECT * " &
                             "FROM [tblDim5$] ")
            End If

            Me.grdExcelData.DataSource = dtExcelData
            Me.grdExcelData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Catch ex As Exception
            MsgBox("Error in uploading. Please upload the correct file.", MsgBoxStyle.Exclamation)
        End Try

        BULibrary.closeOleCon()


        For x As Integer = 0 To dtExcelData.Rows.Count - 1
            If (combxTask.SelectedValue.ToString() = "tblBudgetClass") Then

                Dim bcode, budget, bclass, ttyp, uploadtyp, grpclass As String                
                Dim grp2cd As Integer

                Try
                    bcode = dtExcelData.Rows(x)("BudgetCode").ToString().Trim()
                    budget = dtExcelData.Rows(x)("Budget").ToString().Trim()
                    bclass = dtExcelData.Rows(x)("BudgetClass").ToString().Trim()
                    ttyp = dtExcelData.Rows(x)("TransType").ToString().Trim()                    
                    uploadtyp = dtExcelData.Rows(x)("UploadType").ToString().Trim()
                    grpclass = dtExcelData.Rows(x)("GrpClass").ToString().Trim()
                    grp2cd = Integer.Parse(dtExcelData.Rows(x)("GrpCode"))

                Catch ex As Exception

                    MsgBox(ex.ToString())

                End Try

            ElseIf (combxTask.SelectedValue.ToString() = "tblBClassMapping") Then
                Dim bcode, expacct, acracct, dim1, dim2 As String

                Try
                    bcode = dtExcelData.Rows(x)("BudgetCode").ToString().Trim()
                    expacct = dtExcelData.Rows(x)("ExpenseAcct").ToString().Trim()
                    acracct = dtExcelData.Rows(x)("AccrualAcct").ToString().Trim()
                    dim1 = dtExcelData.Rows(x)("Dim1").ToString().Trim()
                    dim2 = dtExcelData.Rows(x)("Dim2").ToString().Trim()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try

            ElseIf (combxTask.SelectedValue.ToString() = "tblDim3") Then
                Dim code, name, division As String

                Try
                    code = dtExcelData.Rows(x)("Code").ToString().Trim()
                    name = dtExcelData.Rows(x)("Name").ToString().Trim()
                    division = dtExcelData.Rows(x)("Division").ToString().Trim()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try

            ElseIf (combxTask.SelectedValue.ToString() = "tblDim4") Then
                Dim code, name, year As String

                Try
                    code = dtExcelData.Rows(x)("Code").ToString().Trim()
                    name = dtExcelData.Rows(x)("Name").ToString().Trim()
                    year = Integer.Parse(dtExcelData.Rows(x)("Year").ToString().Trim())
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try

            ElseIf (combxTask.SelectedValue.ToString() = "tblDim5") Then
                Dim code, name, bu As String

                Try
                    code = dtExcelData.Rows(x)("Code").ToString().Trim()
                    name = dtExcelData.Rows(x)("Name").ToString().Trim()
                    bu = dtExcelData.Rows(x)("BU").ToString().Trim()
                Catch ex As Exception
                    MsgBox(ex.ToString())
                End Try

            End If
        Next

    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        If MsgBox("Are you sure you want to update table " & combxTask.SelectedValue.ToString() & "?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
            Dim BULibrary As New TIBudgetUploader.BULibrary()

            If (combxTask.SelectedValue.ToString() = "tblBudgetClass") Then
                BULibrary.OpenSqlCon()

                BULibrary.SqlUpdate("Delete from tblBudgetClass")


                For x As Integer = 0 To grdExcelData.Rows.Count - 1
                    ''Me.grdExcelData.Rows(i).Cells("Year").Value.ToString()
                    BULibrary.InsertBClass("spInsertBClass", Me.grdExcelData.Rows(x).Cells("BudgetCode").Value.ToString(),
                                           Me.grdExcelData.Rows(x).Cells("Budget").Value.ToString(),
                                           Me.grdExcelData.Rows(x).Cells("BudgetClass").Value.ToString(),
                                           Me.grdExcelData.Rows(x).Cells("TransType").Value.ToString(),
                                           Me.grdExcelData.Rows(x).Cells("UploadType").Value.ToString(),
                                           Me.grdExcelData.Rows(x).Cells("GrpClass").Value.ToString(),
                                           Integer.Parse(Me.grdExcelData.Rows(x).Cells("GrpCode").Value.ToString()))
                Next

                BULibrary.CloseSqlCon()
                MsgBox("Table " & combxTask.SelectedValue.ToString() & " successfully updated", MsgBoxStyle.Information)
            ElseIf (combxTask.SelectedValue.ToString() = "tblBClassMapping") Then

                BULibrary.OpenSqlCon()

                BULibrary.SqlUpdate("Delete from tblBClassMapping")

                For x As Integer = 0 To grdExcelData.Rows.Count - 1
                    BULibrary.InsertBClassMapping("spInsertBClassMapping", Me.grdExcelData.Rows(x).Cells("BudgetCode").Value.ToString(),
                                                  Me.grdExcelData.Rows(x).Cells("ExpenseAcct").Value.ToString(),
                                                  Me.grdExcelData.Rows(x).Cells("AccrualAcct").Value.ToString(),
                                                  Me.grdExcelData.Rows(x).Cells("Dim1").Value.ToString(),
                                                  Me.grdExcelData.Rows(x).Cells("Dim2").Value.ToString())
                Next

                BULibrary.CloseSqlCon()
                MsgBox("Table " & combxTask.SelectedValue.ToString() & " successfully updated", MsgBoxStyle.Information)

            ElseIf (combxTask.SelectedValue.ToString() = "tblDim3") Then
                BULibrary.OpenSqlCon()

                BULibrary.SqlUpdate("Delete from tblDim3")

                For x As Integer = 0 To grdExcelData.Rows.Count - 1
                    BULibrary.InsertDim3("spInsertDim3", Me.grdExcelData.Rows(x).Cells("Code").Value.ToString(),
                                         Me.grdExcelData.Rows(x).Cells("Name").Value.ToString(),
                                         Me.grdExcelData.Rows(x).Cells("Division").Value.ToString())
                Next

                BULibrary.CloseSqlCon()
                MsgBox("Table " & combxTask.SelectedValue.ToString() & " successfully updated", MsgBoxStyle.Information)

            ElseIf (combxTask.SelectedValue.ToString() = "tblDim4") Then
                BULibrary.OpenSqlCon()

                BULibrary.SqlUpdate("Delete from tblDim4")

                For x As Integer = 0 To grdExcelData.Rows.Count - 1
                    BULibrary.InsertDim4("spInsertDim4", Me.grdExcelData.Rows(x).Cells("Code").Value.ToString(),
                                        Me.grdExcelData.Rows(x).Cells("Name").Value.ToString(),
                                        Me.grdExcelData.Rows(x).Cells("Year").Value.ToString())
                Next

                BULibrary.CloseSqlCon()
                MsgBox("Table " & combxTask.SelectedValue.ToString() & " successfully updated", MsgBoxStyle.Information)

            ElseIf (combxTask.SelectedValue.ToString() = "tblDim5") Then
                BULibrary.OpenSqlCon()

                BULibrary.SqlUpdate("Delete from tblDim5")

                For x As Integer = 0 To grdExcelData.Rows.Count - 1
                    BULibrary.InsertDim5("spInsertDim5", Me.grdExcelData.Rows(x).Cells("Code").Value.ToString(),
                                         Me.grdExcelData.Rows(x).Cells("Name").Value.ToString(),
                                         Me.grdExcelData.Rows(x).Cells("BU").Value.ToString())
                Next

                BULibrary.CloseSqlCon()
                MsgBox("Table " & combxTask.SelectedValue.ToString() & " successfully updated", MsgBoxStyle.Information)
            End If

        End If

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class