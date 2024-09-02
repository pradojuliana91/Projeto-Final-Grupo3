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

        }
    }
}