<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpresasDashboard.aspx.vb" Inherits="TesteFelipePantheon._EmpresasDashboard" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" style="margin-top: 20px" >



    <div class="jumbotron">

            <asp:Button  type="button" class="btn btn-primary " ID="cmdGet" runat="server" Text="Incluir Empresa"  OnClick="btnEnviar_Incluir"/> 
        <asp:GridView  border="0" class="table" Height="100px" ID="GridView1" runat="server" AutoGenerateColumns="False"  OnRowCommand="GridView1_RowCommand"  OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="#" DataField="Id" />
                <asp:BoundField HeaderText="Nome" DataField="Nome" />
                <asp:BoundField HeaderText="Cnpj" DataField="Cnpj" />
                <asp:CommandField ShowEditButton="true" />
                <asp:CommandField ShowDeleteButton="true"  />
   
            </Columns>
        </asp:GridView>
           </div>
</asp:Content>
