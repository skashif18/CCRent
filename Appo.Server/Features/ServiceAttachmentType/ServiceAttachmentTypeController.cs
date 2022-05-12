using Appo.Server.Features.ServiceAttachmentType.Model;
using Appo.Server.Features.ServiceAttachmentType.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Appo.Server.Features.ServiceAttachment.Model;

namespace Appo.Server.Features.ServiceAttachmentType
{
    public class ServiceAttachmentTypeController : ApiController
    {
        private readonly IServiceAttachmentTypeService repository;

        private IWebHostEnvironment _hostEnvironment;



        public ServiceAttachmentTypeController(IServiceAttachmentTypeService _repository, IWebHostEnvironment hostEnvironment)
        {
            repository = _repository;
            _hostEnvironment = hostEnvironment;
        }


        [HttpGet]
        [Route("by-service-type-Id")]
        public IEnumerable<ServiceAttachmentTypeResponseModel> GetByServiceTypeId(int Id)
            => repository.GetByServiceTypeId(Id);

        [HttpGet]
        [Route("by-Id")]
        public ServiceAttachmentTypeResponseModel GetById(int Id)
            => repository.GetById(Id);

    }
}
