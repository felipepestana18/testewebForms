Imports System.Runtime.Remoting
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic.ApplicationServices

Public Class _Empresas
    Inherits Page

    Dim empresas As Empresas = New Empresas()
    Dim empresaData As EmpresasData = New EmpresasData()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            CarregarEmpresas()
            Dim idEmpresa As Integer = Request.QueryString("Id")

            If idEmpresa > 0 Then
                CarregarDados(idEmpresa)
            End If

        End If



    End Sub


    Private Sub CarregarDados(ByVal idEmpresa As Integer)
        Dim listaAssociados = New List(Of Empresas)
        Dim listaAssociadosPrenchido = New List(Of String)
        Dim IsPrenchido As Boolean = False
        Dim empresaVielModel As New List(Of EmpresaViewModels)

        Dim list As New List(Of String)()

        Dim empresaVielModel1 As New EmpresaViewModels()
        If (idEmpresa) Then
            listaAssociados = empresaData.CarregarInformacaoAssociado(idEmpresa)
            For Each associado In listaAssociados
                If (Not IsPrenchido) Then
                    txtNome.Text = associado.Nome
                    txtCnpj.Text = associado.Cnpj
                    IsPrenchido = True
                End If
            Next

            listaAssociadosPrenchido = empresaData.CarregarAssociadosPrenchida(idEmpresa)

            For Each Empresa In listaAssociadosPrenchido
                list.Add(Empresa)
            Next

            For Each item As ListItem In txtAssociados.Items
                item.Selected = list.Contains(item.Value)

            Next
        Else

        End If

    End Sub

    Private Sub CarregarEmpresas()
        Dim listaEmpresa = New List(Of AssociadosViewModels)

        listaEmpresa = empresaData.CarregarAssociados()

        For Each empresa In listaEmpresa
            txtAssociados.Items.Add(New ListItem With {
                    .Text = empresa.Nome,
                    .Value = empresa.id
                })
        Next




    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim FoiSalvo As Boolean

        empresas.Nome = txtNome.Text
        empresas.Cnpj = txtCnpj.Text
        Dim IdEmpresa As Integer = Request.QueryString("Id")
        For Each associado As ListItem In txtAssociados.Items

            If associado.Selected Then
                Dim associadosViewModels As New AssociadosViewModels()
                associadosViewModels.id = (Convert.ToInt32(associado.Value))
                associadosViewModels.Nome = Nothing
                empresas.associados.Add(associadosViewModels)
                empresas.Id = IdEmpresa
            End If
        Next



        If (IdEmpresa > 0) Then
            FoiSalvo = empresaData.Update(empresas)
        Else
            FoiSalvo = empresaData.Create(empresas)
        End If


        If (FoiSalvo = True) Then
            Response.Redirect("~/pages/Empresas/EmpresasDashboard.aspx")

        Else
            lblErro.Visible = True
        End If
    End Sub
End Class