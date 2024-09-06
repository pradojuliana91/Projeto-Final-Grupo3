<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cadastrar.aspx.cs" Inherits="ProjetoFinal.Web.Produtos.Cadastrar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>Cadastro Produto</h1>
        </div>
        <br />
        <div style="margin-bottom: 10px">
            <label>Código do Produto:</label>
            <asp:TextBox ID="txtCodigoProduto" runat="server" MaxLength="50"></asp:TextBox>
            <label>Descrição:</label>
            <asp:TextBox ID="txtDescricao" runat="server" MaxLength="100"></asp:TextBox>
            <label>Unidade:</label>

            <asp:TextBox ID="txtUnidade" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <br />
            <label>Valor de Venda:</label>
            <asp:TextBox ID="txtValorVenda" runat="server" MaxLength="10"></asp:TextBox>
            <label>IPI:</label>
            <asp:TextBox ID="txtIPI" runat="server" MaxLength="5"></asp:TextBox>
            <label>Estoque:</label>
            <asp:TextBox ID="txtUnid" runat="server" MaxLength="2"></asp:TextBox>
        </div>
        <br />
        <br />
        <div style="margin-bottom: 10px">
            <asp:Button ID="BtnNovo" runat="server" CssClass="btn btn-success" OnClick="BtnSalvar_Click" Text="Salvar" />
            <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-secondary" OnClick="BtnVoltar_Click" Text="Voltar" />
        </div>
    </div>
</asp:Content>
