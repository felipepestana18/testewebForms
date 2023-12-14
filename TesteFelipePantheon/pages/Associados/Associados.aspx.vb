Imports System.Runtime.Remoting
Imports System.Web.Services.Description
Imports Microsoft.VisualBasic.ApplicationServices

Public Class _Associados
    Inherits Page

    Dim associados As Associados = New Associados()
    Dim associadoData As AssociadosData = New AssociadosData()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If (Not Page.IsPostBack) Then
            CarregarEmpresas()
            Dim IdAssociado As Integer = Request.QueryString("Id")

            If IdAssociado > 0 Then
                CarregarDados(IdAssociado)
            End If

        End If

    End Sub


    Private Sub CarregarDados(ByVal IdAssociado As Integer)
        Dim listaAssociados = New List(Of Associados)
        Dim listaEmpresas = New List(Of String)
        Dim IsPrenchido As Boolean = False
        Dim empresaVielModel As New List(Of EmpresaViewModels)

        Dim list As New List(Of String)()

        Dim empresaVielModel1 As New EmpresaViewModels()
        If (IdAssociado) Then
            listaAssociados = associadoData.CarregarInformacaoAssociado(IdAssociado)
            For Each associado In listaAssociados
                If (Not IsPrenchido) Then
                    txtNome.Text = associado.Nome
                    txtCpf.Text = associado.Cpf
                    txtData.Text = associado.DataNascimento
                    IsPrenchido = True
                End If
            Next

            listaEmpresas = associadoData.CarregarEmpresaPrenchida(IdAssociado)


            For Each Empresa In listaEmpresas
                list.Add(Empresa)
            Next

            For Each item As ListItem In txtEmpresas.Items
                item.Selected = list.Contains(item.Value)

            Next
        Else


        End If

    End Sub

    Private Sub CarregarEmpresas()
        Dim listaEmpresa = New List(Of EmpresaViewModels)

        listaEmpresa = associadoData.CarregarEmpresa()

        For Each empresa In listaEmpresa
            txtEmpresas.Items.Add(New ListItem With {
                    .Text = empresa.Nome,
                    .Value = empresa.Id
                })
        Next

    End Sub

    Protected Sub btnEnviar_Click(ByVal sender As Object, ByVal e As EventArgs)


        Dim FoiSalvo As Boolean

        associados.Nome = txtNome.Text
        associados.Cpf = txtCpf.Text
        associados.DataNascimento = txtData.Text
        Dim IdAssociado As Integer = Request.QueryString("Id")
        For Each empresa As ListItem In txtEmpresas.Items

            If empresa.Selected Then
                Dim empresaVielModel As New EmpresaViewModels()
                empresaVielModel.Id = (Convert.ToInt32(empresa.Value))
                empresaVielModel.Nome = Nothing
                associados.empresas.Add(empresaVielModel)
                associados.Id = IdAssociado
            End If
        Next

        If (IdAssociado > 0) Then
            FoiSalvo = associadoData.Update(associados)
        Else
            FoiSalvo = associadoData.Create(associados)
        End If


        If (FoiSalvo = True) Then
            Response.Redirect("~/pages/Associados/AssociadosDashboard.aspx")

        Else
            lblErro.Visible = True
        End If
    End Sub
End Class