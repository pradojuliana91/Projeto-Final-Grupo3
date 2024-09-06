<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="ProjetoFinal.Web.Produtos.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>Editar Produto</h1>
        </div>
        <br />
        <div style="margin-bottom: 10px">
            <label>Código:</label><asp:TextBox ID="txtCodigoProduto" runat="server" ReadOnly="True" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <label>Descrição:</label><asp:TextBox ID="txtDescricao" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <label>Unidade:</label><asp:TextBox ID="txtUnidade" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <label>Valor de Venda:</label><asp:TextBox ID="txtValorVenda" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <label>IPI (%):</label><asp:TextBox ID="txtIPI" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <label>Estoque:</label><asp:TextBox ID="txtUnid" runat="server" MaxLength="50"></asp:TextBox>
        </div>
        <br />
        <div style="margin-bottom: 10px">
            <asp:Button ID="btnSalvar" runat="server" CssClass="btn btn-success" OnClick="BtnSalvar_Click" Text="Salvar" />
            <asp:Button ID="btnVoltar" runat="server" CssClass="btn btn-secondary" OnClick="BtnVoltar_Click" Text="Voltar" />
        </div>
    </div>
</asp:Content>
