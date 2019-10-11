Imports Microsoft.Reporting.WinForms

Public Class rptBdgtMvmnt
    Dim strUserIDL, strUserBUH As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDL = strUserID
        strUserBUH = strUserBU
    End Sub
    Private Sub rptBdgtMvmnt_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load        
        'TODO: This line of code loads data into the 'TradeInvDBDataSet.spgetReportMvmnt' table. You can move, or remove it, as needed.
        'Me.spgetReportMvmntTableAdapter.Fill(Me.TradeInvDBDataSet.spgetReportMvmnt)
        'TODO: This line of code loads data into the 'TradeInvDBDataSet.spgetReportMvmnt' table. You can move, or remove it, as needed.        

        'Me.spgetReportMvmntTableAdapter.Fill(Me.TradeInvDBDataSet.spgetReportMvmnt, strUserBUH)       

        'With ReportViewer1
        '    .LocalReport.ReportPath = "~\" & Application.StartupPath & "\Report1.rdlc"
        '    Dim lpar As New ReportParameter("BUCode", strUserBUH, False)
        '    Dim lpar1(0) As ReportParameter
        '    lpar1(0) = lpar
        '    .LocalReport.DataSources(
        '    .LocalReport.SetParameters(lpar1)
        '    .RefreshReport()
        'End With


        'Me.ReportViewer1.RefreshReport()
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim channels() As String = {"Modern Trade", _
                                  "General Trade", _
                                    "All Channels"}

        For Each channel As String In channels
            combxChannel.Items.Add(channel)
        Next
        combxChannel.SelectedIndex = 0

        Dim divisions() As String = {"Frozen", _
                                  "Canned", _
                                  "Kapal Api", _
                                  "All Divisions"}

        For Each division As String In divisions
            combxDivision.Items.Add(division)
        Next

        combxDivision.SelectedIndex = 0

        Dim dtBudgets As New DataTable()
        dtBudgets = BULibrary.SqlDataTable("SELECT DISTINCT Budget FROM tblBudgetClass " &
                                           "WHERE Active=1")
        For x As Integer = 0 To dtBudgets.Rows.Count - 1
            chkTtyp.Items.Add(dtBudgets.Rows(x)("Budget").ToString())
            chkTtyp.SetItemCheckState(x, CheckState.Checked)
        Next

        Dim dtChkPermission As New DataTable()
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



    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click        

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim strSelectedChnnl, strSelectedDiv As String
        strSelectedChnnl = combxChannel.SelectedItem.ToString()
        strSelectedDiv = combxDivision.SelectedItem.ToString()

        If strSelectedChnnl = "All Channels" Then
            strSelectedChnnl = ""
        End If
        If strSelectedDiv = "All Divisions" Then
            strSelectedDiv = ""
            'kapal api
            'frozen
            'canned
        End If
        

        ReportViewer1.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Clear()


        Dim dtChkPermission As New DataTable()
        Dim CONST_QUERY As String = "0"
        dtChkPermission = BULibrary.SqlDataTable("SELECT * FROM tblUserPermissions " &
                                                 "WHERE UserID='" & strUserIDL & "' " &
                                                 "AND (PermissionID='1' or PermissionID='3')")

        If dtChkPermission.Rows.Count > 0 Then 'user's permission is 1 or 3

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
                ReportDataSource2.Name = "dsReportMvmnt"
                ReportDataSource2.Value = Me.spgetFilterBdgtReportMvmntBindingSource
                Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "TIBudgetUploader.Report1.rdlc"

                ' Try
                Me.spgetFilterBdgtReportMvmntTableAdapter.FillByBdgt(Me.TradeInvDBDataSet.spgetFilterBdgtReportMvmnt, _
                                                             combxBU.SelectedValue.ToString(), _
                                                             DateTime.Parse(datePckrF.Text).ToString("d"), _
                                                             DateTime.Parse(datePckrT.Text).ToString("d"), _
                                                             strSelectedChnnl, _
                                                             strSelectedDiv, strUserIDL)
                'Catch ex As Exception
                '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation)
                '    Me.ReportViewer1.RefreshReport()
                'End Try

                Me.ReportViewer1.RefreshReport()

            Else
                MsgBox("Please choose budget!", MsgBoxStyle.Exclamation)
                Return
                ' MsgBox(DateTime.Parse(datePckrT.Text).ToString())
                'Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
                'ReportDataSource2.Name = "dsReportMvmnt"
                'ReportDataSource2.Value = Me.spgetFilterReportMvmntBindingSource
                'Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
                'Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "TIBudgetUploader.Report1.rdlc"

                'Try
                '    Me.spgetFilterReportMvmntTableAdapter.FillByDate(Me.TradeInvDBDataSet.spgetFilterReportMvmnt, _
                '                                                 combxBU.SelectedValue.ToString(), _
                '                                                 DateTime.Parse(datePckrF.Text).ToString("d"), _
                '                                                 DateTime.Parse(datePckrT.Text).ToString("d"), _
                '                                                 strSelectedChnnl, _
                '                                                 strSelectedDiv)
                'Catch ex As Exception
                '    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation)
                '    Me.ReportViewer1.RefreshReport()
                'End Try

                'Me.ReportViewer1.RefreshReport()
            End If


        Else 'user's permission is Reports(BU)
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
                ReportDataSource2.Name = "dsReportMvmnt"
                ReportDataSource2.Value = Me.spgetFilterBdgtReportMvmntBindingSource
                Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "TIBudgetUploader.Report1.rdlc"

                Try
                    Me.spgetFilterBdgtReportMvmntTableAdapter.FillByBdgt(Me.TradeInvDBDataSet.spgetFilterBdgtReportMvmnt, _
                                                                 combxBU.SelectedValue.ToString(), _
                                                                 DateTime.Parse(datePckrF.Text).ToString("d"), _
                                                                 DateTime.Parse(datePckrT.Text).ToString("d"), _
                                                                 strSelectedChnnl, _
                                                                 strSelectedDiv, strUserIDL)
                Catch ex As Exception
                    'MsgBox(ex.ToString(), MsgBoxStyle.Exclamation)
                    Me.ReportViewer1.RefreshReport()
                End Try

                Me.ReportViewer1.RefreshReport()

            Else
                'MsgBox(DateTime.Parse(datePckrF.Text).ToString())
                ' MsgBox(DateTime.Parse(datePckrT.Text).ToString())
                Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
                ReportDataSource2.Name = "dsReportMvmnt"
                ReportDataSource2.Value = Me.spgetFilterReportMvmntBindingSource
                Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource2)
                Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "TIBudgetUploader.Report1.rdlc"

                Try
                    Me.spgetFilterReportMvmntTableAdapter.FillByDate(Me.TradeInvDBDataSet.spgetFilterReportMvmnt, _
                                                                 combxBU.SelectedValue.ToString(), _
                                                                 DateTime.Parse(datePckrF.Text).ToString("d"), _
                                                                 DateTime.Parse(datePckrT.Text).ToString("d"), _
                                                                 strSelectedChnnl, _
                                                                 strSelectedDiv)
                Catch ex As Exception
                    MsgBox(ex.ToString(), MsgBoxStyle.Exclamation)
                    Me.ReportViewer1.RefreshReport()
                End Try

                Me.ReportViewer1.RefreshReport()
            End If
        End If


        DeleteTempB()
    End Sub

    'Private Sub btnAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAll.Click
    '    ReportViewer1.Clear()
    '    Me.ReportViewer1.LocalReport.DataSources.Clear()
    '    Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
    '    ReportDataSource1.Name = "dsReportMvmnt"
    '    ReportDataSource1.Value = Me.spgetReportMvmntBindingSource
    '    Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
    '    Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "TIBudgetUploader.Report1.rdlc"
    '    Me.spgetReportMvmntTableAdapter.Fill(Me.TradeInvDBDataSet.spgetReportMvmnt, strUserBUH)
    '    Me.ReportViewer1.RefreshReport()
    'End Sub

    Private Sub grpFilters_Enter(sender As System.Object, e As System.EventArgs) Handles grpFilters.Enter

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
        ReportViewer1.LocalReport.DisplayName = "Budget Movement " & combxBU.SelectedValue.ToString()
    End Sub
End Class