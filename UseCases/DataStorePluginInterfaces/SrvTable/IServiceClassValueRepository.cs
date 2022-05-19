using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public interface IServiceClassValueRepository
    {

        Response Create(SrvServiceClassValue model);
        Response Update(SrvServiceClassValue model);
        SrvServiceClassValue GetById(int Id);
        IEnumerable<SrvServiceClassValue> GetByServiceId(int serviceId);
        Response Delete(int Id);
    }
}
