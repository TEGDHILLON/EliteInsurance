using AutoMapper;
using Elite.Web.API.Others.DTOs;
using Elite.Web.API.Others.Models;

namespace Elite.Web.API.Others.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountDTO>();
            CreateMap<AccountDTO, Account>();

            CreateMap<Insurance, InsuranceDTO>();
            CreateMap<InsuranceDTO, Insurance>();
        }
    }
}
