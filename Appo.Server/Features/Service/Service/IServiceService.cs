using Appo.Server.Features.Service.Model;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;

namespace Appo.Server.Features.Service.Service
{
    public interface IServiceService
    {
        Response Create(ServiceRequestModel model);
        Response Update(ServiceRequestModel model);
        IEnumerable<ServiceResponseModel> GetAll(string email);
        Response Delete(int Id);
        ServiceResponseModel GetById(int Id);
        IEnumerable<SrvService> GetService();
    }
}
