Imports System.Runtime.Remoting
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic.ApplicationServices

Public Class _AssociadosDashboard
    Inherits Page

    Dim associados As Associados = New Associados()
    Dim associado As AssociadosData = New AssociadosData()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            Dim IdAssociado As Integer = Request.QueryString("Id")

            If IdAssociado > 0 Then

            Else
                CarregarDados()
            End If

            'AssociadosDashboard.DataSource
            'AssociadosDashboard.DataBind()
        End If

    End Sub


    Private Function CarregarDados() As DataTable

        Dim lista As List(Of Associados) = New List(Of Associados)()

        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Id")
        dt.Columns.Add("Nome")
        dt.Columns.Add("Cpf")
        dt.Columns.Add("DataNascimento")


        lista = associado.Carregar()
        For Each empresa In lista

            Dim dr1 As DataRow = dt.NewRow()
            dr1("Id") = empresa.Id
            dr1("Nome") = empresa.Nome
            dr1("Cpf") = empresa.Cpf
            dr1("DataNascimento") = empresa.DataNascimento
            dt.Rows.Add(dr1)

        Next
        GridView1.DataSource = dt
        GridView1.DataBind()

        Return dt
    End Function

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        Dim IndexId As Integer = Convert.ToInt32(e.CommandArgument)
        Dim LinhaClick As GridViewRow = GridView1.Rows(IndexId)
        Dim IdAssociado As Integer = Convert.ToInt32(LinhaClick.Cells(0).Text)

        If e.CommandName = "Edit" Then
            Response.Redirect(String.Format("~/pages/Associados/Associados.aspx?Id={0}", IdAssociado))
        Else
            associado.Delete(IdAssociado)
            Response.Redirect("~/pages/Associados/AssociadosDashboard.aspx")
        End If


    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As EventArgs)




        'Terminei nessa parte depois é só pegar e fazer as no banco excluido
        Dim empresas As List(Of Integer) = New List(Of Integer)()

    End Sub

    Protected Sub btnEnviar_Incluir(ByVal sender As Object, ByVal e As EventArgs)

        Response.Redirect(String.Format("~/pages/Associados/Associados.aspx"))
    End Sub



End Class