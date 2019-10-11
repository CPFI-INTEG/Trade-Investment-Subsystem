Imports Microsoft.Reporting.WinForms

Public Class rptBudgetPerMonth
    Dim strUserIDL, strUserBUH As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDL = strUserID
        strUserBUH = strUserBU
    End Sub

    Private Sub rptBudgetPerMonth_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'TradeInvDBDataSet.spgetRptBudgetPerMonth' table. You can move, or remove it, as needed.
        'Me.spgetRptBudgetPerMonthTableAdapter.Fill(Me.TradeInvDBDataSet.spgetRptBudgetPerMonth)

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtBatchNo, dtBUs, dtBudgets, dtChkPermission As New DataTable()

        dtBatchNo = BULibrary.SqlDataTable("SELECT Distinct BatchNo from tblHeaderBudget ORDER BY BatchNo")

        dtBUs = BULibrary.SqlDataTable("SELECT * FROM tblBusinessUnits WHERE BUCode <> '110'")

        dtChkPermission = BULibrary.SqlDataTable("SELECT * FROM tblUserPermissions " &
                                         "WHERE UserID='" & strUserIDL & "' " &
                                         "AND (PermissionID='1' or PermissionID='3')")

        If dtChkPermission.Rows.Count > 0 Then 'user's permission is 1 or 3
            combxBU.DataSource = BULibrary.SqlDataTable("SELECT *,BUCode + '-' + Name AS CODE_NAME FROM tblBusinessUnits WHERE BUCode <> '111'")

            combxBU.DisplayMember = "CODE_NAME"
            combxBU.ValueMember = "BUCode"
        Else 'user's permission is Reports(BU)
            combxBU.DataSource = BULibrary.SqlDataTable("SELECT *,BUCode + '-' + Name AS CODE_NAME FROM tblBusinessUnits WHERE BUCode ='" & strUserBUH & "'")

            combxBU.DisplayMember = "CODE_NAME"
            combxBU.ValueMember = "BUCode"
        End If

        dtBudgets = BULibrary.SqlDataTable("SELECT DISTINCT Budget FROM tblBudgetClass " &
                                           "WHERE Active=1")
        For x As Integer = 0 To dtBudgets.Rows.Count - 1
            chkTtyp.Items.Add(dtBudgets.Rows(x)("Budget").ToString())
            chkTtyp.SetItemCheckState(x, CheckState.Checked)
        Next

        Dim divisions() As String = {"Frozen", _
                                  "Canned", _
                                  "Kapal Api", _
                                  "All Divisions"}

        For Each division As String In divisions
            combxDivision.Items.Add(division)
        Next

        combxDivision.SelectedIndex = 0


    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim strSelectedDiv As String
        ', strSelectedMonth 
        strSelectedDiv = combxDivision.SelectedItem.ToString()
        If strSelectedDiv = "All Divisions" Then
            strSelectedDiv = ""
        End If

        ReportViewer1.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Clear()



        If chkTtyp.CheckedItems.Count > 0 Then
            Dim dt As New DataTable()
            For i As Integer = 0 To chkTtyp.CheckedItems.Count - 1
                dt = BULibrary.GetBudgetCode("spgetBudgetCode", chkTtyp.CheckedItems.Item(i).ToString())
                BULibrary.OpenSqlCon()
                'BULibrary.InsertToTempB("spInsertTempB", dt.Rows(i)("BudgetCode").ToString().Substring(0, 2), strUserIDL)
                BULibrary.InsertToTempB("spInsertTempB", dt.Rows(0)("GrpClass").ToString(), strUserIDL)
                BULibrary.CloseSqlCon()
            Next

            Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
            Dim paramDivision As New ReportParameter("paramDivision", combxDivision.SelectedItem.ToString())
            'Dim paramBatchNo As New ReportParameter("paramBatchNo", combxBatch.SelectedValue.ToString())
            ReportDataSource2.Name = "dsBudgetPerMonth2"
            ReportDataSource2.Value = Me.spgetRptBudgetPerMonthBindingSource
            Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "TIBudgetUploader.rptBudgetPerMonth2.rdlc"
            Me.ReportViewer1.LocalReport.SetParameters(paramDivision)
            'Me.ReportViewer1.LocalReport.SetParameters(paramBatchNo)


            Try
                Me.spgetRptBudgetPerMonthTableAdapter.Fill(Me.TradeInvDBDataSet.spgetRptBudgetPerMonth, _
                                                           strUserIDL, _
                                                           strSelectedDiv, _
                                                           combxBU.SelectedValue.ToString())
            Catch ex As Exception
                'MsgBox(ex.ToString(), MsgBoxStyle.Exclamation)
                Me.ReportViewer1.RefreshReport()
            End Try

            Me.ReportViewer1.RefreshReport()

        Else
            MsgBox("Please choose budget!", MsgBoxStyle.Exclamation)
            Return
        End If


        DeleteTempB()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub DeleteTempB()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        'delete records from tempB table
        BULibrary.OpenSqlCon()
        BULibrary.SqlUpdate("DELETE FROM tblTempB")
        BULibrary.CloseSqlCon()
        'delete records from tempB table
    End Sub

    Private Sub ReportViewer1_ReportExport(sender As System.Object, e As Microsoft.Reporting.WinForms.ReportExportEventArgs) Handles ReportViewer1.ReportExport
        'rptBudgetPerMonth.Name = "Budget Per Month_" & combxBatch.SelectedValue.ToString() & "_" & combxBU.SelectedValue.ToString()
        ReportViewer1.LocalReport.DisplayName = "Budget Per Month_" & combxBU.SelectedValue.ToString()

    End Sub
End Class