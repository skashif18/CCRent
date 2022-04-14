namespace UseCases.DataStorePluginInterfaces.Masters
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System.Collections.Generic;
    public  interface IGenderRepository
    {
        Response Create(SysGender model);
        Response Update(SysGender model);
        IEnumerable<SysGender> GetAll();
        SysGender GetById(int id);
        Response Delete(int Id);
    }
}
