Imports System.IO
Public Class frmViewError    
    Dim UserIDH, UserBUH, UserPermissionH, txt, lbl As String
    Public Sub New(ByVal UserID As String, ByVal strBU As String, ByVal txtFileLocation As String, ByVal lblFileName As String)
        InitializeComponent()
        UserIDH = UserID
        UserBUH = strBU
        txt = txtFileLocation
        lbl = lblFileName
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmViewError_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim BULibrary As New TIBudgetUploader.BULibrary()

        If listViewError.Items.Count > 0 Then

            Try

                Dim fBrowse As New FolderBrowserDialog

                With fBrowse
                    .Description = "Choose Destination"
                    .ShowNewFolderButton = True
                End With
                If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then                    
                    Dim desErrorLog As String = fBrowse.SelectedPath & "\\" &
                               DateTime.Now.ToString("MM") & DateTime.Now.Day.ToString() &
                               DateTime.Now.Year.ToString() & "_" & UserIDH & ".txt"
                    Dim sw As New StreamWriter(desErrorLog)
                    sw.WriteLine("File Location : " & txt)
                    sw.WriteLine("File Name : " & lbl)
                    sw.WriteLine("User ID : " & UserIDH)
                    sw.WriteLine()
                    For i As Integer = 0 To listViewError.Items.Count - 1
                        sw.WriteLine(listViewError.Items(i).ToString())
                    Next
                    sw.Close()
                    sw.Dispose()
                    MsgBox("Error successfully downloaded to selected path.", MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox("Can't able to write error logs.", MsgBoxStyle.Information)
            End Try

        End If
    End Sub
End Class