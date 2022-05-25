using Appo.Server.Features.ServiceSchedule.Model;
using Appo.Server.Features.ServiceSchedule.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceSchedule
{
    public class ServiceScheduleController : ApiController
    {
        private readonly IServiceScheduleService repository;

        public ServiceScheduleController(IServiceScheduleService _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("by-service-Id")]
        [AllowAnonymous]
        public IEnumerable<ServiceScheduleResponseModel> GetByServiceId(int Id)
            => repository.GetByServiceId(Id);


        [HttpGet]
        [Route("by-Id")]
        [AllowAnonymous]
        public ServiceScheduleResponseModel GetById(int Id)
            => repository.GetById(Id);


        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create(ServiceScheduleRequestModel model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(ServiceScheduleRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete(int Id)
        {
            var result = repository.Delete(Id);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }

}