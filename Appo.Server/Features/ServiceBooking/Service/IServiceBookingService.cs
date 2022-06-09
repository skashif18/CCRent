using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public interface IServiceBookingService
    {
        Response Create(ServiceBookingRequestModel model);
        Response Update(ServiceBookingRequestModel model);

        ServiceBookingResponseModel GetById(int Id);
        IEnumerable<ServiceBookingResponseModel> GetByServiceId(int serviceId);
        IEnumerable<ServiceBookingResponseModel> GetByCustomerId(int customerId);

    }
}
