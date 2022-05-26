using Appo.Server.Features.Service.Model;
using Appo.Server.Features.Service.Service;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plugins.DataStore.SQL.Infrastructure.Services;
using System.Collections.Generic;

namespace Appo.Server.Features.Service
{
    public class ServiceController : ApiController
    {
        private readonly IServiceService repository;

        private ICurrentUserService currentUserService;
        public ServiceController(IServiceService _repository, ICurrentUserService _currentUserService)
        {
            repository = _repository;
            currentUserService = _currentUserService;

        }

        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public IEnumerable<ServiceResponseModel> GetAll()
            => repository.GetAll(currentUserService.GetUserName());


        [HttpGet]
        [Route("GetService")]
        [AllowAnonymous]
        public IEnumerable<SrvService> GetService()
            => repository.GetService();





        [HttpGet]
        [Route("by-Id")]
        public ServiceResponseModel GetById(int Id)
            => repository.GetById(Id);


        [HttpPost]
        [Route("create")]
        public IActionResult Create(ServiceRequestModel model)
        {
            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(ServiceRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
