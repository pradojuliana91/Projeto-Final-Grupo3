using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Service;
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
        private readonly RelatorioService relatorioService = new RelatorioService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvRelComissaoVendedor.Visible = false;
            }
        }

        protected void BtnRelComiPorVend_Click(object sender, EventArgs e)
        {
            try
            {
                gvRelPedidoVendedor.Visible = false;
                relatorioService.RelatorioComissaoVendedor();
                List<RelComissaoVendedor> rel = relatorioService.RelatorioComissaoVendedor();
                if (rel != null && rel.Count > 0)
                {
                    gvRelComissaoVendedor.Visible = true;
                    gvRelComissaoVendedor.DataSource = rel;
                    gvRelComissaoVendedor.DataBind();
                }
                else
                {
                    gvRelComissaoVendedor.Visible = false;
                    CommonUtils.Alerta(this, "Não foi encontrado registro(s) de comissão para vendedor(es)!");
                }
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
                gvRelComissaoVendedor.Visible = false;
                relatorioService.RelatorioComissaoVendedor();
                List<RelPedidoVendedor> rel = relatorioService.RelatorioPedidoVendedor();
                if (rel != null && rel.Count > 0)
                {
                    gvRelPedidoVendedor.Visible = true;
                    gvRelPedidoVendedor.DataSource = rel;
                    gvRelPedidoVendedor.DataBind();
                }
                else
                {
                    gvRelPedidoVendedor.Visible = false;
                    CommonUtils.Alerta(this, "Não foi encontrado registro(s) de pedidos para vendedor(es)!");
                }
            }
            catch (Exception ex)
            {
                CommonUtils.Alerta(this, "Erro ao gerar relaório pedido por vendedor!");
                Console.WriteLine("Erro Gerar Relatorio Pedido - " + ex.Message);
            }
        }
    }
}