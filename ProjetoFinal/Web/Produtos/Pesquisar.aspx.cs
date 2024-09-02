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

        }

        protected void BtnPesquisa_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
           
        }
    }
}