Public Class frmChangePwd
    Dim IsFirstLoginH As Boolean
    Dim strUserIDL, strUserBUH, strUserPermissionH As String
    Dim BULibrary As New TIBudgetUploader.BULibrary()
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String, ByVal IsFirstLogin As Boolean)
        InitializeComponent()
        strUserIDL = strUserID
        strUserBUH = strUserBU
        IsFirstLoginH = IsFirstLogin
    End Sub
    Private Sub btnChange_Click(sender As System.Object, e As System.EventArgs) Handles btnChange.Click
        Dim dtChkPwd As New DataTable()
        dtChkPwd = BULibrary.SqlDataTable("SELECT * FROM tblUsers WHERE " &
                                          "UserID='" & strUserIDL & "'")
        If (IsFirstLoginH) Then 'user's first login

            If dtChkPwd.Rows.Count > 0 Then

                If txtCurrent.Text Is Nothing And txtNew.Text Is Nothing And txtConfirm.Text Is Nothing Then
                    MsgBox("Fill out all required fields!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text Is Nothing Or txtNew.Text Is Nothing Or txtConfirm.Text Is Nothing Then
                    MsgBox("Fill out all required field!s", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text = "" And txtNew.Text = "" And txtConfirm.Text = "" Then
                    MsgBox("Fill out all required fields!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text = "" Or txtNew.Text = "" Or txtConfirm.Text = "" Then
                    MsgBox("Fill out all required fields!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtNew.Text <> txtConfirm.Text Then
                    MsgBox("Password confirmation doesn't match!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text = txtNew.Text And txtCurrent.Text = txtConfirm.Text Then
                    MsgBox("Current password and new password should not be the same! Please enter a different password!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf BULibrary.EncryptPwd(txtCurrent.Text) <> dtChkPwd.Rows(0)("Password").ToString() Then
                    MsgBox("Please enter your correct current password!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf BULibrary.EncryptPwd(txtCurrent.Text) = dtChkPwd.Rows(0)("Password").ToString() Then
                    Dim frmHome As New frmHome(strUserIDL, strUserBUH)

                    BULibrary.OpenSqlCon()
                    BULibrary.UpdatePassword("spUpdatePassword", strUserIDL, BULibrary.EncryptPwd(txtNew.Text), 1)
                    BULibrary.CloseSqlCon()

                    MsgBox("Password has been changed.")
                    frmHome.Show()
                    Me.Close()
                End If

            Else
                MsgBox("Login Failed! Contact your system administrator.", MsgBoxStyle.Exclamation)

            End If

        Else 'user is changing his/her password
            If dtChkPwd.Rows.Count > 0 Then

                If txtCurrent.Text Is Nothing And txtNew.Text Is Nothing And txtConfirm.Text Is Nothing Then
                    MsgBox("Fill out all required fields!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text Is Nothing Or txtNew.Text Is Nothing Or txtConfirm.Text Is Nothing Then
                    MsgBox("Fill out all required field!s", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text = "" And txtNew.Text = "" And txtConfirm.Text = "" Then
                    MsgBox("Fill out all required fields!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text = "" Or txtNew.Text = "" Or txtConfirm.Text = "" Then
                    MsgBox("Fill out all required fields!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtNew.Text <> txtConfirm.Text Then
                    MsgBox("Password confirmation doesn't match!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf txtCurrent.Text = txtNew.Text And txtCurrent.Text = txtConfirm.Text Then
                    MsgBox("Current password and new password should not be the same! Please enter a different password!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf BULibrary.EncryptPwd(txtCurrent.Text) <> dtChkPwd.Rows(0)("Password").ToString() Then
                    MsgBox("Please enter your correct current password!", MsgBoxStyle.Exclamation)
                    clearAllTxt()
                ElseIf BULibrary.EncryptPwd(txtCurrent.Text) = dtChkPwd.Rows(0)("Password").ToString() Then

                    BULibrary.OpenSqlCon()
                    BULibrary.UpdatePassword("spUpdatePassword", strUserIDL, BULibrary.EncryptPwd(txtNew.Text), 1)
                    BULibrary.CloseSqlCon()
                    MsgBox("Password has been changed.")
                    Me.Close()
                End If

            Else
                MsgBox("Login Failed! Contanct your system administrator.", MsgBoxStyle.Exclamation)

            End If

        End If

    End Sub
    Public Sub clearAllTxt()
        txtCurrent.Clear()
        txtNew.Clear()
        txtConfirm.Clear()
    End Sub

    Private Sub frmChangePwd_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnChange.Focus()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If (IsFirstLoginH) Then
            Me.Close()
            Dim frmLogin As New frmLogin()
            frmLogin.Show()
        Else
            Me.Close()
        End If
        
    End Sub
End Class