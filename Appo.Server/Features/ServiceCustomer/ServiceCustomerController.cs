using Appo.Server.Features.ServiceClassValue.Model;
using Appo.Server.Features.ServiceClassValue.Service;
using Appo.Server.Features.ServiceCustomer.Model;
using Appo.Server.Features.ServiceCustomer.Services;
using CoreBusiness;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceCustomer
{
    public class ServiceCustomerController : ApiController
    {
        private readonly IServiceCustomerService repository;

        public ServiceCustomerController(IServiceCustomerService _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("by-email")]
        [AllowAnonymous]
        public ServiceCustomerResponseModel GetByServiceEmail(string email)
            => repository.GetByServiceEmail(email);

        [HttpPut]
        [Route("update")]
        [AllowAnonymous]
        public Response GetByServiceEmail(ServiceCustomerRequestModel model)
            => repository.Update(model);


    }
}
