using System.Data.SqlClient;

namespace Vera.Interface.DAL
{
    public interface IDapperConnection
    {
        SqlConnection OpenConnection();
    }
}
