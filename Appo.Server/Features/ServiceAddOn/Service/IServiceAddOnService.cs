using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceAddOn.Service
{
    public interface IServiceAddOnService
    {
        public Response Create(ServiceAddOnRequestModel model);

        public ServiceAddOnResponseModel GetById(int Id);

        public IEnumerable<ServiceAddOnResponseModel> GetByServiceId(int serviceId);

        public Response Update(ServiceAddOnRequestModel model);
    }
}
