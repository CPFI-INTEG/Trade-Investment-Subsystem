Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Deployment.Application
Public Class frmHome
    Dim strUserIDL, strUserBUH, strUserPermissionH As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDL = strUserID
        strUserBUH = strUserBU
    End Sub
    Private Sub UploadFullBudgetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadFullBudgetToolStripMenuItem.Click

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetSeries As New DataTable()

        dtGetSeries = BULibrary.SqlDataTable("SELECT * FROM tblRecurringJournals " &
                                                 "WHERE " &
                                                 "Downloaded=0 " &
                                                 "AND DateDownloaded='1753-01-01 00:00:00.000'")
        If dtGetSeries.Rows.Count > 0 Then
            MsgBox("Can't upload budget by now because there are accruals that are not yet downloaded!", MsgBoxStyle.Exclamation)
            'Dim frmUploader As New frmUploader(True, strUserIDL, strUserBUH)
            'frmUploader.ShowDialog()
        Else
            Dim frmUploader As New frmUploader(True, strUserIDL, strUserBUH)
            frmUploader.ShowDialog()
        End If
    End Sub

    'Private Sub UploadRevisedBudgetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadRevisedBudgetToolStripMenuItem.Click
    '    Dim BULibrary As New TIBudgetUploader.BULibrary()
    '    Dim dtGetSeries As New DataTable()

    '    dtGetSeries = BULibrary.SqlDataTable("SELECT * FROM tblRecurringJournals " &
    '                                             "WHERE Year=" & DateTime.Now.Year &
    '                                             " AND Downloaded=0 " &
    '                                             "AND DateDownloaded='1753-01-01 00:00:00.000'")
    '    If dtGetSeries.Rows.Count > 0 Then
    '        MsgBox("Can't upload revised budget because there are accruals that are not yet downloaded!", MsgBoxStyle.Exclamation)
    '    Else
    '        Dim frmUploader As New frmUploader(False, strUserIDL, strUserBUH)
    '        frmUploader.ShowDialog()
    '    End If


    'End Sub

    Private Sub frmHome_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'PictureBox1.Image = My.Resources.resTIBUploader.uploader_logo
        PictureBox1.Image = My.Resources.resTIBUploader.uploader_logo___v2
        PictureBox1.SizeMode = PictureBoxSizeMode.CenterImage

        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim dtBU As New DataTable()
        dtBU = BULibrary.SqlDataTable("SELECT * FROM tblBusinessUnits WHERE BUCode='" & strUserBUH & "'")

        Dim frmLogin As New frmLogin()
        frmLogin.Close()
        Dim dtGetPermission As New DataTable()
        Dim sqlCon As Object
        sqlCon = New SqlConnectionStringBuilder(Configuration.ConfigurationManager.ConnectionStrings("BuConnectionString").ConnectionString)
        ToolStripLabel1.Text = "User: " & strUserIDL
        ToolStripLabel2.Text = strUserBUH
        ToolStripLabel3.Text = dtBU.Rows(0)("Name").ToString().Trim()
        ToolStripLabel4.Text = "Data Source: " & sqlCon.DataSource.ToString() & " - " & sqlCon.InitialCatalog


        dtGetPermission = BULibrary.SqlDataTable("SELECT * FROM tblUserPermissions " &
                                                "WHERE UserID='" & strUserIDL & "'")

        If dtGetPermission.Rows.Count > 0 Then

            For i As Integer = 0 To dtGetPermission.Rows.Count - 1
                Dim strPermissionID As String

                strPermissionID = dtGetPermission.Rows(i)("PermissionID").ToString().Trim()

                Select Case strPermissionID

                    Case "1"
                        'UploadFullBudgetToolStripMenuItem.Visible = True
                        'DownloadsToolStripMenuItem.Visible = True
                        'SearchToolStripMenuItem.Visible = True
                        'UserMaintenanceToolStripMenuItem.Visible = True
                        'BudgetClassMaintenanceToolStripMenuItem.Visible = True
                        'QueryAnalyzerToolStripMenuItem.Visible = True

                        BudgetToolStripMenuItem.Visible = True
                        AccrualsToolStripMenuItem.Visible = True
                        ReportsToolStripMenuItem.Visible = True
                        MMaintainanceToolStripMenuItem.Visible = True

                        UserMaintainanceToolStripMenuItem.Visible = True
                        'UserMaintenanceToolStripMenuItem.Visible = True
                        BudgetClassMaintainanceToolStripMenuItem.Visible = True
                        'BudgetClassMaintenanceToolStripMenuItem.Visible = True
                        QueryAnalayzerToolStripMenuItem.Visible = True

                        UserAccountToolStripMenuItem.Visible = True


                    Case "2"
                        'UploadFullBudgetToolStripMenuItem.Visible = True
                        'SearchToolStripMenuItem.Visible = True
                        BudgetToolStripMenuItem.Visible = True
                        UserAccountToolStripMenuItem.Visible = True

                    Case "3"
                        'SearchToolStripMenuItem.Visible = True
                        ReportsToolStripMenuItem.Visible = True
                        UserAccountToolStripMenuItem.Visible = True

                    Case "4"
                        'SearchToolStripMenuItem.Visible = True
                        ReportsToolStripMenuItem.Visible = True
                        UserAccountToolStripMenuItem.Visible = True

                    Case "5"
                        'DownloadsToolStripMenuItem.Visible = True
                        AccrualsToolStripMenuItem.Visible = True
                        UserAccountToolStripMenuItem.Visible = True

                    Case "7"
                        MMaintainanceToolStripMenuItem.Visible = True                        
                        BudgetClassMaintainanceToolStripMenuItem.Visible = True
                        UserAccountToolStripMenuItem.Visible = True

                End Select

            Next

        Else
            'MsgBox("Login Failed: Contact your system administrator", MsgBoxStyle.Exclamation)
            'Application.Exit()

        End If

        'Dim dt As New DataTable()
        'dt = BULibrary.SqlDataTable("SELECT * FROM tblHeaderBudget WHERE Year = " & DateTime.Now.Year &
        '                        "and UploadSequenceNo = '00'")

        'If dt.Rows.Count > 0 Then
        '    btnFullBudget.Enabled = False
        'Else
        '    btnFullBudget.Enabled = True
        'End If

        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub btnFullBudget_Click(sender As System.Object, e As System.EventArgs)
        Dim frmUploader As New frmUploader(True, strUserIDL, strUserBUH)
        frmUploader.ShowDialog()
    End Sub

    Private Sub btnRevised_Click(sender As System.Object, e As System.EventArgs)
        Dim frmUploader As New frmUploader(False, strUserIDL, strUserBUH)
        frmUploader.ShowDialog()
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim frmLogin As New frmLogin()
        frmLogin.Show()
        Me.Close()
        Me.Dispose()

    End Sub

    'Private Sub btnUserMaintenance_Click(sender As System.Object, e As System.EventArgs)
    '    Dim frmUserMaintenance As New frmUserMaintenance()

    '    frmUserMaintenance.ShowDialog()
    'End Sub

    Private Sub btnDownload_Click(sender As System.Object, e As System.EventArgs)
        'Dim frmDonwloads As New frmDownloads()
        'frmDonwloads.ShowDialog()
        


    End Sub

    Private Sub DownloadsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadsToolStripMenuItem.Click
        'Dim frmDownloadsMenu As New frmDownloadsMenu(strUserIDL, strUserBUH)
        'frmDownloadsMenu.ShowDialog()
        Dim frmDownloads As New frmDownloads(strUserIDL, strUserBUH)
        frmDownloads.ShowDialog()

    End Sub


    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs)
        Dim frmReports As New frmReports(strUserIDL, strUserBUH)
        frmReports.ShowDialog()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As System.Object, e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub SearchToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SearchToolStripMenuItem.Click
        Dim frmReports As New frmReports(strUserIDL, strUserBUH)
        frmReports.ShowDialog()
    End Sub

    Private Sub UserMaintenanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UserMaintenanceToolStripMenuItem.Click
        Dim frmUserMaintenance As New frmUserMaintenance(strUserIDL, strUserBUH)
        frmUserMaintenance.ShowDialog()
    End Sub

    Private Sub BudgetClassMaintenanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetClassMaintenanceToolStripMenuItem.Click
        Dim frmBClassMaintenance As New frmBClassMaintenance(strUserIDL, strUserBUH)
        frmBClassMaintenance.ShowDialog()
    End Sub

    Private Sub QueryAnalyzerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QueryAnalyzerToolStripMenuItem.Click
        Dim frmCredentials As New frmCredentials()

        frmCredentials.Show()

    End Sub

    Private Sub UploadBudgetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UploadBudgetToolStripMenuItem.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetSeries As New DataTable()

        dtGetSeries = BULibrary.SqlDataTable("SELECT * FROM tblRecurringJournals " &
                                                 "WHERE " &
                                                 "Downloaded=0 " &
                                                 "AND DateDownloaded='1753-01-01 00:00:00.000'")
        If dtGetSeries.Rows.Count > 0 Then
            MsgBox("Can't upload budget by now because there are accruals that are not yet downloaded!", MsgBoxStyle.Exclamation)
            'Dim frmUploader As New frmUploader(True, strUserIDL, strUserBUH)
            'frmUploader.ShowDialog()
        Else
            Dim frmUploader As New frmUploader(True, strUserIDL, strUserBUH)
            frmUploader.ShowDialog()
        End If
    End Sub

    Private Sub DownloadAccrualsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles DownloadAccrualsToolStripMenuItem.Click
        'Dim frmDownloads As New frmDownloads(strUserIDL, strUserBUH)
        'frmDownloads.ShowDialog()
    End Sub

    Private Sub ReportsToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ReportsToolStripMenuItem1.Click
        Dim frmReports As New frmReports(strUserIDL, strUserBUH)
        frmReports.ShowDialog()
    End Sub

    Private Sub UserMaintainanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UserMaintainanceToolStripMenuItem.Click
        Dim frmUserMaintenance As New frmUserMaintenance(strUserIDL, strUserBUH)
        frmUserMaintenance.ShowDialog()
    End Sub

    Private Sub BudgetClassMaintainanceToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetClassMaintainanceToolStripMenuItem.Click
        Dim frmBClassMaintenance As New frmBClassMaintenance(strUserIDL, strUserBUH)
        frmBClassMaintenance.ShowDialog()
    End Sub

    Private Sub QueryAnalayzerToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles QueryAnalayzerToolStripMenuItem.Click
        Dim frmCredentials As New frmCredentials()
        frmCredentials.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        Dim frmChangePwd As New frmChangePwd(strUserIDL, strUserBUH, False)
        frmChangePwd.Show()
    End Sub

    Private Sub VersionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles VersionToolStripMenuItem.Click
        Dim frmVersion As New frmVersion()
        frmVersion.ShowDialog()
    End Sub

    Private Sub UpdatesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles UpdatesToolStripMenuItem.Click
        Dim isUpdateAvailable As Boolean = ApplicationDeployment.CurrentDeployment.CheckForUpdate()

        If isUpdateAvailable = True Then
            If MsgBox("Updates are available on your application. Do you want to update?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
                ApplicationDeployment.CurrentDeployment.Update()
                MsgBox("Your application has been successfully updated.")
            Else
                'do nothing
            End If
            
        Else
            MsgBox("No updates available. Your application is up to date")
        End If
    End Sub

    Private Sub BudgetMovementToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetMovementToolStripMenuItem.Click
        Dim frmRptBudgetMovement As New rptBdgtMvmnt(strUserIDL, strUserBUH)
        frmRptBudgetMovement.ShowDialog()
    End Sub

    Private Sub BudgetPerMonthToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetPerMonthToolStripMenuItem.Click
        Dim rptBudgetPerMonth As New rptBudgetPerMonth(strUserIDL, strUserBUH)
        rptBudgetPerMonth.ShowDialog()
    End Sub

    Private Sub ListOfBusinessPartnersToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ListOfBusinessPartnersToolStripMenuItem.Click
        Dim rptViewAllBP As New rptViewAllBP()
        rptViewAllBP.ShowDialog()
    End Sub

    Private Sub BudgetClassificationsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetClassificationsToolStripMenuItem.Click
        Dim rptViewBudgetClass As New rptViewBudgetClass()
        rptViewBudgetClass.ShowDialog()
    End Sub

    Private Sub BudgetVSActualSummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetVSActualSummaryToolStripMenuItem.Click
        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDL, "Summary", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub

    Private Sub BudgetVSActualDetailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles BudgetVSActualDetailToolStripMenuItem.Click
        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDL, "Detail", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub

    Private Sub ExceededBudgetSummaryToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExceededBudgetSummaryToolStripMenuItem.Click
        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDL, "Exceeded Budget/No Budget (Summary)", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub

    Private Sub ExceededBudgetDetailToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExceededBudgetDetailToolStripMenuItem.Click
        Dim frmFxnBudgetVSActual As New frmFxnBudgetVSActual(strUserIDL, "Exceeded Budget/No Budget (Detail)", strUserBUH)
        frmFxnBudgetVSActual.ShowDialog()
    End Sub

    Private Sub ReUploadBudgetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ReUploadBudgetToolStripMenuItem.Click

    End Sub

    Private Sub RevisedBudgetToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RevisedBudgetToolStripMenuItem.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetSeries As New DataTable()

        dtGetSeries = BULibrary.SqlDataTable("SELECT * FROM tblRecurringJournals " &
                                                 "WHERE " &
                                                 "Downloaded=0 " &
                                                 "AND DateDownloaded='1753-01-01 00:00:00.000'")
        If dtGetSeries.Rows.Count > 0 Then
            MsgBox("Can't upload budget by now because there are accruals that are not yet downloaded!", MsgBoxStyle.Exclamation)
            'Dim frmUploader As New frmUploader(True, strUserIDL, strUserBUH)
            'frmUploader.ShowDialog()
        Else
            Dim frmUploader As New frmUploader(False, strUserIDL, strUserBUH)
            frmUploader.ShowDialog()
        End If
    End Sub
    Private Sub RevertBudgetToolStripMenuItem_Click_1(sender As System.Object, e As System.EventArgs) Handles RevertBudgetToolStripMenuItem.Click
        If MsgBox("Are you sure you want to revert from previous uploaded budget?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
            Dim BULibrary As New TIBudgetUploader.BULibrary()
            Dim dtForRevert As DataTable

            dtForRevert = BULibrary.SqlDataTable("SELECT Distinct BudgetID, PrevID From tblDetailBudget WHERE BudgetID in (SELECT distinct BudgetID from tblTemp)")


            For i As Integer = 0 To dtForRevert.Rows.Count - 1
                BULibrary.OpenSqlCon()
                BULibrary.SqlUpdate("UPDATE tblHeaderBudget SET IsLatest=1 WHERE BudgetID='" & dtForRevert.Rows(i)("PrevID").ToString() & "'")
                BULibrary.SqlUpdate("DELETE FROM tblHeaderBudget WHERE BudgetID='" & dtForRevert.Rows(i)("BudgetID").ToString() & "'")
                BULibrary.SqlUpdate("DELETE FROM tblDetailBudget WHERE BudgetID='" & dtForRevert.Rows(i)("BudgetID").ToString() & "'")
                BULibrary.SqlUpdate("DELETE FROM tblTemp WHERE BudgetID='" & dtForRevert.Rows(i)("BudgetID").ToString() & "'")
                BULibrary.SqlUpdate("DELETE FROM tblRecurringJournals WHERE UserID=''")
                BULibrary.CloseSqlCon()
            Next

            MsgBox("Data successfully reverted!")
        Else
            'do nothing
        End If

        

    End Sub

    Private Sub ValidateAccrualsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ValidateAccrualsToolStripMenuItem.Click
        Dim frmValidateAccrual As New frmValidateAccruals()
        frmValidateAccrual.Show()
    End Sub

    Private Sub InititalAccrualsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles InititalAccrualsToolStripMenuItem.Click
        Dim frmDownloads As New frmDownloads(strUserIDL, strUserBUH)
        frmDownloads.ShowDialog()
    End Sub

    Private Sub RevisedAccrualsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles RevisedAccrualsToolStripMenuItem.Click
        Dim frmRevAccruals As New RevisedAccrual(strUserIDL, strUserBUH)
        frmRevAccruals.ShowDialog()
    End Sub
End Class