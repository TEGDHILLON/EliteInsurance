using Dapper;
using Elite.Web.API.Others.Models;
using Elite.Web.API.Database.Providers;
using Elite.Web.API.Database.Repositories.Interfaces;
using System.Collections.Generic;
using System.Text;

namespace Elite.Web.API.Database.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        protected IDbProvider provider;

        public RegionRepository(IDbProvider provider)
        {
            this.provider = provider;
        }
        public IEnumerable<Region> GetAllRegions()
        {
            using (var connection = provider.GetConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select * from Region");

                connection.Open();
                return connection.Query<Region>(query.ToString(), null);
            }
        }
    }
}
