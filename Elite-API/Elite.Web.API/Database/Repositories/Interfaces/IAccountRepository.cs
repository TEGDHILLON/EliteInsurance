using Elite.Web.API.Others.DTOs;
using Elite.Web.API.Others.Models;

namespace Elite.Web.API.Database.Repositories.Interfaces
{
    public interface IAccountRepository 
    {
        int Create(Account entity);
        AccountDTO Get(Account entity);
    }
}
