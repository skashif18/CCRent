using Appo.Server.Features.ServiceAttachment.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceAttachment.Service
{
    public interface IServiceAttachmentService
    {
        Response Create(ServiceAttachmentRequestModel model);
        Response Update(ServiceAttachmentRequestModel model);

        ServiceAttachmentResponseModel GetById(int Id);

        IEnumerable<ServiceAttachmentResponseModel> GetByServiceId(int serviceId);

        Response Delete(int Id);
    }
}
