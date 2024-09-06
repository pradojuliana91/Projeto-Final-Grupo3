using ProjetoFinal.Dao.Config;
using ProjetoFinal.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Dao.Repository
{
    public class RelatorioRepository
    {
        public List<RelComissaoVendedor> RelatorioComissaoVendedor()
        {
            string sql = @"SELECT 
	                            v.Vendedor ,v.CPF , f.idFatura , f.DataFaturamento , f.ValorFaturado , CAST(v.Comissao as decimal(20,12)) as Comissao, 
                                CAST(((v.Comissao * f.ValorFaturado )/100) as decimal(20,12)) as ValorComissao
                           FROM 
	                            Faturas f 
	                            INNER JOIN Pedidos p on f.idPedido = p.idPedido 
	                            INNER JOIN Vendedores v on p.idVendedor = v.idVendedor ";


            List<RelComissaoVendedor> relatorioComissao = new List<RelComissaoVendedor>();
            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        RelComissaoVendedor comissaoVendedor = new RelComissaoVendedor
                        {
                            NomeVendedor = dataReader.GetString(dataReader.GetOrdinal("Vendedor")),
                            CPF = dataReader.GetString(dataReader.GetOrdinal("CPF")),
                            IdFatura = dataReader.GetInt32(dataReader.GetOrdinal("idFatura")),
                            DataFaturamento = dataReader.GetDateTime(dataReader.GetOrdinal("DataFaturamento")),
                            ValorFaturado = dataReader.GetDecimal(dataReader.GetOrdinal("ValorFaturado")),
                            Comissao = dataReader.GetDecimal(dataReader.GetOrdinal("Comissao")),
                            ValorComissao = dataReader.GetDecimal(dataReader.GetOrdinal("ValorComissao"))
                        };

                        relatorioComissao.Add(comissaoVendedor);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar relatorio comissao vendedor", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return relatorioComissao;
        }

        public List<RelPedidoVendedor> RelatorioPedidoVendedor()
        {
            string sql = @"SELECT 
	                            v.Vendedor ,v.CPF ,c.Nome as Cliente, c.CNPJ , p.idPedido , p.DataPedido, f.ValorFaturado as ValorPedido
                           FROM 
	                            Faturas f 
	                            INNER JOIN Pedidos p on f.idPedido = p.idPedido 
	                            INNER JOIN Clientes c on p.idCliente = c.idCliente 
	                            INNER JOIN Vendedores v on p.idVendedor = v.idVendedor ";


            List<RelPedidoVendedor> relatorioVendPedidos = new List<RelPedidoVendedor>();
            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        RelPedidoVendedor pedidosVendedor = new RelPedidoVendedor
                        {
                            Vendedor = dataReader.GetString(dataReader.GetOrdinal("Vendedor")),
                            CPF = dataReader.GetString(dataReader.GetOrdinal("CPF")),
                            Cliente = dataReader.GetString(dataReader.GetOrdinal("Cliente")),
                            CNPJ = dataReader.GetString(dataReader.GetOrdinal("CNPJ")),
                            idPedido = dataReader.GetInt32(dataReader.GetOrdinal("idPedido")),
                            DataPedido = dataReader.GetDateTime(dataReader.GetOrdinal("DataPedido")),
                            ValorPedido = dataReader.GetDecimal(dataReader.GetOrdinal("ValorPedido"))
                        };

                        relatorioVendPedidos.Add(pedidosVendedor);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar relatorio pedidos por vendedor", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return relatorioVendPedidos;
        }
    }
}