Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class frmQueryAnalyzer

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Try

            If RichTextBox1.Text.ToLower().Contains("delete") Or RichTextBox1.Text.ToLower().Contains("drop") Or RichTextBox1.Text.ToLower().Contains("update") Or RichTextBox1.Text.ToLower().Contains("alter") Or RichTextBox1.Text.ToLower().Contains("insert") Or RichTextBox1.Text.ToLower().Contains("truncate") Or RichTextBox1.Text.ToLower().Contains("create") Then
                MsgBox("Query Error!", MsgBoxStyle.Exclamation)
                Return
            Else
                Dim BULibrary As New TIBudgetUploader.BULibrary()

                'Dim dt As New DataTable()
                'dt = BULibrary.SqlDataTable(RichTextBox1.Text)

                'DataGridView1.DataSource = dt

                BULibrary.OpenSqlCon()

                Dim rdr As SqlDataReader
                Dim dt As New DataTable()

                rdr = BULibrary.GetQuery(RichTextBox1.Text)
                dt.Load(rdr)

                DataGridView1.DataSource = dt
                'test
                Dim cs As New System.Windows.Forms.DataGridViewCellStyle
                cs.BackColor = Color.LightCyan
                Me.DataGridView1.AlternatingRowsDefaultCellStyle = cs
                'test
                DataGridView1.Refresh()
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells



                rdr.Close()
                BULibrary.CloseSqlCon()
            End If

        Catch ex As Exception
            'MsgBox("Query Error!", MsgBoxStyle.Exclamation)
            MsgBox("Query Error! " & ex.ToString(), MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub frmQueryAnalyzer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim BULibrary As New TIBudgetUploader.BULibrary()
        Dim dtAllTbls As New DataTable()

        dtAllTbls = BULibrary.SqlDataTable("USE TradeInvDB_LIVE" &
                                            " SELECT name FROM sys.tables" &
                                            " where name <> 'sysdiagrams' " &
                                            "ORDER BY name")

        ComboBox1.DataSource = dtAllTbls
        ComboBox1.DisplayMember = "name"
        ComboBox1.ValueMember = "name"


    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim strQuery As String
        strQuery = "Select TOP 1000 * FROM "

        RichTextBox1.Text = strQuery + ComboBox1.SelectedValue.ToString()
    End Sub
End Class