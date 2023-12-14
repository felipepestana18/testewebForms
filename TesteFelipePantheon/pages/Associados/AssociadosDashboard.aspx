<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AssociadosDashboard.aspx.vb" Inherits="TesteFelipePantheon._AssociadosDashboard" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" style="margin-top: 20px" >
     
    
    
  

    <div class="jumbotron">

            <asp:Button  type="button" class="btn btn-primary " ID="cmdGet" runat="server" Text="Incluir Associado"  OnClick="btnEnviar_Incluir"/> 
        <asp:GridView  border="0" class="table" Height="100px" ID="GridView1" runat="server" AutoGenerateColumns="False"  OnRowCommand="GridView1_RowCommand"  OnRowDeleting="GridView1_RowDeleting">
            <Columns>
                <asp:BoundField HeaderText="#" DataField="Id" />
                <asp:BoundField HeaderText="Nome" DataField="Nome" />
                <asp:BoundField HeaderText="Cpf" DataField="Cpf" />
                <asp:BoundField HeaderText="DataNascimento" DataField="DataNascimento" />
                <asp:CommandField ShowEditButton="true" />
                <asp:CommandField ShowDeleteButton="true"  />
   
            </Columns>
        </asp:GridView>
           </div>
</asp:Content>
