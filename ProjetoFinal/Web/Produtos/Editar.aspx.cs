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
    public partial class Editar : System.Web.UI.Page
    {
        private readonly ProdutoService produtoService = new ProdutoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["editar-produto-idProduto"] != null)
                {
                    int idProduto = (int)Session["editar-produto-idProduto"];
                    CarregarProduto(idProduto);
                }
                else
                {
                    Response.Redirect("/Web/Produtos/Pesquisar", false);
                }
            }
        }

        private void CarregarProduto(int codigoProduto)
        {
            var produto = produtoService.Pesquisa(codigoProduto, null).FirstOrDefault();
            if (produto != null)
            {
                txtCodigoProduto.Text = produto.CodigoProduto.ToString();
                txtDescricao.Text = produto.Descricao;
                txtUnidade.Text = produto.Unidade;
                txtValorVenda.Text = produto.ValorVenda.ToString();
                txtIPI.Text = produto.IPI.ToString();
                txtUnid.Text = produto.Estoque.ToString();
            }
            else
            {
                CommonUtils.Alerta(this, "Produto não encontrado!");
                btnSalvar.Enabled = false;
            }
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

                produtoService.Editar(produto);
                Session["msg-pesquisa-produto"] = "Produto Atualizado Com Sucesso!";
                Response.Redirect("/Web/Produtos/Pesquisar", false);
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao atualizar produto!");
                Console.WriteLine("Erro ao atualizar produto: ", ex);
            }
        }

        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Web/Produtos/Pesquisar", false);
        }
    }
}