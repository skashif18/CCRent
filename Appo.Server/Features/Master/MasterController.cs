using Appo.Server.Features.Master.Model;
using Appo.Server.Features.Master.Service;
using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Appo.Server.Features.Master
{
    [AllowAnonymous]
    public class MasterController : ApiController
    {
        private readonly IGetMasterRepository repository;
        private readonly IMasterService service;
        public MasterController(IGetMasterRepository _repository, IMasterService _service)
        {
            repository = _repository;
            service = _service;
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

        [HttpGet]
        [Route("GetClasses")]
        public IEnumerable<IdNameModel> GetClasses()
          => repository.GetClass();

        [HttpGet]
        [Route("GetValues")]
        public IEnumerable<IdNameModel> GetClassValues(int Id)
          => repository.GetValuesByClassId(Id);



        [HttpGet]
        [Route("GetClassesWithValues")]
        public IEnumerable<SrvClassResponseModel> GetClassesWithValues()
          => service.GetClassesWithValues();

        [HttpGet]
        [Route("GetAddOn")]
        public IEnumerable<IdNameModel> GetAddOn()
           => repository.GetAddOn();



    }
}
