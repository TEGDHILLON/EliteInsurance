using Dapper;
using Elite.Web.API.Database.Providers;
using Elite.Web.API.Others.Models;
using System.Collections.Generic;
using System.Text;

namespace Elite.Web.API.Database.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        protected IDbProvider provider;

        public MakeRepository(IDbProvider provider)
        {
            this.provider = provider;
        } 

        public IEnumerable<Make> GetAllMakes()
        {
            using (var connection = provider.GetConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select * from Make");

                connection.Open();
                return connection.Query<Make>(query.ToString(), null);
            }
        }
    }
}
