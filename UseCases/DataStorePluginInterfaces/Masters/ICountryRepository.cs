using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    internal interface ICountryRepository
    {
        IEnumerable<Country> GetCountry();
        Response AddCountry(Country Country);
        Response UpdateCountry(Country Country);
        Response DeleteCountry(int CountryId);
        Country GetCountryById(int CountryId);
    }
}
