Imports System.Runtime.Remoting
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic.ApplicationServices

Public Class _EmpresasDashboard
    Inherits Page

    Dim empresas As Empresas = New Empresas()
    Dim empresaData As EmpresasData = New EmpresasData()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            Dim IdAssociado As Integer = Request.QueryString("Id")

            If IdAssociado > 0 Then

            Else
                CarregarDados()
            End If
        End If

    End Sub


    Private Function CarregarDados() As DataTable

        Dim lista As List(Of Empresas) = New List(Of Empresas)()

        Dim dt As DataTable = New DataTable()
        dt.Columns.Add("Id")
        dt.Columns.Add("Nome")
        dt.Columns.Add("Cnpj")

        lista = empresaData.Carregar()
        For Each empresa In lista

            Dim dr1 As DataRow = dt.NewRow()
            dr1("Id") = empresa.Id
            dr1("Nome") = empresa.Nome
            dr1("Cnpj") = empresa.Cnpj
            dt.Rows.Add(dr1)

        Next
        GridView1.DataSource = dt
        GridView1.DataBind()

        Return dt
    End Function

    Protected Sub GridView1_RowCommand(ByVal sender As Object, ByVal e As GridViewCommandEventArgs)

        Dim IndexId As Integer = Convert.ToInt32(e.CommandArgument)
        Dim LinhaClick As GridViewRow = GridView1.Rows(IndexId)
        Dim idEmpresa As Integer = Convert.ToInt32(LinhaClick.Cells(0).Text)

        If e.CommandName = "Edit" Then
            Response.Redirect(String.Format("~/pages/Empresas/Empresas.aspx?Id={0}", idEmpresa))
        Else
            empresaData.Delete(idEmpresa)
            Response.Redirect("~/pages/Empresas/EmpresasDashboard.aspx")
        End If


    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As EventArgs)


        Dim empresas As List(Of Integer) = New List(Of Integer)()

    End Sub

    Protected Sub btnEnviar_Incluir(ByVal sender As Object, ByVal e As EventArgs)

        Response.Redirect(String.Format("~/pages/Empresas/Empresas.aspx"))
    End Sub



End Class