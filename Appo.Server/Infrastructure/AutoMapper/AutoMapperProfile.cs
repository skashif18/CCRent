using Appo.Server.Features.Category.Model;
using Appo.Server.Features.Master.Model;
using Appo.Server.Features.Service.Model;
using Appo.Server.Features.ServiceAttachment.Model;
using Appo.Server.Features.ServiceAttachmentType.Model;
using Appo.Server.Features.ServiceType.Model;
using AutoMapper;
using CoreBusiness.Master;

namespace Appo.Server.Infrastructure.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CategoryRequestModel, SrvCategory>();
            CreateMap<SrvCategory, CategoryResponseModel>();

            CreateMap<ServiceTypeRequestModel, SrvServiceType>();
            CreateMap<SrvServiceType, ServiceTypeResponseModel>();

            CreateMap<ServiceRequestModel, SrvService>();
            CreateMap<SrvService, ServiceResponseModel>();

            CreateMap<ServiceAttachmentRequestModel, SrvServiceAttachment>();
            CreateMap<SrvServiceAttachment, ServiceAttachmentResponseModel>();

            CreateMap<SrvServiceTypeAttachment, ServiceAttachmentTypeResponseModel>();

            CreateMap<SrvClass, SrvClassResponseModel>();

        }
    }
}
