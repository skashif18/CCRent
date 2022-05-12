using Appo.Server.Features.ServiceAttachment.Model;
using Appo.Server.Features.ServiceAttachment.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceAttachment
{
    public class ServiceAttachmentController : ApiController
    {
        private readonly IServiceAttachmentService repository;

        private readonly IWebHostEnvironment Environment;
        public ServiceAttachmentController(IServiceAttachmentService _repository, IWebHostEnvironment _hostEnvironment)
        {
            repository = _repository;
            Environment = _hostEnvironment;
        }


        [HttpGet]
        [Route("by-service-Id")]
        public IEnumerable<ServiceAttachmentResponseModel> GetByServiceId(int Id)
            => repository.GetByServiceId(Id);





        [HttpGet]
        [Route("by-Id")]
        public ServiceAttachmentResponseModel GetById(int Id)
            => repository.GetById(Id);


        [HttpPost]
        [Route("create")]
        public IActionResult Create(ServiceAttachmentRequestModel model)
        {
            string contentPath = this.Environment.ContentRootPath;

            model.ServerLocalPath = contentPath;

            model.FileUrlpath = $"\\upload\\serviceImage";

            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(ServiceAttachmentRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
