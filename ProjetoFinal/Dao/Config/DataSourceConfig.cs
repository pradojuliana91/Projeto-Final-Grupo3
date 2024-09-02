using System.Configuration;
using System.Data.SqlClient;

namespace ProjetoFinal.Dao.Config
{

    public static class DataSourceConfig
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["cesumar"].ConnectionString;

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}