using Dapper;
using Elite.Web.API.Others.Models;
using Elite.Web.API.Database.Providers;
using System.Collections.Generic;
using System.Text;

namespace Elite.Web.API.Database.Repositories.Interfaces
{
    public class CompanyRepository : ICompanyRepository
    {
        protected IDbProvider provider;

        public CompanyRepository(IDbProvider provider)
        {
            this.provider = provider;
        }

        public IEnumerable<Company> GetAllCompaniesByRegionId(int makeId)
        {
            using (var connection = provider.GetConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select * from Company where RegionId = @RegionId");

                connection.Open();
                return connection.Query<Company>(query.ToString(), new { RegionId = makeId });
            }
        }
    }
}
