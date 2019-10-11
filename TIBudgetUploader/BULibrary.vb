Imports System.Collections.Generic
Imports System.Linq
Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Configuration
Imports System.Windows.Forms
Imports System.Text
Imports System.Security.Cryptography
Namespace TIBudgetUploader
    Public Class BULibrary
        Protected connection As SqlConnection
        Protected BuConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("BuConnectionString").ConnectionString
        Protected oleconnection As OleDbConnection
        Protected xlsxConnectionString As String = ""
        ''05282014
        'Protected CogConnection As SqlConnection
        'Protected CogConnectionString As String = System.Configuration.ConfigurationManager.ConnectionStrings("CogConnectionString").ConnectionString
        Public Sub New()
            connection = New SqlConnection(BuConnectionString)
            'CogConnection = New SqlConnection(CogConnectionString) '05282014
        End Sub
        'public SqlConnection OpenSqlCon()
        '{

        '    connection = new SqlConnection(BuConnectionString);
        '    return connection;
        '    //using (connection)
        '    //{
        '    //    try
        '    //    {
        '    //        connection.Open();
        '    //    }
        '    //    catch (Exception ex)
        '    //    {
        '    //        MessageBox.Show(ex.ToString());
        '    //    }
        '    //}
        '    //return connection;
        '}
        Public Sub OpenSqlCon()
            Try
                connection.Open()
            Catch ex As Exception
                MsgBox("Can not connect to datasource. Please contact your system administrator!", MsgBoxStyle.Critical)
            End Try
        End Sub
        Public Sub CloseSqlCon()
            connection.Close()
        End Sub
        ''05282014
        'Public Sub openCogCon()
        '    Try
        '        CogConnection.Open()
        '    Catch ex As Exception
        '        MsgBox("Can not connect to COGNOS Datasource. Please contact your system administrator!", MsgBoxStyle.Critical)
        '    End Try
        'End Sub
        'Public Sub closeCogCon()
        '    CogConnection.Close()
        'End Sub
        ''05282014
        Public Sub openOleCon(ByVal filePath As String)
            xlsxConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties=""Excel 12.0;HDR=Yes;IMEX=2"""
            oleconnection = New OleDbConnection(xlsxConnectionString)
            oleconnection.Open()
        End Sub
        Public Sub closeOleCon()
            oleconnection.Close()
        End Sub
        Public Function OleDataTable(ByVal query As String) As DataTable
            Dim oa As New OleDbDataAdapter(query, oleconnection)
            Dim dt As New DataTable()
            oa.Fill(dt)
            Return dt
        End Function
        Public Function SqlDataTable(ByVal query As String) As DataTable
            Dim ad As New SqlDataAdapter(query, connection)
            Dim dt As New DataTable()
            ad.Fill(dt)
            Return dt
        End Function
        Public Sub SqlUpdate(ByVal query As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = query
            cmd.CommandType = CommandType.Text
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Function SpDataTable(ByVal sp As String) As DataTable
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            Return dt
        End Function
        'Public Sub InsertFullBudget(ByVal sp As String, _
        '                            ByVal BudgetID As String, _
        '                            ByVal UploadSequenceNo As String, _
        '                            ByVal Year As Integer, _
        '                            ByVal BudgetCode As String, _
        '                            ByVal BPCode As String, _
        '                            ByVal BusinessUnit As String, _
        '                            ByVal Brand As String, ByVal SKU As String, _
        '                            ByVal Amount As Decimal, _
        '                            ByVal DateUploaded As DateTime)
        Public Sub InsertFullBudget(ByVal sp As String, _
                                    ByVal BudgetID As String, _
                                    ByVal UploadSequenceNo As String, _
                                    ByVal Year As Integer, _
                                    ByVal BudgetCode As String, _
                                    ByVal BPCode As String, _
                                    ByVal Frozen As String, _
                                    ByVal BusinessUnit As String, _
                                    ByVal Amount As Decimal, _
                                    ByVal DateUploaded As DateTime,
                                    ByVal Uploader As String, _
                                    ByVal BatchNo As String,
                                    ByVal IsLatest As Boolean,
                                    ByVal Tax As String,
                                    ByVal Tax_Amt As Decimal)

            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = BudgetID
            cmd.Parameters.Add(New SqlParameter("@UploadSequenceNo", SqlDbType.NVarChar, 50)).Value = UploadSequenceNo
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = Year
            cmd.Parameters.Add(New SqlParameter("@BudgetCode", SqlDbType.NVarChar, 20)).Value = BudgetCode
            cmd.Parameters.Add(New SqlParameter("@Frozen", SqlDbType.NVarChar, 20)).Value = Frozen
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 9)).Value = BPCode
            cmd.Parameters.Add(New SqlParameter("@BusinessUnit", SqlDbType.NVarChar, 3)).Value = BusinessUnit
            'cmd.Parameters.Add(New SqlParameter("@Brand", SqlDbType.NVarChar, 50)).Value = Brand
            'cmd.Parameters.Add(New SqlParameter("@SKU", SqlDbType.NVarChar, 50)).Value = SKU
            cmd.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal])).Value = Amount
            cmd.Parameters.Add(New SqlParameter("@DateUploaded", SqlDbType.DateTime)).Value = DateUploaded
            cmd.Parameters.Add(New SqlParameter("@Uploader", SqlDbType.NVarChar, 20)).Value = Uploader
            cmd.Parameters.Add(New SqlParameter("@BatchNo", SqlDbType.NVarChar, 20)).Value = BatchNo
            cmd.Parameters.Add(New SqlParameter("@IsLatest", SqlDbType.Bit)).Value = IsLatest
            cmd.Parameters.Add(New SqlParameter("@Tax", SqlDbType.NVarChar, 50)).Value = Tax
            cmd.Parameters.Add(New SqlParameter("@Tax_Amt", SqlDbType.Decimal)).Value = Tax_Amt
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        '04062015
        Public Sub InsertRevisedBudget(ByVal sp As String, _
                            ByVal BudgetID As String, _
                            ByVal Year As Integer, _
                            ByVal Budget As String, _
                            ByVal BPCode As String, _
                            ByVal SeqNo As String, _
                            ByVal Division As String, _
                            ByVal BU As Integer, _
                            ByVal Flag As String, _
                            ByVal Month As Integer, _
                            ByVal Amount As Decimal, _
                            ByVal PrevID As String, _
                            ByVal PrevAmt As Decimal
                            )

            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = BudgetID
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = Year
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 50)).Value = Budget
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 9)).Value = BPCode
            cmd.Parameters.Add(New SqlParameter("@SeqNo", SqlDbType.NVarChar, 2)).Value = SeqNo
            cmd.Parameters.Add(New SqlParameter("@Division", SqlDbType.NVarChar, 50)).Value = Division
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.Int)).Value = BU
            cmd.Parameters.Add(New SqlParameter("@Flag", SqlDbType.NVarChar, 3)).Value = Flag
            cmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.Int)).Value = Month
            cmd.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal])).Value = Amount
            cmd.Parameters.Add(New SqlParameter("@PrevID", SqlDbType.NVarChar, 50)).Value = PrevID
            cmd.Parameters.Add(New SqlParameter("@PrevAmt", SqlDbType.[Decimal])).Value = PrevAmt
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertDetailBudget(ByVal sp As String, _
                                      ByVal budgetid As String, _
                                      ByVal bpcode As String, _
                                      ByVal month As Integer, _
                                      ByVal amount As Decimal, _
                                      ByVal budget As String, _
                                      ByVal frozen As String, _
                                      ByVal year As Integer, _
                                      ByVal bu As String,
                                      ByVal Tax As String,
                                      ByVal Tax_Amt As Decimal, _
                                      ByVal SeqNo As String, _
                                      ByVal PrevID As String, _
                                      ByVal PrevAmt As Decimal)

            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 50)).Value = bpcode
            cmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.Int)).Value = month
            cmd.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal])).Value = Math.Round(amount, 2)
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 50)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@Frozen", SqlDbType.NVarChar, 50)).Value = frozen
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = year
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            cmd.Parameters.Add(New SqlParameter("@Tax", SqlDbType.NVarChar, 50)).Value = Tax
            cmd.Parameters.Add(New SqlParameter("@Tax_Amt", SqlDbType.Decimal)).Value = Tax_Amt
            cmd.Parameters.Add(New SqlParameter("@UploadSequenceNo", SqlDbType.NVarChar, 2)).Value = SeqNo
            cmd.Parameters.Add(New SqlParameter("@PrevID", SqlDbType.NVarChar, 50)).Value = PrevID
            cmd.Parameters.Add(New SqlParameter("@PrevAmt", SqlDbType.Decimal)).Value = PrevAmt

            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertRevDetBudget(ByVal sp As String, _
                                      ByVal budgetid As String, _
                                      ByVal bpcode As String, _
                                      ByVal bcode As String, _
                                      ByVal month As Integer, _
                                      ByVal amount As Decimal)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 50)).Value = bpcode
            cmd.Parameters.Add(New SqlParameter("@BudgetCode", SqlDbType.NVarChar, 10)).Value = bcode
            cmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.Int)).Value = month
            cmd.Parameters.Add(New SqlParameter("@Amount", SqlDbType.[Decimal])).Value = Math.Round(amount, 2)
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Function GetBudgetCode(ByVal sp As String, ByVal budget As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@budget", SqlDbType.NVarChar, 50)).Value = budget
            'cmd.Parameters.Add(new SqlParameter("@cls", SqlDbType.NVarChar, 50)).Value = cls;
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function GetBudgetID(ByVal sp As String, _
                                    ByVal budgetid As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            'cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 50)).Value = bpcode
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function ChkUpload(ByVal sp As String, _
                                  ByVal year As Integer, _
                                  ByVal budget As String, _
                                  ByVal bpcode As String, _
                                  ByVal frozen As String, _
                                  ByVal bu As String, _
                                  ByVal tax As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = year
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 50)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 9)).Value = bpcode
            cmd.Parameters.Add(New SqlParameter("@Frozen", SqlDbType.NVarChar, 50)).Value = frozen
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            cmd.Parameters.Add(New SqlParameter("@EWT", SqlDbType.NVarChar, 3)).Value = tax
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function GetDetailBudget(ByVal sp As String, _
                                        ByVal budgetid As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            'cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 9)).Value = bpcode
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function GetMaxSeqNo(ByVal sp As String, _
                                    ByVal bpcode As String, _
                                    ByVal yr As String, _
                                    ByVal budget As String,
                                    ByVal bu As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 50)).Value = bpcode
            cmd.Parameters.Add(New SqlParameter("@yr", SqlDbType.NVarChar, 50)).Value = yr
            cmd.Parameters.Add(New SqlParameter("@budget", SqlDbType.NVarChar, 50)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function GetDetByMonth(ByVal sp As String, _
                                       ByVal month As Integer, _
                                       ByVal budgetid As String) As DataTable 'get current uploaded revised (HEADER)
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.Int)).Value = month
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function GetBalance(ByVal sp As String, _
                                   ByVal budgetid As String, _
                                   ByVal month As Integer) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            cmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.Int)).Value = month
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function ChkIfHdrExist(ByVal sp As String, ByVal bpcode As String, ByVal yr As String, _
                                      ByVal budget As String, ByVal seqno As String, _
                                      ByVal amt As Decimal) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 50)).Value = bpcode
            cmd.Parameters.Add(New SqlParameter("@yr", SqlDbType.NVarChar, 50)).Value = yr
            cmd.Parameters.Add(New SqlParameter("@budget", SqlDbType.NVarChar, 50)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@seqno", SqlDbType.NVarChar, 2)).Value = seqno
            cmd.Parameters.Add(New SqlParameter("@amt", SqlDbType.Decimal)).Value = amt
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function GetCurUploadedBudget(ByVal sp As String, ByVal userid As String) As DataTable
            'ByVal seqno As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Sub InsertToTemp(ByVal sp As String, _
                              ByVal budgetid As String, _
                              ByVal userid As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertToTempB(ByVal sp As String, _
                              ByVal budgetid As String, _
                              ByVal userid As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 50)).Value = budgetid
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 50)).Value = userid
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertToTempC(ByVal sp As String, _
                      ByVal type As String, _
                      ByVal userid As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.NVarChar, 50)).Value = type
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 50)).Value = userid
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertToTempD(ByVal sp As String, _
              ByVal type As String, _
              ByVal userid As String, _
              ByVal status As String, _
              ByVal compfrm As String, _
              ByVal budget As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Type", SqlDbType.NVarChar, 50)).Value = type
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 50)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@Status", SqlDbType.NVarChar, 10)).Value = status
            cmd.Parameters.Add(New SqlParameter("@CompFrm", SqlDbType.NVarChar, 50)).Value = compfrm
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 10)).Value = budget
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub

        Public Sub InsertBatch(ByVal sp As String, _
                              ByVal year As Integer)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = year
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Function GetMaxBatch(ByVal sp As String, _
                                 ByVal yr As Integer) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = yr
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Sub InsertRcjn(ByVal sp As String, _
                              ByVal rcjn As String, _
                              ByVal yr As Integer, _
                              ByVal month As Integer,
                              ByVal downloaded As Boolean, _
                              ByVal datedownloaded As DateTime, _
                              ByVal userid As String, _
                              ByVal series As String, _
                              ByVal bu As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Rcjn", SqlDbType.NVarChar, 50)).Value = rcjn
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = yr
            cmd.Parameters.Add(New SqlParameter("@Month", SqlDbType.Int)).Value = month
            cmd.Parameters.Add(New SqlParameter("@Downloaded", SqlDbType.Bit)).Value = downloaded
            cmd.Parameters.Add(New SqlParameter("@DateDownloaded", SqlDbType.DateTime)).Value = datedownloaded
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@Series", SqlDbType.NVarChar, 50)).Value = series
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertSeries(ByVal sp As String, _
                              ByVal series As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Series", SqlDbType.NVarChar, 4)).Value = series
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub UpdateRcjn(ByVal sp As String, _
                              ByVal series As String, _
                              ByVal datedownloaded As DateTime, _
                              ByVal userid As String,
                              ByVal downloaded As Boolean, _
                              ByVal bu As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Series", SqlDbType.NVarChar, 50)).Value = series
            cmd.Parameters.Add(New SqlParameter("@DateDownloaded", SqlDbType.DateTime, 50)).Value = datedownloaded
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 50)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@Downloaded", SqlDbType.Bit)).Value = downloaded
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub UpdateHdrBudget(ByVal sp As String, _
                                    ByVal rcjn As String, _
                                    ByVal budgetid As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Rcjn", SqlDbType.NVarChar, 3)).Value = rcjn
            cmd.Parameters.Add(New SqlParameter("@BudgetID", SqlDbType.NVarChar, 50)).Value = budgetid
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub

        Public Function ChkLogin(ByVal sp As String, _
                                 ByVal userid As String, _
                                 ByVal pw As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@PW", SqlDbType.NVarChar, 50)).Value = pw
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function EncryptPwd(ByVal strPwd As String) As String

            Dim sha1Obj As New Security.Cryptography.SHA1CryptoServiceProvider
            Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(strPwd)

            bytesToHash = sha1Obj.ComputeHash(bytesToHash)

            Dim strResult As String = ""

            For Each b As Byte In bytesToHash
                strResult += b.ToString("x1")
            Next

            Return strResult

        End Function
        Public Sub InsertUser(ByVal sp As String, _
                              ByVal userid As String, _
                              ByVal empcode As String, _
                              ByVal bu As String, _
                              ByVal pwd As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@EmpCode", SqlDbType.NVarChar, 8)).Value = empcode
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            cmd.Parameters.Add(New SqlParameter("@Password", SqlDbType.NVarChar, 50)).Value = pwd
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertUserDetails(ByVal sp As String, _
                              ByVal empcode As String, _
                              ByVal last As String, _
                              ByVal first As String, _
                              ByVal middle As String, _
                              ByVal bu As String, _
                              ByVal dept As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@EmpCode", SqlDbType.NVarChar, 8)).Value = empcode
            cmd.Parameters.Add(New SqlParameter("@LastName", SqlDbType.NVarChar, 20)).Value = last
            cmd.Parameters.Add(New SqlParameter("@FirstName", SqlDbType.NVarChar, 20)).Value = first
            cmd.Parameters.Add(New SqlParameter("@Middle ", SqlDbType.NVarChar, 5)).Value = middle
            cmd.Parameters.Add(New SqlParameter("@BU ", SqlDbType.NVarChar, 5)).Value = bu
            cmd.Parameters.Add(New SqlParameter("@Department ", SqlDbType.NVarChar, 20)).Value = dept
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertUserPermissions(ByVal sp As String, _
                             ByVal userid As String, _
                             ByVal empcode As String, _
                             ByVal perid As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@EmpCode", SqlDbType.NVarChar, 8)).Value = empcode
            cmd.Parameters.Add(New SqlParameter("@PermissionID", SqlDbType.NVarChar, 2)).Value = perid
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub UpdatePassword(ByVal sp As String, _
                              ByVal userid As String, _
                              ByVal pwd As String, _
                              ByVal intIspwdchngd As Integer)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@Password", SqlDbType.NVarChar, 50)).Value = pwd
            cmd.Parameters.Add(New SqlParameter("@PasswordChanged", SqlDbType.Int, 1)).Value = intIspwdchngd
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertError(ByVal sp As String, _
                               ByVal userid As String, _
                               ByVal form As String, _
                               ByVal filename As String, _
                               ByVal excel As String, _
                               ByVal errdate As DateTime
                               )
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 50)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@Form", SqlDbType.NVarChar, 50)).Value = form
            cmd.Parameters.Add(New SqlParameter("@FileName", SqlDbType.NVarChar)).Value = filename
            cmd.Parameters.Add(New SqlParameter("@ExcelFileName", SqlDbType.NVarChar, 50)).Value = excel
            cmd.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime)).Value = errdate
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertAuditLog(ByVal sp As String, _
                       ByVal userid As String, _
                       ByVal action As String, _
                       ByVal form As String, _
                       ByVal bu As String, _
                       ByVal auditDate As DateTime
                       )
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 50)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@Action", SqlDbType.NVarChar, 100)).Value = action
            cmd.Parameters.Add(New SqlParameter("@FormName", SqlDbType.NVarChar, 50)).Value = form
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            cmd.Parameters.Add(New SqlParameter("@Date", SqlDbType.DateTime)).Value = auditDate
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub CopyFile(ByVal FileToCopy As String, ByVal NewCopy As String)
            If System.IO.File.Exists(FileToCopy) = True Then
                System.IO.File.Copy(FileToCopy, NewCopy)
            End If
        End Sub
        Public Function GetUsrPermission(ByVal sp As String, _
                                         ByVal empcode As String, _
                                         ByVal userid As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@EmpCode", SqlDbType.NVarChar, 8)).Value = empcode
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function ChkUsrPermissionIfExist(ByVal sp As String, _
                                         ByVal empcode As String, _
                                         ByVal userid As String, _
                                         ByVal permission As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@EmpCode", SqlDbType.NVarChar, 8)).Value = empcode
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            cmd.Parameters.Add(New SqlParameter("@Permission", SqlDbType.NVarChar, 50)).Value = permission
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function GetAllUsers(ByVal sp As String, _
                                 ByVal userid As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@UserID", SqlDbType.NVarChar, 20)).Value = userid
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Function ChkActOrDeac(ByVal sp As String, _
                                      ByVal budgetcode As String, _
                                      ByVal budget As String, _
                                      ByVal budgetclass As String, _
                                      ByVal ttyp As String, _
                                      ByVal uploadtype As String, _
                                      ByVal grpclass As String) As DataTable
            'connection.Open();
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetCode", SqlDbType.NVarChar, 20)).Value = budgetcode
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 20)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@BudgetClass", SqlDbType.NVarChar, 50)).Value = budgetclass
            cmd.Parameters.Add(New SqlParameter("@TransType", SqlDbType.NVarChar, 3)).Value = ttyp
            cmd.Parameters.Add(New SqlParameter("@UploadType", SqlDbType.NVarChar, 20)).Value = uploadtype
            cmd.Parameters.Add(New SqlParameter("@GrpClass", SqlDbType.NVarChar, 2)).Value = grpclass
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        Public Sub UpdateBudgetClass(ByVal sp As String, _
                                      ByVal budgetcode As String, _
                                      ByVal budget As String, _
                                      ByVal budgetclass As String, _
                                      ByVal ttyp As String, _
                                      ByVal uploadtype As String, _
                                      ByVal grpclass As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetCode", SqlDbType.NVarChar, 20)).Value = budgetcode
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 20)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@BudgetClass", SqlDbType.NVarChar, 50)).Value = budgetclass
            cmd.Parameters.Add(New SqlParameter("@TransType", SqlDbType.NVarChar, 3)).Value = ttyp
            cmd.Parameters.Add(New SqlParameter("@UploadType", SqlDbType.NVarChar, 20)).Value = uploadtype
            cmd.Parameters.Add(New SqlParameter("@GrpClass", SqlDbType.NVarChar, 2)).Value = grpclass
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        Public Sub InsertBClass(ByVal sp As String, _
                                ByVal budgetcode As String, _
                                ByVal budget As String, _
                                ByVal budgetclass As String, _
                                ByVal ttyp As String, _
                                ByVal uploadtype As String, _
                                ByVal grpclass As String,
                                ByVal grpcode As Integer)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetCode", SqlDbType.NVarChar, 20)).Value = budgetcode
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 50)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@BudgetClass", SqlDbType.NVarChar, 50)).Value = budgetclass
            cmd.Parameters.Add(New SqlParameter("@TransType", SqlDbType.NVarChar, 3)).Value = ttyp
            cmd.Parameters.Add(New SqlParameter("@UploadType", SqlDbType.NVarChar, 20)).Value = uploadtype
            cmd.Parameters.Add(New SqlParameter("@GrpClass", SqlDbType.NVarChar, 20)).Value = grpclass
            cmd.Parameters.Add(New SqlParameter("@GROUP2CD", SqlDbType.NVarChar, 20)).Value = grpcode
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        'Public Function ConnectKompie() As Boolean

        '    Try
        '        Dim ret As Long
        '        ret = Shell("net use d: \\10.10.1.84\Docs pl@nn3r2012 /user: administrator")
        '        Return ret
        '        Return True
        '        'Process.Start(
        '    Catch ex As Exception
        '        Return False
        '    End Try

        'End Function
        Public Sub GiveCredentials()
            Dim strCommand As String
            strCommand = "net use x: \\10.10.1.84\Docs pl@nn3r2012 /user:administrator"
            Shell("CMD /k" & strCommand, AppWinStyle.Hide)
        End Sub
        Public Sub DeleteCredentials()
            Dim strCommand As String
            strCommand = "NET USE X: /delete"
            Shell("CMD /k" & strCommand, AppWinStyle.Hide)
        End Sub
        Public Function GetQuery(ByVal query As String) As SqlDataReader
            Dim cmd As New SqlCommand()
            cmd.CommandType = CommandType.Text
            cmd.CommandText = query
            cmd.Connection = connection
            Return cmd.ExecuteReader()
        End Function
        '09202013
        Public Function GetDim3PerBU(ByVal sp As String, ByVal division As String) As DataTable
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Division", SqlDbType.NVarChar, 20)).Value = division
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        '09202013
        Public Function GetDim5PerBU(ByVal sp As String, ByVal bu As String) As DataTable
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 10)).Value = bu
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        '09202013
        Public Function GetDim4PerYr(ByVal sp As String, ByVal yr As String) As DataTable
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.NVarChar, 10)).Value = yr
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            'connection.Close();
            Return dt
        End Function
        ''02022014
        Public Sub UpdateIsLatest(ByVal sp As String, _
                            ByVal yr As Integer, _
                            ByVal budget As String,
                            ByVal bpcode As String,
                            ByVal seqno As String,
                            ByVal division As String,
                            ByVal bu As String, _
                            ByVal ewt As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@year", SqlDbType.Int)).Value = yr
            cmd.Parameters.Add(New SqlParameter("@Budget", SqlDbType.NVarChar, 20)).Value = budget
            cmd.Parameters.Add(New SqlParameter("@BPCode", SqlDbType.NVarChar, 9)).Value = bpcode
            cmd.Parameters.Add(New SqlParameter("@UploadSequenceNo", SqlDbType.NVarChar, 2)).Value = seqno
            cmd.Parameters.Add(New SqlParameter("@Division", SqlDbType.NVarChar, 20)).Value = division
            cmd.Parameters.Add(New SqlParameter("@BusinessUnit", SqlDbType.NVarChar, 3)).Value = bu
            cmd.Parameters.Add(New SqlParameter("@EWT", SqlDbType.NVarChar, 3)).Value = ewt

            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub
        ''02022014
        '02032014
        Public Sub InsertBClassMapping(ByVal sp As String, _
                        ByVal budgetcode As String, _
                        ByVal expacct As String, _
                        ByVal acracct As String, _
                        ByVal dim1 As String, _
                        ByVal dim2 As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@BudgetCode", SqlDbType.NVarChar, 20)).Value = budgetcode
            cmd.Parameters.Add(New SqlParameter("@ExpenseAcct", SqlDbType.NVarChar, 7)).Value = expacct
            cmd.Parameters.Add(New SqlParameter("@AccrualAcct", SqlDbType.NVarChar, 7)).Value = acracct
            cmd.Parameters.Add(New SqlParameter("@Dim1", SqlDbType.NVarChar, 6)).Value = dim1
            cmd.Parameters.Add(New SqlParameter("@Dim2", SqlDbType.NVarChar, 6)).Value = dim2
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub

        Public Sub InsertDim3(ByVal sp As String, _
                        ByVal code As String, _
                        ByVal name As String, _
                        ByVal division As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Code", SqlDbType.NVarChar, 6)).Value = code
            cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name
            cmd.Parameters.Add(New SqlParameter("@Division", SqlDbType.NVarChar, 20)).Value = division
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub

        Public Sub InsertDim4(ByVal sp As String, _
                ByVal code As String, _
                ByVal name As String, _
                ByVal yr As Integer)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Code", SqlDbType.NVarChar, 6)).Value = code
            cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name
            cmd.Parameters.Add(New SqlParameter("@Year", SqlDbType.Int)).Value = yr
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub

        Public Sub InsertDim5(ByVal sp As String, _
                        ByVal code As String, _
                        ByVal name As String, _
                        ByVal bu As String)
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            'connection.Open();
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Code", SqlDbType.NVarChar, 6)).Value = code
            cmd.Parameters.Add(New SqlParameter("@Name", SqlDbType.NVarChar, 50)).Value = name
            cmd.Parameters.Add(New SqlParameter("@BU", SqlDbType.NVarChar, 3)).Value = bu
            Dim ad As New SqlDataAdapter(cmd)
            cmd.ExecuteNonQuery()
            cmd.Dispose()
        End Sub


        '02032014

        Public Function GetLeac(ByVal sp As String, ByVal leac As Integer) As DataTable
            Dim cmd As New SqlCommand()
            cmd.Connection = connection
            cmd.CommandText = sp
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlParameter("@Leac", SqlDbType.VarChar, 12)).Value = leac
            Dim ad As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            ad.Fill(dt)
            Return dt
        End Function

    End Class
End Namespace
