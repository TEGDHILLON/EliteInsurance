namespace Elite.Web.API.Database.Providers
{
    public class DbProviderFactory
    {
        public static IDbProvider GetProvider(DbProviderTypes type, string connectionString)
        {
            IDbProvider provider = null;
            if (type == DbProviderTypes.MsSql)
            {
                provider = new MsSqlDbProvider(connectionString);
            }
            return provider;
        }
    }
}
