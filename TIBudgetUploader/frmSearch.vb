Imports System.Runtime.Serialization.Formatters.Binary

Public Class frmSearch
    Dim columnIndexH, columnNameH As String
    Dim flagH As Boolean
    Public Sub New(ByVal columnIndex As String, ByVal columnName As String, ByVal flag As Boolean)
        InitializeComponent()
        columnIndexH = columnIndex
        columnNameH = columnName
        flagH = flag
    End Sub
    Dim columnIndex As Integer
    Dim columnName As String
    Dim frmUploader As frmUploader()
    Private Sub frmSearch_Load(sender As System.Object, e As System.EventArgs) Handles Me.Load
        Dim loc As Point
        loc = Control.MousePosition
        Me.Location = loc
        Me.TextBox1.Focus()

        columnIndex = columnIndexH
        columnName = columnNameH
        Label1.Text = columnName

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frmUploader As New frmUploader(True, "", "")
        'Dim frmBrowseUploadedFiles As New frmBrowseUploadedFiles()

        Dim grdData As DataGridView = TryCast(frmUploader.thisForm.Controls("grdData"), DataGridView) 'to access control in other form
        Dim searchValue As String = TextBox1.Text
        grdData.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Try
            For Each row As DataGridViewRow In grdData.Rows
                If Label1.Text = "BudgetID" Then
                    If row.Cells(0).Value.ToString().Contains(searchValue) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "Budget" Then
                    If row.Cells(1).Value.ToString().Contains(searchValue) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "CustomerCode" Then
                    If row.Cells(2).Value.ToString().Contains(searchValue) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "Division" Then
                    If row.Cells(3).Value.ToString().Contains(searchValue) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "Customer" Then
                    If row.Cells(4).Value.ToString().Contains(searchValue.ToUpper()) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "BusinessUnitCode" Then
                    If row.Cells(5).Value.ToString().Contains(searchValue) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "BusinessUnit" Then
                    If row.Cells(6).Value.ToString().Contains(searchValue.ToUpper()) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "FullYrAmt" Then
                    If row.Cells(7).Value.ToString().Contains(searchValue) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
                If Label1.Text = "DateUploaded" Then
                    If row.Cells(8).Value.ToString().Contains(searchValue) Then
                        row.Selected = True
                        grdData.FirstDisplayedScrollingRowIndex = row.Index
                        Me.Close()
                        Return
                    End If
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error Message: " & ex.Message)
        End Try
        Me.Close()
    End Sub

    Private Sub frmSearch_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        'If e.KeyCode = Keys.Escape Then
        '    Me.Close()
        'End If
    End Sub
End Class