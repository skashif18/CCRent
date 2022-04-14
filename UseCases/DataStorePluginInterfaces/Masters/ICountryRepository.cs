namespace UseCases.DataStorePluginInterfaces.Masters
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System.Collections.Generic;
    public  interface ICountryRepository
    {
        Response Create(SysCountry model);
        Response Update(SysCountry model);
        IEnumerable<SysCountry> GetAll();
        SysCountry GetById(int id);
        Response Delete(int Id);
    }
}
