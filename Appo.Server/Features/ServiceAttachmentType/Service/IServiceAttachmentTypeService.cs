using Appo.Server.Features.ServiceAttachmentType.Model;
using CoreBusiness;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;

namespace Appo.Server.Features.ServiceAttachmentType.Service
{
    public interface IServiceAttachmentTypeService
    {
        ServiceAttachmentTypeResponseModel GetById(int Id);

        IEnumerable<ServiceAttachmentTypeResponseModel> GetByServiceTypeId(int serviceId);
    }
}
