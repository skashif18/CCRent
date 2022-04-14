namespace UseCases.DataStorePluginInterfaces.Masters
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System.Collections.Generic;
    public  interface ILanguageRepository
    {
        Response Create(SysLanguage model);
        Response Update(SysLanguage model);
        IEnumerable<SysLanguage> GetAll();
        SysLanguage GetById(int id);
        Response Delete(int Id);
    }
}
