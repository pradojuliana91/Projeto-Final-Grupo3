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
        public List<Produto> Pesquisa(int? codigo, string nome)
        {
            return null;
        }

        public Produto BuscaPorCodigo(int codigo)
        {
            return null;
        }

        public void Salvar(Produto produto)
        {
            string sql = @"INSERT .....";

            // fazer insert

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

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
            string sql = @"UPDATE .....";

            // fazer update

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

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