<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empresas.aspx.vb" Inherits="TesteFelipePantheon._Empresas" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" style="margin-top: 20px">

    <div class="jumbotron">
        <div class="row">

            <div class="form-group">
                <label>Nome:</label>
                <asp:TextBox CssClass="form-control" ID="txtNome" runat="server" placeholder="Digite o Nome"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Cnpj:</label>
                <asp:TextBox CssClass="form-control" ID="txtCnpj" runat="server" placeholder="Digite o Cnpj"></asp:TextBox>
            </div>
            <label>Associados:</label>
            <div class="form-group">
                <asp:ListBox Style="height: 80px; width: 300px; border-radius: 4px" ID="txtAssociados" SelectionMode="multiple" runat="server" ToolTip="Select"></asp:ListBox>
            </div>

            <asp:Button type="button"  class="btn btn-success" ID="cmdGet" runat="server" Text="Salvar"  OnClick="btnEnviar_Click"/>

            <asp:Label style="color: red; font-size: 30px" ID="lblErro" runat="server"   Visible="false">Ops!!! Error ao Salvar no banco de dados</asp:Label>
        </div>

    </div>
</asp:Content>


