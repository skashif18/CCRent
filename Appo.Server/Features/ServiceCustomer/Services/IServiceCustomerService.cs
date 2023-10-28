using Appo.Server.Features.ServiceClassValue.Model;
using Appo.Server.Features.ServiceCustomer.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceCustomer.Services
{
    public interface IServiceCustomerService
    {
        public ServiceCustomerResponseModel GetByServiceEmail(string email);

        public Response Update(ServiceCustomerRequestModel model);
    }
}
