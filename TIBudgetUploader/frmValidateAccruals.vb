Public Class frmValidateAccruals
    Dim BULibrary As New TIBudgetUploader.BULibrary()
    Private Sub frmValidateAccruals_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load        
        Dim dtBU As DataTable

        dtBU = BULibrary.SqlDataTable("SELECT BUCode, Name from tblBusinessUnits ORDER BY BUCode")
        combxCompany.DataSource = dtBU
        combxCompany.DisplayMember = "Name"
        combxCompany.ValueMember = "BUCode"
        combxCompany.SelectedIndex = 1
        combxYear.SelectedIndex = 1

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        lstErrorLogs.Items.Clear()
        Dim ctr As Integer = 0
        Dim dtValidateAccrual, dtFPeriods As DataTable
        dtFPeriods = BULibrary.SqlDataTable("SELECT COMPANY_CD as COMPANY, PERIOD, F_GLD AS GLD_CLOSING_STAT FROM PERIOD_STATUS WHERE COMPANY_CD=" & Integer.Parse(combxCompany.SelectedValue.ToString()) &
                                           " AND YEAR=" & Integer.Parse(combxYear.SelectedItem.ToString()))
        dtValidateAccrual = BULibrary.SqlDataTable("spValidateAccrual " & Integer.Parse(combxYear.SelectedItem.ToString()) & "," & Integer.Parse(combxCompany.SelectedValue.ToString()))
        DataGridView1.DataSource = dtFPeriods
        DataGridView2.DataSource = dtValidateAccrual

        For i As Integer = 0 To dtValidateAccrual.Rows.Count - 1
            'check the posted and closed fiscal periods
            If (Decimal.Parse(dtValidateAccrual.Rows(i)("EntryAmt").ToString()) < 0.0 Or Decimal.Parse(dtValidateAccrual.Rows(i)("EntryAmt").ToString()) > 0.0) And dtValidateAccrual.Rows(i)("F_GLD").ToString() = "Closed" Then
                ctr = ctr + 1
                lstErrorLogs.Items.Add(dtValidateAccrual.Rows(i)("BudgetID").ToString() & "Fiscal Period " & dtValidateAccrual.Rows(i)("Month").ToString())
            End If
        Next

        If ctr > 0 Then
            MsgBox("There are " & ctr & " affected accounts that need to be re-checked before posting of accruals")
        End If

    End Sub
End Class