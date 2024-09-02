using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjetoFinal.Web
{
    public partial class Relatorios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void BtnRelComiPorVend_Click(object sender, EventArgs e)
        {
            try
            {
                // Codigo rel comissao
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao gerar relatório comissão por vendedor!");
                Console.WriteLine("Erro Gerar Relatorio Comissao - " + ex.Message);
            }
        }

        protected void BtnRelPedPorVend_Click(object sender, EventArgs e)
        {
            try
            {
                // Codigo rel pedido
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao gerar relaório pedido por vendedor!");
                Console.WriteLine("Erro Gerar Relatorio Pedido - " + ex.Message);
            }
        }
    }
}