Public Class frmLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtChkLogin As New DataTable()
        Dim dtChkIfPwdChangd As New DataTable()
        'Dim frmHome As New frmHome(txtUserName.Text.Trim(), dtChkIfPwdChangd.Rows(0)("BU").ToString())        


        dtChkLogin = BULibrary.ChkLogin("spChkLogin", _
                                        txtUserName.Text, _
                                        BULibrary.EncryptPwd(txtPassword.Text))

        If dtChkLogin.Rows.Count > 0 Then

            dtChkIfPwdChangd = BULibrary.SqlDataTable("SELECT *, DATEDIFF(day, GETDATE(), DateExpiration) AS RemainingDays FROM tblUsers " &
                                                      "WHERE UserID='" & txtUserName.Text & "'")
            If dtChkIfPwdChangd.Rows(0)("PasswordChanged").ToString() = False Then
                If dtChkIfPwdChangd.Rows(0)("Active").ToString() = "True" Then
                    Dim frmChangePwd As New frmChangePwd(txtUserName.Text, dtChkIfPwdChangd.Rows(0)("BU").ToString(), True)
                    frmChangePwd.Show()
                    Me.Hide()
                Else
                    MsgBox("User is inactive. Failed to login!", MsgBoxStyle.Exclamation)
                End If
                'Dim frmChangePwd As New frmChangePwd(txtUserName.Text, dtChkIfPwdChangd.Rows(0)("BU").ToString())
                'frmChangePwd.Show()
                'Me.Hide()
            Else

                If dtChkIfPwdChangd.Rows(0)("Active").ToString() = "True" Then
                    '01212014
                    If Integer.Parse(dtChkIfPwdChangd.Rows(0)("RemainingDays").ToString()) < 0 Then
                        MsgBox("Your password was already expired. Please contact your system administrator", MsgBoxStyle.Exclamation)
                    ElseIf Integer.Parse(dtChkIfPwdChangd.Rows(0)("RemainingDays").ToString()) <= 10 Then
                        MsgBox("Your password will expire in " & dtChkIfPwdChangd.Rows(0)("RemainingDays").ToString() & "days. Please change password before expiration.", MsgBoxStyle.Information)
                        Dim frmHome As New frmHome(txtUserName.Text.Trim(), dtChkIfPwdChangd.Rows(0)("BU").ToString())
                        frmHome.Show()
                        Me.Hide()
                    Else
                        Dim frmHome As New frmHome(txtUserName.Text.Trim(), dtChkIfPwdChangd.Rows(0)("BU").ToString())
                        frmHome.Show()
                        Me.Hide()
                    End If
                    '01212014

                    'Dim frmHome As New frmHome(txtUserName.Text.Trim(), dtChkIfPwdChangd.Rows(0)("BU").ToString())
                    'frmHome.Show()
                    'Me.Hide()

                Else
                    MsgBox("User is inactive. Failed to login!", MsgBoxStyle.Exclamation)
                End If

            End If

        Else
            MsgBox("Login failed. Input correct username and password.", MsgBoxStyle.Exclamation)
            txtPassword.Clear()
        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        'Me.Close()

        Me.Dispose()
        Application.Exit()

    End Sub

    Private Sub frmLogin_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Dim strImgLocation As String = Image.FromFile(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", "login.jpg")).ToString()
        'PictureBox1.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath & "\\Images\\logo.bmp")
        'Me.Icon = System.Drawing.Icon.ExtractAssociatedIcon(System.Windows.Forms.Application.StartupPath & "\\Images\\Copy of icon.png")
        PictureBox1.Image = My.Resources.resTIBUploader.cpglogo


    End Sub


End Class
