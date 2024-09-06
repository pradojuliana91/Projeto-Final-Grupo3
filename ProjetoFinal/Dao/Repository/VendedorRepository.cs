using ProjetoFinal.Dao.Config;
using ProjetoFinal.Dao.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Dao.Repository
{
    public class VendedorRepository
    {
        public List<Vendedor> Pesquisa(int? codigo, string nome)
        {
            string sql = @"SELECT idVendedor, Vendedor,CAST(Comissao as decimal(20,12)) as Comissao, Endereco, Bairro, Cidade, CEP, UF, CPF FROM Vendedores Where 1=1";
           
            List<SqlParameter> parameters = new List<SqlParameter>();

            if (codigo.HasValue)
            {
                sql += " AND idVendedor = @idVendedor";
                parameters.Add(new SqlParameter("@idVendedor", codigo.Value));
            }

            if (!string.IsNullOrEmpty(nome))
            {
                sql += " AND Vendedor LIKE @nome";
                parameters.Add(new SqlParameter("@nome", "%" + nome + "%"));
            }


            List<Vendedor> vendedores = new List<Vendedor>();
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
                        Vendedor contato = new Vendedor
                        {
                            IdVendedor = dataReader.GetInt32(dataReader.GetOrdinal("idVendedor")),
                            NomeVendedor = dataReader.GetString(dataReader.GetOrdinal("Vendedor")),
                            Comissao = dataReader.GetDecimal(dataReader.GetOrdinal("Comissao")),
                            Endereco = dataReader.GetString(dataReader.GetOrdinal("Endereco")),
                            Bairro = dataReader.GetString(dataReader.GetOrdinal("Bairro")),
                            Cidade = dataReader.GetString(dataReader.GetOrdinal("Cidade")),
                            CEP = dataReader.GetString(dataReader.GetOrdinal("CEP")),
                            UF = dataReader.GetString(dataReader.GetOrdinal("UF")),
                            CPF = dataReader.GetString(dataReader.GetOrdinal("CPF"))
                        };

                        vendedores.Add(contato);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar vendedores", ex);
                }
                finally
                {
                    connection.Close();
                }
            }

            return vendedores;
        }

        public Vendedor BuscaPorCodigo(int codigo)
        {
            string sql = @"SELECT idVendedor, Vendedor,CAST(Comissao as decimal(20,12)) as Comissao, Endereco, Bairro, Cidade, CEP, UF, CPF 
                            FROM Vendedores WHERE idVendedor = @idVendedor";

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@idVendedor", codigo));

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
                        Vendedor vededor = new Vendedor
                        {
                            IdVendedor = dataReader.GetInt32(dataReader.GetOrdinal("idVendedor")),
                            NomeVendedor = dataReader.GetString(dataReader.GetOrdinal("Vendedor")),
                            Comissao = dataReader.GetDecimal(dataReader.GetOrdinal("Comissao")),
                            Endereco = dataReader.GetString(dataReader.GetOrdinal("Endereco")),
                            Bairro = dataReader.GetString(dataReader.GetOrdinal("Bairro")),
                            Cidade = dataReader.GetString(dataReader.GetOrdinal("Cidade")),
                            CEP = dataReader.GetString(dataReader.GetOrdinal("CEP")),
                            UF = dataReader.GetString(dataReader.GetOrdinal("UF")),
                            CPF = dataReader.GetString(dataReader.GetOrdinal("CPF"))
                        };

                        return vededor;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar vendedor", ex); ;
                }
                finally
                {
                    connection.Close();
                }
                return null;
            }
        }

        public void Salvar(Vendedor vendedor)
        {
            string sql = @"INSERT INTO Vendedores (Vendedor, Comissao, Endereco, Bairro, Cidade, CEP, UF, CPF) 
                           VALUES (@NomeVendedor, @Comissao, @Endereco, @Bairro, @Cidade, @CEP, @UF, @CPF)";

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@NomeVendedor", vendedor.NomeVendedor);
                    command.Parameters.AddWithValue("@Comissao", vendedor.Comissao);
                    command.Parameters.AddWithValue("@Endereco", vendedor.Endereco);
                    command.Parameters.AddWithValue("@Bairro", vendedor.Bairro);
                    command.Parameters.AddWithValue("@Cidade", vendedor.Cidade);
                    command.Parameters.AddWithValue("@CEP", vendedor.CEP);
                    command.Parameters.AddWithValue("@UF", vendedor.UF);
                    command.Parameters.AddWithValue("@CPF", vendedor.CPF);

                    command.ExecuteNonQuery();                    
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar vendedor", ex); ;
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Editar(Vendedor vendedor)
        {
            string sql = @"UPDATE Vendedores SET Vendedor = @NomeVendedor, Comissao = @Comissao, Endereco = @Endereco, 
                        Bairro = @Bairro, Cidade = @Cidade, CEP = @CEP, UF = @UF, CPF = @CPF WHERE IdVendedor = @IdVendedor";

            

            using (SqlConnection connection = DataSourceConfig.GetSqlConnection())
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@NomeVendedor", vendedor.NomeVendedor);
                    command.Parameters.AddWithValue("@Comissao", vendedor.Comissao);
                    command.Parameters.AddWithValue("@Endereco", vendedor.Endereco);
                    command.Parameters.AddWithValue("@Bairro", vendedor.Bairro);
                    command.Parameters.AddWithValue("@Cidade", vendedor.Cidade);
                    command.Parameters.AddWithValue("@CEP", vendedor.CEP);
                    command.Parameters.AddWithValue("@UF", vendedor.UF);
                    command.Parameters.AddWithValue("@CPF", vendedor.CPF);
                    command.Parameters.AddWithValue("@IdVendedor", vendedor.IdVendedor);

                    command.ExecuteNonQuery();
                }

                catch (Exception ex)
                {
                    throw new Exception("Erro ao atualizar vendedor", ex); 
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}