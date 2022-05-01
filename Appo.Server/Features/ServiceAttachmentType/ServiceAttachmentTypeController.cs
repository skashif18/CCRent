using Appo.Server.Features.ServiceAttachmentType.Model;
using Appo.Server.Features.ServiceAttachmentType.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace Appo.Server.Features.ServiceAttachmentType
{
    public class ServiceAttachmentTypeController : ApiController
    {
        private readonly IServiceAttachmentType repository;


        public ServiceAttachmentTypeController(IServiceAttachmentType _repository)
        {
            repository = _repository;
        }


        [HttpGet]
        [Route("by-service-type-Id")]
        public IEnumerable<ServiceAttachmentTypeResponseModel> GetByServiceId(int Id)
            => repository.GetByServiceTypeId(Id);

        [HttpGet]
        [Route("by-Id")]
        public ServiceAttachmentTypeResponseModel GetById(int Id)
            => repository.GetById(Id);

    }
}
