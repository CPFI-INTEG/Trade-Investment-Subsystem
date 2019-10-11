Imports System.IO
Imports System.Globalization
Public Class RevisedAccrual
    Dim strUserIDH, strUserBUH, strUserPermissionH, strBUCode As String
    Dim BULibrary As New TIBudgetUploader.BULibrary()
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDH = strUserID
        strUserBUH = strUserBU
        strBUCode = strUserBU
    End Sub
    Private Sub RevisedAccrual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load        
        LoadForm()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnPreview_Click(sender As System.Object, e As System.EventArgs) Handles btnPreview.Click
        DataGridView1.Columns.Clear()
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
        Dim ctr As Integer = 0
        Dim dtRevAccrual, dtGetBudget, dtGetMaxRcjn, _
            dtBClassMapping, dtGetDim3PerBU, dtGetDim5PerBU, _
            dtGetDim4PerYr, dtGetLedgerAcct, dtGetLeac, dtGetDim5For511 As DataTable
        dtRevAccrual = BULibrary.SqlDataTable("spGenerateAccrual " & Integer.Parse(combxMonth.SelectedValue.ToString()) & ", " & strUserBUH) '04102015
        dtGetBudget = BULibrary.SqlDataTable("SELECT * FROM tblHeaderBudget " &
                                     "WHERE Year = " & combxYear.SelectedValue.ToString() &
                                     " AND BusinessUnit='" &
                                     strUserBUH & "' AND RecurringJournal is NULL AND UploadSequenceNo<>'00'") 'modified 04142015        
        'dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
        '                                  "WHERE Year=" & combxYear.SelectedValue & " AND BU='" &
        '                              strUserBUH & "'")
        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MIN(RecurringJournal) as MaxRcjn FROM tblRecurringJournals WHERE Year=" &
                                      Integer.Parse(combxYear.SelectedValue.ToString()) & " AND BU='" &
                                      strUserBUH & "' AND USERID=''")
        DataGridView1.Columns.Add("Rcjn", "Recurring Journal") '0
        DataGridView1.Columns.Add("Lino", "Line No") '1
        DataGridView1.Columns.Add("BPCode", "Customer") '2
        DataGridView1.Columns.Add("LedgerAcct", "Ledger Account") '3
        DataGridView1.Columns.Add("Dim1", "Dimension 1") '4
        DataGridView1.Columns.Add("Dim2", "Dimension 2") '5
        DataGridView1.Columns.Add("Dim3", "Dimension 3") '6
        DataGridView1.Columns.Add("Dim4", "Dimension 4") '7
        DataGridView1.Columns.Add("Dim5", "Dimension 5") '8
        DataGridView1.Columns.Add("Debit", "Debit") '9
        DataGridView1.Columns.Add("Credit", "Credit") '10
        DataGridView1.Columns.Add("BudgetID", "Transaction Reference") '11
        DataGridView1.Columns.Add("BU", "Company Code") '12        
        DataGridView1.Rows.Add((dtGetBudget.Rows.Count) * 5) 'tentative ewt 02042014

        For i As Integer = 0 To dtGetBudget.Rows.Count - 1
            'start validations
            dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                                 "WHERE BudgetCode='" & dtGetBudget.Rows(i)("Budget").ToString() &
                                 "'")

            If dtBClassMapping.Rows.Count = 0 Then
                MsgBox("There are no Budget Class Mapping maintained! Please contact your system administrator!", MsgBoxStyle.Critical)
                Return
            End If
            dtGetDim3PerBU = BULibrary.GetDim3PerBU("spgetDim3PerBU", dtGetBudget.Rows(i)("Division").ToString())

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
            'end validations

            dtGetLedgerAcct = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE SystemID='" & dtGetBudget.Rows(i)("Tax").ToString() & "'")

            'preview of accruals
            If dtGetBudget.Rows(i)("Tax").ToString() = "T02" Or dtGetBudget.Rows(i)("Tax").ToString() = "T01" Then 'T02 EWT 5% or T01 EWT 2%
                'DEBIT Expense
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If

                strAmnt = Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()).ToString("N", New CultureInfo("en-US")) 'adjustment entry amt
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "1"  'debit
                strBU = strUserBUH


                DataGridView1.Rows(ctr - 1).Cells(0).Value = strRcjn
                DataGridView1.Rows(ctr - 1).Cells(1).Value = strLino
                DataGridView1.Rows(ctr - 1).Cells(2).Value = strBPCode
                DataGridView1.Rows(ctr - 1).Cells(3).Value = strLeac
                DataGridView1.Rows(ctr - 1).Cells(4).Value = strDim1
                DataGridView1.Rows(ctr - 1).Cells(5).Value = strDim2
                DataGridView1.Rows(ctr - 1).Cells(6).Value = strDim3
                DataGridView1.Rows(ctr - 1).Cells(7).Value = strDim4
                DataGridView1.Rows(ctr - 1).Cells(8).Value = strDim5
                DataGridView1.Rows(ctr - 1).Cells(9).Value = strAmnt
                DataGridView1.Rows(ctr - 1).Cells(10).Value = ""
                DataGridView1.Rows(ctr - 1).Cells(11).Value = strRefr
                DataGridView1.Rows(ctr - 1).Cells(12).Value = strBU

                'CREDIT EWT
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If

                strAmnt = Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()) * Decimal.Parse(dtGetLedgerAcct.Rows(0)("Percentage").ToString()), 2).ToString("N", New CultureInfo("en-US"))
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "2"  'credit
                strBU = strUserBUH


                DataGridView1.Rows(ctr - 1).Cells(0).Value = strRcjn
                DataGridView1.Rows(ctr - 1).Cells(1).Value = strLino
                DataGridView1.Rows(ctr - 1).Cells(2).Value = strBPCode
                DataGridView1.Rows(ctr - 1).Cells(3).Value = strLeac
                DataGridView1.Rows(ctr - 1).Cells(4).Value = strDim1
                DataGridView1.Rows(ctr - 1).Cells(5).Value = strDim2
                DataGridView1.Rows(ctr - 1).Cells(6).Value = strDim3
                DataGridView1.Rows(ctr - 1).Cells(7).Value = strDim4
                DataGridView1.Rows(ctr - 1).Cells(8).Value = strDim5
                DataGridView1.Rows(ctr - 1).Cells(9).Value = ""
                DataGridView1.Rows(ctr - 1).Cells(10).Value = strAmnt
                DataGridView1.Rows(ctr - 1).Cells(11).Value = strRefr
                DataGridView1.Rows(ctr - 1).Cells(12).Value = strBU

                'CREDIT ACCRUAL
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
                strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString()

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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If

                strAmnt = Math.Round((Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()) - Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()) * Decimal.Parse(dtGetLedgerAcct.Rows(0)("Percentage").ToString()), 2)), 2).ToString("N", New CultureInfo("en-US"))
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "2"  'credit
                strBU = strUserBUH


                DataGridView1.Rows(ctr - 1).Cells(0).Value = strRcjn
                DataGridView1.Rows(ctr - 1).Cells(1).Value = strLino
                DataGridView1.Rows(ctr - 1).Cells(2).Value = strBPCode
                DataGridView1.Rows(ctr - 1).Cells(3).Value = strLeac
                DataGridView1.Rows(ctr - 1).Cells(4).Value = strDim1
                DataGridView1.Rows(ctr - 1).Cells(5).Value = strDim2
                DataGridView1.Rows(ctr - 1).Cells(6).Value = strDim3
                DataGridView1.Rows(ctr - 1).Cells(7).Value = strDim4
                DataGridView1.Rows(ctr - 1).Cells(8).Value = strDim5
                DataGridView1.Rows(ctr - 1).Cells(9).Value = ""
                DataGridView1.Rows(ctr - 1).Cells(10).Value = strAmnt
                DataGridView1.Rows(ctr - 1).Cells(11).Value = strRefr
                DataGridView1.Rows(ctr - 1).Cells(12).Value = strBU
            Else 'Sales Discount

                'DEBIT
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(1)("BPCode").ToString()
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(i)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(i)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If


                strAmnt = Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()), 2).ToString("N", New CultureInfo("en-US"))
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "1"  'debit
                strBU = strUserBUH


                DataGridView1.Rows(ctr - 1).Cells(0).Value = strRcjn
                DataGridView1.Rows(ctr - 1).Cells(1).Value = strLino
                DataGridView1.Rows(ctr - 1).Cells(2).Value = strBPCode
                DataGridView1.Rows(ctr - 1).Cells(3).Value = strLeac
                DataGridView1.Rows(ctr - 1).Cells(4).Value = strDim1
                DataGridView1.Rows(ctr - 1).Cells(5).Value = strDim2
                DataGridView1.Rows(ctr - 1).Cells(6).Value = strDim3
                DataGridView1.Rows(ctr - 1).Cells(7).Value = strDim4
                DataGridView1.Rows(ctr - 1).Cells(8).Value = strDim5
                DataGridView1.Rows(ctr - 1).Cells(9).Value = strAmnt
                DataGridView1.Rows(ctr - 1).Cells(10).Value = ""
                DataGridView1.Rows(ctr - 1).Cells(11).Value = strRefr
                DataGridView1.Rows(ctr - 1).Cells(12).Value = strBU

                'CREDIT            
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
                strLeac = dtGetLedgerAcct.Rows(0)("Code2").ToString() 'Sales Discount Accrual Acct 04142015

                dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                    strDim1 = ""
                Else
                    dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                             "WHERE BudgetCode='" & dtGetBudget.Rows(i)("Budget").ToString() &
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If


                strAmnt = Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()), 2).ToString("N", New CultureInfo("en-US"))
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "2"  'credit
                strBU = strUserBUH

                DataGridView1.Rows(ctr - 1).Cells(0).Value = strRcjn
                DataGridView1.Rows(ctr - 1).Cells(1).Value = strLino
                DataGridView1.Rows(ctr - 1).Cells(2).Value = strBPCode
                DataGridView1.Rows(ctr - 1).Cells(3).Value = strLeac
                DataGridView1.Rows(ctr - 1).Cells(4).Value = strDim1
                DataGridView1.Rows(ctr - 1).Cells(5).Value = strDim2
                DataGridView1.Rows(ctr - 1).Cells(6).Value = strDim3
                DataGridView1.Rows(ctr - 1).Cells(7).Value = strDim4
                DataGridView1.Rows(ctr - 1).Cells(8).Value = strDim5
                DataGridView1.Rows(ctr - 1).Cells(9).Value = ""
                DataGridView1.Rows(ctr - 1).Cells(10).Value = strAmnt
                DataGridView1.Rows(ctr - 1).Cells(11).Value = strRefr
                DataGridView1.Rows(ctr - 1).Cells(12).Value = strBU

            End If
        Next
        btnDownload.Enabled = True
    End Sub

    Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs) Handles btnDownload.Click
        Dim fBrowse As New FolderBrowserDialog
        Dim dtGetMaxRcjn As DataTable
        With fBrowse
            .Description = "Choose Destination"
            .ShowNewFolderButton = True
        End With
        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then

            DownloadH(fBrowse.SelectedPath)
            DownloadD(fBrowse.SelectedPath)
            BULibrary.OpenSqlCon()            
            'dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MAX(RecurringJournal) as MaxRcjn FROM tblRecurringJournals " &
            '                                 "WHERE Year=" & Integer.Parse(combxYear.SelectedValue.ToString()) & "AND BU='" &
            '                                strUserBUH & "'")
            dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MIN(RecurringJournal) as MaxRcjn FROM tblRecurringJournals WHERE Year=" &
                                                  Integer.Parse(combxYear.SelectedValue.ToString()) & " AND BU='" &
                                                  strUserBUH & "' AND USERID=''")
            BULibrary.SqlUpdate("UPDATE tblRecurringJournals SET DateDownloaded='" & DateTime.Now &
                                "', UserID='" & strUserIDH & "', Downloaded=1 WHERE BU=" &
                                Integer.Parse(strUserBUH) & " AND RecurringJournal='" &
                                dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString() & "'")
            BULibrary.CloseSqlCon()

            MsgBox("File downloaded!", MsgBoxStyle.Information)
        End If
        btnDownload.Enabled = False
        LoadForm()
    End Sub

    Private Sub DownloadH(ByVal strPath As String)
        Dim strRcjn, strRcjd, strTtyp, strSer, strCur, _
           strRate, strBPCode, _
           strRate2, strRate3, strRatf1, _
           strRatf2, strRatf3, strBU As String


        Dim dtGetMaxRcjn, dtYrTtyp, dtForex As New DataTable()
        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MIN(RecurringJournal) as MaxRcjn FROM tblRecurringJournals WHERE Year=" &
                                              Integer.Parse(combxYear.SelectedValue.ToString()) & " AND BU='" &
                                              strUserBUH & "' AND USERID=''")

        dtYrTtyp = BULibrary.SqlDataTable("SELECT * FROM tblYrTtyp WHERE Year=" & Integer.Parse(combxYear.SelectedValue.ToString()))

        dtForex = BULibrary.SqlDataTable("SELECT * FROM tblForexRate WHERE Currency = 'USD'")
        Dim sw As New StreamWriter(strPath & "\\H" &
                           DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                           DateTime.Now.Year.ToString() & "_" & strBUCode & "_" & dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString() &
                           "_" & combxMonth.SelectedValue.ToString() & ".txt")

        strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
        strRcjd = "Trade Investment Upload"
        strTtyp = combxTtyp.SelectedValue.ToString()
        strSer = "0000"
        strCur = "PHP"
        strBPCode = ""
        strRate = "1"        
        strRate2 = dtForex.Rows(0)("Amount").ToString()
        strRate3 = "0"
        strRatf1 = "1"
        strRatf2 = "1"
        strRatf3 = "1"        
        strBU = strBUCode

        Using sw
            sw.WriteLine("|" & strRcjn & "|" & strRcjd & "|" & strTtyp & "|" &
                         strSer & "|" & strCur & "|" & strBPCode & "|" & strRate & "|" &
                         strRate2 & "|" & strRate3 & "|" & strRatf1 & "|" & strRatf2 & "|" &
                         strRatf3 & "|" & strBU & "|")
        End Using
    End Sub

    Private Sub DownloadD(ByVal strPath As String)
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
        Dim ctr As Integer = 0
        Dim dtRevAccrual, dtGetBudget, dtGetMaxRcjn, _
            dtBClassMapping, dtGetDim3PerBU, dtGetDim5PerBU, _
            dtGetDim4PerYr, dtGetLedgerAcct, dtGetLeac, dtGetDim5For511 As DataTable
        dtRevAccrual = BULibrary.SqlDataTable("spGenerateAccrual " & Integer.Parse(combxMonth.SelectedValue.ToString()) & ", " & strUserBUH) '04102015
        dtGetBudget = BULibrary.SqlDataTable("SELECT * FROM tblHeaderBudget " &
                                     "WHERE Year = " & combxYear.SelectedValue.ToString() &
                                     " AND BusinessUnit='" &
                                     strUserBUH & "' AND RecurringJournal is NULL AND UploadSequenceNo<>'00'") 'modified 04142015        
        dtGetMaxRcjn = BULibrary.SqlDataTable("SELECT MIN(RecurringJournal) as MaxRcjn FROM tblRecurringJournals WHERE Year=" &
                                              Integer.Parse(combxYear.SelectedValue.ToString()) & " AND BU='" &
                                              strUserBUH & "' AND USERID=''")
        Dim sw As New StreamWriter(strPath & "\\D" &
                                  DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                  DateTime.Now.Year.ToString() & "_" & strUserBUH & "_" & dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString() &
                                  "_" & combxMonth.SelectedValue.ToString() & ".txt")

        For i As Integer = 0 To dtGetBudget.Rows.Count - 1            
            dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                                 "WHERE BudgetCode='" & dtGetBudget.Rows(i)("Budget").ToString() &
                                 "'")
            dtGetDim3PerBU = BULibrary.GetDim3PerBU("spgetDim3PerBU", dtGetBudget.Rows(i)("Division").ToString())
            dtGetDim5PerBU = BULibrary.GetDim5PerBU("spgetDim5PerBU", strUserBUH)
            dtGetDim4PerYr = BULibrary.GetDim4PerYr("spgetDim4PerYr", combxYear.SelectedValue)
            dtGetLedgerAcct = BULibrary.SqlDataTable("SELECT * FROM tblTax WHERE SystemID='" & dtGetBudget.Rows(i)("Tax").ToString() & "'")

            'writing of accruals
            If dtGetBudget.Rows(i)("Tax").ToString() = "T02" Or dtGetBudget.Rows(i)("Tax").ToString() = "T01" Then 'T02 EWT 5% or T01 EWT 2%
                'DEBIT Expense
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If

                strAmnt = Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()).ToString() 'adjustment entry amt
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "1"  'debit
                strBU = strUserBUH


                sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")


                'CREDIT EWT
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If

                strAmnt = Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()) * Decimal.Parse(dtGetLedgerAcct.Rows(0)("Percentage").ToString()), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "2"  'credit
                strBU = strUserBUH


                sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")


                'CREDIT ACCRUAL
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
                strLeac = dtBClassMapping.Rows(0)("AccrualAcct").ToString()

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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If

                strAmnt = Math.Round((Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()) - Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()) * Decimal.Parse(dtGetLedgerAcct.Rows(0)("Percentage").ToString()), 2)), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "2"  'credit
                strBU = strUserBUH


                sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")
            Else 'Sales Discount

                'DEBIT
                ctr = ctr + 1
                strRcjn = dtGetMaxRcjn.Rows(0)("MaxRcjn").ToString()
                strLino = ctr
                strBPCode = dtGetBudget.Rows(1)("BPCode").ToString()
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(i)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(i)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If


                strAmnt = Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
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
                strBPCode = dtGetBudget.Rows(i)("BPCode").ToString()
                strLeac = dtGetLedgerAcct.Rows(0)("Code2").ToString() 'Sales Discount Accrual Acct 04142015

                dtGetLeac = BULibrary.GetLeac("spgetLeac", Integer.Parse(strLeac))
                If Integer.Parse(dtGetLeac.Rows(0)("DIM1_USED_CD").ToString()) = 1 Then
                    strDim1 = ""
                Else
                    dtBClassMapping = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                             "WHERE BudgetCode='" & dtGetBudget.Rows(i)("Budget").ToString() &
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
                    If strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Kapal Api" Then
                        'strDim5 = combxDim5.SelectedValue.ToString() '01202014
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "511" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Canned" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    ElseIf strUserBUH = "211" And dtGetBudget.Rows(i)("Division").ToString() = "Frozen" Then
                        dtGetDim5For511 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE Name ='" & dtGetBudget.Rows(i)("Division").ToString() & "' AND BU='" & strUserBUH & "'")
                        strDim5 = dtGetDim5For511.Rows(0)("Code").ToString()
                    Else
                        strDim5 = dtGetDim5PerBU.Rows(0)("Code").ToString() '01202014
                    End If
                End If


                strAmnt = Math.Round(Decimal.Parse(dtRevAccrual.Rows(0)("EntryAmt").ToString()), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = dtGetBudget.Rows(i)("BudgetID").ToString()
                strDbcr = "2"  'credit
                strBU = strUserBUH

                sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

            End If
        Next
        sw.Close()
        sw.Dispose()
    End Sub

    Private Sub InsertInitialRcjn()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetMaxRcjn, dt As New DataTable()
        Dim strSeries, strMonth As String
        Dim intMaxRcjno As Integer
        Dim c As Char
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

    Private Sub LoadForm()
        btnDownload.Enabled = False
        Dim dtDivision, dtYr, dtMonth, dtTtyp As DataTable
        dtDivision = BULibrary.SqlDataTable("SELECT BUCode, BUCode + '-' + Name AS BUName FROM tblBUsinessUnits WHERE BUCode=" &
                                            Integer.Parse(strUserBUH) & " ORDER BY 1")
        combxDivision.DataSource = dtDivision
        combxDivision.DisplayMember = "BUName"
        combxDivision.ValueMember = "BUCode"

        dtYr = BULibrary.SqlDataTable("SELECT DISTINCT Year FROM tblHeaderBudget ORDER BY 1 DESC")
        combxYear.DataSource = dtYr
        combxYear.DisplayMember = "Year"
        combxYear.ValueMember = "Year"

        'dtMonth = BULibrary.SqlDataTable("SELECT PERIOD FROM PERIOD_STATUS WHERE F_GLD='Open' " &
        '                                 "AND COMPANY_CD=" & Integer.Parse(strUserBUH) &
        '                                 " AND Year=" & Integer.Parse(combxYear.SelectedValue.ToString()) &
        '                                 " AND PERIOD <> 13")

        dtMonth = BULibrary.SqlDataTable("SELECT Month, Series FROM tblRecurringJournals WHERE BU=" & strUserBUH &
                                         " AND Year=" & Integer.Parse(combxYear.SelectedValue.ToString()) &
                                         " AND UserID='' AND Downloaded=0")
        combxMonth.DataSource = dtMonth
        combxMonth.DisplayMember = "Month"
        combxMonth.ValueMember = "Month"

        dtTtyp = BULibrary.SqlDataTable("SELECT * FROM tblYrTtyp WHERE Year=" & Date.Now.Year)
        combxTtyp.DataSource = dtTtyp
        combxTtyp.DisplayMember = "Ttype"
        combxTtyp.ValueMember = "Ttype"
    End Sub


End Class