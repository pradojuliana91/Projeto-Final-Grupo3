using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal.Web.Vendedores
{
    public partial class Cadastrar : System.Web.UI.Page
    {
        private readonly VendedorService vendedorService = new VendedorService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpaTela();
            }
        }

        private void LimpaTela()
        {
            txtVendedor.Text = string.Empty;
            txtComissao.Text = string.Empty;
            txtEndereco.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtCEP.Text = string.Empty;
            txtUF.Text = string.Empty;
            txtCPF.Text = string.Empty;
        }

        protected void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
               //validar campos obrigatórios e tipos de dados.

               Vendedor vendedor = new Vendedor
               {
                   NomeVendedor = txtVendedor.Text,
                   Comissao = decimal.Parse(txtComissao.Text),
                   Endereco = txtEndereco.Text,
                   Bairro = txtBairro.Text,
                   Cidade = txtCidade.Text,
                   CEP = txtCEP.Text,
                   UF = txtUF.Text,
                   CPF = txtCPF.Text
               };

                vendedorService.Salvar(vendedor);
                Session.Add("msg-pesquisa-vendedor", "Vendedor Salvo Com Sucesso!");
                Response.Redirect("/Web/Vendedores/Pesquisar", false);
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao salvar vendedor!");
                Console.WriteLine("Erro Salvar Vendedor - " + ex.Message);
            }
        }


        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Web/Vendedores/Pesquisar", false);
        }
    }
}