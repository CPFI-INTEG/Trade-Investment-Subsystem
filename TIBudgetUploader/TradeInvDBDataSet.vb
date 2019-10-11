Partial Class TradeInvDBDataSet
    Partial Class spfxnBudgetVSActual_SummaryDataTable

    End Class

    Partial Class spgetFilterBdgtReportMvmntDataTable

    End Class

    Partial Class viewHeaderBUdgetDataTable

        Private Sub viewHeaderBUdgetDataTable_ColumnChanging(sender As System.Object, e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.ChannelColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace TradeInvDBDataSetTableAdapters
    'Partial Class spgetReportMvmntTableAdapter

    '    Sub Fill(spgetReportMvmntDataTable As Global.TIBudgetUploader.TradeInvDBDataSet.spgetReportMvmntDataTable)
    '        Throw New NotImplementedException
    '    End Sub

    'End Class

    Partial Public Class viewHeaderBUdgetTableAdapter
    End Class
End Namespace
