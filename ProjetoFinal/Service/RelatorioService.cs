using ProjetoFinal.Dao.Domain;
using ProjetoFinal.Dao.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Service
{
    public class RelatorioService
    {
        private readonly RelatorioRepository relatorioRepository = new RelatorioRepository();
        public List<RelComissaoVendedor> RelatorioComissaoVendedor()
        {
            return relatorioRepository.RelatorioComissaoVendedor();
        }

        public List<RelPedidoVendedor> RelatorioPedidoVendedor()
        {
            return relatorioRepository.RelatorioPedidoVendedor();
        }
    }
}