using Appo.Server.Features.ServiceClassValue.Model;
using Appo.Server.Features.ServiceClassValue.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceClassValue
{
    public class ServiceClassValueController : ApiController
    {
        private readonly IServiceClassValueService repository;

        public ServiceClassValueController(IServiceClassValueService _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("by-service-Id")]
        [AllowAnonymous]
        public IEnumerable<ServiceClassValueResponseModel> GetByServiceId(int Id)
            => repository.GetByServiceId(Id);


        [HttpGet]
        [Route("by-Id")]
        [AllowAnonymous]
        public ServiceClassValueResponseModel GetById(int Id)
            => repository.GetById(Id);


        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create(ServiceClassValueRequestModel model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(ServiceClassValueRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }

}
