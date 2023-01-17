using Appo.Server.Features.ServiceRequest.Model;
using Appo.Server.Features.ServiceRequest.Service;
using Appo.Server.Features.ServiceRequestQuotation.Model;
using Appo.Server.Features.ServiceRequestQuotation.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Plugins.DataStore.SQL.Infrastructure.Services;
using System.Threading.Tasks;

namespace Appo.Server.Features.ServiceRequestQuotation
{
    public class ServiceRequestQuotationController : ApiController
    {
        private readonly IServiceRequestQuotationService repository;

        private ICurrentUserService currentUserService;
        public ServiceRequestQuotationController(IServiceRequestQuotationService _repository, ICurrentUserService _currentUserService)
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
        public async Task<IActionResult> GetBySupplierId(int suppId)
            => Ok(await repository.GetBySupplierId(suppId));

        [HttpGet]
        [Route("GetBySrvReqId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBySrvReqId(int srvReqId)
           => Ok(await repository.GetBySrvReqId(srvReqId));

        [HttpGet]
        [Route("GetBySrvId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetBySrvId(int srvId)
           => Ok(await repository.GetBySrvId(srvId));


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ServiceRequestQuotationRequestModel model)
        {
            var result = await repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(ServiceRequestQuotationRequestModel model)
        {
            var result = await repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        [Route("updateStatus")]
        public async Task<IActionResult> UpdateStatus(ServiceRequestQuotationStatusModel model)
        {
            var result = await repository.UpdateStatus(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
