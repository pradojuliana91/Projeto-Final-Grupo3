<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Relatorios.aspx.cs" Inherits="ProjetoFinal.Web.Relatorios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>Relatórios</h1>
        </div>
        <br />
        <h2>Comissões por vendedor</h2>
        <asp:Button ID="btnRelComiPorVend" runat="server" CssClass="btn btn-success" OnClick="BtnRelComiPorVend_Click" Text="Gerar" />
        <br />
        <h2>Pedidos por vendedor</h2>
        <asp:Button ID="btnRelPedPorVend" runat="server" CssClass="btn btn-success" OnClick="BtnRelPedPorVend_Click" Text="Gerar" />        
    </div>
</asp:Content>