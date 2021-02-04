using Dapper;
using Elite.Web.API.Database.Providers;
using Elite.Web.API.Others.Models;
using System.Collections.Generic;
using System.Text;

namespace Elite.Web.API.Database.Repositories.Interfaces
{
    public class ModelRepository : IModelRepository
    {
        protected IDbProvider provider;

        public ModelRepository(IDbProvider provider)
        {
            this.provider = provider;
        }

        public IEnumerable<Model> GetAllModelByMakeId(int makeId)
        {
            using (var connection = provider.GetConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select * from Model where MakeId = @MakeId");

                connection.Open();
                return connection.Query<Model>(query.ToString(), new { MakeId = makeId });
            }
        }
    }
}
