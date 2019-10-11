Imports Microsoft.Reporting.WinForms
Public Class frmFxnBudgetVSActual
    Public Property strReport As String
    Dim strUserIDH, strReportTypH, strUserBUH As String
    Public Sub New(ByVal strUserID As String, ByVal strReportType As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDH = strUserID
        strReportTypH = strReportType
        strUserBUH = strUserBU
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frmFxnBudgetVSActual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If strReportTypH = "Summary" Then
            Me.Text = "Budget VS Actual - Summary"
        ElseIf strReportTypH = "Detail" Then
            Me.Text = "Budget VS Actual - Detail"
        Else
            Me.Text = "Budget VS Actual - Exceeded Budget"
        End If

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtFillType, dtFillCompFrm, dtBUs, dtDim5, dtChkPermission As New DataTable()


        'dtBUs = BULibrary.SqlDataTable("select Desc_Division, Division from tblAllBU where Division IN (211,311,271,511)")
        dtBUs = BULibrary.SqlDataTable("select Desc_Division, Division from tblAllBU where Division IN (211,311,271,511, 871) and (Desc_Division <> 'Frozen Division' or Division <> 311)")
        dtChkPermission = BULibrary.SqlDataTable("SELECT * FROM tblUserPermissions " &
                                 "WHERE UserID='" & strUserIDH & "' " &
                                 "AND (PermissionID='1' or PermissionID='3')")


        If dtChkPermission.Rows.Count > 0 Then 'user's permission is 1 or 3
            combxBU.DataSource = BULibrary.SqlDataTable("select Desc_Division, Division from tblAllBU where Division IN (211,311,271,511, 871) and (Desc_Division <> 'Frozen Division' or Division <> 311)")

            combxBU.DisplayMember = "Desc_Division"
            combxBU.ValueMember = "Division"
        Else 'user's permission is Reports(BU)
            combxBU.DataSource = BULibrary.SqlDataTable("select Desc_Division, Division from tblAllBU where Division ='" & strUserBUH & "'")

            combxBU.DisplayMember = "Desc_Division"
            combxBU.ValueMember = "Division"
        End If

        'combxBU.DataSource = dtBUs
        'combxBU.DisplayMember = "Desc_Division"
        'combxBU.ValueMember = "Division"

        txtYear.Text = Date.Now.Year.ToString()
        txtPeriod.Text = Date.Now.Month.ToString()
        txtDim4.Text = "YR" & Date.Now.Year.ToString()
        txtFrmBP.Text = "0"
        txtToBP.Text = "999999999"
        lstType.SelectedIndex = 0
        chkStat.SetItemChecked(0, True)

        'Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        Dim rptDataSource As ReportDataSource
        Dim BULibrary As New TIBudgetUploader.BULibrary()


        If lstType.SelectedItems.Count > 0 Then

            For z As Integer = 0 To chkCompanyFrom.CheckedItems.Count - 1
                For x As Integer = 0 To chkStat.CheckedItems.Count - 1
                    For i As Integer = 0 To lstType.SelectedItems.Count - 1
                        For y As Integer = 0 To lstBudget.SelectedItems.Count - 1

                            BULibrary.OpenSqlCon()

                            'BULibrary.InsertToTempD("spInsertTempD", chkType.CheckedItems.Item(i).ToString(), strUserIDH, chkStat.CheckedItems.Item(x).ToString(), chkCompanyFrom.CheckedItems.Item(z).ToString())
                            BULibrary.InsertToTempD("spInsertTempD", lstType.SelectedItems.Item(i), strUserIDH, chkStat.CheckedItems.Item(x).ToString(), chkCompanyFrom.CheckedItems.Item(z).ToString(), lstBudget.SelectedItems.Item(y).ToString().Substring(0, 3).Trim())

                            BULibrary.CloseSqlCon()

                        Next
                    Next
                Next
            Next
        End If


        'strReport = "rptBudgetVSActual_Sum"
        Try
            Dim strSelectedTypes As String = ""
            Dim strSelectedCompFrm As String = ""
            Dim strSelectedStat As String = ""

            For i As Integer = 0 To lstType.SelectedItems.Count - 1                
                strSelectedTypes = strSelectedTypes & " " & lstType.SelectedItems.Item(i)
            Next
            For x As Integer = 0 To chkCompanyFrom.CheckedItems.Count - 1
                strSelectedCompFrm = strSelectedCompFrm & " " & chkCompanyFrom.CheckedItems.Item(x).ToString()
            Next
            Dim str As String
            For o As Integer = 0 To chkStat.CheckedItems.Count - 1
                str = chkStat.CheckedItems.Item(o).ToString()
                If str = "FI" Then
                    str = "Finalized"
                Else
                    str = "Non-Finalized"
                End If
                'strSelectedStat = strSelectedStat & " " & chkStat.CheckedItems.Item(o).ToString()
                strSelectedStat = strSelectedStat & " " & str
            Next

            Dim paramDivision As New ReportParameter("paramDivision", combxBU.Text.ToUpper())
            Dim paramYear As New ReportParameter("paramYear", txtYear.Text)
            Dim paramPeriod As New ReportParameter("paramPeriod", txtPeriod.Text)
            Dim paramReportType As New ReportParameter("paramReportType", strReportTypH)
            Dim paramSelectedTypes As New ReportParameter("paramSelectedTypes", strSelectedTypes)
            Dim paramSelectedCompFrm As New ReportParameter("paramSelectedCompFrm", strSelectedCompFrm)
            Dim paramSelectedStat As New ReportParameter("paramSelectedStat", strSelectedStat)

            If strReportTypH = "Summary" Then


                strReport = "rptBudgetVSActual_Summary_V2"

                With Me.ReportViewer1.LocalReport
                    .ReportPath = "Reports\" & strReport & ".rdlc"
                    .SetParameters(paramDivision)
                    .SetParameters(paramYear)
                    .SetParameters(paramPeriod)
                    .SetParameters(paramReportType)
                    .SetParameters(paramSelectedTypes)
                    .SetParameters(paramSelectedCompFrm)
                    .SetParameters(paramSelectedStat)
                    .DataSources.Clear()
                End With

                Dim ds As New TradeInvDBDataSet()
                'Dim da As New TradeInvDBDataSetTableAdapters.spfxnBudgetVSActual_NF_FITableAdapter
                Dim da As New TradeInvDBDataSetTableAdapters.spfxnBudgetVSActual_SummaryTableAdapter

                'da.Fill(ds.spfxnBudgetVSActual_NF_FI, txtDim4.Text, txtYear.Text, txtPeriod.Text, Integer.Parse(combxBU.SelectedValue.ToString()), _
                'txtFrmBP.Text, txtToBP.Text, txtFrmLeac.Text, txtToLeac.Text, strUserIDH)
                da.Fill(ds.spfxnBudgetVSActual_Summary, txtDim4.Text, Integer.Parse(txtYear.Text), Integer.Parse(txtPeriod.Text), combxBU.Text, _
                         txtFrmBP.Text, txtToBP.Text, strUserIDH)

                'rptDataSource = New ReportDataSource("dsBudgetVSActual_Sum", ds.Tables("spfxnBudgetVSActual_NF_FI"))
                rptDataSource = New ReportDataSource("ds_BudgetVSActual_Summary_V2", ds.Tables("spfxnBudgetVSActual_Summary"))



            ElseIf strReportTypH = "Detail" Then


                strReport = "rptBudgetVSActual_Detail_V2"

                With Me.ReportViewer1.LocalReport
                    .ReportPath = "Reports\" & strReport & ".rdlc"
                    .SetParameters(paramDivision)
                    .SetParameters(paramYear)
                    .SetParameters(paramPeriod)
                    .SetParameters(paramReportType)
                    .DataSources.Clear()
                End With

                Dim ds As New TradeInvDBDataSet()
                'Dim da As New TradeInvDBDataSetTableAdapters.spfxnBudgetVSActual_NF_FI_DETAILTableAdapter
                'da.Fill(ds.spfxnBudgetVSActual_NF_FI_DETAIL, txtDim4.Text, txtYear.Text, txtPeriod.Text, Integer.Parse(combxBU.SelectedValue.ToString()), _
                '        txtFrmBP.Text, txtToBP.Text, txtFrmLeac.Text, txtToLeac.Text, strUserIDH)
                Dim da As New TradeInvDBDataSetTableAdapters.spfxnBudgetVSActual_DetailTableAdapter
                da.Fill(ds.spfxnBudgetVSActual_Detail, txtDim4.Text, Integer.Parse(txtYear.Text), Integer.Parse(txtPeriod.Text), combxBU.Text, _
                         txtFrmBP.Text, txtToBP.Text, strUserIDH)

                rptDataSource = New ReportDataSource("dsBudgetVSActual_Detail_V2", ds.Tables("spfxnBudgetVSActual_Detail"))



            ElseIf strReportTypH = "Exceeded Budget/No Budget (Summary)" Then
                strReport = "Exceeded_Budget_Sum"

                With Me.ReportViewer1.LocalReport
                    .ReportPath = "Reports\" & strReport & ".rdlc"
                    .SetParameters(paramDivision)
                    .SetParameters(paramYear)
                    .SetParameters(paramPeriod)
                    .SetParameters(paramReportType)
                    .SetParameters(paramSelectedTypes)
                    .SetParameters(paramSelectedCompFrm)
                    .SetParameters(paramSelectedStat)
                    .DataSources.Clear()
                End With

                Dim ds As New TradeInvDBDataSet()
                Dim da As New TradeInvDBDataSetTableAdapters.spfxnBudgetVSActual_SummaryTableAdapter

                da.Fill(ds.spfxnBudgetVSActual_Summary, txtDim4.Text, Integer.Parse(txtYear.Text), Integer.Parse(txtPeriod.Text), combxBU.Text, _
                         txtFrmBP.Text, txtToBP.Text, strUserIDH)

                rptDataSource = New ReportDataSource("ds_Budget_Exceeded_Sum", ds.Tables("spfxnBudgetVSActual_Summary"))
            Else
                strReport = "Exceeded_Budget_Detail"

                With Me.ReportViewer1.LocalReport
                    .ReportPath = "Reports\" & strReport & ".rdlc"
                    .SetParameters(paramDivision)
                    .SetParameters(paramYear)
                    .SetParameters(paramPeriod)
                    .SetParameters(paramReportType)
                    .DataSources.Clear()
                End With

                Dim ds As New TradeInvDBDataSet()
                Dim da As New TradeInvDBDataSetTableAdapters.spfxnBudgetVSActual_DetailTableAdapter
                da.Fill(ds.spfxnBudgetVSActual_Detail, txtDim4.Text, Integer.Parse(txtYear.Text), Integer.Parse(txtPeriod.Text), combxBU.Text, _
                         txtFrmBP.Text, txtToBP.Text, strUserIDH)

                rptDataSource = New ReportDataSource("dsBudgetVSActual_Detail_V2", ds.Tables("spfxnBudgetVSActual_Detail"))


            End If

            Me.ReportViewer1.LocalReport.DataSources.Add(rptDataSource)

            Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try

        BULibrary.OpenSqlCon()

        BULibrary.SqlUpdate("DELETE FROM tblTempD WHERE UserID ='" & strUserIDH & "'")

        BULibrary.CloseSqlCon()

    End Sub

    Private Sub ReportViewer1_ReportExport(sender As System.Object, e As Microsoft.Reporting.WinForms.ReportExportEventArgs) Handles ReportViewer1.ReportExport
        ReportViewer1.LocalReport.DisplayName = "Budget VS Actual - " & strReportTypH & "_" & combxBU.Text
    End Sub

    Private Sub combxBU_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles combxBU.SelectedIndexChanged
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtFillCompFrm, dtBUs As New DataTable()

        'dtBUs = BULibrary.SqlDataTable("select Desc_Division, Division from tblAllBU where Division IN (211,311,271,511)")
        'combxBU.DataSource = dtBUs
        combxBU.DisplayMember = "Desc_Division"
        combxBU.ValueMember = "Division"

        chkCompanyFrom.Items.Clear()
               
        dtFillCompFrm = BULibrary.SqlDataTable("select distinct DIM5_CD from GLD_NF_FI " &
                                               "where COMPANY_CD in (select distinct division from tblAllBU where Desc_Division ='" &
                                               combxBU.Text.ToString() & "' and DIM5_CD <> '')")

        If dtFillCompFrm.Rows.Count > 0 Then
            For x As Integer = 0 To dtFillCompFrm.Rows.Count - 1
                Me.chkCompanyFrom.Items.Add(dtFillCompFrm.Rows(x)("DIM5_CD").ToString())
            Next
        End If

        

    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub lstBudget_MouseHover(sender As System.Object, e As System.EventArgs) Handles lstBudget.MouseHover

    End Sub

    Private Sub txtFrmBP_LostFocus(sender As Object, e As System.EventArgs) Handles txtFrmBP.LostFocus

        If txtFrmBP.Text = "" Then
            txtFrmBP.Text = "0000000000"
            txtToBP.Text = 9999999999
        ElseIf Val(txtFrmBP.Text) = 0 Then
            txtFrmBP.Text = "0000000000"
            txtToBP.Text = 9999999999
        Else
            txtToBP.Text = txtFrmBP.Text
        End If

    End Sub
End Class