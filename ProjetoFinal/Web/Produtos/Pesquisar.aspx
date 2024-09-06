<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pesquisar.aspx.cs" Inherits="ProjetoFinal.Web.Produtos.Pesquisar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h1>Pesquisa Produto</h1>
        </div>
        <br />
        <div style="margin-bottom: 10px">
            <label>Código:</label>
            <asp:TextBox ID="txtCodigo" runat="server" MaxLength="9"></asp:TextBox>
            <label>Produto:</label>
            <asp:TextBox ID="txtProduto" runat="server" MaxLength="50"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="btnPesquisar" runat="server" CssClass="btn btn-primary" OnClick="BtnPesquisa_Click" Text="Pesquisar" />
            <asp:Button ID="BtnNovo" runat="server" CssClass="btn btn-secondary" OnClick="BtnNovo_Click" Text="Novo" />
        </div>
        <div style="clear: both"></div>
        <asp:GridView ID="gvProduto" runat="server" AutoGenerateColumns="False" Width="100%" 
                      CssClass="table table-bordered table-striped table-hover" GridLines="None">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btn_editar" runat="server" ToolTip="Editar" Text="Editar" CssClass="btn btn-primary"
                            CausesValidation="false" CommandName="editar" OnClick="BtnEditar_Click"
                            CommandArgument='<%# Eval("idProduto") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:BoundField DataField="idProduto" HeaderText="Código" />
                <asp:BoundField DataField="Descricao" HeaderText="Nome" />
                <asp:BoundField DataField="Unidade" HeaderText="Unidade" />
                <asp:BoundField DataField="ValorVenda" HeaderText="Valor de Venda" DataFormatString="{0:C}" />
                <asp:BoundField DataField="IPI" HeaderText="IPI (%)" DataFormatString="{0:N2}" />
                <asp:BoundField DataField="Estoque" HeaderText="Estoque" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
