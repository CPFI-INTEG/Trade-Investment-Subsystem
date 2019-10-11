Public Class frmReportFilters

    Private Sub frmReportFilters_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim channels() As String = {"Modern Trade", _
                                  "General Trade"}

        For Each channel As String In channels
            combxChannel.Items.Add(channel)
        Next

        Dim divisions() As String = {"Frozened", _
                                  "Canned"}

        For Each division As String In divisions
            combxChannel.Items.Add(division)
        Next

    End Sub
End Class