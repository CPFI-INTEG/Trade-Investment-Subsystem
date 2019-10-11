Imports System.IO
Imports System.Globalization

Public Class frmDownloads
    Dim IsInitialH As Boolean
    Dim strUserIDH, strUserBUH, strUserPermissionH, strBUCode As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        'IsInitialH = IsInitial
        strUserIDH = strUserID
        strUserBUH = strUserBU
        strBUCode = strUserBU
    End Sub
    Dim BULibrary As New TIBudgetUploader.BULibrary()
    Private Sub frmDownloads_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.StartPosition = FormStartPosition.CenterScreen
        ' If (IsInitialH) Then
        'grpBoxR.Enabled = False
        'lblYr.Text = DateTime.Now.Year.ToString()
        Dim dtCustomers As New DataTable()
        Dim yr As String

        yr = DateTime.Now.Year.ToString().Substring(2, 2)

        'Me.lblSeries.Text = yr & "01"
        'Else
        'grpBoxI.Enabled = False
        'lblRYr.Text = DateTime.Now.Year.ToString()
        Dim dtGetSeries As New DataTable()
        Dim yr2 As String

        dtGetSeries = BULibrary.SqlDataTable("SELECT * FROM tblRecurringJournals " &
                                             " WHERE BU='" & strUserBUH & "'" &
                                             " AND UserID = '' " &
                                             "AND DateDownloaded='1753-01-01 00:00:00.000' " &
                                             "AND Downloaded=0")

        If dtGetSeries.Rows.Count > 0 Then
            For x As Integer = 0 To dtGetSeries.Rows.Count - 1
                Dim strSer As String
                'strYr = dtGetSeries.Rows(x)("Year").ToString().Substring(2, 2)
                'strMonth = dtGetSeries.Rows(x)("Month").ToString()
                strSer = dtGetSeries.Rows(x)("Series").ToString()

                Me.combxSeries.Items.Add(strSer)
            Next
        Else
            yr2 = DateTime.Now.Year.ToString().Substring(2, 2)
            Me.combxSeries.Text = yr2 & DateTime.Now.ToString("MM")
        End If
        'End If

        combxYear.DataSource = BULibrary.SqlDataTable("SELECT DISTINCT Year from tblRecurringJournals")
        combxYear.DisplayMember = "Year"
        combxYear.ValueMember = "Year"
        combxYear.SelectedValue = DateTime.Now.Year.ToString()

        'combxTransType.DataSource = BULibrary.SqlDataTable("SELECT * FROM tblYrTtyp WHERE Year = " & Integer.Parse(DateTime.Now.Year))
        combxTransType.DataSource = BULibrary.SqlDataTable("SELECT distinct * FROM tblYrTtyp")
        combxTransType.DisplayMember = "Ttype"
        combxTransType.ValueMember = "Ttype"


        '05202014
        combxInstance.SelectedIndex = 2


    End Sub

    Private Sub combxCustomer_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'Dim dtBudgetID As New DataTable()
        'dtBudgetID = BULibrary.SqlDataTable("SELECT BudgetID FROM tblHeaderBudget WHERE BPCode='" & combxCustomer.SelectedValue.ToString() &
        '                                    "'")

        'Me.combxBudgetID.DataSource = dtBudgetID
        'Me.combxBudgetID.DisplayMember = "BudgetID"
        'Me.combxBudgetID.ValueMember = "BudgetID"
    End Sub

    'Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click
    '    Dim fBrowse As New FolderBrowserDialog

    '    With fBrowse
    '        .Description = "Choose Destination"
    '        .ShowNewFolderButton = True
    '    End With
    '    If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then
    '        DownloadHeader(fBrowse.SelectedPath)
    '        DownloadDetail(fBrowse.SelectedPath)
    '        DownloadInstructions(fBrowse.SelectedPath)
    '        'InsertInitialRcjn()

    '        BULibrary.OpenSqlCon()

    '        BULibrary.UpdateRcjn("spUpdateRcjn", lblSeries.Text, DateTime.Now, strUserIDH, True, strUserBUH)

    '        BULibrary.CloseSqlCon()

    '        Me.btnDownload.Enabled = False
    '        MsgBox("File downloaded!", MsgBoxStyle.Information)
    '    End If

    'End Sub
    'Private Sub DownloadHeader(ByVal strPath As String)
    '    Dim strRcjn, strRcjd, strTtyp, strSer, strCur, _
    '        strRate, strBPCode, _
    '        strRate2, strRate3, strRatf1, _
    '        strRatf2, strRatf3, strBU As String
    '    Dim dtGetMaxRcjn, dtYrTtyp As New DataTable()
    '    'Dim sw As New StreamWriter("E:\\Files\\Trade Investment- Subsystem\\Application\\" & "H" &
    '    '                           DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
    '    '                           DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
    '    Dim sw As New StreamWriter(strPath & "\\H" &
    '                               DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
    '                               DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
    '    dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
    '                                          "WHERE Year=" & DateTime.Now.Year)

    '    dtYrTtyp = BULibrary.SqlDataTable("SELECT * FROM tblYrTtyp WHERE Year=" & DateTime.Now.Year)

    '    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
    '    strRcjd = "Trade Investment Upload"
    '    'strTtyp = "J50"
    '    strTtyp = dtYrTtyp.Rows(0)("Ttype").ToString()
    '    strSer = Me.lblSeries.Text
    '    strCur = "PHP"
    '    strBPCode = ""
    '    strRate = "1"
    '    strRate2 = "45.7"
    '    strRate3 = "0"
    '    strRatf1 = "1"
    '    strRatf2 = "1"
    '    strRatf3 = "1"
    '    strBU = strUserBUH

    '    Using sw
    '        sw.WriteLine("|" & strRcjn & "|" & strRcjd & "|" & strTtyp & "|" &
    '                     strSer & "|" & strCur & "|" & strBPCode & "|" & strRate & "|" &
    '                     strRate2 & "|" & strRate3 & "|" & strRatf1 & "|" & strRatf2 & "|" &
    '                     strRatf3 & "|" & strBU & "|")
    '    End Using

    'End Sub
    'Private Sub DownloadDetail(ByVal strPath As String)
    '    Dim strRcjn, strLino, _
    '    strBPCode, _
    '    strLeac, _
    '    strDim1, _
    '    strDim2, _
    '    strDim3, _
    '    strDim4, _
    '    strDim5, _
    '    strAmnt, _
    '    strCcty, _
    '    strCvat, _
    '    strVamt, _
    '    strQty1, _
    '    strQty2, _
    '    strRefr, _
    '    strDbcr, _
    '    strBU As String
    '    Dim dtBClassMapping As New DataTable()
    '    Dim dtGetBudget As New DataTable()
    '    Dim dtGetMaxRcjn As New DataTable()
    '    Dim ctr As Integer = 0
    '    'Dim sw As New StreamWriter("E:\\Files\\Trade Investment- Subsystem\\Application\\" & "D" &
    '    '                           DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
    '    '                           DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
    '    Dim sw As New StreamWriter(strPath & "\\D" &
    '                               DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
    '                               DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")

    '    dtGetBudget = BULibrary.SqlDataTable("SELECT * FROM tblHeaderBudget " &
    '                                         "WHERE Year = " & DateTime.Now.Year &
    '                                         " AND UploadSequenceNo='00' AND BusinessUnit='" &
    '                                         strUserBUH & "'")

    '    dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
    '                                              "WHERE Year=" & DateTime.Now.Year)



    '    For a As Integer = 0 To dtGetBudget.Rows.Count - 1

    '        dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
    '                                             "WHERE BudgetCode='" & dtGetBudget.Rows(a)("Budget").ToString() &
    '                                             "'")

    '        'dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
    '        '                                      "WHERE Year=" & DateTime.Now.Year)

    '        'DEBIT
    '        ctr = ctr + 1
    '        strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
    '        strLino = ctr
    '        strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
    '        strLeac = dtBClassMapping.Rows(0)("ExpenseAcct").ToString() 'debit       
    '        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
    '        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
    '        strDim3 = dtBClassMapping.Rows(0)("Dim3").ToString()
    '        strDim4 = dtBClassMapping.Rows(0)("Dim4").ToString()
    '        strDim5 = dtBClassMapping.Rows(0)("Dim5").ToString()
    '        strAmnt = Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / 12).ToString()
    '        strCcty = "PHI"
    '        strCvat = "V00"
    '        strVamt = "0"
    '        strQty1 = "0"
    '        strQty2 = "0"
    '        strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
    '        strDbcr = "1"  'debit
    '        strBU = strUserBUH
    '        sw.Write("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
    '                     strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
    '                     strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
    '                     strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
    '                     strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|" & "|")
    '        'sw.WriteLine()

    '        'CREDIT            
    '        ctr = ctr + 1
    '        strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
    '        strLino = ctr
    '        strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
    '        strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit
    '        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
    '        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
    '        strDim3 = dtBClassMapping.Rows(0)("Dim3").ToString()
    '        strDim4 = dtBClassMapping.Rows(0)("Dim4").ToString()
    '        strDim5 = dtBClassMapping.Rows(0)("Dim5").ToString()
    '        strAmnt = Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / 12).ToString()
    '        strCcty = "PHI"
    '        strCvat = "V00"
    '        strVamt = "0"
    '        strQty1 = "0"
    '        strQty2 = "0"
    '        strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
    '        strDbcr = "2"  'credit
    '        strBU = strUserBUH

    '        sw.Write("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
    '                     strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
    '                     strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
    '                     strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
    '                     strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")
    '        'If ((a Mod 2) = 0) Then
    '        '    sw.WriteLine()
    '        'End If

    '        'sw.Write("~")
    '        sw.WriteLine()
    '    Next
    '    sw.Close()
    '    sw.Dispose()

    '    For b As Integer = 0 To dtGetBudget.Rows.Count - 1

    '        BULibrary.OpenSqlCon()

    '        BULibrary.UpdateHdrBudget("spUpdateHdrBudget", dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString(), _
    '                                  dtGetBudget.Rows(b)("BudgetID").ToString())

    '        BULibrary.CloseSqlCon()

    '    Next


    'End Sub
    Private Sub DownloadInstructions(ByVal strPath As String)

        Dim dtGetMaxRcjn, dtForexRate As New DataTable()

        Dim rcjn, _
        fyer, _
        fprd, _
        byer, _
        btno, _
        docn, _
        rate1, _
        r2, _
        r3, _
        ratf1, _
        rf2, _
        rf3, _
        rvus, _
        rbyr, _
        rbno, _
        rdoc As String

        'Dim sw As New StreamWriter("E:\\Files\\Trade Investment- Subsystem\\Application\\" & "I" &
        '                           DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
        '                           DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
        Dim sw As New StreamWriter(strPath & "\\I" &
                                   DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                   DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")

        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                              "WHERE Year=" & Integer.Parse(combxYear.SelectedValue.ToString()))

        dtForexRate = BULibrary.SqlDataTable("SELECT * FROM tblForexRate WHERE Currency = 'USD'")

        rcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
        fyer = DateTime.Now.Year.ToString()
        fprd = DateTime.Now.ToString("MM")
        byer = DateTime.Now.Year.ToString()
        btno = ""
        docn = ""
        rate1 = "1"
        'r2 = "45.7"
        r2 = dtForexRate.Rows(0)("Amount").ToString()
        r3 = "0.000001"
        ratf1 = "1"
        rf2 = "1"
        rf3 = "1"
        rvus = ""
        rbyr = "0"
        rbno = "0"
        rdoc = "0"

        Using sw
            sw.WriteLine("|" & rcjn & "|" & fyer & "|" & fprd & "|" & byer & "|" & btno & "|" &
                         docn & "|" & rate1 & "|" & r2 & "|" & r3 & "|" & ratf1 & "|" &
                         rf2 & "|" & rf3 & "|" & rvus & "|" & rbyr & "|" & rbno & "|" &
                         rdoc & "|")
        End Using
        Try
            'BULibrary.GiveCredentials()
            BULibrary.CopyFile(strPath & "\\I" &
                        DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                        DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt", "\\10.10.1.84\\Docs\\Downloaded Files\\Instructions\\" & "I" &
                       DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                       DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
            'BULibrary.DeleteCredentials()
        Catch ex As Exception
            BULibrary.OpenSqlCon()
            BULibrary.InsertError("spInsertError", strUserIDH, "frmUploader", "FILE NAME CANT COPY", "INSTRUCTIONFILE", DateTime.Now)
            BULibrary.CloseSqlCon()
        End Try

    End Sub
    Private Sub lblDownloadR_Click(sender As System.Object, e As System.EventArgs) Handles lblDownloadR.Click
        BULibrary.GiveCredentials()
        If combxSeries.SelectedItem Is Nothing Then
            MsgBox("Please select series!", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim fBrowse As New FolderBrowserDialog

        With fBrowse
            .Description = "Choose Destination"
            .ShowNewFolderButton = True
        End With
        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then

            DownloadH(fBrowse.SelectedPath)
            DownloadD(fBrowse.SelectedPath)
            'If chkboxInstructions.Checked Then
            '    DownloadInstructions(fBrowse.SelectedPath)
            'End If
            BULibrary.OpenSqlCon()

            BULibrary.UpdateRcjn("spUpdateRcjn", combxSeries.SelectedItem.ToString(), DateTime.Now, strUserIDH, True, strUserBUH)

            BULibrary.CloseSqlCon()

            'Me.btnDownload.Enabled = False
            Me.lblDownloadR.Enabled = False
            MsgBox("File downloaded!", MsgBoxStyle.Information)



        End If

        BULibrary.DeleteCredentials()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If combxSeries.SelectedItem Is Nothing Then
            MsgBox("Please select series!", MsgBoxStyle.Exclamation)
            Return
        End If
        If combxYear.SelectedValue.ToString().Substring(2, 2) <> combxSeries.SelectedItem.ToString().Substring(0, 2) Then
            MsgBox("Please select correct year or series!", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim strRcjn, strLino, _
              strBPCode, _
              strLeac, _
              strDim1, _
              strDim2, _
              strDim3, _
              strDim4, _
              strDim5, _
              strAmnt, _
              strCcty, _
              strCvat, _
              strVamt, _
              strQty1, _
              strQty2, _
              strRefr, _
              strDbcr, _
              strBU As String
        'Dim strEWT_Amt As String
        Dim strPrevBudgetID, strNewBudgetID As String
        Dim intPrevMonth, intNextMonth, intDivisor As Integer
        Dim decAccrual As Decimal
        Dim decAccTax_Amt As Decimal
        Dim decVat As Decimal
        Dim dtBClassMapping, _
            dtGetBudget, _
            dtGetMaxRcjn, _
            dtGetDetBudget, _
            dtGetNewDetBudget, _
            dtGetDim3PerBU, _
            dtGetDim5PerBU, _
            dtGetDim5For511, _
            dtGetVAT, _
            dtGetLedgerAcct, _
            dtGetDim4PerYr, _
            dtGetLeac As New DataTable()
        Dim ctr As Integer = 0
        intDivisor = (12 - Integer.Parse(combxSeries.SelectedItem.ToString().Substring(2, 2))) + 1
        dtGetBudget = BULibrary.SqlDataTable("SELECT * FROM tblHeaderBudget " &
                                             "WHERE Year = " & combxYear.SelectedValue.ToString() &
                                             " AND BusinessUnit='" &
                                             strUserBUH & "' AND RecurringJournal is NULL AND UploadSequenceNo='00'") 'modified 04142015

        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                                  "WHERE Year=" & combxYear.SelectedValue & " AND BU='" &
                                              strUserBUH & "'")


        grdPrev2.Columns.Add("Rcjn", "Recurring Journal") '0
        grdPrev2.Columns.Add("Lino", "Line No") '1
        grdPrev2.Columns.Add("BPCode", "Customer") '2
        grdPrev2.Columns.Add("LedgerAcct", "Ledger Account") '3
        grdPrev2.Columns.Add("Dim1", "Dimension 1") '4
        grdPrev2.Columns.Add("Dim2", "Dimension 2") '5
        grdPrev2.Columns.Add("Dim3", "Dimension 3") '6
        grdPrev2.Columns.Add("Dim4", "Dimension 4") '7
        grdPrev2.Columns.Add("Dim5", "Dimension 5") '8
        grdPrev2.Columns.Add("Debit", "Debit") '9
        grdPrev2.Columns.Add("Credit", "Credit") '10
        grdPrev2.Columns.Add("BudgetID", "Transaction Reference") '11
        grdPrev2.Columns.Add("BU", "Company Code") '12
        'grdPrev2.Rows.Add((dtGetBudget.Rows.Count) * 2)
        grdPrev2.Rows.Add((dtGetBudget.Rows.Count) * 5) 'tentative ewt 02042014


        For a As Integer = 0 To dtGetBudget.Rows.Count - 1

            If dtGetBudget.Rows(a)("UploadSequenceNo").ToString() = "00" Then

                dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                                                 "WHERE BudgetCode='" & dtGetBudget.Rows(a)("Budget").ToString() &
                                                 "'")

                If dtBClassMapping.Rows.Count = 0 Then
                    MsgBox("There are no Budget Class Mapping maintained! Please contact your system administrator!", MsgBoxStyle.Critical)
                    Return
                End If
                'start 09202013
                dtGetDim3PerBU = BULibrary.GetDim3PerBU("spgetDim3PerBU", dtGetBudget.Rows(a)("Division").ToString())

                If dtGetDim3PerBU.Rows.Count = 0 Then
                    MsgBox("There are no Dimension 3 maintained in your company! Please contact your system administrator!", MsgBoxStyle.Critical)
                    Return
                End If

                dtGetDim5PerBU = BULibrary.GetDim5PerBU("spgetDim5PerBU", strUserBUH)

                If dtGetDim3PerBU.Rows.Count = 0 Then
                    MsgBox("There are no Dimension 5 maintained in your company! Please contact your system administrator!", MsgBoxStyle.Critical)
                    Return
                End If

                dtGetDim4PerYr = BULibrary.GetDim4PerYr("spgetDim4PerYr", combxYear.SelectedValue)

                If dtGetDim4PerYr.Rows.Count = 0 Then
                    MsgBox("There are no Dimension 4 maintained for the selected year! Please contact your system administrator!", MsgBoxStyle.Critical)
                    Return
                End If

                dtGetVAT = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE Name='VAT'")
                decVat = Decimal.Parse(dtGetVAT.Rows(0)("Percentage").ToString())

                dtGetLedgerAcct = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE SystemID='" & dtGetBudget.Rows(a)("Tax").ToString() & "'")
                'dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(dtGetLedgerAcct.Rows(0)("Code").ToString()))

                If dtGetBudget.Rows(a)("Tax").ToString() = "T04" Then 'sales discount
                    'DEBIT
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()                    
                    strLeac = dtGetLedgerAcct.Rows(0)("Code").ToString() 'Sales Discount Expense Acct

                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If




                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString("N", New CultureInfo("en-US"))
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "1"  'debit
                    strBU = strUserBUH


                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = strAmnt
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU

                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    'strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit
                    'If dtGetBudget.Rows(a)("GROUP2_CD").ToString() = "8000" Then
                    '    dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                    '                                             "WHERE BudgetCode = 'OTH'")
                    '    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString()
                    'Else
                    '    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit
                    'End If
                    strLeac = dtGetLedgerAcct.Rows(0)("Code2").ToString() 'Sales Discount Accrual Acct

                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                                 "WHERE BudgetCode='" & dtGetBudget.Rows(a)("Budget").ToString() &
                                 "'")
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If


                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString("N", New CultureInfo("en-US"))
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"  'credit
                    strBU = strUserBUH

                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = strAmnt
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU

                ElseIf dtGetBudget.Rows(a)("Tax").ToString() = "T01" Then 'ewt 2%

                    'DEBIT
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("ExpenseAcct").ToString()

                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If

                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString("N", New CultureInfo("en-US"))
                    'strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round((Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) * decVat), 2)).ToString("N", New CultureInfo("en-US"))

                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "1"  'debit
                    strBU = strUserBUH


                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = strAmnt
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU


                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    'strLeac = "EWT LEAC" 'EWT leac
                    strLeac = dtGetLedgerAcct.Rows(0)("Code").ToString()


                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2).ToString("N", New CultureInfo("en-US"))
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = strAmnt 'credit
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU


                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit - acrrual acct



                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2)).ToString("N", New CultureInfo("en-US"))
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = strAmnt 'credit
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU

                ElseIf dtGetBudget.Rows(a)("Tax").ToString() = "T02" Then 'ewt 5%

                    'DEBIT
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("ExpenseAcct").ToString() 'debit DA Expense                            



                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString("N", New CultureInfo("en-US"))
                    'strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round((Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) * decVat), 2)).ToString("N", New CultureInfo("en-US"))

                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "1"  'debit
                    strBU = strUserBUH


                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = strAmnt
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU


                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    'strLeac = "EWT LEAC" 'EWT leac
                    strLeac = dtGetLedgerAcct.Rows(0)("Code").ToString()



                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2).ToString("N", New CultureInfo("en-US"))
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = strAmnt 'credit
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU


                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit - acrrual acct



                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2)).ToString("N", New CultureInfo("en-US"))
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    grdPrev2.Rows(ctr - 1).Cells(0).Value = strRcjn
                    grdPrev2.Rows(ctr - 1).Cells(1).Value = strLino
                    grdPrev2.Rows(ctr - 1).Cells(2).Value = strBPCode
                    grdPrev2.Rows(ctr - 1).Cells(3).Value = strLeac
                    grdPrev2.Rows(ctr - 1).Cells(4).Value = strDim1
                    grdPrev2.Rows(ctr - 1).Cells(5).Value = strDim2
                    grdPrev2.Rows(ctr - 1).Cells(6).Value = strDim3
                    grdPrev2.Rows(ctr - 1).Cells(7).Value = strDim4
                    grdPrev2.Rows(ctr - 1).Cells(8).Value = strDim5
                    grdPrev2.Rows(ctr - 1).Cells(9).Value = ""
                    grdPrev2.Rows(ctr - 1).Cells(10).Value = strAmnt 'credit
                    grdPrev2.Rows(ctr - 1).Cells(11).Value = strRefr
                    grdPrev2.Rows(ctr - 1).Cells(12).Value = strBU


                End If


            Else 'preview revised 04062015 

            End If

        Next
        Me.grdPrev2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        lblDownloadR.Enabled = True
        Button1.Enabled = False
        combxYear.Enabled = False
        combxSeries.Enabled = False
    End Sub
    Private Sub DownloadH(ByVal strPath As String)
        Dim strRcjn, strRcjd, strTtyp, strSer, strCur, _
            strRate, strBPCode, _
            strRate2, strRate3, strRatf1, _
            strRatf2, strRatf3, strBU As String

        'Dim strMonthinSer As String
        'Dim intMonthinSer As Integer

        Dim dtGetMaxRcjn, dtYrTtyp, dtForex As New DataTable()
        'Dim sw As New StreamWriter("E:\\Files\\Trade Investment- Subsystem\\Application\\" & "RH" &
        '                           DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
        '                           DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
        Dim sw As New StreamWriter(strPath & "\\H" &
                                   DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                   DateTime.Now.Year.ToString() & "_" & strBUCode & ".txt")
        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                              "WHERE Year=" & Integer.Parse(combxYear.SelectedValue.ToString()) & "AND BU='" &
                                              strUserBUH & "'")

        dtYrTtyp = BULibrary.SqlDataTable("SELECT * FROM tblYrTtyp WHERE Year=" & Integer.Parse(combxYear.SelectedValue.ToString()))

        dtForex = BULibrary.SqlDataTable("SELECT * FROM tblForexRate WHERE Currency = 'USD'")

        'strMonthinSer = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString().Substring(1, 2)       
        'intMonthinSer = Integer.Parse(strMonthinSer) + 1

        strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
        strRcjd = "Trade Investment Upload"
        'strTtyp = "J50"
        'strTtyp = dtYrTtyp.Rows(0)("Ttype").ToString()
        strTtyp = combxTransType.SelectedValue.ToString()
        strSer = Me.combxSeries.SelectedItem.ToString()
        strCur = "PHP"
        strBPCode = ""
        strRate = "1"
        'strRate2 = "45.7"
        strRate2 = dtForex.Rows(0)("Amount").ToString()
        strRate3 = "0"
        strRatf1 = "1"
        strRatf2 = "1"
        strRatf3 = "1"
        'strBU = strUserBUH
        strBU = strBUCode

        Using sw
            sw.WriteLine("|" & strRcjn & "|" & strRcjd & "|" & strTtyp & "|" &
                         strSer & "|" & strCur & "|" & strBPCode & "|" & strRate & "|" &
                         strRate2 & "|" & strRate3 & "|" & strRatf1 & "|" & strRatf2 & "|" &
                         strRatf3 & "|" & strBU & "|")
        End Using
        Try
            'BULibrary.GiveCredentials()
            BULibrary.CopyFile(strPath & "\\H" &
                                       DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                       DateTime.Now.Year.ToString() & "_" & strBUCode & ".txt", "\\10.10.1.84\\Docs\\Downloaded Files\\Header\\" & "H" &
                                       DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                       DateTime.Now.Year.ToString() & "_" & strBUCode & ".txt")
            'BULibrary.DeleteCredentials()
        Catch ex As Exception
            BULibrary.OpenSqlCon()
            BULibrary.InsertError("spInsertError", strUserIDH, "frmUploader", "FILE NAME CANT COPY", "HEADERFILE", DateTime.Now)
            BULibrary.CloseSqlCon()
        End Try
    End Sub
    Private Sub DownloadD(ByVal strPath As String)

        Dim ctrWriteLine As Integer = 1 'tentative ewt 020242014
        Dim strRcjn, strLino, _
               strBPCode, _
               strLeac, _
               strDim1, _
               strDim2, _
               strDim3, _
               strDim4, _
               strDim5, _
               strAmnt, _
               strCcty, _
               strCvat, _
               strVamt, _
               strQty1, _
               strQty2, _
               strRefr, _
               strDbcr, _
               strBU As String
        Dim strPrevBudgetID, strNewBudgetID As String
        Dim intPrevMonth, intNextMonth, intDivisor As Integer
        Dim decAccrual As Decimal
        Dim decVat As Decimal
        Dim decAccTax_Amt As Decimal
        Dim dtBClassMapping, _
            dtGetBudget, _
            dtGetMaxRcjn, _
            dtGetDetBudget, _
            dtGetNewDetBudget, _
            dtGetDim3PerBU, _
            dtGetDim5PerBU, _
            dtGetDim5For511, _
            dtGetVAT, _
            dtGetLedgerAcct, _
            dtGetDim4PerYr, _
            dtGetLeac As New DataTable()
        intDivisor = (12 - Integer.Parse(combxSeries.SelectedItem.ToString().Substring(2, 2))) + 1
        Dim ctr As Integer = 0
        'Dim sw As New StreamWriter("E:\\Files\\Trade Investment- Subsystem\\Application\\" & "RD" &
        '                           DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
        '                           DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
        Dim sw As New StreamWriter(strPath & "\\D" &
                                   DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                   DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")

        dtGetBudget = BULibrary.SqlDataTable("SELECT * FROM tblHeaderBudget " &
                                             "WHERE Year = " & Integer.Parse(combxYear.SelectedValue.ToString()) &
                                             " AND BusinessUnit='" &
                                             strUserBUH & "' AND RecurringJournal is NULL ")

        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
                                                  "WHERE Year=" & Integer.Parse(combxYear.SelectedValue.ToString()) & "AND BU='" &
                                              strUserBUH & "'")

        For a As Integer = 0 To dtGetBudget.Rows.Count - 1

            If dtGetBudget.Rows(a)("UploadSequenceNo").ToString() = "00" Then
                'download initial                
                dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                                                 "WHERE BudgetCode='" & dtGetBudget.Rows(a)("Budget").ToString() &
                                                 "'")
                'start 09202013
                dtGetDim3PerBU = BULibrary.GetDim3PerBU("spgetDim3PerBU", dtGetBudget.Rows(a)("Division").ToString())
                dtGetDim5PerBU = BULibrary.GetDim5PerBU("spgetDim5PerBU", strUserBUH)
                dtGetDim4PerYr = BULibrary.GetDim4PerYr("spgetDim4PerYr", combxYear.SelectedValue)
                'end 09202013
                dtGetVAT = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE Name='VAT'")
                decVat = Decimal.Parse(dtGetVAT.Rows(0)("Percentage").ToString())
                dtGetLedgerAcct = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE SystemID='" & dtGetBudget.Rows(a)("Tax").ToString() & "'")

                'start bitches!

                If dtGetBudget.Rows(a)("Tax").ToString() = "T04" Then 'sales discount
                    'DEBIT
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    'strLeac = dtBClassMapping.Rows(0)("ExpenseAcct").ToString() 'debit 
                    'strLeac = "SALES DISC LEAC" '- sales disc ledget acct       
                    strLeac = dtGetLedgerAcct.Rows(0)("Code").ToString() 'Sales Discount


                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "1"  'debit
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    'strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit
                    'If dtGetBudget.Rows(a)("GROUP2_CD").ToString() = "8000" Then
                    '    dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                    '                                             "WHERE BudgetCode = 'OTH'")
                    '    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString()
                    'Else
                    '    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit
                    'End If

                    strLeac = dtGetLedgerAcct.Rows(0)("Code2").ToString() 'Sales Discount Accrual Acct

                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                         "WHERE BudgetCode='" & dtGetBudget.Rows(a)("Budget").ToString() &
                             "'")
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"  'credit
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                ElseIf dtGetBudget.Rows(a)("Tax").ToString() = "T01" Then 'ewt 2%

                    'DEBIT
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("ExpenseAcct").ToString()


                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If


                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString()
                    'strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round((Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) * decVat), 2)).ToString("N", New CultureInfo("en-US"))

                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "1"  'debit
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    'strLeac = "EWT LEAC" 'EWT leac
                    strLeac = dtGetLedgerAcct.Rows(0)("Code").ToString()



                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If



                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit - acrrual acct


                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If


                    strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2)).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                ElseIf dtGetBudget.Rows(a)("Tax").ToString() = "T02" Then 'ewt 5%

                    'DEBIT
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("ExpenseAcct").ToString() 'debit DA Expense                            


                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If


                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2).ToString()
                    'strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round((Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) * decVat), 2)).ToString("N", New CultureInfo("en-US"))

                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "1"  'debit
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    'strLeac = "EWT LEAC" 'EWT leac
                    strLeac = dtGetLedgerAcct.Rows(0)("Code").ToString()


                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If


                    strAmnt = Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                    'CREDIT            
                    ctr = ctr + 1
                    strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                    strLino = ctr
                    strBPCode = dtGetBudget.Rows(a)("BPCode").ToString()
                    strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString() 'Credit - acrrual acct


                    dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                    If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                        strDim1 = ""
                    Else
                        strDim1 = dtBClassMapping.Rows(0)("Dim1").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM2_USED_CD").ToString()) = 1 Then
                        strDim2 = ""
                    Else
                        strDim2 = dtBClassMapping.Rows(0)("Dim2").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM3_USED_CD").ToString()) = 1 Then
                        strDim3 = ""
                    Else
                        strDim3 = dtGetDim3PerBU.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM4_USED_CD").ToString()) = 1 Then
                        strDim4 = ""
                    Else
                        strDim4 = dtGetDim4PerYr.Rows(0)("Code").ToString()
                    End If

                    If Integer.Parse(dtGetLeac.Rows(0)("DIM5_USED_CD").ToString()) = 1 Then
                        strDim5 = ""
                    Else
                        If strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Kapal Api" Then
                            'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "511" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Canned" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        ElseIf strUserBUH = "211" And dtGetBudget.Rows(a)("Division").ToString() = "Frozen" Then
                            dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(a)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                            strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                        Else
                            strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                        End If
                    End If


                    strAmnt = (Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Amount").ToString() / intDivisor), 2) - Math.Round(Decimal.Parse(dtGetBudget.Rows(a)("Tax_Amount").ToString() / intDivisor), 2)).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = dtGetBudget.Rows(a)("BudgetID").ToString()
                    strDbcr = "2"
                    strBU = strUserBUH

                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                End If


                'end bitches!

            Else 'download revised 04062015

            End If
        Next
        sw.Close()
        sw.Dispose()
        Try
            'BULibrary.GiveCredentials()
            BULibrary.CopyFile(strPath & "\\D" &
                                DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt", "\\10.10.1.84\\Docs\\Downloaded Files\\Detail\\" & "D" &
                               DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                               DateTime.Now.Year.ToString() & "_" & strUserBUH & ".txt")
            'BULibrary.DeleteCredentials()
        Catch ex As Exception
            BULibrary.OpenSqlCon()
            BULibrary.InsertError("spInsertError", strUserIDH, "frmUploader", "FILE NAME CANT COPY", "DETAILFILE", DateTime.Now)
            BULibrary.CloseSqlCon()
        End Try
        For b As Integer = 0 To dtGetBudget.Rows.Count - 1

            BULibrary.OpenSqlCon()

            BULibrary.UpdateHdrBudget("spUpdateHdrBudget", dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString(), _
                                      dtGetBudget.Rows(b)("BudgetID").ToString())

            BULibrary.CloseSqlCon()

        Next

    End Sub

    Private Sub grpBoxR_Enter(sender As System.Object, e As System.EventArgs) Handles grpBoxR.Enter

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
    End Sub

    Private Sub combxInstance_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles combxInstance.SelectedIndexChanged
        ''05202014
        Dim dtGetBUCode As New DataTable()
        If combxInstance.SelectedItem.ToString() = "CPG" Then
            dtGetBUCode = BULibrary.SqlDataTable("SELECT * FROM tblBusinessUnits where BUCode=" & strUserBUH)
            strBUCode = dtGetBUCode.Rows(0)("CPG_Code").ToString()
        ElseIf combxInstance.SelectedItem.ToString() = "BU1" Then
            dtGetBUCode = BULibrary.SqlDataTable("SELECT * FROM tblBusinessUnits where BUCode=" & strUserBUH)
            strBUCode = dtGetBUCode.Rows(0)("BUCode").ToString()
        Else
            dtGetBUCode = BULibrary.SqlDataTable("SELECT * FROM tblBusinessUnits where BUCode=" & strUserBUH)
            strBUCode = dtGetBUCode.Rows(0)("BU2_Code").ToString()
        End If
    End Sub

    Private Sub combxYear_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles combxYear.SelectedIndexChanged

    End Sub
End Class