<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pesquisar.aspx.cs" Inherits="ProjetoFinal.Web.Vendedores.Pesquisar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>Pesquisa Vendedor</h1>
        </div>
        <br />
        <div style="margin-bottom: 10px">
            <label>código:</label>
            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="9"></asp:TextBox>
            <label>Vendedor:</label>
            <asp:TextBox ID="txtVendedor" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-primary" OnClick="BtnPesquisa_Click" Text="Pesquisar" />
            <asp:Button ID="BtnNovo" runat="server" CssClass="btn btn-secondary" OnClick="BtnNovo_Click" Text="Novo" />
        </div>
        <div style="clear: both">
        </div>
        <asp:GridView ID="gvVendedor" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="table table-bordered table-striped table-hover" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_editar" runat="server" ToolTip="Editar" Text="Editar" CssClass="btn btn-primary"
                            CausesValidation="false" CommandName="editar" OnClick="BtnEditar_Click"
                            CommandArgument='<%# Eval("IdVendedor") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="idVendedor" HeaderText="Código" />
                <asp:BoundField DataField="NomeVendedor" HeaderText="Nome" />
                <asp:BoundField DataField="CPF" HeaderText="CPF" />
                <asp:BoundField DataField="Comissao" HeaderText="Comissão" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
