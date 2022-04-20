using Appo.Server.Features.Category.Model;
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
        }
    }
}
