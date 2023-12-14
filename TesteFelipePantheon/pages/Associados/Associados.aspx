<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Associados.aspx.vb" Inherits="TesteFelipePantheon._Associados" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" style="margin-top: 20px">

    <div class="jumbotron">
        <div class="row">

      
            <div class="form-group">
                <label>Nome:</label>
                <asp:TextBox CssClass="form-control" ID="txtNome" placeholder="Digite o Nome" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Cpf:</label>
                <asp:TextBox CssClass="form-control" ID="txtCpf"  placeholder="Digite o Cpf" runat="server"></asp:TextBox>
            </div>


            <h5 style="color: yellowgreen"> está sem tratamento jquery não funcionou, coloque o valor da data por exemplo: 02/06/2022 </h5>
            <div class="form-group">
                <label>Data Nascimento:</label>
                <asp:TextBox  placeholder="Data Nascimento" Text='<%# String.Format("{0:MM-dd-yyyy}", Eval("JoinDate")) %>' CssClass="b-datepicker form-control" ID="txtData" runat="server"></asp:TextBox>
            </div>
            <label>Empresas:</label>
            <div class="form-group">
                <asp:ListBox Style="height: 80px; width: 300px; border-radius: 4px" ID="txtEmpresas" SelectionMode="multiple" runat="server" ToolTip="Select"></asp:ListBox>
            </div>

            <asp:Button type="button"  class="btn btn-success" ID="cmdGet" runat="server" Text="Salvar"  OnClick="btnEnviar_Click"/>

            <asp:Label style="color: red; font-size: 30px" ID="lblErro" runat="server"   Visible="false">Ops!!! Error ao Salvar no banco de dados</asp:Label>
        </div>

    </div>
</asp:Content>


