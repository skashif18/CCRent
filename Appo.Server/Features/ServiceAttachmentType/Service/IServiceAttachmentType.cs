using Appo.Server.Features.ServiceAttachmentType.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceAttachmentType.Service
{
    public interface IServiceAttachmentType
    {
        ServiceAttachmentTypeResponseModel GetById(int Id);

        IEnumerable<ServiceAttachmentTypeResponseModel> GetByServiceTypeId(int Id);
    }
}
