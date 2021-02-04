using Elite.Web.API.Others.Models;
using Elite.Web.API.Database.Repositories;
using Elite.Web.API.Database.Repositories.Interfaces;
using System.Collections.Generic;

namespace Elite.Web.API.Business.Managers
{
    public class BaseManager
    {
        private IRegionRepository _regionRepository;
        private IMakeRepository _makeRepository;
        private IModelRepository _modelRepository; 
        private ICompanyRepository _companyRepository;

        public BaseManager(
            IRegionRepository regionRepository, 
            IMakeRepository makeRepository, 
            IModelRepository modelRepository,
            ICompanyRepository companyRepository
            )
        {
            _regionRepository = regionRepository;
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
            _companyRepository = companyRepository;
        }

        public IEnumerable<Region> GetAllRegions()
        {
            var result = _regionRepository.GetAllRegions();
            return result;
        }

        public IEnumerable<Company> GetAllCompaniesByRegionId(int regionId)
        {
            var result = _companyRepository.GetAllCompaniesByRegionId(regionId);
            return result;
        }

        public IEnumerable<Make> GetAllMakes()
        {
            var result = _makeRepository.GetAllMakes();
            return result;
        }

        public IEnumerable<Model> GetAllModels(int makeId)
        {
            var result = _modelRepository.GetAllModelByMakeId(makeId);
            return result;
        }
        
    }
}
