using Elite.Web.API.Others.Models;
using System.Collections.Generic;

namespace Elite.Web.API.Database.Repositories
{
    public interface IMakeRepository
    {
        IEnumerable<Make> GetAllMakes();
    }
}
