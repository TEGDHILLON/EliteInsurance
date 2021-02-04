using Dapper;
using Elite.Web.API.Database.Providers;
using Elite.Web.API.Database.Repositories.Interfaces;
using Elite.Web.API.Others.DTOs;
using Elite.Web.API.Others.Models;
using System;
using System.Text;

namespace Elite.Web.API.Database.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        protected IDbProvider provider;

        public AccountRepository(IDbProvider provider)
        {
            this.provider = provider;
        }

        public int Create(Account entity)
        {
            try
            {
                using (var connection = provider.GetConnection())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("insert into Account (Name,Email,Phone,Password) " +
                        "values (@Name,@Email,@Phone,@Password) ");
                    query.Append("select SCOPE_IDENTITY()");

                    connection.Open();
                    return connection.ExecuteScalar<int>(query.ToString(), new
                    {
                        entity.Name,
                        entity.Email,
                        entity.Phone,
                        entity.Password
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public AccountDTO Get(Account entity)
        {
            using (var connection = provider.GetConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("select * from [Account] where Phone = @Phone and Password = @Password;");

                connection.Open();
                return connection.QueryFirstOrDefault<AccountDTO>(query.ToString(), new { entity.Phone, entity.Password });
            }
        }
    }
}
