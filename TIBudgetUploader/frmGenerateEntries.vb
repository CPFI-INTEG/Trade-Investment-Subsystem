Imports System.IO
Public Class frmGenerateEntries
    Dim BULibrary As New TIBudgetUploader.BULibrary()
    Private Sub frmGenerateEntries_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim dtComp As New DataTable()
        dtComp = BULibrary.SqlDataTable("SELECT * FROM tblBusinessUnits where BUCode not in (310,111) order by 1")

        ComboBox2.DataSource = dtComp
        ComboBox2.DisplayMember = "Name"
        ComboBox2.ValueMember = "BUCode"

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs)

        Preview(ComboBox2.SelectedValue.ToString())

    End Sub

    Private Sub Preview(ByVal comp As String)
        Dim dtFromUpload, dtMapB1Entries, dtDim5, dtNormalEntries As New DataTable()
        Dim strRcjn, strLino,
              strBPCode,
              strLeac,
              strDim1,
              strDim2,
              strDim3,
              strDim4,
              strDim5,
              strAmnt,
              strCcty,
              strCvat,
              strVamt,
              strQty1,
              strQty2,
              strRefr,
              strDbcr,
              strBU As String
        Dim ctr As Integer = 0

        dtFromUpload = BULibrary.SqlDataTable("SELECT * FROM [TradeInvDB_LIVE].[dbo].[From_Upload] WHERE BU='" & ComboBox2.SelectedValue & "'")

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
        DataGridView1.Rows.Add((dtFromUpload.Rows.Count) * 5)

        For i As Integer = 0 To dtFromUpload.Rows.Count - 1
            'If IsDBNull(dtFromUpload.Rows(i)("Budget").ToString()) = False Or IsDBNull(dtFromUpload.Rows(i)("Budget").ToString()) = False Then
            '    MsgBox(Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString())
            '    MsgBox(dtFromUpload.Rows(i)("Budget").ToString())
            'End If


            'dtMapB1Entries = BULibrary.SqlDataTable("SELECT * FROM tblMappingEntries " & _
            '                                          "WHERE BPCode='" & Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString() & "'" &
            '                                          " AND Budget='" & dtFromUpload.Rows(i)("Budget").ToString() & "'" &
            '                                          " AND Percentage <> '' ")

            dtMapB1Entries = BULibrary.SqlDataTable("SELECT * FROM tblMappingEntries " &
                                          "WHERE BPCode='" & IIf(IsDBNull(dtFromUpload.Rows(i)("BPCode")) = True, "", dtFromUpload.Rows(i)("BPCode")) & "'" &
                                          " AND Budget='" & IIf(IsDBNull(dtFromUpload.Rows(i)("Budget")) = True, "", dtFromUpload.Rows(i)("Budget")) & "'" &
                                          " AND Percentage <> '' ")

            dtDim5 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE BU=" & dtFromUpload.Rows(i)("BU").ToString() &
                                            " AND Division='" & dtFromUpload.Rows(i)("Division").ToString() & "'")

            If dtMapB1Entries.Rows.Count > 0 Then
                'special entries here
                'DEBIT Expense
                '---------------------------------------------------------
                ctr = ctr + 1
                strRcjn = TextBox3.Text
                strLino = ctr
                strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString()
                strLeac = dtMapB1Entries.Rows(0)("DEBIT").ToString()
                strDim1 = dtMapB1Entries.Rows(0)("DIM 1").ToString()
                strDim2 = "613002"
                strDim3 = "201100"
                If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                    strDim3 = "201400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                    strDim3 = "201200"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "BANGUS" Then
                    strDim3 = "202105"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "HUNTS" Then
                    strDim3 = "252400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "EINSTEIN" Then
                    strDim3 = "253100"

                End If
                strDim4 = "YR2019"
                strDim5 = dtDim5.Rows(0)("Code").ToString()
                strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = TextBox4.Text
                strDbcr = "1"  'debit
                strBU = ComboBox2.SelectedValue.ToString()

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
                '--------------------------------------------------------------- ------------

                'CREDIT Accrued
                ctr = ctr + 1
                strRcjn = TextBox3.Text
                strLino = ctr
                strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString
                strLeac = dtMapB1Entries.Rows(0)("CREDIT_1").ToString()
                strDim1 = dtMapB1Entries.Rows(0)("DIM 1").ToString()
                strDim2 = "613002"
                strDim3 = "201100"
                If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                    strDim3 = "201400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                    strDim3 = "201200"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "BANGUS" Then
                    strDim3 = "202105"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "HUNTS" Then
                    strDim3 = "252400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "EINSTEIN" Then
                    strDim3 = "253100"
                End If

                strDim4 = "YR2019"
                strDim5 = dtDim5.Rows(0)("Code").ToString()
                strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()) - (Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()) * Decimal.Parse(dtMapB1Entries.Rows(0)("Percentage").ToString())), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = TextBox4.Text
                strDbcr = "2"  'credit
                strBU = ComboBox2.SelectedValue.ToString()

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

                'CREDIT EWT
                '-------------------------------------------------
                If Trim(dtMapB1Entries.Rows(0)("CREDIT_2").ToString()) <> "" Then


                    ctr = ctr + 1
                    strRcjn = TextBox3.Text
                    strLino = ctr
                    strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString
                    strLeac = dtMapB1Entries.Rows(0)("CREDIT_2").ToString()
                    strDim1 = dtMapB1Entries.Rows(0)("DIM 1").ToString()
                    strDim2 = ""
                    strDim3 = "201100"
                    If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                        strDim3 = "201400"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                        strDim3 = "201200"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "BANGUS" Then
                        strDim3 = "202105"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "HUNTS" Then
                        strDim3 = "252400"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "EINSTEIN" Then
                        strDim3 = "253100"

                    End If
                    strDim4 = "YR2019"
                    strDim5 = dtDim5.Rows(0)("Code").ToString()
                    strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()) * Decimal.Parse(dtMapB1Entries.Rows(0)("Percentage").ToString()), 2).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = TextBox4.Text
                    strDbcr = "2"  'credit
                    strBU = ComboBox2.SelectedValue.ToString()

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

                'Else
                '    'normal entries here
                '    dtNormalEntries = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                '                                             "WHERE BudgetName='" & dtFromUpload.Rows(i)("Budget").ToString() & "'")

                '    'DEBIT Expense
                '    ctr = ctr + 1
                '    strRcjn = TextBox3.Text
                '    strLino = ctr
                '    strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString()
                '    strLeac = "1111111111"
                '    strDim1 = dtNormalEntries.Rows(0)("Dim1").ToString()
                '    strDim2 = "613002"
                '    strDim3 = "201100"
                '    If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                '        strDim3 = "201400"
                '    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                '        strDim3 = "201200"
                '    End If
                '    strDim4 = "YR2019"
                '    strDim5 = dtDim5.Rows(0)("Code").ToString()
                '    strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()), 2).ToString()
                '    strCcty = "PHI"
                '    strCvat = "V00"
                '    strVamt = "0"
                '    strQty1 = "0"
                '    strQty2 = "0"
                '    strRefr = TextBox4.Text
                '    strDbcr = "1"  'debit
                '    strBU = ComboBox2.SelectedValue.ToString()

                '    DataGridView1.Rows(ctr - 1).Cells(0).Value = strRcjn
                '    DataGridView1.Rows(ctr - 1).Cells(1).Value = strLino
                '    DataGridView1.Rows(ctr - 1).Cells(2).Value = strBPCode
                '    DataGridView1.Rows(ctr - 1).Cells(3).Value = strLeac
                '    DataGridView1.Rows(ctr - 1).Cells(4).Value = strDim1
                '    DataGridView1.Rows(ctr - 1).Cells(5).Value = strDim2
                '    DataGridView1.Rows(ctr - 1).Cells(6).Value = strDim3
                '    DataGridView1.Rows(ctr - 1).Cells(7).Value = strDim4
                '    DataGridView1.Rows(ctr - 1).Cells(8).Value = strDim5
                '    DataGridView1.Rows(ctr - 1).Cells(9).Value = strAmnt
                '    DataGridView1.Rows(ctr - 1).Cells(10).Value = ""
                '    DataGridView1.Rows(ctr - 1).Cells(11).Value = strRefr
                '    DataGridView1.Rows(ctr - 1).Cells(12).Value = strBU


                '    'CREDIT Accrued
                '    ctr = ctr + 1
                '    strRcjn = TextBox3.Text
                '    strLino = ctr
                '    strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString()
                '    strLeac = "1111111111"
                '    strDim1 = dtNormalEntries.Rows(0)("Dim1").ToString()
                '    strDim2 = "613002"
                '    strDim3 = "201100"
                '    If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                '        strDim3 = "201400"
                '    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                '        strDim3 = "201200"
                '    End If
                '    strDim4 = "YR2019"
                '    strDim5 = dtDim5.Rows(0)("Code").ToString()
                '    strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()), 2).ToString()
                '    strCcty = "PHI"
                '    strCvat = "V00"
                '    strVamt = "0"
                '    strQty1 = "0"
                '    strQty2 = "0"
                '    strRefr = TextBox4.Text
                '    strDbcr = "2"  'credit
                '    strBU = ComboBox2.SelectedValue.ToString()

                '    DataGridView1.Rows(ctr - 1).Cells(0).Value = strRcjn
                '    DataGridView1.Rows(ctr - 1).Cells(1).Value = strLino
                '    DataGridView1.Rows(ctr - 1).Cells(2).Value = strBPCode
                '    DataGridView1.Rows(ctr - 1).Cells(3).Value = strLeac
                '    DataGridView1.Rows(ctr - 1).Cells(4).Value = strDim1
                '    DataGridView1.Rows(ctr - 1).Cells(5).Value = strDim2
                '    DataGridView1.Rows(ctr - 1).Cells(6).Value = strDim3
                '    DataGridView1.Rows(ctr - 1).Cells(7).Value = strDim4
                '    DataGridView1.Rows(ctr - 1).Cells(8).Value = strDim5
                '    DataGridView1.Rows(ctr - 1).Cells(9).Value = ""
                '    DataGridView1.Rows(ctr - 1).Cells(10).Value = strAmnt
                '    DataGridView1.Rows(ctr - 1).Cells(11).Value = strRefr
                '    DataGridView1.Rows(ctr - 1).Cells(12).Value = strBU
            End If

        Next

    End Sub
    Private Sub Download(ByVal comp As String, ByVal strpath As String)
        Dim dtFromUpload, dtMapB1Entries, dtDim5, dtNormalEntries As New DataTable()
        Dim strRcjn, strLino,
              strBPCode,
              strLeac,
              strDim1,
              strDim2,
              strDim3,
              strDim4,
              strDim5,
              strAmnt,
              strCcty,
              strCvat,
              strVamt,
              strQty1,
              strQty2,
              strRefr,
              strDbcr,
              strBU As String
        Dim ctr As Integer = 0
        Dim sw As New StreamWriter(strpath & "\\D" &
                           DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                           DateTime.Now.Year.ToString() & "_" & ComboBox2.SelectedValue.ToString() & "_" & TextBox3.Text & ".txt")

        dtFromUpload = BULibrary.SqlDataTable("SELECT * FROM From_Upload WHERE BU='" & ComboBox2.SelectedValue & "'")

        For i As Integer = 0 To dtFromUpload.Rows.Count - 1
            '    dtMapB1Entries = BULibrary.SqlDataTable("SELECT * FROM tblMappingEntries " & "WHERE BPCode='" & Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString() & "'" &
            '                                            " AND Budget='" & dtFromUpload.Rows(i)("Budget").ToString() & "'" &
            '                                            " AND Percentage <> '' ")

            dtMapB1Entries = BULibrary.SqlDataTable("SELECT * FROM tblMappingEntries " &
                              "WHERE BPCode='" & IIf(IsDBNull(dtFromUpload.Rows(i)("BPCode")) = True, "", dtFromUpload.Rows(i)("BPCode")) & "'" &
                              " AND Budget='" & IIf(IsDBNull(dtFromUpload.Rows(i)("Budget")) = True, "", dtFromUpload.Rows(i)("Budget")) & "'" &
                              " AND Percentage <> '' ")

            dtDim5 = BULibrary.SqlDataTable("SELECT * FROM tblDim5 WHERE BU=" & dtFromUpload.Rows(i)("BU").ToString() &
                                            " AND Division='" & dtFromUpload.Rows(i)("Division").ToString() & "'")

            If dtMapB1Entries.Rows.Count > 0 Then
                'special entries here
                'DEBIT Expense
                ctr = ctr + 1
                strRcjn = TextBox3.Text
                strLino = ctr
                strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString()
                strLeac = dtMapB1Entries.Rows(0)("DEBIT").ToString()
                strDim1 = dtMapB1Entries.Rows(0)("DIM 1").ToString()
                strDim2 = "613002"
                strDim3 = "201100"
                If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                    strDim3 = "201400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                    strDim3 = "201200"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "BANGUS" Then
                    strDim3 = "202105"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "HUNTS" Then
                    strDim3 = "252400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "EINSTEIN" Then
                    strDim3 = "253100"

                End If
                strDim4 = "YR2019"
                strDim5 = dtDim5.Rows(0)("Code").ToString()
                strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = TextBox4.Text
                strDbcr = "1"  'debit
                strBU = ComboBox2.SelectedValue.ToString()

                'write here
                sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                ''insert lines
                BULibrary.OpenSqlCon()
                BULibrary.SqlUpdate("INSERT INTO From_Download VALUES ('" & strRcjn & "','" & strLino & "','" &
                                    strBPCode & "','" & strLeac & "','" & strDim1 & "','" & strDim2 & "','" &
                                    strDim3 & "','" & strDim4 & "','" & strDim5 & "','" & strAmnt & "','" &
                                    strCcty & "','" & strCvat & "','" & strVamt & "','" & strQty1 & "','" &
                                    strQty2 & "','" & strRefr & "','" & strDbcr & "','" & strBU & "')")
                BULibrary.CloseSqlCon()

                'CREDIT Accrued
                ctr = ctr + 1
                strRcjn = TextBox3.Text
                strLino = ctr
                strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString
                strLeac = dtMapB1Entries.Rows(0)("CREDIT_1").ToString()
                strDim1 = dtMapB1Entries.Rows(0)("DIM 1").ToString()
                strDim2 = "613002"
                strDim3 = "201100"
                If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                    strDim3 = "201400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                    strDim3 = "201200"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "BANGUS" Then
                    strDim3 = "202105"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "HUNTS" Then
                    strDim3 = "252400"
                ElseIf dtFromUpload.Rows(i)("Division").ToString() = "EINSTEIN" Then
                    strDim3 = "253100"
                End If
                strDim4 = "YR2019"
                strDim5 = dtDim5.Rows(0)("Code").ToString()
                strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()) - (Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()) * Decimal.Parse(dtMapB1Entries.Rows(0)("Percentage").ToString())), 2).ToString()
                strCcty = "PHI"
                strCvat = "V00"
                strVamt = "0"
                strQty1 = "0"
                strQty2 = "0"
                strRefr = TextBox4.Text
                strDbcr = "2"  'credit
                strBU = ComboBox2.SelectedValue.ToString()

                'write here
                sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                ''insert lines
                BULibrary.OpenSqlCon()
                BULibrary.SqlUpdate("INSERT INTO From_Download VALUES ('" & strRcjn & "','" & strLino & "','" &
                                    strBPCode & "','" & strLeac & "','" & strDim1 & "','" & strDim2 & "','" &
                                    strDim3 & "','" & strDim4 & "','" & strDim5 & "','" & strAmnt & "','" &
                                    strCcty & "','" & strCvat & "','" & strVamt & "','" & strQty1 & "','" &
                                    strQty2 & "','" & strRefr & "','" & strDbcr & "','" & strBU & "')")
                BULibrary.CloseSqlCon()

                'CREDIT EWT
                If Trim(dtMapB1Entries.Rows(0)("CREDIT_2").ToString()) <> "" Then
                    ctr = ctr + 1
                    strRcjn = TextBox3.Text
                    strLino = ctr
                    strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString
                    strLeac = dtMapB1Entries.Rows(0)("CREDIT_2").ToString()
                    strDim1 = dtMapB1Entries.Rows(0)("DIM 1").ToString()
                    strDim2 = ""
                    strDim3 = "201100"
                    If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                        strDim3 = "201400"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                        strDim3 = "201200"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "BANGUS" Then
                        strDim3 = "202105"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "HUNTS" Then
                        strDim3 = "252400"
                    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "EINSTEIN" Then
                        strDim3 = "253100"

                    End If
                    strDim4 = "YR2019"
                    strDim5 = dtDim5.Rows(0)("Code").ToString()
                    strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()) * Decimal.Parse(dtMapB1Entries.Rows(0)("Percentage").ToString()), 2).ToString()
                    strCcty = "PHI"
                    strCvat = "V00"
                    strVamt = "0"
                    strQty1 = "0"
                    strQty2 = "0"
                    strRefr = TextBox4.Text
                    strDbcr = "2"  'credit
                    strBU = ComboBox2.SelectedValue.ToString()

                    'write here
                    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                    ''insert lines
                    BULibrary.OpenSqlCon()
                    BULibrary.SqlUpdate("INSERT INTO From_Download VALUES ('" & strRcjn & "','" & strLino & "','" &
                                        strBPCode & "','" & strLeac & "','" & strDim1 & "','" & strDim2 & "','" &
                                        strDim3 & "','" & strDim4 & "','" & strDim5 & "','" & strAmnt & "','" &
                                        strCcty & "','" & strCvat & "','" & strVamt & "','" & strQty1 & "','" &
                                        strQty2 & "','" & strRefr & "','" & strDbcr & "','" & strBU & "')")
                    BULibrary.CloseSqlCon()
                End If
                'Else
                '    'normal entries here

                '    dtNormalEntries = BULibrary.SqlDataTable("SELECT * FROM tblBClassMapping " &
                '                                             "WHERE BudgetName='" & dtFromUpload.Rows(i)("Budget").ToString() & "'")

                '    'DEBIT Expense
                '    ctr = ctr + 1
                '    strRcjn = TextBox3.Text
                '    strLino = ctr
                '    strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString()
                '    strLeac = "1111111111"
                '    strDim1 = dtNormalEntries.Rows(0)("Dim1").ToString()
                '    strDim2 = "613002"
                '    strDim3 = "201100"
                '    If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                '        strDim3 = "201400"
                '    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                '        strDim3 = "201200"
                '    End If
                '    strDim4 = "YR2019"
                '    strDim5 = dtDim5.Rows(0)("Code").ToString()
                '    strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()), 2).ToString()
                '    strCcty = "PHI"
                '    strCvat = "V00"
                '    strVamt = "0"
                '    strQty1 = "0"
                '    strQty2 = "0"
                '    strRefr = TextBox4.Text
                '    strDbcr = "1"  'debit
                '    strBU = ComboBox2.SelectedValue.ToString()

                '    'write here
                '    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                '    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                '    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                '    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                '    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                '    ''insert lines
                '    BULibrary.OpenSqlCon()
                '    BULibrary.SqlUpdate("INSERT INTO From_Download VALUES ('" & strRcjn & "','" & strLino & "','" &
                '                        strBPCode & "','" & strLeac & "','" & strDim1 & "','" & strDim2 & "','" &
                '                        strDim3 & "','" & strDim4 & "','" & strDim5 & "','" & strAmnt & "','" &
                '                        strCcty & "','" & strCvat & "','" & strVamt & "','" & strQty1 & "','" &
                '                        strQty2 & "','" & strRefr & "','" & strDbcr & "','" & strBU & "')")
                '    BULibrary.CloseSqlCon()


                '    'CREDIT Accrued
                '    ctr = ctr + 1
                '    strRcjn = TextBox3.Text
                '    strLino = ctr
                '    strBPCode = Integer.Parse(dtFromUpload.Rows(i)("BPCode").ToString()).ToString()
                '    strLeac = "1111111111"
                '    strDim1 = dtNormalEntries.Rows(0)("Dim1").ToString()
                '    strDim2 = "613002"
                '    strDim3 = "201100"
                '    If dtFromUpload.Rows(i)("Division").ToString() = "DISTRIBUTED" Then
                '        strDim3 = "201400"
                '    ElseIf dtFromUpload.Rows(i)("Division").ToString() = "FROZEN" Then
                '        strDim3 = "201200"
                '    End If
                '    strDim4 = "YR2019"
                '    strDim5 = dtDim5.Rows(0)("Code").ToString()
                '    strAmnt = Math.Round(Decimal.Parse(dtFromUpload.Rows(i)("Adjustments").ToString()), 2).ToString()
                '    strCcty = "PHI"
                '    strCvat = "V00"
                '    strVamt = "0"
                '    strQty1 = "0"
                '    strQty2 = "0"
                '    strRefr = TextBox4.Text
                '    strDbcr = "2"  'credit
                '    strBU = ComboBox2.SelectedValue.ToString()

                '    'write here
                '    sw.WriteLine("|" & strRcjn & "|" & strLino & "|" & strBPCode & "|" & strLeac & "|" &
                '    strDim1 & "|" & strDim2 & "|" & strDim3 & "|" &
                '    strDim4 & "|" & strDim5 & "|" & strAmnt & "|" &
                '    strCcty & "|" & strCvat & "|" & strVamt & "|" & strQty1 & "|" &
                '    strQty2 & "|" & strRefr & "|" & strDbcr & "|" & strBU & "|")

                '    ''insert lines
                '    BULibrary.OpenSqlCon()
                '    BULibrary.SqlUpdate("INSERT INTO From_Download VALUES ('" & strRcjn & "','" & strLino & "','" &
                '                        strBPCode & "','" & strLeac & "','" & strDim1 & "','" & strDim2 & "','" &
                '                        strDim3 & "','" & strDim4 & "','" & strDim5 & "','" & strAmnt & "','" &
                '                        strCcty & "','" & strCvat & "','" & strVamt & "','" & strQty1 & "','" &
                '                        strQty2 & "','" & strRefr & "','" & strDbcr & "','" & strBU & "')")
                '    BULibrary.CloseSqlCon()


            End If

        Next
        sw.Close()
        sw.Dispose()
        MsgBox("File Downloaded")
    End Sub

    Private Sub DownloadH(ByVal comp As String, ByVal strpath As String)
        Dim strRcjn, strRcjd, strTtyp, strSer, strCur,
            strRate, strBPCode,
            strRate2, strRate3, strRatf1,
            strRatf2, strRatf3, strBU As String


        Dim dtYrTtyp, dtForex As New DataTable()
        Dim sw As New StreamWriter(strpath & "\\H" &
                                   DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                                   DateTime.Now.Year.ToString() & "_" & ComboBox2.SelectedValue.ToString() & "_" & TextBox3.Text & ".txt")

        dtYrTtyp = BULibrary.SqlDataTable("SELECT * FROM tblYrTtyp WHERE BU=" & Integer.Parse(ComboBox2.SelectedValue.ToString()))
        dtForex = BULibrary.SqlDataTable("SELECT * FROM tblForexRate WHERE Currency = 'USD'")

        strRcjn = TextBox3.Text
        strRcjd = TextBox4.Text
        strTtyp = dtYrTtyp.Rows(0)("Ttype").ToString()
        strSer = "0000"
        strCur = "PHP"
        strBPCode = ""
        strRate = "1"
        strRate2 = dtForex.Rows(0)("Amount").ToString()
        strRate3 = "0"
        strRatf1 = "1"
        strRatf2 = "1"
        strRatf3 = "1"
        strBU = ComboBox2.SelectedValue.ToString()

        Using sw
            sw.WriteLine("|" & strRcjn & "|" & strRcjd & "|" & strTtyp & "|" &
                         strSer & "|" & strCur & "|" & strBPCode & "|" & strRate & "|" &
                         strRate2 & "|" & strRate3 & "|" & strRatf1 & "|" & strRatf2 & "|" &
                         strRatf3 & "|" & strBU & "|")
        End Using
    End Sub

    Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs)
        Dim fBrowse As New FolderBrowserDialog
        With fBrowse
            .Description = "Choose Destination"
            .ShowNewFolderButton = True
        End With
        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Download(ComboBox2.SelectedValue.ToString(), fBrowse.SelectedPath)
            DownloadH(ComboBox2.SelectedValue.ToString(), fBrowse.SelectedPath)
        End If
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        TextBox3.Clear()
        TextBox4.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Preview(ComboBox2.SelectedValue.ToString())
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fBrowse As New FolderBrowserDialog
        With fBrowse
            .Description = "Choose Destination"
            .ShowNewFolderButton = True
        End With
        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Download(ComboBox2.SelectedValue.ToString(), fBrowse.SelectedPath)
            DownloadH(ComboBox2.SelectedValue.ToString(), fBrowse.SelectedPath)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Close()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        'TextBox3.Clear()
        'TextBox4.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
    End Sub

    Private Sub TextBox4_TextChanged_1(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class