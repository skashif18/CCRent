using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public  interface IServiceBookingRepository
    {
        Response Create(SrvServiceBooking model);
        Response Update(SrvServiceBooking model);
        Response Cancel(SrvServiceBooking model);
        SrvServiceBooking GetById(int Id);
        IEnumerable<SrvServiceBooking> GetByServiceId(int serviceId);
        IEnumerable<SrvServiceBooking> GetByCustomerId(int customerId);

    }
}
