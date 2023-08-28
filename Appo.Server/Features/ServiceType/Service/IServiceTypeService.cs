using Appo.Server.Features.ServiceType.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceType.Service
{
    public interface IServiceTypeService
    {
        Response Create(ServiceTypeRequestModel model);

        IList<ServiceTypeResponseModel> GetAll();

        Response Update(ServiceTypeRequestModel model);
        string GetChildToParent(int catId);

        ServiceTypeResponseModel GetById(int id);

        IEnumerable<ServiceTypeResponseModel> GetBaseParentAll();

        IEnumerable<ServiceTypeResponseModel> GetChildByParentId(int Id);
    }
}
