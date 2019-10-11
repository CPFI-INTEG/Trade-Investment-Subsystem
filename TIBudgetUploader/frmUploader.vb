Option Explicit On
Imports System.IO
Public Class frmUploader
    Dim IsOrigBudgetH As Boolean
    Dim UserIDH, UserBUH, UserPermissionH As String
    Public Shared thisForm As frmUploader
    Public Sub New(ByVal IsOrigBudget As Boolean, ByVal UserID As String, ByVal strBU As String)
        InitializeComponent()
        IsOrigBudgetH = IsOrigBudget
        UserIDH = UserID
        UserBUH = strBU
    End Sub

    Private Sub btnUpload_Click(sender As System.Object, e As System.EventArgs) Handles btnUpload.Click

        If combxMonth.Text = "" Then
            MsgBox("Please choose a month!", MsgBoxStyle.Exclamation)
            Return
        End If
        If listError.Items.Count > 0 Then
            MsgBox("Can't upload file. Please check error logs.", MsgBoxStyle.Exclamation)
            Return
        End If

        ProgressBar1.Maximum = 35
        ProgressBar1.Step = 1
        Dim BULibrary As TIBudgetUploader.BULibrary = New TIBudgetUploader.BULibrary()
        Dim dtGetCurUploadedBudget, dtMaxBatch As New DataTable()
        Dim batch As String
        DeleteTemp()
        BULibrary.GiveCredentials()

        BULibrary.OpenSqlCon()

        BULibrary.InsertBatch("spInsertBatch", Integer.Parse(combxYear.SelectedValue.ToString()))

        dtMaxBatch = BULibrary.GetMaxBatch("spgetMaxBatch", Integer.Parse(combxYear.SelectedValue.ToString()))

        If combxMonth.SelectedIndex.ToString().Length = 1 Then
            batch = combxYear.SelectedValue.ToString() & (combxMonth.SelectedIndex + 1).ToString().PadLeft(2, "0") & dtMaxBatch.Rows(0)("MaxBatchNo").ToString()
            BULibrary.CloseSqlCon()
        Else
            batch = combxYear.SelectedValue.ToString() & (combxMonth.SelectedIndex + 1).ToString() & dtMaxBatch.Rows(0)("MaxBatchNo").ToString()
            BULibrary.CloseSqlCon()
        End If




        For i As Integer = 0 To grdExcelData.Rows.Count - 1

            Dim dtBudget, dtChkUpload, dtEWT As New DataTable()

            Dim budget, bpcode, _
                    seqno, bcode, budgetID As String
            Dim yr, bu, uploadtype, frozen, amt, ewt As String

            Dim IntMonth As Integer

            Dim decEWT_Amt As Decimal


            budget = Me.grdExcelData.Rows(i).Cells("Budget").Value.ToString()
            bpcode = Me.grdExcelData.Rows(i).Cells("BPCode").Value.ToString()
            'start 09232013
            If bpcode.Length = 3 Then
                'If bpcode.Length < 9 Then
                bpcode = bpcode.PadLeft(9, "0")
            Else
                'do nothing
            End If
            'end 09232013

            yr = Me.grdExcelData.Rows(i).Cells("Year").Value.ToString()
            bu = Me.grdExcelData.Rows(i).Cells("BU").Value.ToString()
            frozen = Me.grdExcelData.Rows(i).Cells("Division").Value.ToString()
            amt = Me.grdExcelData.Rows(i).Cells("Amount").Value.ToString()
            'IntMonth = 12 - (combxMonth.SelectedIndex + 1)
            IntMonth = 12 - combxMonth.SelectedIndex

            dtBudget = BULibrary.GetBudgetCode("spgetBudgetCode", budget)
            'bcode = dtBudget.Rows(0)("BudgetCode").ToString().Substring(0, 2)
            bcode = dtBudget.Rows(0)("GrpClass").ToString()
            uploadtype = dtBudget.Rows(0)("UploadType").ToString()
            '02042014
            ewt = Me.grdExcelData.Rows(i).Cells("Flag").Value.ToString()

            If ewt = "" Then
                decEWT_Amt = 0.0
            Else
                dtEWT = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE SystemID='" & ewt & "'")
                decEWT_Amt = Decimal.Parse(Decimal.Parse(amt) * Decimal.Parse(dtEWT.Rows(0)("Percentage").ToString()))
            End If

            If uploadtype = "Per BU" Then

                'dtChkUpload = BULibrary.ChkUpload("spChkUpload", _
                '                              Integer.Parse(yr), _
                '                              bcode, _
                '                              bu.PadLeft(9, "0"), _
                '                              frozen, _
                '                              bu)
                dtChkUpload = BULibrary.ChkUpload("spChkUpload", _
                                              Integer.Parse(yr), _
                                              bcode, _
                                              bpcode, _
                                              frozen, _
                                              bu, _
                                              ewt)
            Else

                dtChkUpload = BULibrary.ChkUpload("spChkUpload", _
                                              Integer.Parse(yr), _
                                              bcode, _
                                              bpcode, _
                                              frozen, _
                                              bu, _
                                              ewt)

            End If


            If dtChkUpload.Rows(0)("MaxUploadSequenceNo").ToString() = "" And IsOrigBudgetH = True Then 'row in excel file is initial budget

                If amt = "0" Then
                    'do nothing
                    'skip row
                Else
                    seqno = "00"
                    If uploadtype = "Per BU" Then 'from If budget = "Merchandisers" Then
                        'budgetID = yr & "-" & bcode & "-" & bu.PadLeft(9, "0") & "-" & seqno & "-" & frozen.Substring(0, 1) & "-" & bu
                        budgetID = yr & "-" & bcode & "-" & bpcode & "-" & seqno & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt

                        'insert to tblHeaderBudget   
                        BULibrary.OpenSqlCon()

                        'BULibrary.InsertFullBudget("spInsertFullBudget", budgetID, seqno, _
                        '                           Integer.Parse(yr), _
                        '                           bcode, bu.PadLeft(9, "0"), frozen, _
                        '                           bu, _
                        '                           Decimal.Parse(amt), _
                        '                           DateTime.Now, UserIDH, batch)


                        BULibrary.InsertFullBudget("spInsertFullBudget", budgetID, seqno, _
                                                   Integer.Parse(yr), _
                                                   bcode, bpcode, frozen, _
                                                   bu, _
                                                   Decimal.Parse(amt), _
                                                   DateTime.Now, UserIDH, batch, True, ewt, decEWT_Amt)
                        BULibrary.InsertToTemp("spInsertTemp", budgetID, UserIDH) 'temporary table lang ito
                    Else
                        budgetID = yr & "-" & bcode & "-" & bpcode & "-" & seqno & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                        'insert to tblHeaderBudget   
                        BULibrary.OpenSqlCon()

                        BULibrary.InsertFullBudget("spInsertFullBudget", budgetID, seqno, _
                                                   Integer.Parse(yr), _
                                                   bcode, bpcode, frozen, _
                                                   bu, _
                                                   Decimal.Parse(amt), _
                                                   DateTime.Now, UserIDH, batch, True, ewt, decEWT_Amt)
                        BULibrary.InsertToTemp("spInsertTemp", budgetID, UserIDH) 'temporary table lang ito
                    End If


                    For x As Integer = 1 To 12 'from For x As Integer = 1 To 12
                        'insert in tblDetailBudget    

                        'BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                        '                             budgetID, bpcode, x, _
                        '                             Math.Round(Decimal.Parse(amt) / 12, 2))

                        If uploadtype = "Per BU" Then

                            If (combxMonth.SelectedIndex + 1) = 1 Then
                                'BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                '                         budgetID, bu.PadLeft(9, "0"), x, _
                                '                         Math.Round(Decimal.Parse(amt) / 12, 2), bcode, frozen, Integer.Parse(yr), bu)

                                BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                                         budgetID, bpcode, x, _
                                                         Math.Round(Decimal.Parse(amt) / 12, 2), bcode, frozen, Integer.Parse(yr), bu, ewt, Math.Round(decEWT_Amt / 12), _
                                                         seqno, "", 0.0)
                            Else

                                If x < (combxMonth.SelectedIndex + 1) Then
                                    'BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                    '                     budgetID, bu.PadLeft(9, "0"), x, _
                                    '                     Math.Round(0, 2), bcode, frozen, Integer.Parse(yr), bu)

                                    BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                                         budgetID, bpcode, x, _
                                                         Math.Round(0, 2), bcode, frozen, Integer.Parse(yr), bu, ewt, Math.Round(0, 2), seqno, "", 0.0)
                                Else
                                    'BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                    '                     budgetID, bu.PadLeft(9, "0"), x, _
                                    '                     Math.Round(Decimal.Parse(amt) / IntMonth, 2), bcode, frozen, Integer.Parse(yr), bu)

                                    BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                                         budgetID, bpcode, x, _
                                                         Math.Round(Decimal.Parse(amt) / IntMonth, 2), bcode, frozen, Integer.Parse(yr), bu, ewt, Math.Round(decEWT_Amt / IntMonth, 2), seqno, "", 0.0)
                                End If
                            End If


                        Else 'upload type is "Per Customer"

                            If (combxMonth.SelectedIndex + 1) = 1 Then
                                BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                                         budgetID, bpcode, x, _
                                                         Math.Round(Decimal.Parse(amt) / 12, 2), bcode, frozen, Integer.Parse(yr), bu, ewt, Math.Round(decEWT_Amt / 12, 2), seqno, "", 0.0)
                            Else

                                If x < (combxMonth.SelectedIndex + 1) Then
                                    BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                                         budgetID, bpcode, x, _
                                                         Math.Round(0, 2), bcode, frozen, Integer.Parse(yr), bu, ewt, Math.Round(0, 2), seqno, "", 0.0)
                                Else
                                    BULibrary.InsertDetailBudget("spInsertDetailBudget", _
                                                         budgetID, bpcode, x, _
                                                         Math.Round(Decimal.Parse(amt) / IntMonth, 2), bcode, frozen, Integer.Parse(yr), bu, ewt, Math.Round(decEWT_Amt / IntMonth, 2), _
                                                         seqno, "", 0.0)
                                End If
                            End If

                        End If


                    Next

                    BULibrary.CloseSqlCon()
                End If
            Else 'row in excel file is revised budget 04062015
                combxMonth.Enabled = True
                If combxMonth.Text = "" Then
                    MsgBox("Please choose a month!", MsgBoxStyle.Exclamation)
                    Return
                End If
                If listError.Items.Count > 0 Then
                    MsgBox("Can't upload file. Please check error logs.", MsgBoxStyle.Exclamation)
                    Return
                End If

                Dim intMaxSeqNo As New Integer
                Dim strPrevID As String
                intMaxSeqNo = Integer.Parse(dtChkUpload.Rows(0)("MaxUploadSequenceNo").ToString())
                intMaxSeqNo = intMaxSeqNo + 1


                If uploadtype = "Per BU" Then  'uploading is per BU

                    If intMaxSeqNo.ToString().Length = 2 Then
                        budgetID = yr & "-" & bcode & "-" & bpcode & "-" & intMaxSeqNo.ToString() & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                        strPrevID = yr & "-" & bcode & "-" & bpcode & "-" & (intMaxSeqNo - 1).ToString() & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                    Else
                        budgetID = yr & "-" & bcode & "-" & bpcode & "-" & intMaxSeqNo.ToString().PadLeft(2, "0") & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                        strPrevID = yr & "-" & bcode & "-" & bpcode & "-" & (intMaxSeqNo - 1).ToString().PadLeft(2, "0") & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                    End If

                Else  'uploading is per customer
                    If intMaxSeqNo.ToString().Length = 2 Then
                        budgetID = yr & "-" & bcode & "-" & bpcode & "-" & intMaxSeqNo.ToString() & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                        strPrevID = yr & "-" & bcode & "-" & bpcode & "-" & (intMaxSeqNo - 1).ToString() & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                    Else
                        budgetID = yr & "-" & bcode & "-" & bpcode & "-" & intMaxSeqNo.ToString().PadLeft(2, "0") & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                        strPrevID = yr & "-" & bcode & "-" & bpcode & "-" & (intMaxSeqNo - 1).ToString().PadLeft(2, "0") & "-" & frozen.Substring(0, 1) & "-" & bu & "-" & ewt
                    End If                    
                End If


                If amt = "0" Then
                    'do nothing
                    'skip row 
                Else

                    Dim dtPrevAmt, dtGetFYAmt As New DataTable()
                    dtPrevAmt = BULibrary.SqlDataTable("SELECT * FROM tblDetailBudget where BudgetID='" & strPrevID & "' and Month=" & Me.grdExcelData.Rows(i).Cells("Month").Value.ToString())
                    dtGetFYAmt = BULibrary.SqlDataTable("SELECT SUM(Amount) AS FYAmt from tblDetailBudget where BudgetID='" & budgetID & "'")
                    BULibrary.OpenSqlCon()


                    If uploadtype = "Per BU" Then

                        BULibrary.InsertDetailBudget("spInsertDetailBudget", budgetID, bpcode, Me.grdExcelData.Rows(i).Cells("Month").Value.ToString(), _
                                                     Decimal.Parse(amt), bcode, frozen, Integer.Parse(yr), bu, ewt, decEWT_Amt, intMaxSeqNo.ToString().PadLeft(2, "0"), _
                                                     strPrevID, dtPrevAmt.Rows(0)("Amount").ToString())
                        BULibrary.InsertToTemp("spInsertTemp", budgetID, UserIDH) 'temporary table lang ito                       
                    Else

                        BULibrary.InsertDetailBudget("spInsertDetailBudget", budgetID, bpcode, Me.grdExcelData.Rows(i).Cells("Month").Value.ToString(), _
                                                     Decimal.Parse(amt), bcode, frozen, Integer.Parse(yr), bu, ewt, decEWT_Amt, intMaxSeqNo.ToString().PadLeft(2, "0"), _
                                                     strPrevID, dtPrevAmt.Rows(0)("Amount").ToString())
                        BULibrary.InsertToTemp("spInsertTemp", budgetID, UserIDH) 'temporary table lang ito                        

                    End If
                    '' stop here 

                    BULibrary.CloseSqlCon()


                End If


            End If

            ProgressBar1.PerformStep()
        Next        
        If IsOrigBudgetH = True Then
            InsertInitialRcjn() 'generate recurring journal number
            dtGetCurUploadedBudget = BULibrary.GetCurUploadedBudget("spGetCurUploadedBudget", UserIDH)
            Me.grdData.DataSource = dtGetCurUploadedBudget 'get currently uploaded budget
            Me.grdData.Columns("FullYearAmt").DefaultCellStyle.Format = "#,###"
            Me.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.btnUpload.Enabled = False
            Me.btnBrowse.Enabled = False
            ProgressBar1.Value = 0S
        Else
            InsertFYRevBudget() 'insert full year revised
            InsertReviseRcjn() 'Generate Recuring Journal Number(s)
            dtGetCurUploadedBudget = BULibrary.SqlDataTable("SELECT * FROM tblDetailBudget WHERE BudgetID in (SELECT DISTINCT BudgetID from tblTemp)")
            Me.grdData.DataSource = dtGetCurUploadedBudget 'get currently uploaded budget
            Me.grdData.Columns("Amount").DefaultCellStyle.Format = "#,###"
            Me.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.btnUpload.Enabled = False
            Me.btnBrowse.Enabled = False
            ProgressBar1.Value = 0S
        End If


        Try
            'BULibrary.GiveCredentials()

            BULibrary.CopyFile(txtFileLocation.Text, "\\10.10.1.84\\Docs\\Uploaded Files\\" & DateTime.Now.ToString("MM").PadLeft(2, "0") & DateTime.Now.Day.ToString() &
                                   DateTime.Now.Year.ToString() & "_" & lblFileName.Text)
            'BULibrary.DeleteCredentials()
        Catch ex As Exception
            BULibrary.OpenSqlCon()
            BULibrary.InsertError("spInsertError", UserIDH, "frmUploader", "FILE NAME CANT COPY", lblFileName.Text, DateTime.Now)
            BULibrary.CloseSqlCon()
        End Try

        MsgBox("File Successfully Uploaded!", MsgBoxStyle.Information)
        BULibrary.DeleteCredentials()



    End Sub

    Private Sub txtFileLocation_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtFileLocation.TextChanged
        'Const width As Integer = 200
        'Dim font As New Font(txtFileLocation.Font.Name, txtFileLocation.Font.Size)
        'Dim s As Size = TextRenderer.MeasureText(txtFileLocation.Text, font)
        'If s.Width > width Then
        '    txtFileLocation.Width = s.Width
        'End If
    End Sub

    Private Sub grdData_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdData.RowHeaderMouseClick
        'Dim frmDetailBudget As New frmDetailBudget(grdData.SelectedRows(0).Cells("BudgetID").Value.ToString() & "-" & grdData.SelectedRows(0).Cells("BPCode").Value.ToString())
        'Dim frmDetailBudget As New frmDetailBudget(grdData.SelectedRows(0).Cells("BudgetID").Value.ToString().Substring(0, 10), _
        'grdData.SelectedRows(0).Cells("BPCode").Value.ToString())
        Dim frmDetailBudget As New frmDetailBudget(grdData.SelectedRows(0).Cells("BudgetID").Value.ToString(), _
                                                   grdData.SelectedRows(0).Cells("Customer").Value.ToString(), _
                                                   grdData.SelectedRows(0).Cells("CustomerCode").Value.ToString(), _
                                                   grdData.SelectedRows(0).Cells("Division").Value.ToString(), _
                                                   grdData.SelectedRows(0).Cells("Budget").Value.ToString())


        frmDetailBudget.ShowDialog()
    End Sub

    Private Sub GetDetailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetDetailToolStripMenuItem.Click

        Try
            Dim frmDetailBudget As New frmDetailBudget(grdData.SelectedRows(0).Cells("BudgetID").Value.ToString(), _
                                           grdData.SelectedRows(0).Cells("Customer").Value.ToString(), _
                                           grdData.SelectedRows(0).Cells("CustomerCode").Value.ToString(), _
                                           grdData.SelectedRows(0).Cells("Division").Value.ToString(), _
                                           grdData.SelectedRows(0).Cells("Budget").Value.ToString())
            frmDetailBudget.ShowDialog()
        Catch ex As Exception
            MsgBox("Please select a budget", MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmUploader_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterScreen
        btnUpload.Enabled = False

        If IsOrigBudgetH = True Then
            Label1.Text = "Upload Full Year Budget"
            Me.Text = "Upload Full Year Budget"
        Else
            Label1.Text = "Upload Revised Budget"
            Me.Text = "Upload Revised Budget"
        End If
        

        EnableCombxMonth()

        ''for testing only
        'Dim BULibrary As New TIBudgetUploader.BULibrary()
        'Dim dtGetCurUploadedBudget As New DataTable()
        'dtGetCurUploadedBudget = BULibrary.GetCurUploadedBudget("spGetCurUploadedBudget", UserIDH)
        'Me.grdData.DataSource = dtGetCurUploadedBudget 'get currently uploaded budget
        'Me.grdData.Columns("FullYearAmt").DefaultCellStyle.Format = "#,###"        
        'Me.grdData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        ''for testing only

        thisForm = Me 'for search pop up


    End Sub
    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        'If combxYear.SelectedValue.ToString() < DateTime.Now.Year.ToString() Then
        '    MsgBox("Can not select previous year!", MsgBoxStyle.Information)
        '    Return
        'End If 'commented out 01062015

        Me.strCountErr.Text = "0"
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        BULibrary.GiveCredentials()
        Dim fDialog As New OpenFileDialog()

        With fDialog
            .Title = "Select file to be uploaded"
            .Filter = "Excel files (*.xls or *.xlsx)|*.xls;*.xlsx"
            If .ShowDialog() = DialogResult.OK Then               
                txtFileLocation.Text = .FileName.ToString()
                lblFileName.Text = .SafeFileName.ToString()                
            Else
                Return
            End If
        End With

        BULibrary.openOleCon(txtFileLocation.Text)
        listError.Items.Clear()

        Dim dtExcelData As New DataTable()
        Try            
            If IsOrigBudgetH = True Then '04062015
                dtExcelData = BULibrary.OleDataTable("SELECT [Year],[BU],[Budget],[BPCode],[Customer Name],[Division], [Quarter] ROUND(SUM([Amount])) AS Amount " &
                                                     "FROM [FullYrBudget$] " &
                                               "GROUP BY [Year],[BU],[Budget],[BPCode],[Customer Name],[Division],[Quarter]") 'use 1 SheetName for excel upload 
            Else                
                dtExcelData = BULibrary.OleDataTable("SELECT [Year],[BU],[Budget],[BPCode],[Customer Name],[Division],[Flag], [Month], [Amount] " &
                                     "FROM [RevisedBudget$] ") 'use 1 SheetName for excel upload 
            End If


            Me.grdExcelData.DataSource = dtExcelData

            Me.grdExcelData.Columns("Amount").DefaultCellStyle.Format = "#,###"
            Me.grdExcelData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
            Me.btnUpload.Enabled = True

            ''aamponin 09162014
            Dim decGTotal As Decimal
            For x As Integer = 0 To dtExcelData.Rows.Count - 1                
                decGTotal += Decimal.Parse(dtExcelData.Rows(x)("Amount").ToString())
            Next
            lblGTotal.Text = decGTotal.ToString("N0")
        Catch ex As Exception
            MsgBox("Error in uploading. Please upload the correct file.", MsgBoxStyle.Exclamation)
            Me.txtFileLocation.Clear()
        End Try

        BULibrary.closeOleCon()

        Dim budget, bpcode, seqno, budgetID As String
        Dim yr, bu, amt, bcode, uploadtype As String
        Dim dtBudget, dtBPCode, dtBU, dtBudgetID, dtChkFlag As New DataTable()
        Dim intCountZero As Integer = 0
        If dtExcelData.Rows.Count = 0 Then
            MsgBox("Error reading file! File returned no rows!", MsgBoxStyle.Exclamation)
            listError.Items.Add(lblFileName.Text & ": Error reading file! File returned no rows!")
            strCountErr.Text = listError.Items.Count.ToString()
        Else
            For x As Integer = 0 To dtExcelData.Rows.Count - 1
                'angelo go here
                budget = dtExcelData.Rows(x)("Budget").ToString().Trim()

                If dtExcelData.Rows(x)("BPCode").ToString().Trim().Length < 9 Then
                    bpcode = dtExcelData.Rows(x)("BPCode").ToString().Trim().PadLeft(9, "0")
                Else
                    bpcode = dtExcelData.Rows(x)("BPCode").ToString().Trim()
                End If

                yr = dtExcelData.Rows(x)("Year").ToString().Trim()
                bu = dtExcelData.Rows(x)("BU").ToString().Trim()
                amt = dtExcelData.Rows(x)("Amount").ToString().Trim()
                seqno = "00"
                'flag = dtExcelData.Rows(x)("Flag").ToString().Trim()

                dtBudget = BULibrary.GetBudgetCode("spgetBudgetCode", budget)

                If dtBudget.Rows.Count = 0 Then
                    'MsgBox(budget & " is not maintained! Please indicate correct budget", MsgBoxStyle.Exclamation)
                    listError.Items.Add("Row " & (x + 1).ToString() & ": " & budget & " is not maintained! Please indicate correct budget.")
                    btnUpload.Enabled = False

                    If listError.Items.Count > 0 Then
                        strCountErr.Text = listError.Items.Count.ToString()
                        Try
                            'BULibrary.GiveCredentials()
                            Dim desErrorLog As String = "\\10.10.1.84\\Docs\\Error Logs\\" & "E" &
                                       DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                       DateTime.Now.Year.ToString() & "_" & UserIDH & ".txt"
                            Dim sw As New StreamWriter(desErrorLog)
                            sw.WriteLine("File Location : " & txtFileLocation.Text)
                            sw.WriteLine("File Name : " & lblFileName.Text)
                            sw.WriteLine("User ID : " & UserIDH)
                            For i As Integer = 0 To listError.Items.Count - 1
                                sw.WriteLine(listError.Items(i).ToString())
                            Next
                            sw.Close()
                            sw.Dispose()
                            BULibrary.OpenSqlCon()
                            BULibrary.InsertError("spInsertError", UserIDH, Me.Text, desErrorLog, lblFileName.Text, DateTime.Now)
                            BULibrary.CloseSqlCon()
                            'BULibrary.DeleteCredentials()
                        Catch ex As Exception
                            'MsgBox("Can't able to write error logs.", MsgBoxStyle.Information)
                            BULibrary.OpenSqlCon()

                            BULibrary.InsertError("spInsertError", UserIDH, "frmUploader", lblFileName.Text, lblFileName.Text, DateTime.Now)

                            BULibrary.CloseSqlCon()

                        End Try

                    End If

                    Return
                End If

                bcode = dtBudget.Rows(0)("GrpClass").ToString()
                uploadtype = dtBudget.Rows(0)("UploadType").ToString()
                budgetID = yr & "-" & bcode & "-" & bpcode & "-" & seqno


                'dtBudgetID = BULibrary.GetBudgetID("spgetBudgetID", budgetID) 'for validations
                'Dim ctr As Integer
                'ctr = x + 1
                'grdExcelData.Rows(x).Cells(0).Value = ctr
                'If dtBudgetID.Rows.Count > 0 Then
                '    listError.Items.Add("Row " & (x + 1).ToString() & ": " & budgetID & " is already uploaded. Please check row.")
                '    btnUpload.Enabled = False
                'End If


                If dtBudget.Rows(0)("Active").ToString() = "False" Then
                    listError.Items.Add("Row " & (x + 1).ToString() & ": " & budget & " budget is not maintained/inactive.")
                    btnUpload.Enabled = False
                End If
                'start 09232013
                If bpcode.Length = 3 Then
                    dtBPCode = BULibrary.SqlDataTable("SELECT * FROM tblBP " &
                                                  "WHERE PARENT_CD ='" & bpcode.PadLeft(9, "0") & "' AND " &
                                                  "BUSINESS_PARTNER_CD='" & bpcode.PadLeft(9, "0") & "'") 'for additional
                Else
                    dtBPCode = BULibrary.SqlDataTable("SELECT * FROM tblBP " &
                                                  "WHERE PARENT_CD ='" & bpcode & "' AND " &
                                                  "BUSINESS_PARTNER_CD='" & bpcode & "'") 'for additional                    
                End If
                'end 09232013
                'dtBPCode = BULibrary.SqlDataTable("SELECT * FROM tblBP " &
                '                                  "WHERE PARENT_CD ='" & bpcode & "' AND " &
                '                                  "BUSINESS_PARTNER_CD='" & bpcode & "'") 'for additional                    
                If uploadtype = "Per Customer" Then
                    If dtBPCode.Rows.Count = 0 Then
                        listError.Items.Add("Row " & (x + 1).ToString() & ": " & bpcode & " Customer is not a mother account.")
                        btnUpload.Enabled = False
                    Else
                        If dtBPCode.Rows(0)("BP_STATUS_DESC").ToString() = "Inactive" Then
                            listError.Items.Add("Row " & (x + 1).ToString() & ": " & bpcode & " Customer is not maintained/inactive.")
                            btnUpload.Enabled = False
                        End If
                    End If
                Else '01202014
                    If dtBPCode.Rows.Count = 0 Then
                        listError.Items.Add("Row " & (x + 1).ToString() & ": " & bpcode & " Customer is not a mother account.")
                        btnUpload.Enabled = False
                    Else
                        If dtBPCode.Rows(0)("BP_STATUS_DESC").ToString() = "Inactive" Then
                            listError.Items.Add("Row " & (x + 1).ToString() & ": " & bpcode & " Customer is not maintained/inactive.")
                            btnUpload.Enabled = False
                        End If
                    End If
                End If

                If yr <> combxYear.SelectedValue.ToString() Then
                    listError.Items.Add("Row " & (x + 1).ToString() & ": " & yr & " is different year from your chosen year.")
                    btnUpload.Enabled = False
                End If
                If yr = "" Then
                    listError.Items.Add("Row " & (x + 1).ToString() & ": " & yr & " is different year from your chosen year.")
                    btnUpload.Enabled = False
                End If
                dtBU = BULibrary.SqlDataTable("SELECT * FROM tblBusinessUnits " &
                                              "WHERE BUCode='" & bu & "'")
                If dtBU.Rows.Count = 0 Then
                    listError.Items.Add("Row " & (x + 1).ToString() & ": " & bu & " Company is invalid.")
                    btnUpload.Enabled = False
                End If
                If amt = "0" Then
                    intCountZero = intCountZero + 1
                End If
                'dtChkFlag = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE SystemID ='" & flag & "'")
                'If dtChkFlag.Rows.Count = 0 Then
                '    listError.Items.Add("Row " & (x + 1).ToString() & ": " & flag & " Flag is invalid.")
                '    btnUpload.Enabled = False
                'End If
                'If amt.Contains("-") Then
                '    listError.Items.Add("Row " & (x + 1).ToString() & ": " & amt & " is invalid. Negative numbers are not allowed")
                '    btnUpload.Enabled = False
                'ElseIf amt.Contains("-") = False Then
                '    Try
                '        Math.Round(Decimal.Parse(amt), 2)
                '    Catch ex As Exception
                '        listError.Items.Add("Row " & (x + 1).ToString() & ": " & amt & " amount is invalid. Please check row!")
                '        btnUpload.Enabled = False
                '        grdExcelData.DataSource = dtExcelData
                '    End Try
                'Else
                '    grdExcelData.DataSource = dtExcelData
                'End If

            Next
            If listError.Items.Count > 0 Then
                strCountErr.Text = listError.Items.Count.ToString()
                Try
                    BULibrary.GiveCredentials()
                    Dim desErrorLog As String = "\\10.10.1.84\\Docs\\Error Logs\\" & "E" &
                               DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                               DateTime.Now.Year.ToString() & "_" & UserIDH & ".txt"
                    Dim sw As New StreamWriter(desErrorLog)
                    sw.WriteLine("File Location : " & txtFileLocation.Text)
                    sw.WriteLine("File Name : " & lblFileName.Text)
                    sw.WriteLine("User ID : " & UserIDH)
                    For i As Integer = 0 To listError.Items.Count - 1
                        sw.WriteLine(listError.Items(i).ToString())
                    Next
                    sw.Close()
                    sw.Dispose()
                    BULibrary.OpenSqlCon()
                    BULibrary.InsertError("spInsertError", UserIDH, Me.Text, desErrorLog, lblFileName.Text, DateTime.Now)
                    BULibrary.CloseSqlCon()
                    BULibrary.DeleteCredentials()
                Catch ex As Exception
                    'MsgBox("Can't able to write error logs.", MsgBoxStyle.Information)                    
                    BULibrary.OpenSqlCon()

                    BULibrary.InsertError("spInsertError", UserIDH, "frmUploader", lblFileName.Text, lblFileName.Text, DateTime.Now)

                    BULibrary.CloseSqlCon()
                End Try

            End If
            If intCountZero > 0 Then
                If MsgBox("There are " & intCountZero.ToString() & " rows that have 0 amounts. Continue anyway?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
                    If listError.Items.Count > 0 Then
                        btnUpload.Enabled = False
                    Else
                        btnUpload.Enabled = True
                    End If
                Else
                    'If listError.Items.Count > 0 Then
                    '    btnUpload.Enabled = False
                    'Else
                    '    btnUpload.Enabled = True
                    'End If
                    btnUpload.Enabled = False
                End If
            Else
                'do nothing
            End If
        End If
        BULibrary.DeleteCredentials()
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub EnableCombxMonth()
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim months() As String = {"January", _
                                  "February", _
                                  "March", _
                                  "April", _
                                  "May", _
                                  "June", _
                                  "July", _
                                  "August", _
                                  "September", _
                                  "October", _
                                  "November", _
                                  "December"}

        For Each month As String In months
            combxMonth.Items.Add(month)
        Next
        combxMonth.SelectedIndex = (DateTime.Now.Month - 1)

        combxYear.DataSource = BULibrary.SqlDataTable("SELECT DISTINCT Year from tblRecurringJournals")
        combxYear.DisplayMember = "Year"
        combxYear.ValueMember = "Year"
        'combxYear.SelectedText = DateTime.Now.Year.ToString()
        combxYear.SelectedValue = DateTime.Now.Year


    End Sub
    'Private Sub InsertSeries()
    '    Dim BULibrary As New TIBudgetUploader.BULibrary()
    '    Dim strSeries As String
    '    If (combxMonth.SelectedIndex + 1).ToString().Length = 2 Then
    '        strSeries = DateTime.Now.Year.ToString().Substring(2, 2) & (combxMonth.SelectedIndex + 1).ToString()
    '    Else
    '        strSeries = DateTime.Now.Year.ToString().Substring(2, 2) & (combxMonth.SelectedIndex + 1).ToString().PadLeft(2, "0")
    '    End If
    '    BULibrary.OpenSqlCon()
    '    BULibrary.InsertSeries("spInsertSeries", strSeries)
    '    BULibrary.CloseSqlCon()

    'End Sub
    Private Sub InsertRcjn()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetMaxRcjn, dt As New DataTable()
        Dim strMaxRcjn As String
        Dim intRcjno As Integer
        Dim strNewRcjn As String
        Dim strSeries As String
        Dim dtBUs As New DataTable()

        'dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
        '                                      "WHERE Year=" & DateTime.Now.Year & " AND BU='" & strBU & "'")

        'dtBUs = BULibrary.SqlDataTable("SELECT DISTINCT BusinessUnit FROM tblHeaderBudget " &
        '                        "WHERE UploadSequenceNo = (SELECT MAX(UploadSequenceNo) from tblHeaderBudget) " &
        '                        "AND Year=" & DateTime.Now.Year & " AND RecurringJournal is NULL")

        dtBUs = BULibrary.SqlDataTable("SELECT DISTINCT BusinessUnit FROM tblHeaderBudget " &
                                "WHERE " &
                                "Year=" & DateTime.Now.Year & " AND RecurringJournal is NULL")

        For x As Integer = 0 To dtBUs.Rows.Count - 1
            dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                              "WHERE Year=" & DateTime.Now.Year & " AND BU='" &
                                              dtBUs.Rows(x)("BusinessUnit").ToString() & "'")
            strMaxRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
            intRcjno = Integer.Parse(dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString().Substring(1, 2))
            intRcjno = intRcjno + 1
            strNewRcjn = "T" & intRcjno
            'If intRcjno.ToString().Substring(1, 1) = "9" Then
            '    strNewRcjn = "T" & intRcjno.ToString().Substring(0, 1) & "A"
            'ElseIf  

            'Else
            '    strNewRcjn = "T" & intRcjno
            'End If

            If (combxMonth.SelectedIndex + 1).ToString().Length = 2 Then
                strSeries = DateTime.Now.Year.ToString().Substring(2, 2) & (combxMonth.SelectedIndex + 1).ToString()
            Else
                strSeries = DateTime.Now.Year.ToString().Substring(2, 2) & (combxMonth.SelectedIndex + 1).ToString().PadLeft(2, "0")
            End If

            BULibrary.OpenSqlCon()
            BULibrary.InsertRcjn("spInsertRcjn", strNewRcjn, DateTime.Now.Year, (combxMonth.SelectedIndex + 1), 0, DateValue("1/1/1753 12:00:00 AM"), "", strSeries, dtBUs.Rows(x)("BusinessUnit").ToString())
            BULibrary.CloseSqlCon()
        Next

    End Sub
    Private Sub InsertInitialRcjn()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetMaxRcjn, dt As New DataTable()
        Dim strSeries, strMonth As String
        Dim intMaxRcjno As Integer
        'Dim c As Char
        Dim dtBUs As New DataTable()
        strMonth = combxMonth.SelectedIndex + 1

        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                              "WHERE Year=" & combxYear.SelectedValue.ToString())

        dtBUs = BULibrary.SqlDataTable("SELECT DISTINCT BusinessUnit FROM tblHeaderBudget " &
                                "WHERE Year=" & combxYear.SelectedValue.ToString() & " AND RecurringJournal is NULL")

        If strMonth.Length = 2 Then
        Else
            strMonth = strMonth.PadLeft(2, "0")
        End If

        For x As Integer = 0 To dtBUs.Rows.Count - 1

            intMaxRcjno = Integer.Parse(dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()) + 1
            strSeries = combxYear.SelectedValue.ToString().Substring(2, 2) & strMonth
            BULibrary.OpenSqlCon()           
            BULibrary.InsertRcjn("spInsertRcjn", intMaxRcjno.ToString(), combxYear.SelectedValue.ToString(), (combxMonth.SelectedIndex + 1), 0, DateValue("1/1/1753 12:00:00 AM"), "", strSeries, dtBUs.Rows(x)("BusinessUnit").ToString())
            BULibrary.CloseSqlCon()
        Next
    End Sub
    Private Sub InsertReviseRcjn()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetMaxRcjn, dt As New DataTable()
        Dim strSeries, strMonth As String
        Dim intMaxRcjno As Integer        
        Dim dtBUs, dtOpnPrd, dtClsPrd As New DataTable()
        strMonth = combxMonth.SelectedIndex + 1

        dtBUs = BULibrary.SqlDataTable("SELECT DISTINCT BusinessUnit FROM tblHeaderBudget " &
                                "WHERE Year=" & combxYear.SelectedValue.ToString() & " AND RecurringJournal is NULL")

        For x As Integer = 0 To dtBUs.Rows.Count - 1

            dtOpnPrd = BULibrary.SqlDataTable("SELECT COMPANY_CD, PERIOD, F_GLD FROM PERIOD_STATUS WHERE F_GLD='Open'" &
                         " AND COMPANY_CD=" & Integer.Parse(dtBUs.Rows(x)("BusinessUnit").ToString()) &
                         " AND Year=" & Integer.Parse(combxYear.SelectedValue.ToString()) &
                         " AND PERIOD <> 13")

            For i As Integer = 0 To dtOpnPrd.Rows.Count - 1
                dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                          "WHERE Year=" & combxYear.SelectedValue.ToString())
                strMonth = dtOpnPrd.Rows(i)("PERIOD").ToString()
                If strMonth.Length = 2 Then
                    strMonth = strMonth
                Else
                    strMonth = strMonth.PadLeft(2, "0")
                End If
                intMaxRcjno = Integer.Parse(dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()) + 1
                strSeries = combxYear.SelectedValue.ToString().Substring(2, 2) & strMonth
                BULibrary.OpenSqlCon()
                BULibrary.InsertRcjn("spInsertRcjn", intMaxRcjno.ToString(), combxYear.SelectedValue.ToString(), Integer.Parse(dtOpnPrd.Rows(i)("PERIOD").ToString()), 0, DateValue("1/1/1753 12:00:00 AM"), "", strSeries, dtBUs.Rows(x)("BusinessUnit").ToString())
                BULibrary.CloseSqlCon()               
            Next
        Next
    End Sub

    Private Sub InsertRevisedRcjn()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetMaxRcjn, dt As New DataTable()
        Dim strSeries, strMonth As String
        Dim intMaxRcjno As Integer
        ' Dim c As Char
        Dim dtBUs As New DataTable()
        strMonth = combxMonth.SelectedIndex + 1

        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                              "WHERE Year=" & combxYear.SelectedValue.ToString())

        dtBUs = BULibrary.SqlDataTable("SELECT DISTINCT BusinessUnit FROM tblHeaderBudget " &
                                "WHERE Year=" & combxYear.SelectedValue.ToString() & " AND RecurringJournal is NULL")

        If strMonth.Length = 2 Then
        Else
            strMonth = strMonth.PadLeft(2, "0")
        End If

        For x As Integer = 0 To dtBUs.Rows.Count - 1

            intMaxRcjno = Integer.Parse(dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()) + 1
            strSeries = combxYear.SelectedValue.ToString().Substring(2, 2) & strMonth
            BULibrary.OpenSqlCon()
            BULibrary.InsertRcjn("spInsertRcjn", intMaxRcjno.ToString(), combxYear.SelectedValue.ToString(), (combxMonth.SelectedIndex + 1), 0, DateValue("1/1/1753 12:00:00 AM"), "", strSeries, dtBUs.Rows(x)("BusinessUnit").ToString())
            BULibrary.CloseSqlCon()
        Next
    End Sub

    Private Sub DeleteTemp()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        'delete records from temp table
        BULibrary.OpenSqlCon()
        BULibrary.SqlUpdate("DELETE FROM tblTemp")
        BULibrary.CloseSqlCon()
        'delete records from temp table
    End Sub
    Private Sub InsertFYRevBudget()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtFYAmt, dtTax, dtOrigFY As New DataTable()
        Dim prevID As String
        Dim intMaxSeqNo As Integer
        Dim decEwtAmt, decNewFYAmt As Decimal
        dtFYAmt = BULibrary.SqlDataTable("spgetFYRevAmt")

        BULibrary.OpenSqlCon()

        For i As Integer = 0 To dtFYAmt.Rows.Count - 1

            dtTax = BULibrary.SqlDataTable("SELECT * FROM tblTax where SystemID='" &
                                           dtFYAmt.Rows(i)("Tax").ToString() & "'")

            'budget id sample : 2014-DA-405000002-01-C-211-T02
            intMaxSeqNo = Integer.Parse(dtFYAmt.Rows(i)("UploadSequenceNo").ToString()) - 1 'get previous upload sequence no.

            If intMaxSeqNo.ToString.Length = 2 Then
                prevID = dtFYAmt.Rows(i)("Year").ToString() & "-" & dtFYAmt.Rows(i)("Budget").ToString() &
                "-" & dtFYAmt.Rows(i)("BPCode").ToString() & "-" & intMaxSeqNo.ToString() &
                "-" & dtFYAmt.Rows(i)("Frozen").ToString().Substring(0, 1) & "-" &
                dtFYAmt.Rows(i)("BU").ToString() & "-" & dtFYAmt.Rows(i)("Tax").ToString()
            Else
                prevID = dtFYAmt.Rows(i)("Year").ToString() & "-" & dtFYAmt.Rows(i)("Budget").ToString() &
                "-" & dtFYAmt.Rows(i)("BPCode").ToString() & "-" & intMaxSeqNo.ToString().ToString().PadLeft(2, "0") &
                "-" & dtFYAmt.Rows(i)("Frozen").ToString().Substring(0, 1) & "-" &
                dtFYAmt.Rows(i)("BU").ToString() & "-" & dtFYAmt.Rows(i)("Tax").ToString()
            End If
            
            decEwtAmt = Decimal.Parse(dtFYAmt.Rows(i)("FYAmt").ToString()) * Decimal.Parse(dtTax.Rows(0)("Percentage").ToString())
            dtOrigFY = BULibrary.SqlDataTable("SELECT * FROM tblHeaderBudget WHERE BudgetID='" & prevID & "'")
            decNewFYAmt = Decimal.Parse(dtFYAmt.Rows(i)("FYAmt").ToString()) + Decimal.Parse(dtOrigFY.Rows(0)("Amount").ToString()) 'full year/orig budget + adjustment amt from uploaded revised

            BULibrary.InsertFullBudget("spInsertFullBudget", dtFYAmt.Rows(i)("BudgetID").ToString(), _
                                       dtFYAmt.Rows(i)("UploadSequenceNo").ToString(), _
                                       dtFYAmt.Rows(i)("Year").ToString(), _
                                       dtFYAmt.Rows(i)("Budget").ToString(), _
                                       dtFYAmt.Rows(i)("BPCode").ToString(), _
                                       dtFYAmt.Rows(i)("Frozen").ToString(), _
                                       dtFYAmt.Rows(i)("BU").ToString(), _
                                       decNewFYAmt.ToString(), _
                                       Date.Now, UserIDH, "", True, _
                                       dtFYAmt.Rows(i)("Tax").ToString(), _
                                       decEwtAmt)
            BULibrary.UpdateIsLatest("spUpdateIsLatest", dtFYAmt.Rows(i)("Year").ToString(), _
                                        dtFYAmt.Rows(i)("Budget").ToString(), _
                                        dtFYAmt.Rows(i)("BPCode").ToString(), _
                                        intMaxSeqNo.ToString().PadLeft(2, "0"), _
                                        dtFYAmt.Rows(i)("Frozen").ToString(), _
                                        dtFYAmt.Rows(i)("BU").ToString(), _
                                        dtFYAmt.Rows(i)("Tax").ToString())

        Next


        BULibrary.CloseSqlCon()

    End Sub

    Private Sub CopyFile(ByVal FileToCopy As String, ByVal NewCopy As String)
        If System.IO.File.Exists(FileToCopy) = True Then
            System.IO.File.Copy(FileToCopy, NewCopy)
        End If
    End Sub

    Private Sub combxMonth_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles combxMonth.SelectedIndexChanged
        'If combxYear.SelectedValue = DateTime.Now.Year.ToString() Then
        '    If (combxMonth.SelectedIndex + 1 < DateTime.Now.Month) Then
        '        MsgBox("You can't choose previous months!", MsgBoxStyle.Exclamation)
        '    End If
        'End If
    End Sub

    Private Sub btnError_Click(sender As System.Object, e As System.EventArgs) Handles btnError.Click
        Dim frmVeiwError As New frmViewError(UserIDH, UserBUH, txtFileLocation.Text, lblFileName.Text)
        For i As Integer = 0 To listError.Items.Count - 1
            frmVeiwError.listViewError.Items.Add(listError.Items(i))

        Next
        frmVeiwError.ShowDialog()
    End Sub

    Private Sub grdExcelData_RowPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles grdExcelData.RowPostPaint
        e.Graphics.DrawString(e.RowIndex + 1, grdExcelData.Font, Brushes.Black, e.RowBounds.X + 15, e.RowBounds.Y + 5)
    End Sub

    Private Sub grdData_RowPostPaint(sender As System.Object, e As System.Windows.Forms.DataGridViewRowPostPaintEventArgs) Handles grdData.RowPostPaint
        e.Graphics.DrawString(e.RowIndex + 1, grdData.Font, Brushes.Black, e.RowBounds.X + 15, e.RowBounds.Y + 5)
    End Sub
    Private Sub frmUploader_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If e.Control AndAlso e.KeyCode = Keys.F Then
        '      Button1.Visible = True
        '      TextBox1.Visible = True
        '  ElseIf e.KeyCode = Keys.Escape Then
        '      Button1.Visible = False
        '      TextBox1.Visible = False
        '  End If
    End Sub

    Private Sub grdData_ColumnHeaderMouseDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdData.ColumnHeaderMouseDoubleClick

        Dim frmSearch As New frmSearch(grdData.SortedColumn.Index, grdData.Columns(grdData.SortedColumn.Index).HeaderText.ToString, 1)
        frmSearch.Show()

    End Sub

    Private Sub grdData_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdData.CellContentClick

    End Sub

    Private Sub BrowseUploadedFIlesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BrowseUploadedFIlesToolStripMenuItem.Click
        Dim frmBrowseUploadedFiles As New frmBrowseUploadedFiles()
        frmBrowseUploadedFiles.Show()
    End Sub
End Class