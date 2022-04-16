
namespace UseCases.DataStorePluginInterfaces.SrvTable.Supplier
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System;
    using System.Collections.Generic;
    public interface ICustomerRepository
    {
        Response Create(SrvCustomer model);
        Response Update(SrvCustomer model);
        SrvCustomer GetById(int Id);

        //for admin
        IEnumerable<SrvCustomer> GetSupplierList();
        Response ActivateSuplier(int Id);
    }
}
