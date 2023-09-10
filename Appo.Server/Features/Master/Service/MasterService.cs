using Appo.Server.Features.Master.Model;
using AutoMapper;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.Masters;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Appo.Server.Features.Master.Service
{

   
    public class MasterService : IMasterService
    {
        private readonly IClassRepository repository;
        private readonly ICountryRepository repositoryCountry;
        private readonly ICityRepository repositoryCity;
        private readonly IMapper mapper;
        public MasterService(IClassRepository _repository, IMapper _mapper, 
            ICountryRepository _repositoryCountry, ICityRepository _repositoryCity)
        {
            repository = _repository;
            repositoryCountry = _repositoryCountry;
            repositoryCity = _repositoryCity;
            mapper = _mapper;
        }
        public IEnumerable<SrvClassResponseModel> GetClassesWithValues()
        {
            var model = repository.GetClassesWithValues();
            return mapper.Map<IEnumerable<SrvClassResponseModel>>(model);
        }

        public IEnumerable<SysCountry> GetCountries()
        {
            return repositoryCountry.GetAll();
        }

        public IEnumerable<SysCity> GetCityByCountryId(int id)
        {
            return repositoryCity.GetCitiesByCountryId(id);
        }
    }
}
