Public Class frmCredentials

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Dim frmQueryAnalyzer As New frmQueryAnalyzer()
        If TextBox1.Text = "t1b5@dm1n" Then
            frmQueryAnalyzer.Show()
            Me.Hide()
        Else

            MsgBox("Wrong Password!", MsgBoxStyle.Exclamation)            
            Me.TextBox1.Clear()
        End If
    End Sub

End Class