namespace UseCases.DataStorePluginInterfaces.Masters
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System.Collections.Generic;
    public interface INationalityRepository
    {
        Response Create(SysNationality sysNationality);
        Response Update(SysNationality sysNationality);
        IEnumerable<SysNationality> GetAll();
        SysNationality GetById(int id);
        Response Delete(int Id);
    }
}
