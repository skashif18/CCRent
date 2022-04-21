using Appo.Server.Features.Category.Model;
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

        }
    }
}
