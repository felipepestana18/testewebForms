Imports System.Data.SqlClient

Public Class Data
    Implements IDisposable

    Protected connectionDB As SqlConnection

    Public Sub New()
        Try
            Dim strConexao As String = "Data Source = DESKTOP-P7N6VT1\MSSQLSERVER01;
                                      initial Catalog = DesafioFelipe;
                                      integrated Security = true;
                                      Trusted_Connection=True;
                                      MultipleActiveResultSets=True;"
            connectionDB = New SqlConnection(strConexao)
            connectionDB.Open()
        Catch er As SqlException
            Console.WriteLine("Erro do Banco ")
        End Try
    End Sub

    Public Sub Dispose()
        connectionDB.Close()
    End Sub

    Private Sub IDisposable_Dispose() Implements IDisposable.Dispose
        Throw New NotImplementedException()
    End Sub
End Class
