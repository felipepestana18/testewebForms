Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports Microsoft.SqlServer

Public Class AssociadosData
    Inherits Data


    Public Function Carregar() As List(Of Associados)

        Dim lista As List(Of Associados) = New List(Of Associados)()
        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = connectionDB
        cmd.CommandText = "SELECT Id, Nome, Cpf, DataNascimento FROM Associados"
        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()
            Dim associado As New Associados()

            associado.Id = CInt(Reader("Id"))
            associado.Nome = CStr(Reader("Nome"))
            associado.Cpf = CStr(Reader("Cpf"))
            associado.DataNascimento = CStr(Reader("DataNascimento"))
            lista.Add(associado)

        End While
        Return lista

    End Function

    Public Function CarregarInformacaoAssociado(ByVal IdAssociado As Integer) As List(Of Associados)
        Dim lista As List(Of Associados) = New List(Of Associados)()
        Dim cmd As SqlCommand = New SqlCommand()
        Dim associado As New Associados()
        Dim empresaViewModel As New EmpresaViewModels()

        cmd.Connection = connectionDB
        cmd.CommandText = "select
	                        a.ID,
	                        a.Nome,
	                        a.Cpf,
	                        a.DataNascimento,
	                        e.Id as idEmpresa,
                            e.Nome as nomeEmpresa
                        from Associados a
                        left join Associados_Emp emp
                          on emp.Id_associado = a.Id
                        left join Empresas e
                          on e.Id = emp.Id_empresa
                        where a.Id = @id"

        cmd.Parameters.AddWithValue("@id", IdAssociado)
        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()

            associado.Id = CInt(Reader("Id"))
            associado.Nome = CStr(Reader("Nome"))
            associado.Cpf = CStr(Reader("Cpf"))
            associado.DataNascimento = CStr(Reader("DataNascimento"))
            empresaViewModel.Id = IIf(Convert.IsDBNull(Reader("idEmpresa")), 0, Reader("idEmpresa"))
            empresaViewModel.Nome = IIf(Convert.IsDBNull(Reader("idEmpresa")), Nothing, Reader("nomeEmpresa"))
            associado.empresas.Add(empresaViewModel)
            lista.Add(associado)
        End While
        Return lista
    End Function


    Public Function Create(Associados As Associados) As Boolean

        Try

            Dim cmd As SqlCommand = New SqlCommand()
            cmd.Connection = connectionDB
            cmd.CommandText = "insert into Associados (Nome, Cpf, DataNascimento) values (@nome, @cpf, @dataNascimento); SELECT SCOPE_IDENTITY();"
            cmd.Parameters.AddWithValue("@nome", Associados.Nome)
            cmd.Parameters.AddWithValue("@cpf", Associados.Cpf)
            cmd.Parameters.AddWithValue("@dataNascimento", Associados.DataNascimento)
            Dim IdAssociado As Integer = CInt(cmd.ExecuteScalar())

            Dim cmd1 As SqlCommand = New SqlCommand()
            cmd1.Connection = connectionDB
            If (Associados.empresas.Count > 0) Then

                For Each item In Associados.empresas

                    If item.Id > 0 Then
                        cmd1.CommandText = "insert into Associados_Emp (Id_associado, Id_empresa) values (@id_associado, @id_empresa)"
                        cmd1.Parameters.AddWithValue("@id_Associado", IdAssociado)
                        cmd1.Parameters.AddWithValue("@id_Empresa", item.Id)
                        cmd1.ExecuteNonQuery()
                        cmd1.Parameters.Clear()
                    End If
                Next

            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function Update(Associados As Associados) As Boolean

        Try

            Dim cmd As SqlCommand = New SqlCommand()
            cmd.Connection = connectionDB
            cmd.CommandText = "UPDATE Associados
                                SET Nome = @nome,
	                                 Cpf= @cpf,
	                                 DataNascimento = @dataNascimento
                                WHERE Associados.Id = @Id"
            cmd.Parameters.AddWithValue("@Id", Associados.Id)
            cmd.Parameters.AddWithValue("@nome", Associados.Nome)
            cmd.Parameters.AddWithValue("@cpf", Associados.Cpf)
            cmd.Parameters.AddWithValue("@dataNascimento", Associados.DataNascimento)
            cmd.ExecuteNonQuery()

            Dim cmd1 As SqlCommand = New SqlCommand()




            If (Associados.empresas.Count > 0) Then

                For Each item In Associados.empresas
                    cmd1.Connection = connectionDB

                    If item.Id > 0 Then
                        cmd1.CommandText = "
                                            IF (EXISTS(SELECT * FROM Associados_Emp emp WHERE emp.Id_associado = @id_associado and emp.Id_empresa = @idEmpresa)) 
                                            BEGIN 
                                              DELETE FROM  Associados_Emp WHERE Id_associado = @id_associado AND Id_empresa IN(SELECT Id_empresa FROM Associados_Emp  WHERE Id_empresa <> @idEmpresa AND Id_associado = @id_Associado )
                                            END 
                                            ELSE 
                                            BEGIN 
                                             INSERT INTO Associados_Emp(Id_associado, Id_empresa) 
                                                VALUES(@id_associado, @idEmpresa) 
                                            END "
                        cmd1.Parameters.AddWithValue("@id_Associado", Associados.Id)
                        cmd1.Parameters.AddWithValue("@idEmpresa", item.Id)
                        cmd1.ExecuteNonQuery()
                        cmd1.Parameters.Clear()

                    End If
                Next

            End If

            Return True

        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Sub Delete(ByVal IdAssociado As Integer)
        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = connectionDB
        cmd.CommandText = "exec SpaExcluirAssociados @id"
        cmd.Parameters.AddWithValue("@id", IdAssociado)
        cmd.ExecuteNonQuery()
    End Sub


    Public Function CarregarEmpresa() As List(Of EmpresaViewModels)
        Dim lista As List(Of EmpresaViewModels) = New List(Of EmpresaViewModels)()
        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = connectionDB
        cmd.CommandText = "select 
							   id, 
						       Nome
						 from Empresas"


        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()
            Dim empresa As New EmpresaViewModels()
            empresa.Id = CInt(Reader("id"))
            empresa.Nome = CStr(Reader("Nome"))

            lista.Add(empresa)
        End While
        Return lista
    End Function

    Public Function CarregarEmpresaPrenchida(ByVal IdAssociado As Integer) As List(Of String)
        Dim lista As List(Of String) = New List(Of String)()

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = connectionDB
        cmd.CommandText = "select emp.Id_empresa from Associados_Emp emp where emp.Id_associado = @id "
        cmd.Parameters.AddWithValue("@id", IdAssociado)
        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()
            Dim empresa As String
            empresa = CStr(Reader("Id_empresa").ToString())
            lista.Add(empresa)
        End While
        Return lista
    End Function
End Class