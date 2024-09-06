using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal.Web.Produtos
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        private readonly ProdutoService produtoService = new ProdutoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpaTela();
            }
        }

        private void LimpaTela()
        {
            txtCodigoProduto.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtUnidade.Text = string.Empty;
            txtValorVenda.Text = string.Empty;
            txtIPI.Text = string.Empty;
            txtUnid.Text = string.Empty;
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtCodigoProduto.Text) ||
                   string.IsNullOrWhiteSpace(txtDescricao.Text) ||
                   string.IsNullOrWhiteSpace(txtUnidade.Text) ||
                   string.IsNullOrWhiteSpace(txtValorVenda.Text))
                {
                    CommonUtils.Alerta(this, "Por favor, preencha todos os campos obrigatórios!");
                    return;
                }
                if (!decimal.TryParse(txtValorVenda.Text, out decimal valorVenda))
                {
                    CommonUtils.Alerta(this, "Valor de Venda inválido!");
                    return;
                }

                if (!decimal.TryParse(txtIPI.Text, out decimal ipi))
                {
                    CommonUtils.Alerta(this, "Valor do IPI inválido!");
                    return;
                }

                if (!int.TryParse(txtUnid.Text, out int estoque))
                {
                    CommonUtils.Alerta(this, "Quantidade de estoque inválida!");
                    return;
                }

                Produto produto = new Produto
                {
                    CodigoProduto = txtCodigoProduto.Text,
                    Descricao = txtDescricao.Text,
                    Unidade = txtUnidade.Text,
                    ValorVenda = valorVenda,
                    IPI = (float)ipi,
                    Estoque = estoque
                };

                // Salvando o produto
                produtoService.Salvar(produto);
                Session.Add("msg-pesquisa-produto", "Produto Cadastrado Com Sucesso!");
                Response.Redirect("/Web/Produtos/Pesquisar", false);
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao salvar produto!");
                Console.WriteLine("Erro ao salvar produto", ex.Message);
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Web/Produtos/Pesquisar", false);
        }
    }
}