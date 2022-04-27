using Appo.Server.Features.ServiceType.Model;
using Appo.Server.Features.ServiceType.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceType
{
    public class ServiceTypeController : ApiController
    {
        private readonly IServiceTypeService repository;
        public ServiceTypeController(IServiceTypeService _repository)
        {
            repository = _repository;

        }

        [HttpGet]
        [Route("all-service-type")]
        public IList<ServiceTypeResponseModel> GetAll()
            => repository.GetAll();

        [HttpGet]
        [Route("root-service-type")]
        public IEnumerable<ServiceTypeResponseModel> GetBaseParent()
            => repository.GetBaseParentAll();

        [HttpGet]
        [Route("childs-service-type-by-parent")]
        public IEnumerable<ServiceTypeResponseModel> GetChildParentByPrentId(int Id)
            => repository.GetChildByParentId(Id);

        [HttpGet]
        [Route("service-type-by-Id")]
        public ServiceTypeResponseModel GetById(int Id)
            => repository.GetById(Id);


        [HttpPost]
        [Route("create-service-type")]
        public IActionResult Create(ServiceTypeRequestModel model)
        {
            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update-service-type")]
        public IActionResult Update(ServiceTypeRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }
}