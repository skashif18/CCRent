namespace UseCases.DataStorePluginInterfaces.Masters
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System.Collections.Generic;
    public  interface ICityRepository
    {
        Response Create(SysCity model);
        Response Update(SysCity model);
        IEnumerable<SysCity> GetAll();
        IEnumerable<SysCity> GetCitiesByCountryId(int CountryId);
        SysCity GetById(int id);
        Response Delete(int Id);
    }
}
