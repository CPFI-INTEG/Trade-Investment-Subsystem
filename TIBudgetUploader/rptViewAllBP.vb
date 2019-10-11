Imports System.IO
Public Class rptViewAllBP

    Private Sub rptViewAllBP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim dtBP As New DataTable()
        dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP")

        Me.grdBP.DataSource = dtBP
        Me.grdBP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells        
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim dtBP As New DataTable()

        If txtBPCode.Text = "" Then
            dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP " &
                                      "WHERE " &
                                      "CustomerName like '%" & txtBP.Text & "%'")
        ElseIf txtBP.Text = "" Then
            dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP " &
                                       "WHERE CustomerCode like '%" & txtBPCode.Text & "%' ")

        Else
            dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP " &
                                      "WHERE CustomerCode like '%" & txtBPCode.Text & "%' " &
                                      "OR CustomerName like '%" & txtBP.Text & "%'")
        End If


        Me.grdBP.DataSource = dtBP
        Me.grdBP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As System.Object, e As System.EventArgs) Handles btnRefresh.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        Dim dtBP As New DataTable()
        dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP")

        Me.grdBP.DataSource = dtBP
        Me.grdBP.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Me.txtBP.Clear()
        Me.txtBPCode.Clear()
    End Sub
    Private Sub Download(ByVal strPath As String, ByVal dt As DataTable)
        Dim bpcode, _
            bp, _
            parentcd, _
            parnt, _
            tax, _
            status, _
            ctypecode, _
            custype, _
            sysdate As String

        Dim sw As New StreamWriter(strPath & "\\BP" & ".csv")
        sw.WriteLine("CustomerCode" & "," & "CustomerName" & "," & "ParentCustomerCode" & "," & "ParentCustomerName" & "," & "TAX" & "," & "Status" & "," & "CustomerTypeCode" & "," & "CustomerType" & "," & "SystemDate")
        For i As Integer = 0 To dt.Rows.Count - 1
            bpcode = dt.Rows(i)("CustomerCode").ToString().Replace(",", "")
            bp = dt.Rows(i)("CustomerName").ToString().Replace(",", "")
            parentcd = dt.Rows(i)("ParentCustomerCode").ToString().Replace(",", "")
            parnt = dt.Rows(i)("ParentCustomerName").ToString().Replace(",", "")
            tax = dt.Rows(i)("TAX").ToString().Replace(",", "")
            status = dt.Rows(i)("Status").ToString().Replace(",", "")
            ctypecode = dt.Rows(i)("CustomerTypeCode").ToString().Replace(",", "")
            custype = dt.Rows(i)("CustomerType").ToString().Replace(",", "")
            sysdate = dt.Rows(i)("SystemDate").ToString().Replace(",", "")

            sw.WriteLine(bpcode & "," & bp & "," & parentcd & "," & parnt & "," & tax & "," & status & "," & ctypecode & "," & custype & "," & sysdate)

            'sw.WriteLine()
        Next
        sw.Close()
    End Sub

    'Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click

    '    If grdBP.Rows.Count = 0 Then
    '        MsgBox("Can't export to exscel please run report!", MsgBoxStyle.Exclamation)
    '        Return

    '    End If

    '    Dim BULibrary As New TIBudgetUploader.BULibrary()

    '    Dim dtBP As New DataTable()

    '    If txtBPCode.Text = "" Then
    '        dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP " &
    '                                  "WHERE " &
    '                                  "CustomerName like '%" & txtBP.Text & "%'")
    '    ElseIf txtBP.Text = "" Then
    '        dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP " &
    '                                   "WHERE CustomerCode like '%" & txtBPCode.Text & "%' ")
    '    Else
    '        dtBP = BULibrary.SqlDataTable("SELECT * FROM viewAllBP " &
    '                                  "WHERE CustomerCode like '%" & txtBPCode.Text & "%' " &
    '                                  "OR CustomerName like '%" & txtBP.Text & "%'")
    '    End If
    '    Dim fBrowse As New FolderBrowserDialog

    '    With fBrowse
    '        .Description = "Save File"
    '        .ShowNewFolderButton = True
    '    End With

    '    Download(fBrowse.SelectedPath, dtBP)
    'End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dt As New DataTable()
        dt = BULibrary.SqlDataTable("SELECT * FROM viewAllBP")
        'dt = grdBP.datas

        Dim fBrowse As New FolderBrowserDialog

        With fBrowse
            .Description = "Choose Destination"
            .ShowNewFolderButton = True
        End With
        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Download(fBrowse.SelectedPath, dt)
            MsgBox("File successfully downloaded!", MsgBoxStyle.Information)
        End If        
    End Sub

End Class