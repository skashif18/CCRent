namespace UseCases.DataStorePluginInterfaces.SrvTable.Supplier
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System.Collections.Generic;

    public  interface ISupplierRepository
    {
        Response Create(SrvSupplier model);
        Response Update(SrvSupplier model);
        SrvSupplier GetById(int Id);

        //for admin
        IEnumerable<SrvSupplier> GetSupplierList();
        Response ActivateSuplier(int Id);

    }
}
