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
        <asp:GridView ID="gvRelComissaoVendedor" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table table-bordered table-striped table-hover" GridLines="None">
            <Columns>
                <asp:BoundField DataField="NomeVendedor" HeaderText="Vendedor" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="IdFatura" HeaderText="ID Fatura" />
                <asp:BoundField DataField="DataFaturamento" HeaderText="Faturamento" />
                <asp:BoundField DataField="ValorFaturado" HeaderText="Vlr Faturado" />
                <asp:BoundField DataField="Comissao" HeaderText="Comissão" />
                <asp:BoundField DataField="ValorComissao" HeaderText="Vlr Comissão" />
            </Columns>
        </asp:GridView>
        <asp:GridView ID="gvRelPedidoVendedor" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table table-bordered table-striped table-hover" GridLines="None">
            <Columns>
                <asp:BoundField DataField="Vendedor" HeaderText="Vendedor" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" />
                <asp:BoundField DataField="DataPedido" HeaderText="DataPedido" />
                <asp:BoundField DataField="idPedido" HeaderText="ID Pedido" />
                <asp:BoundField DataField="ValorPedido" HeaderText="Vlr Pedido" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
