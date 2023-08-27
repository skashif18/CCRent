using Appo.Server.Features.ServiceClassValue.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceClassValue.Service
{
    public interface IServiceClassValueService
    {
        public Response Create(ServiceClassValueRequestModel model);

        public ServiceClassValueResponseModel GetById(int Id);

        public IEnumerable<ServiceClassValueResponseModel> GetByServiceId(int serviceId);

        public Response Update(ServiceClassValueRequestModel model);
        Response Delete(int id);
    }
}
