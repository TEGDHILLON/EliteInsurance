using AutoMapper;
using Elite.Web.API.Database.Repositories.Interfaces;
using Elite.Web.API.Others.DTOs;
using Elite.Web.API.Others.Models;
using System.Collections.Generic;

namespace Elite.Web.API.Business.Managers
{
    public class InsuranceManager
    {
        private IInsuranceRepository _insuranceRepository;
        private readonly IMapper _autoMapper;

        public InsuranceManager(IInsuranceRepository insuranceRepository, IMapper autoMapper)
        {
            _insuranceRepository = insuranceRepository;
            _autoMapper = autoMapper;
        }

        public IEnumerable<InsuranceInfoDTO> GetAll()
        {
            var result = _insuranceRepository.GetAll();
            return result;
        }

        public InsuranceInfoDTO GetById(int id)
        {
            var result = _insuranceRepository.GetById(id);
            return result;
        }

        public int Create(InsuranceDTO insurance)
        {
            // convert InsuranceDTO to Insurance object using auto mapper 
            var autoMap = _autoMapper.Map<Insurance>(insurance);
            var result = _insuranceRepository.Create(autoMap);
            return result;
        }
        public bool Update(InsuranceDTO insurance)
        {
            // convert InsuranceDTO to Insurance object using auto mapper 
            var autoMap = _autoMapper.Map<Insurance>(insurance);
            var result = _insuranceRepository.Update(autoMap);
            return result;
        }

        public bool Delete(int id)
        {
            var result = _insuranceRepository.Delete(id);
            return result;
        }
    }
}
