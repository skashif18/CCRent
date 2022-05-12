using Appo.Server.Features.ServiceAttachmentType.Model;
using Appo.Server.Features.ServiceAttachmentType.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace Appo.Server.Features.ServiceAttachmentType
{
    public class ServiceAttachmentTypeController : ApiController
    {
        private readonly IServiceAttachmentType repository;

        private IWebHostEnvironment _hostEnvironment;



        public ServiceAttachmentTypeController(IServiceAttachmentType _repository, IWebHostEnvironment hostEnvironment)
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


        [HttpPost]
        [Route("upload")]
        public IActionResult UploadFile(IList<IFormFile> files, IFormCollection data)
        {

            IDictionary<string, string> payload = new Dictionary<string, string>();
            payload.Add("serviceId", data["serviceId"]);
            payload.Add("attachmentId", data["attachmentId"]);
            var result = repository.UploadFile(files, payload);

            return Ok(true);    
        }

        [HttpGet]
        [Route("fetchImage")]
        public IActionResult GetImage(int serviceId,int attachmentId)
        {
            Stream objFiles = repository.GetImage(serviceId, attachmentId);

            return File(objFiles,contentType:"image/jpeg");
        }

    }
}
