using Appo.Server.Features.ServiceAddOn.Service;
using Appo.Server.Features.ServiceClassValue.Model;
using Appo.Server.Features.ServiceClassValue.Service;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.ServiceClassValue
{
    public class ServiceBookingController : ApiController
    {
        private readonly IServiceBookingService repository;

        public ServiceBookingController(IServiceBookingService _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("by-service-Id")]
        [AllowAnonymous]
        public IEnumerable<ServiceBookingResponseModel> GetByServiceId(int Id)
            => repository.GetByServiceId(Id);

        [HttpGet]
        [Route("by-customer-Id")]
        [AllowAnonymous]
        public IEnumerable<ServiceBookingResponseModel> GetByCustomerId(int Id)
            => repository.GetByCustomerId(Id);


        [HttpGet]
        [Route("by-vendor-username")]
        [AllowAnonymous]
        public IEnumerable<ServiceBookingResponseModel> GetByVendorUserName(string username)
            => repository.GetByVendorUserName(username);

        [HttpGet]
        [Route("by-customer-username")]
        [AllowAnonymous]
        public IEnumerable<ServiceBookingResponseModel> GetByCustomerUserName(string username)
            => repository.GetByCustomerUserName(username);


        [HttpGet]
        [Route("by-Id")]
        [AllowAnonymous]
        public ServiceBookingResponseModel GetById(int Id)
            => repository.GetById(Id);


        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create(ServiceBookingRequestModel model)
        {

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        [AllowAnonymous]
        public IActionResult Update(ServiceBookingRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }

}
