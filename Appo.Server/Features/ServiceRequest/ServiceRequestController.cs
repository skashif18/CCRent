using Appo.Server.Features.Service.Model;
using Appo.Server.Features.Service.Service;
using Appo.Server.Features.ServiceRequest.Model;
using Appo.Server.Features.ServiceRequest.Service;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plugins.DataStore.SQL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appo.Server.Features.ServiceRequest
{
    public class ServiceRequestController : ApiController
    {
        private readonly IServiceRequestService repository;

        private ICurrentUserService currentUserService;
        public ServiceRequestController(IServiceRequestService _repository, ICurrentUserService _currentUserService)
        {
            repository = _repository;
            currentUserService = _currentUserService;

        }

        [HttpGet]
        [Route("GetById")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll(int id)
            => Ok(await repository.GetById(id));


        [HttpGet]
        [Route("GetByCatId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByCatId(int catId)
            => Ok(await repository.GetByCatId(catId));

        [HttpGet]
        [Route("GetByUser")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByUser(string email)
            => Ok(await repository.GetByUser(email));


        [HttpGet]
        [Route("GetBySrvTypeId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBySrvTypeId(int srvTypeId)
           => Ok(await repository.GetBySrvTypeId(srvTypeId));

        [HttpGet]
        [Route("GetAll")]
        [AllowAnonymous]
        public async Task<Object> GetAll()
        {
            return (await repository.GetAll());
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ServiceRequestRequestModel model)
        {
            var result = await repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ServiceRequestRequestModel model)
        {
            var result = await repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
