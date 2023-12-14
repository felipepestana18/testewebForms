Imports System.Data.SqlClient
Imports System.Diagnostics.Eventing
Imports Microsoft.SqlServer

Public Class EmpresasData
    Inherits Data


    Public Function Carregar() As List(Of Empresas)

        Dim lista As List(Of Empresas) = New List(Of Empresas)()
        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = connectionDB
        cmd.CommandText = "SELECT Id, Nome, Cnpj FROM Empresas"
        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()
            Dim empresa As New Empresas()

            empresa.Id = CInt(Reader("Id"))
            empresa.Nome = CStr(Reader("Nome"))
            empresa.Cnpj = CStr(Reader("Cnpj"))
            lista.Add(empresa)

        End While
        Return lista

    End Function

    Public Function CarregarInformacaoAssociado(ByVal idEmpresa As Integer) As List(Of Empresas)
        Dim lista As List(Of Empresas) = New List(Of Empresas)()
        Dim cmd As SqlCommand = New SqlCommand()
        Dim empresa As New Empresas()
        Dim associadosViewModel As New AssociadosViewModels()

        cmd.Connection = connectionDB
        cmd.CommandText = "select emp.Id,
							   emp.Nome,
							   emp.Cnpj,
							   ascd.Id as idAssociado,
							   ascd.Nome as nomeAssociado
						from Empresas emp
						left join Associados_Emp asm
						on asm.Id_empresa = emp.Id
						left join Associados ascd
						on ascd.Id = asm.Id_associado
						where emp.id = @id"

        cmd.Parameters.AddWithValue("@id", idEmpresa)
        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()
            empresa.Id = CInt(Reader("Id"))
            empresa.Nome = CStr(Reader("Nome"))
            empresa.Cnpj = CStr(Reader("Cnpj"))
            associadosViewModel.Id = IIf(Convert.IsDBNull(Reader("idAssociado")), 0, Reader("idAssociado"))
            associadosViewModel.Nome = IIf(Convert.IsDBNull(Reader("nomeAssociado")), Nothing, Reader("nomeAssociado"))
            empresa.associados.Add(associadosViewModel)
            lista.Add(empresa)
        End While
        Return lista
    End Function


    Public Function Create(empresas As Empresas) As Boolean

        Try

            Dim cmd As SqlCommand = New SqlCommand()
            cmd.Connection = connectionDB
            cmd.CommandText = "insert into Empresas(Nome, Cnpj) values (@nome, @cnpj); SELECT SCOPE_IDENTITY();"
            cmd.Parameters.AddWithValue("@nome", empresas.Nome)
            cmd.Parameters.AddWithValue("@cnpj", empresas.Cnpj)
            Dim idEmpresa As Integer = CInt(cmd.ExecuteScalar())

            Dim cmd1 As SqlCommand = New SqlCommand()
            cmd1.Connection = connectionDB
            If (empresas.associados.Count > 0) Then

                For Each item In empresas.associados

                    If item.id > 0 Then
                        cmd1.CommandText = "insert into Associados_Emp (Id_associado, Id_empresa) values (@id_associado, @id_empresa)"
                        cmd1.Parameters.AddWithValue("@id_Empresa", idEmpresa)
                        cmd1.Parameters.AddWithValue("@id_Associado", item.id)
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


    Public Function Update(empresas As Empresas) As Boolean

        Try

            Dim cmd As SqlCommand = New SqlCommand()
            cmd.Connection = connectionDB
            cmd.CommandText = "UPDATE Empresas
                                SET Nome = @nome,
	                                Cnpj= @cnpj
                               WHERE Empresas.Id = @Id"
            cmd.Parameters.AddWithValue("@Id", empresas.Id)
            cmd.Parameters.AddWithValue("@nome", empresas.Nome)
            cmd.Parameters.AddWithValue("@cnpj", empresas.Cnpj)
            cmd.ExecuteNonQuery()

            Dim cmd1 As SqlCommand = New SqlCommand()

            If (empresas.associados.Count > 0) Then

                For Each item In empresas.associados
                    cmd1.Connection = connectionDB

                    If item.id > 0 Then
                        cmd1.CommandText = "
                                            IF (EXISTS(SELECT * FROM Associados_Emp emp WHERE emp.Id_associado = @id_associado and emp.Id_empresa = @idEmpresa)) 
                                            BEGIN 
                                              DELETE FROM  Associados_Emp WHERE Id_associado = @id_associado AND Id_empresa IN(SELECT Id_empresa FROM Associados_Emp  WHERE Id_empresa = @idEmpresa AND Id_associado = @id_Associado )
                                            END 
                                            ELSE 
                                            BEGIN 
                                             INSERT INTO Associados_Emp(Id_associado, Id_empresa) 
                                                VALUES(@id_associado, @idEmpresa) 
                                            END "
                        cmd1.Parameters.AddWithValue("@idEmpresa", empresas.Id)
                        cmd1.Parameters.AddWithValue("@id_Associado", item.id)
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


    Public Sub Delete(ByVal IdEmpresa As Integer)
        Dim cmd As SqlCommand = New SqlCommand()
        cmd.Connection = connectionDB
        cmd.CommandText = "exec SpaExcluirEmpresa @id"
        cmd.Parameters.AddWithValue("@id", IdEmpresa)
        cmd.ExecuteNonQuery()
    End Sub


    Public Function CarregarAssociados() As List(Of AssociadosViewModels)
        Dim lista As List(Of AssociadosViewModels) = New List(Of AssociadosViewModels)()
        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = connectionDB
        cmd.CommandText = "select 
							   id, 
						       Nome
						 from Associados"

        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()
            Dim empresa As New AssociadosViewModels()
            empresa.id = CInt(Reader("id"))
            empresa.Nome = CStr(Reader("Nome"))

            lista.Add(empresa)
        End While
        Return lista
    End Function

    Public Function CarregarAssociadosPrenchida(ByVal IdAssociado As Integer) As List(Of String)
        Dim lista As List(Of String) = New List(Of String)()

        Dim cmd As SqlCommand = New SqlCommand()


        cmd.Connection = connectionDB
        cmd.CommandText = "select emp.Id_associado from Associados_Emp emp where emp.Id_empresa = @id "
        cmd.Parameters.AddWithValue("@id", IdAssociado)
        Dim Reader = cmd.ExecuteReader()
        While Reader.Read()
            Dim associado As String
            associado = CStr(Reader("Id_associado").ToString())
            lista.Add(associado)
        End While
        Return lista
    End Function
End Class