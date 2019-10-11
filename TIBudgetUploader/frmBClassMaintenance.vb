Public Class frmBClassMaintenance
    Dim strUserIDL, strUserBUH, strUserPermissionH As String
    Public Sub New(ByVal strUserID As String, ByVal strUserBU As String)
        InitializeComponent()
        strUserIDL = strUserID
        strUserBUH = strUserBU
    End Sub

    Private Sub frmBClassMaintenance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim uploadtypes() As String = {"Per Customer", _
                                  "Per BU"}

        For Each uploadtype As String In uploadtypes
            Me.combxUploadType.Items.Add(uploadtype)
        Next
        Me.combxUploadType.SelectedIndex = 0
        RefreshForm()
    End Sub

    Private Sub Label4_Click(sender As System.Object, e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub grdBClass_RowHeaderMouseClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grdBClass.RowHeaderMouseClick
        txtTtyp.ReadOnly = True
        btnAdd.Enabled = False
        txtBudgetCode.Text = Me.grdBClass.SelectedRows(0).Cells("BudgetCode").Value.ToString()
        combxGroup.Text = Me.grdBClass.SelectedRows(0).Cells("Budget").Value.ToString()
        txtBClass.Text = Me.grdBClass.SelectedRows(0).Cells("BudgetClass").Value.ToString()
        txtTtyp.Text = Me.grdBClass.SelectedRows(0).Cells("TransType").Value.ToString()
        combxUploadType.Text = Me.grdBClass.SelectedRows(0).Cells("UploadType").Value.ToString()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click

        If txtTtyp.Text = "" Or txtTtyp.Text = String.Empty Then
            MsgBox("Kindly input Transaction Type!", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim BULibrary As New TIBudgetUploader.BULibrary()

        If MsgBox("Are you sure you want to add budget?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
            BULibrary.OpenSqlCon()

            BULibrary.InsertBClass("spInsertBClass", txtBudgetCode.Text.Replace("*", ""), _
                                        combxGroup.Text, _
                                        txtBClass.Text.Replace("*", ""), _
                                        txtTtyp.Text.Replace("*", ""), _
                                        combxUploadType.SelectedItem.ToString(), _
                                        combxGroup.SelectedValue.ToString(), 1)

            BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
            "Added Budget Transaction with TtypeCode: " & txtTtyp.Text.Replace("*", "") & " and BudgetCode: " & txtBudgetCode.Text.Replace("*", ""), _
            Me.Text, strUserBUH, DateTime.Now)

            BULibrary.CloseSqlCon()
            MsgBox("Budget successfully added!", MsgBoxStyle.Information)
            RefreshForm()
        Else
            RefreshForm()
        End If


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        If txtBudgetCode.Text = "" Or txtBudgetCode.Text = String.Empty Then
            MsgBox("Please select a budget!", MsgBoxStyle.Exclamation)
            Return
        End If

        If txtBClass.Text = "" Or txtBClass.Text = String.Empty Then
            MsgBox("Please input budget class!", MsgBoxStyle.Exclamation)
            Return
        End If

        If MsgBox("Are you sure you want to update this budget?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
            Dim BULibrary As New TIBudgetUploader.BULibrary()

            BULibrary.OpenSqlCon()

            BULibrary.UpdateBudgetClass("spUpdateBudgetClass", _
                                        txtBudgetCode.Text.Replace("*", ""), _
                                        combxGroup.Text, _
                                        txtBClass.Text.Replace("*", ""), _
                                        txtTtyp.Text.Replace("*", ""), _
                                        combxUploadType.SelectedItem.ToString(), _
                                        combxGroup.SelectedValue.ToString())

            BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
            "Updated Budget Transaction with TtypeCode: " & txtTtyp.Text.Replace("*", "") & " and BudgetCode: " & txtBudgetCode.Text.Replace("*", ""), _
            Me.Text, strUserBUH, DateTime.Now)

            BULibrary.CloseSqlCon()
            MsgBox("Budget successfully updated!", MsgBoxStyle.Information)
            RefreshForm()
        Else
            RefreshForm()
        End If

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If txtBudgetCode.Text = "" Or txtBClass.Text = "" Then
            MsgBox("Please select a budget!", MsgBoxStyle.Exclamation)
            Return
        End If

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtChkActorDeac As New DataTable()

        dtChkActorDeac = BULibrary.ChkActOrDeac("spChkActOrDeac", _
                                                txtBudgetCode.Text, _
                                                combxGroup.Text, _
                                                txtBClass.Text, _
                                                txtTtyp.Text, _
                                                combxUploadType.SelectedItem.ToString(), _
                                                combxGroup.SelectedValue.ToString())

        If dtChkActorDeac.Rows.Count > 0 Then
            If dtChkActorDeac.Rows(0)("Active").ToString() = "True" Then 'user is deactivating the budget
                If MsgBox("Are you sure you want to deactivate this budget?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then
                    BULibrary.OpenSqlCon()

                    BULibrary.SqlUpdate("UPDATE tblBudgetClass " &
                                        "SET Active=0" &
                                        "WHERE " &
                                         "BudgetCode ='" & txtBudgetCode.Text.Replace("*", "") & "' " &
                                         "AND " &
                                         "Budget ='" & combxGroup.Text & "' " &
                                         "AND " &
                                         "BudgetClass ='" & txtBClass.Text.Replace("*", "") & "' " &
                                         "AND  " &
                                         "TransType ='" & txtTtyp.Text.Replace("*", "") & "' " &
                                         "AND " &
                                         "UploadType ='" & combxUploadType.SelectedItem.ToString() & "' " &
                                         "AND " &
                                         "GrpClass ='" & combxGroup.SelectedValue.ToString() & "' ")

                    BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
                    "Deactivated Budget Transaction with TtypeCode: " & txtTtyp.Text.Replace("*", "") & " and BudgetCode: " & txtBudgetCode.Text.Replace("*", ""), _
                    Me.Text, strUserBUH, DateTime.Now)

                    BULibrary.CloseSqlCon()
                    MsgBox("Budget successfully deactivated", MsgBoxStyle.Information)
                End If
            Else 'user is activating the budget
                If MsgBox("Are you sure you want to activate this budget?", MsgBoxStyle.YesNoCancel, "Message") = MsgBoxResult.Yes Then

                    BULibrary.OpenSqlCon()

                    BULibrary.SqlUpdate("UPDATE tblBudgetClass " &
                                        "SET Active=1" &
                                        "WHERE " &
                                         "BudgetCode ='" & txtBudgetCode.Text.Replace("*", "") & "' " &
                                         "AND " &
                                         "Budget ='" & combxGroup.Text & "' " &
                                         "AND " &
                                         "BudgetClass ='" & txtBClass.Text.Replace("*", "") & "' " &
                                         "AND  " &
                                         "TransType ='" & txtTtyp.Text.Replace("*", "") & "' " &
                                         "AND " &
                                         "UploadType ='" & combxUploadType.SelectedItem.ToString() & "' " &
                                         "AND " &
                                         "GrpClass ='" & combxGroup.SelectedValue.ToString() & "' ")

                    BULibrary.InsertAuditLog("spInsertAuditLog", strUserIDL, _
                    "Activated Budget Transaction with TtypeCode: " & txtTtyp.Text.Replace("*", "") & " and BudgetCode: " & txtBudgetCode.Text.Replace("*", ""), _
                    Me.Text, strUserBUH, DateTime.Now)

                    BULibrary.CloseSqlCon()
                    MsgBox("Budget successfully activated", MsgBoxStyle.Information)
                End If
            End If
        Else
            'returned no rows
        End If

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        RefreshForm()
    End Sub
    Private Sub RefreshForm()
        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtGetBudgetClass As New DataTable()


        'Dim uploadtypes() As String = {"Per Customer", _
        '                          "Per BU", _
        '                            "NA"}

        'For Each uploadtype As String In uploadtypes
        '    Me.combxUploadType.Items.Add(uploadtype)
        'Next
        'Me.combxUploadType.SelectedIndex = 0

        Me.combxGroup.DataSource = BULibrary.SqlDataTable("SELECT DISTINCT Budget, GrpClass from tblBudgetClass ")
        Me.combxGroup.DisplayMember = "Budget"
        Me.combxGroup.ValueMember = "GrpClass"
        Me.combxGroup.SelectedIndex = 0

        dtGetBudgetClass = BULibrary.SqlDataTable("SELECT * FROM tblBudgetClass ORDER BY Active DESC")

        Me.grdBClass.DataSource = dtGetBudgetClass
        Me.grdBClass.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        txtBudgetCode.Clear()
        txtBClass.Clear()
        txtTtyp.Text = String.Empty
        combxGroup.SelectedIndex = 0
        combxUploadType.SelectedIndex = 0
        txtBudgetCode.ReadOnly = False
        txtTtyp.ReadOnly = False
        'btnAdd.Enabled = True
    End Sub

    Private Sub combxGroup_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles combxGroup.SelectedIndexChanged

        If txtBudgetCode.Text <> "" And txtBudgetCode.Text.Length > 2 Then

            Dim grpclass As String
            grpclass = combxGroup.SelectedValue.ToString()

            txtBudgetCode.ReadOnly = True
            txtBudgetCode.Text = grpclass & txtBudgetCode.Text.Substring(2, 2)

        Else
            txtBudgetCode.Text = combxGroup.SelectedValue.ToString()
        End If

    End Sub


    Private Sub TaskToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TaskToolStripMenuItem.Click
        Dim frmTasks As New frmTasks()
        frmTasks.Show()

    End Sub
End Class