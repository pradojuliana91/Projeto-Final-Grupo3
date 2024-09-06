using ProjetoFinal.Dao.Config;
using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Service;
using System;

namespace ProjetoFinal.Web.Vendedores
{
    public partial class Editar : System.Web.UI.Page
    {

        private readonly VendedorService vendedorService = new VendedorService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpaTela();
                MontaTelaEditar();
            }
        }

        private void MontaTelaEditar()
        {
            if (Session["editar-vendedor-idVendedor"] != null)
            {
                int codigo = (int)Session["editar-vendedor-idVendedor"];
                Vendedor vendedor = vendedorService.BuscaPorCodigo(codigo);
                if (vendedor != null)
                {
                    txtVendedor.Text = vendedor.NomeVendedor;
                    txtComissao.Text = vendedor.Comissao.ToString();
                    txtEndereco.Text = vendedor.Endereco;
                    txtBairro.Text = vendedor.Bairro;
                    txtCidade.Text = vendedor.Cidade;
                    txtCEP.Text = vendedor.CEP;
                    txtUF.Text = vendedor.UF;
                    txtCPF.Text = vendedor.CPF;
                }
                else
                {
                    Session.Remove("editar-vendedor-idVendedor");
                    Session.Add("msg-pesquisa-vendedor", "Vendedor Não Encontrado!");
                    Response.Redirect("/Web/Vendedores/Pesquisar", false);
                }
            }
            else
            {
                Session.Remove("editar-vendedor-idVendedor");
                Response.Redirect("/Web/Vendedores/Pesquisar", false);
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
                if (string.IsNullOrWhiteSpace(txtVendedor.Text))
                {
                    CommonUtils.Alerta(this, "Nome do Vendedor não pode estar vazio!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCPF.Text))
                {
                    CommonUtils.Alerta(this, "CPF não pode estar vazio!");
                    return;
                }

                if (!decimal.TryParse(txtComissao.Text, out decimal comissao))
                {
                    CommonUtils.Alerta(this, "Comissão inválida! Por favor, insira um valor numérico.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCEP.Text))
                {
                    CommonUtils.Alerta(this, "CEP não pode estar vazio!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEndereco.Text))
                {
                    CommonUtils.Alerta(this, "Endereço não pode estar vazio!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBairro.Text))
                {
                    CommonUtils.Alerta(this, "Bairro não pode estar vazio!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCidade.Text))
                {
                    CommonUtils.Alerta(this, "Cidade não pode estar vazia!");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtUF.Text))
                {
                    CommonUtils.Alerta(this, "UF não pode estar vazio!");
                    return;
                }

                int codigoVendedorEditar = (int)Session["editar-vendedor-idVendedor"];

                Vendedor vendedor = new Vendedor
                {
                    IdVendedor = codigoVendedorEditar,
                    NomeVendedor = txtVendedor.Text,
                    Comissao = decimal.Parse(txtComissao.Text),
                    Endereco = txtEndereco.Text,
                    Bairro = txtBairro.Text,
                    Cidade = txtCidade.Text,
                    CEP = txtCEP.Text,
                    UF = txtUF.Text,
                    CPF = txtCPF.Text
                };

                vendedorService.Editar(vendedor);
                Session.Remove("editar-vendedor-idVendedor");
                Session.Add("msg-pesquisa-vendedor", "Vendedor Atualizado Com Sucesso!");
                Response.Redirect("/Web/Vendedores/Pesquisar", false);
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao editar vendedor!");
                Console.WriteLine("Erro Editar Vendedor - " + ex.Message);
            }
        }


        protected void BtnVoltar_Click(object sender, EventArgs e)
        {
            Session.Remove("editar-vendedor-idVendedor");
            Response.Redirect("/Web/Vendedores/Pesquisar", false);
        }
    }
}