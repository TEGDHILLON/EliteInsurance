using System.Data;

namespace Elite.Web.API.Database.Providers
{
    public interface IDbProvider
    {
        string ConnectionString { get; }
        IDbConnection GetConnection();
    }
}
