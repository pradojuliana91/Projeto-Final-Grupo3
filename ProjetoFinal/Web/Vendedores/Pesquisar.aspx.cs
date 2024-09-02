using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Service;

namespace ProjetoFinal.Web.Vendedores
{
    public partial class Pesquisar : System.Web.UI.Page
    {

        private readonly VendedorService vendedorService = new VendedorService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpaTela();
                if (Session["msg-pesquisa-vendedor"] != null)
                {
                    CommonUtils.Alerta(this, Session["msg-pesquisa-vendedor"].ToString());
                    Session.Remove("msg-pesquisa-vendedor");
                }
            }
        }

        private void LimpaTela()
        {
            txtCodigo.Text = string.Empty;
            txtVendedor.Text = string.Empty;
            gvVendedor.Visible = false;
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Web/Vendedores/Cadastrar", false);
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
                List<Vendedor> vendedores = vendedorService.Pesquisa(CommonUtils.ParseIntOrNull(txtCodigo.Text), txtVendedor.Text);
                if (vendedores != null && vendedores.Count > 0)
                {
                    gvVendedor.Visible = true;
                    gvVendedor.DataSource = vendedores;
                    gvVendedor.DataBind();
                }
                else
                {
                    gvVendedor.Visible = false;
                    CommonUtils.Alerta(this, "Não foi encontrado vendedor(es) com o(s) filtro(s) informado(s)!");
                }
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao pesquisar vendedores!");
                Console.WriteLine("Erro ao Pesquisar Vendedor - " + ex.Message);
            }
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                int idVendedor = int.Parse(btn.CommandArgument);
                Session.Add("editar-vendedor-idVendedor", idVendedor);
                Response.Redirect("/Web/Vendedores/Editar", false);
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao tentar editar vendedor!");
                Console.WriteLine("Erro ao editar Vendedor - " + ex.Message);
            }
        }
    }
}