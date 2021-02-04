using Elite.Web.API.Others.Models;
using System.Collections.Generic;

namespace Elite.Web.API.Database.Repositories.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAllRegions();
    }
}
