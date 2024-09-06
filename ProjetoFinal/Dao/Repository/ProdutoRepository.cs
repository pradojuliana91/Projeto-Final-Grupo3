using ProjetoFinal.Dao.Config;
using ProjetoFinal.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Dao.Repository
{
    public class ProdutoRepository
    {
        public List<Produto> Pesquisa(int? codigo, string descricao)
        {
            string sql = @"SELECT idProduto, CodigoProduto, Descricao, Unidade, ValorVenda, IPI, Estoque FROM Produtos WHERE 1=1";

            List<SqlParameter> parameters = new List<SqlParameter>();

            if (codigo.HasValue)
            {
                sql += " AND idProduto = @idProduto";
                parameters.Add(new SqlParameter("@idProduto", codigo.Value));
            }

            if (!string.IsNullOrEmpty(descricao))
            {
                sql += " AND Descricao LIKE @Descricao";
                parameters.Add(new SqlParameter("@Descricao", "%" + descricao + "%"));
            }

            List<Produto> produtos = new List<Produto>();
            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddRange(parameters.ToArray());

                    SqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Produto produto = new Produto
                        {
                            idProduto = dataReader.GetInt32(dataReader.GetOrdinal("idProduto")),
                            CodigoProduto = dataReader.GetString(dataReader.GetOrdinal("CodigoProduto")),
                            Descricao = dataReader.GetString(dataReader.GetOrdinal("Descricao")),
                            Unidade = dataReader.GetString(dataReader.GetOrdinal("Unidade")),
                            ValorVenda = dataReader.GetDecimal(dataReader.GetOrdinal("ValorVenda")),
                            IPI = (float)dataReader.GetDouble(dataReader.GetOrdinal("IPI")),
                            Estoque = (float)dataReader.GetDouble(dataReader.GetOrdinal("Estoque"))
                        };

                        produtos.Add(produto);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar produtos", ex);
                }
                finally
                {
                    connection.Close();
                }
            }
            return produtos;
        }
        public void Salvar(Produto produto)
        {
            string sql = @"INSERT INTO Produtos (CodigoProduto, Descricao, Unidade, ValorVenda, IPI, Estoque) 
                       VALUES (@CodigoProduto, @Descricao, @Unidade, @ValorVenda, @IPI, @Estoque)";

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())


            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@CodigoProduto", produto.CodigoProduto);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Unidade", produto.Unidade);
                    command.Parameters.AddWithValue("@ValorVenda", produto.ValorVenda);
                    command.Parameters.AddWithValue("@IPI", produto.IPI);
                    command.Parameters.AddWithValue("@Estoque", produto.Estoque);


                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar produto", ex); ;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Editar(Produto produto)
        {
            string sql = @"UPDATE Produtos 
                           SET CodigoProduto = @CodigoProduto, Descricao = @Descricao, Unidade = @Unidade, 
                               ValorVenda = @ValorVenda, IPI = @IPI, Estoque = @Estoque
                           WHERE idProduto = @idProduto";



            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@idProduto", produto.idProduto);
                    command.Parameters.AddWithValue("@CodigoProduto", produto.CodigoProduto);
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao);
                    command.Parameters.AddWithValue("@Unidade", produto.Unidade);
                    command.Parameters.AddWithValue("@ValorVenda", produto.ValorVenda);
                    command.Parameters.AddWithValue("@IPI", produto.IPI);
                    command.Parameters.AddWithValue("@Estoque", produto.Estoque);



                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar produto", ex); ;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}