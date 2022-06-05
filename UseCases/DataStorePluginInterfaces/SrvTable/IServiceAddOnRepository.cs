using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public interface IServiceAddOnRepository
    {
        Response Create(SrvServiceAddOn model);
        Response Update(SrvServiceAddOn model);
        SrvServiceAddOn GetById(int Id);
        IEnumerable<SrvServiceAddOn> GetByServiceId(int serviceId);
        Response Delete(int Id);
    }
}
