using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Appo.Server.Features.Master
{
    public class MasterController : ApiController
    {
        private readonly IGetMasterRepository repository;
        public MasterController(IGetMasterRepository _repository)
        {
            repository = _repository;
        }
        [HttpGet]
        [Route("GetGenders")]
        public IEnumerable<IdNameModel> GetGenders()
           => repository.GetGenders();
        [HttpGet]
        [Route("GetNationalities")]
        public IEnumerable<IdNameModel> GetNationalities()
           => repository.GetNationalities();
        [HttpGet]
        [Route("GetLanguages")]
        public IEnumerable<IdNameModel> GetLanguages()
           => repository.GetLanguages();
        [HttpGet]
        [Route("GetReligions")]
        public IEnumerable<IdNameModel> GetReligions()
           => repository.GetReligions();

        [HttpGet]
        [Route("GetCities")]
        public IEnumerable<IdNameModel> GetCities()
          => repository.GetCities();

    }
}
