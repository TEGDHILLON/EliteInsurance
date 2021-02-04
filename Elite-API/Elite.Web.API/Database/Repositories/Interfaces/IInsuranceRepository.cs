using Elite.Web.API.Others.DTOs;
using Elite.Web.API.Others.Models;
using System.Collections.Generic;

namespace Elite.Web.API.Database.Repositories.Interfaces
{
    public interface IInsuranceRepository
    {
        IEnumerable<InsuranceInfoDTO> GetAll();
        InsuranceInfoDTO GetById(int id);
        int Create(Insurance entity);
        bool Update(Insurance entity);
        bool Delete(int id);
    }
}
