Public Class frmAddUser
    Dim strUserIDL, strUserBUH, strUserPermissionH As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDL = strUserID
        strUserBUH = strUserBU
    End Sub
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click        

        If txtDept.Text = "" Or txtEmpCode.Text = "" Or txtFName.Text = "" Or txtLName.Text = "" Or txtMI.Text = "" Or txtUserID.Text = "" Then
            MsgBox("Please complete all details!", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim BULibrary As New TIBudgetUploader.BULibrary()

        BULibrary.OpenSqlCon()

        BULibrary.InsertUserDetails("spInsertUserDetails", txtEmpCode.Text, txtLName.Text, txtFName.Text, txtMI.Text, combxBU.SelectedValue.ToString(), txtDept.Text)
        BULibrary.InsertUser("spInsertUser", txtUserID.Text, txtEmpCode.Text, combxBU.SelectedValue.ToString(), BULibrary.EncryptPwd("tibs123"))

        MsgBox("User successfully added", MsgBoxStyle.Information)

        BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, "Added User: " & txtUserID.Text, Me.Text, strUserBUH, DateTime.Now)

        BULibrary.CloseSqlCon()
    End Sub

    Private Sub frmAddUser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim dt As New DataTable()

        dt = BULibrary.SqlDataTable("SELECT *,BUCode + '-' + Name AS CODE_NAME FROM tblBusinessUnits")

        combxBU.DataSource = dt

        combxBU.DisplayMember = "CODE_NAME"
        combxBU.ValueMember = "BUCode"

        combxBU.SelectedIndex = 0

    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        txtDept.Clear()
        txtEmpCode.Clear()
        txtFName.Clear()
        txtLName.Clear()
        txtMI.Clear()        
        txtUserID.Clear()
        combxBU.SelectedIndex = 0
    End Sub

    Private Sub GroupBox1_Enter(sender As System.Object, e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class