using Appo.Server.Features.ServiceAddOn.Service;
using Appo.Server.Features.ServiceClassValue.Model;
using Appo.Server.Features.ServiceClassValue.Service;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceClassValue
{
    public class ServiceAddOnController : ApiController
    {
        private readonly IServiceAddOnService repository;

        public ServiceAddOnController(IServiceAddOnService _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("by-service-Id")]
        [AllowAnonymous]
        public IEnumerable<ServiceAddOnResponseModel> GetByServiceId(int Id)
            => repository.GetByServiceId(Id);


        [HttpGet]
        [Route("by-Id")]
        [AllowAnonymous]
        public ServiceAddOnResponseModel GetById(int Id)
            => repository.GetById(Id);


        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create(ServiceAddOnRequestModel model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(ServiceAddOnRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int id)
        {
            var result = repository.Delete(id);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }

}
