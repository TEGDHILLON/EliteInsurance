using Dapper;
using Elite.Web.API.Database.Providers;
using Elite.Web.API.Database.Repositories.Interfaces;
using Elite.Web.API.Others.DTOs;
using Elite.Web.API.Others.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Elite.Web.API.Database.Repositories
{
    public class InsuranceRepository : IInsuranceRepository
    {
        protected IDbProvider provider;

        public InsuranceRepository(IDbProvider provider)
        {
            this.provider = provider;
        }

        public int Create(Insurance entity)
        {
            try
            {
                using (var connection = provider.GetConnection())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("insert into Insurance (AccountId,CompanyId,Year,ModelId,Amount,AnnualFee,Phone,Note) " +
                        "values (@AccountId,@CompanyId,@Year,@ModelId,@Amount,@AnnualFee,@Phone,@Note) ");
                    query.Append("select SCOPE_IDENTITY()");

                    connection.Open();
                    return connection.ExecuteScalar<int>(query.ToString(), new
                    {
                        entity.AccountId,
                        entity.CompanyId,
                        entity.Year,
                        entity.ModelId,
                        entity.Amount,
                        entity.AnnualFee,
                        entity.Phone,
                        entity.Note
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Delete(int id)
        {
            using (var connection = provider.GetConnection())
            {
                connection.Open();
                return connection.Execute("delete from [Insurance] where Id = @Id", new { Id = id }) == 1;
            }
        }

        public IEnumerable<InsuranceInfoDTO> GetAll()
        {
            using (var connection = provider.GetConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("" +
                    "select i.Id,i.AccountId,i.Year,ml.Name as Model,mk.Name as Make,r.Name as Region," +
                    "c.Name as Company,i.Amount,i.AnnualFee,i.Phone,i.Note,i.CreatedOn,i.UpdatedOn " +
                    "from Insurance i " +
                    "left join Company c on i.CompanyId = c.Id " +
                    "left join Model ml on i.ModelId = ml.Id " +
                    "left join Make mk on ml.MakeId = mk.Id " +
                    "left join Region r on c.RegionId = r.Id");

                connection.Open();
                return connection.Query<InsuranceInfoDTO>(query.ToString(), null);
            }
        }

        public InsuranceInfoDTO GetById(int id)
        {
            using (var connection = provider.GetConnection())
            {
                StringBuilder query = new StringBuilder();
                query.Append("" +
                    "select i.Id,i.AccountId,i.Year,ml.Name as Model,mk.Name as Make,r.Name as Region," +
                    "c.Name as Company,i.Amount,i.AnnualFee,i.Phone,i.Note,i.CreatedOn,i.UpdatedOn " +
                    "from Insurance i " +
                    "left join Company c on i.CompanyId = c.Id " +
                    "left join Model ml on i.ModelId = ml.Id " +
                    "left join Make mk on ml.MakeId = mk.Id " +
                    "left join Region r on c.RegionId = r.Id where i.Id = @Id");

                connection.Open();
                return connection.QueryFirstOrDefault<InsuranceInfoDTO>(query.ToString(), new { Id = id });
            }
        }

        public bool Update(Insurance entity)
        {
            try
            {
                using (var connection = provider.GetConnection())
                {
                    StringBuilder query = new StringBuilder();
                    query.Append(@"update [Insurance] Set 
	                                  Year = @Year,
                                      Amount = @Amount,
                                      AnnualFee = @AnnualFee,
                                      Phone = @Phone,
                                      Note = @Note,
                                      UpdatedOn = @UpdatedOn
	                                  where Id = @Id");

                    connection.Open();
                    return connection.ExecuteScalar<bool>(query.ToString(), new
                    {
                        entity.Id,
                        entity.Year,
                        entity.Amount,
                        entity.AnnualFee,
                        entity.Phone,
                        entity.Note,
                        UpdatedOn = DateTime.Now
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
