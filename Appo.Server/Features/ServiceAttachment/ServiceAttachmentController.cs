using Appo.Server.Features.ServiceAttachment.Model;
using Appo.Server.Features.ServiceAttachment.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceAttachment
{
    public class ServiceAttachmentController : ApiController
    {
        private readonly IServiceAttachmentService repository;


        public ServiceAttachmentController(IServiceAttachmentService _repository )
        {
            repository = _repository;
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
