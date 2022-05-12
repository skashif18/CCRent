using Appo.Server.Features.ServiceAttachment.Model;
using CoreBusiness;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Appo.Server.Features.ServiceAttachment.Service
{
    public interface IServiceAttachmentService
    {
        Response Create(IFormFile files, IFormCollection formFileCollection);
        Response Update(ServiceAttachmentRequestModel model);

        ServiceAttachmentResponseModel GetById(int Id);

        IEnumerable<ServiceAttachmentResponseModel> GetByServiceId(int serviceId);

        Response Delete(int Id);
        Stream GetImage(string filePath);
    }
}
