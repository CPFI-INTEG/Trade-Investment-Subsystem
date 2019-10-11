Public Class frmUserMaintenance
    Dim strUserIDL, strUserBUH, strUserPermissionH As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDL = strUserID
        strUserBUH = strUserBU
    End Sub

    Private Sub frmUserMaintenance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtAllUsers As New DataTable()

        'combxRole.DataSource = BULibrary.SqlDataTable("SELECT * FROM tblRoles " &
        '                                              "WHERE RoleID !='1' " &
        '                                              "AND Description != 'System Administrator'")
        'combxRole.DisplayMember = "Description"
        'combxRole.ValueMember = "RoleID"        

        'Me.combxPermission.DataSource = BULibrary.SqlDataTable("SELECT * FROM tblPermissions " &
        '                                                    "WHERE PermissionID !='1' " &
        '                                                    "AND Description != 'System Administrator'")
        'Me.combxPermission.DisplayMember = "Description"
        'Me.combxPermission.ValueMember = "PermissionID"

        Dim dtPermissions As New DataTable()
        dtPermissions = BULibrary.SqlDataTable("SELECT * FROM tblPermissions " &
                                               "WHERE PermissionID !='1'")
        For x As Integer = 0 To dtPermissions.Rows.Count - 1
            Me.chkPermissions.Items.Add(dtPermissions.Rows(x)("Description").ToString())
        Next

        RefreshForm()

    End Sub


    Private Sub grdDataUsers_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdDataUsers.RowHeaderMouseClick

        For x As Integer = 0 To chkPermissions.Items.Count - 1
            chkPermissions.SetItemCheckState(x, CheckState.Unchecked)
        Next

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        lblUserName.Text = Me.grdDataUsers.SelectedRows(0).Cells("UserID").Value.ToString()
        lblEmpCode.Text = Me.grdDataUsers.SelectedRows(0).Cells("EmpCode").Value.ToString()
        lblFullName.Text = Me.grdDataUsers.SelectedRows(0).Cells("FullName").Value.ToString()
        lblBUnit.Text = Me.grdDataUsers.SelectedRows(0).Cells("BusinessUnit").Value.ToString()
        lblDept.Text = Me.grdDataUsers.SelectedRows(0).Cells("Department").Value.ToString()
        'combxPermission.SelectedValue = Me.grdDataUsers.SelectedRows(0).Cells("Permission").Value.ToString()

        Dim dtUsrPermissions As New DataTable()
        dtUsrPermissions = BULibrary.GetUsrPermission("spgetUsrPermission", lblEmpCode.Text, lblUserName.Text)

        For i As Integer = 0 To dtUsrPermissions.Rows.Count - 1
            For x As Integer = 0 To chkPermissions.Items.Count - 1
                If dtUsrPermissions.Rows(i)("Description").ToString() = chkPermissions.Items(x).ToString() Then
                    chkPermissions.SetItemCheckState(x, CheckState.Checked)
                End If
            Next
        Next

    End Sub

    Private Sub btnInserUser_Click(sender As System.Object, e As System.EventArgs) Handles btnInserUser.Click
        Dim frmAddUser As New frmAddUser(strUserIDL, strUserBUH)
        frmAddUser.ShowDialog()
    End Sub

    Private Sub btnInsertBulk_Click(sender As System.Object, e As System.EventArgs) Handles btnInsertBulk.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim strFileLocation As String


        Dim fDialog As New OpenFileDialog()
        With fDialog
            .Title = "Select file to be uploaded"
            .Filter = "Excel files (*.xls or *.xlsx)|*.xls;*.xlsx"
            'End With
            If .ShowDialog() = DialogResult.OK Then
                strFileLocation = .FileName.ToString()
            Else
                Return
            End If
        End With

        BULibrary.openOleCon(strFileLocation)

        Dim dtExcelData As New DataTable()
        Try
            dtExcelData = BULibrary.OleDataTable("SELECT * FROM [tblUsers$]") 'use 1 SheetName for excel upload
        Catch ex As Exception
            MsgBox("Error in uploading. Please upload the correct file.", MsgBoxStyle.Exclamation)
            Return
        End Try

        BULibrary.closeOleCon()

        BULibrary.OpenSqlCon()

        For i As Integer = 0 To dtExcelData.Rows.Count - 1

            If dtExcelData.Rows.Count > 0 Then

                'Dim hashPwd As String = BULibrary.EncryptPwd(dtExcelData.Rows(i)("Password").ToString())
                Dim hashPwd As String = BULibrary.EncryptPwd("tibs123")
                'Dim perID As String

                BULibrary.InsertUser("spInsertUser", dtExcelData.Rows(i)("UserID").ToString().Trim(), _
                                     dtExcelData.Rows(i)("EmpCode").ToString().Trim(), _
                                    dtExcelData.Rows(i)("BU").ToString().Trim(), _
                                    hashPwd)

                BULibrary.InsertUserDetails("spInsertUserDetails", _
                                            dtExcelData.Rows(i)("EmpCode").ToString().Trim(), _
                                            dtExcelData.Rows(i)("LastName").ToString().Trim(), _
                                            dtExcelData.Rows(i)("FirstName").ToString().Trim(), _
                                            dtExcelData.Rows(i)("Middle").ToString().Trim(), _
                                            dtExcelData.Rows(i)("BU").ToString().Trim(), _
                                            dtExcelData.Rows(i)("Department").ToString().Trim())

                BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
                                         "Added User: " & dtExcelData.Rows(i)("UserID").ToString().Trim(), _
                                         Me.Text, strUserBUH, DateTime.Now)

            End If

        Next        
        BULibrary.CloseSqlCon()
        MsgBox("Users successfully added.", MsgBoxStyle.Information)

    End Sub

    Private Sub btnAll_Click(sender As System.Object, e As System.EventArgs) Handles btnAll.Click
        RefreshForm()
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        If lblUserName.Text <> "" Then
            If MsgBox("Are you sure you want to reset user's password?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then

                BULibrary.OpenSqlCon()
                'BULibrary.UpdatePassword("spUpdatePassword", lblUserName.Text.Trim(), _
                '                         BULibrary.EncryptPwd(lblEmpCode.Text.Trim()), 0)

                BULibrary.UpdatePassword("spUpdatePassword", lblUserName.Text.Trim(), _
                         BULibrary.EncryptPwd("tibs123"), 0)

                BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
                         "Reset Acct Password of: " & lblUserName.Text.Trim(), _
                         Me.Text, strUserBUH, DateTime.Now)

                BULibrary.CloseSqlCon()
                MsgBox("User's password has been reset.", MsgBoxStyle.Information)
            End If

        Else
            MsgBox("Please select a user!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnDeactivate_Click(sender As System.Object, e As System.EventArgs) Handles btnDeactivate.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        If lblUserName.Text = "" Or lblEmpCode.Text = "" Then
            MsgBox("Please select a user!", MsgBoxStyle.Exclamation)
        Else
            If MsgBox("Are you sure you want to deactivate this user?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
                BULibrary.OpenSqlCon()
                BULibrary.SqlUpdate("UPDATE tblUsers SET Active=0 WHERE " &
                                    "UserID='" & lblUserName.Text.Trim() & "' " &
                                    "AND EmpCode='" & lblEmpCode.Text.Trim() & "'")

                BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
                "Deactivated: " & lblUserName.Text.Trim(), _
                Me.Text, strUserBUH, DateTime.Now)

                BULibrary.CloseSqlCon()
                MsgBox("User is now deactivated!", MsgBoxStyle.Exclamation)
            End If

        End If

    End Sub

    Private Sub btnActivate_Click(sender As System.Object, e As System.EventArgs) Handles btnActivate.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        If lblUserName.Text = "" Or lblEmpCode.Text = "" Then
            MsgBox("Please select a user!", MsgBoxStyle.Exclamation)
        Else
            If MsgBox("Are you sure you want to activate this user?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
                BULibrary.OpenSqlCon()
                BULibrary.SqlUpdate("UPDATE tblUsers SET Active=1 WHERE " &
                                    "UserID='" & lblUserName.Text.Trim() & "' " &
                                    "AND EmpCode='" & lblEmpCode.Text.Trim() & "'")

                BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
                "Activated: " & lblUserName.Text.Trim(), _
                Me.Text, strUserBUH, DateTime.Now)

                BULibrary.CloseSqlCon()
                MsgBox("User is now activated!", MsgBoxStyle.Exclamation)
            End If

        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        If chkPermissions.CheckedItems.Count = 0 Then
            MsgBox("Please choose at least 1 permission!", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        'If lblUserName.Text = "" Or lblEmpCode.Text = "" Then
        '    MsgBox("Please select a user!", MsgBoxStyle.Exclamation)
        'Else

        '    If MsgBox("Are you sure you want to update this user?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
        '        BULibrary.OpenSqlCon()
        '        BULibrary.SqlUpdate("UPDATE tblUserPermissions SET PermissionID='" & combxPermission.SelectedValue.ToString() &
        '                             "' WHERE UserID='" & lblUserName.Text & "'")
        '        BULibrary.CloseSqlCon()
        '        MsgBox("User successfully updated!", MsgBoxStyle.Exclamation)

        '    End If

        'End If
        If lblUserName.Text = "" Or lblEmpCode.Text = "" Then
            MsgBox("Please select a user!", MsgBoxStyle.Exclamation)
        Else
            If MsgBox("Are you sure you want to update this user?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then

                Dim dtChkIfExist, dtGetPerID As New DataTable()

                For i As Integer = 0 To chkPermissions.CheckedItems.Count - 1

                    dtChkIfExist = BULibrary.ChkUsrPermissionIfExist("spChkUsrPermissionIfExist", _
                                                                 lblEmpCode.Text, _
                                                                 lblUserName.Text, _
                                                                 chkPermissions.CheckedItems.Item(i).ToString())

                    If dtChkIfExist.Rows.Count > 0 Then 'user permission exists therefore skip

                    Else 'user permission does not exists therefore insert new records

                        dtGetPerID = BULibrary.SqlDataTable("SELECT * FROM tblPermissions " &
                                                            "WHERE Description='" & chkPermissions.CheckedItems.Item(i).ToString() & "'")

                        BULibrary.OpenSqlCon()

                        BULibrary.InsertUserPermissions("spInsertUserPermissions", lblUserName.Text, lblEmpCode.Text, dtGetPerID.Rows(0)("PermissionID").ToString())

                        BULibrary.CloseSqlCon()

                        'MsgBox("User successfully updated!", MsgBoxStyle.Information)
                    End If
                Next
                For x As Integer = 0 To chkPermissions.Items.Count - 1

                    Dim dt As New DataTable()
                    dt = BULibrary.SqlDataTable("SELECT * FROM tblPermissions " &
                                                "WHERE Description='" & chkPermissions.Items.Item(x).ToString() & "'")

                    If (chkPermissions.GetItemCheckState(x) = CheckState.Unchecked) Then
                        BULibrary.OpenSqlCon()

                        BULibrary.SqlUpdate("DELETE FROM tblUserPermissions " &
                                            "WHERE EmpCode='" & lblEmpCode.Text & "' " &
                                            "AND UserID='" & lblUserName.Text & "' " &
                                            "AND PermissionID='" & dt.Rows(0)("PermissionID").ToString() & "'")

                        BULibrary.CloseSqlCon()
                    End If                    
                Next
                BULibrary.OpenSqlCon()
                BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
                "Updated user permissions of: " & lblUserName.Text.Trim(), _
                Me.Text, strUserBUH, DateTime.Now)
                BULibrary.CloseSqlCon()

                MsgBox("User successfully updated!", MsgBoxStyle.Information)

            Else
                'refresh form
                RefreshForm()
            End If

        End If


    End Sub
    Private Sub RefreshForm()
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        lblUserName.Text = String.Empty
        lblEmpCode.Text = String.Empty
        lblFullName.Text = String.Empty
        lblBUnit.Text = String.Empty
        lblDept.Text = String.Empty
        For x As Integer = 0 To chkPermissions.Items.Count - 1
            chkPermissions.SetItemCheckState(x, CheckState.Unchecked)
        Next

        Dim dtAllUsers As New DataTable()

        dtAllUsers = BULibrary.GetAllUsers("spgetAllUsers", strUserIDL)

        If dtAllUsers.Rows.Count > 1 Then

            Me.grdDataUsers.DataSource = dtAllUsers
            Me.grdDataUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        End If
    End Sub
End Class