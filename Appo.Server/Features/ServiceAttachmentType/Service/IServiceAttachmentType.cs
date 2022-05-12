using Appo.Server.Features.ServiceAttachmentType.Model;
using CoreBusiness;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Appo.Server.Features.ServiceAttachmentType.Service
{
    public interface IServiceAttachmentType
    {
        ServiceAttachmentTypeResponseModel GetById(int Id);

        IEnumerable<ServiceAttachmentTypeResponseModel> GetByServiceTypeId(int serviceId);

        Response UploadFile(IList<IFormFile> files, IDictionary<string, string> data);

        Stream GetImage(int serviceId, int attachmentId);
    }
}
