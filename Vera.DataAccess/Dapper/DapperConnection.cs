using System.Configuration;
using System.Data.SqlClient;
using Vera.Interface.DAL;

namespace Vera.DataAccess.Dapper
{
    public class DapperConnection : IDapperConnection
    {
        public static readonly string ConnectionString = ConfigurationManager.AppSettings["VeraConnection"];

        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
