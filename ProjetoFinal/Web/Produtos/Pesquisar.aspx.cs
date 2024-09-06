using ProjetoFinal.Dao.Config;
using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Dao.Repository;
using ProjetoFinal.Service;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal.Web.Produtos
{
    public partial class Pesquisar : System.Web.UI.Page
    {

        private readonly ProdutoService produtoService = new ProdutoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpaTela();
                if (Session["msg-pesquisa-produto"] != null)
                {
                    CommonUtils.Alerta(this, Session["msg-pesquisa-produto"].ToString());
                    Session.Remove("msg-pesquisa-produto");
                }
            }
        }

        private void LimpaTela()
        {
            txtCodigo.Text = string.Empty;
            txtProduto.Text = string.Empty;
            gvProduto.Visible = false;
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Web/Produtos/Cadastrar", false);
        }

        protected void BtnPesquisa_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text) && !CommonUtils.IsNumeric(txtCodigo.Text))
                {
                    CommonUtils.Alerta(this, "Código só pode conter números");
                    return;
                }

                List<Produto> produtos = produtoService.Pesquisa(CommonUtils.ParseIntOrNull(txtCodigo.Text), txtProduto.Text);

                if (produtos != null && produtos.Count > 0)
                {
                    gvProduto.Visible = true;
                    gvProduto.DataSource = produtos;
                    gvProduto.DataBind();
                }
                else
                {
                    gvProduto.Visible = false;
                    CommonUtils.Alerta(this, "Não foi encontrado produto(s) com o(s) filtro(s) informado(s)!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao buscar produtos:");
                Console.WriteLine("Mensagem: " + ex.Message);
                Console.WriteLine("Stack Trace: " + ex.StackTrace);
                throw;
            }
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int idProduto = int.Parse(btn.CommandArgument);
                Session["editar-produto-idProduto"] = idProduto;
                Response.Redirect("/Web/Produtos/Editar", false);                
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao tentar editar produto!");
                Console.WriteLine("Erro ao editar Produto - " + ex.Message);
            }
        }
    }
}