<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="ProjetoFinal.Web.Vendedores.Cadastrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>Cadastro Vendedor</h1>
        </div>
        <br />
        <div style="margin-bottom: 10px">
            <label>Vendedor:</label>
            <asp:TextBox ID="txtVendedor" runat="server" MaxLength="50"></asp:TextBox>
            <label>CPF:</label>
            <asp:TextBox ID="txtCPF" runat="server" MaxLength="11"></asp:TextBox>
            <label>Comissao:</label>
            <asp:TextBox ID="txtComissao" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <br />
            <label>CEP:</label>
            <asp:TextBox ID="txtCEP" runat="server" MaxLength="50"></asp:TextBox>
            <label>Endereço:</label>
            <asp:TextBox ID="txtEndereco" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <label>Bairro:</label>
            <asp:TextBox ID="txtBairro" runat="server" MaxLength="50"></asp:TextBox>
            <label>Cidade:</label>
            <asp:TextBox ID="txtCidade" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <label>UF:</label>
            <asp:TextBox ID="txtUF" runat="server" MaxLength="2"></asp:TextBox>
        </div>
        <br />
        <br />
        <asp:Button ID="BtnNovo" runat="server" CssClass="btn btn-success" OnClick="BtnSalvar_Click" Text="Salvar" />
        <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-secondary" OnClick="BtnVoltar_Click" Text="Voltar" />
    </div>
</asp:Content>

