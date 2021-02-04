using System.Data;
using System.Data.SqlClient;

namespace Elite.Web.API.Database.Providers
{
    public class MsSqlDbProvider : IDbProvider
    {
        public string ConnectionString { private set; get; }

        public MsSqlDbProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
