namespace UseCases.DataStorePluginInterfaces.Masters
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System.Collections.Generic;
    public interface IReligionRepository
    {
        Response Create(SysReligion sysReligion);
        Response Update(SysReligion sysReligion);
        IEnumerable<SysReligion> GetAll();
        SysReligion GetById(int id);
        Response Delete(int Id);
    }
}
