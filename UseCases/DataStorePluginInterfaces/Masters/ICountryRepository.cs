using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICountryRepository
    {
        IEnumerable<Country> GetCountry();
        Response AddCountry(Country country);
        Response UpdateCountry(Country country);
        Response DeleteCountry(int CountryId);
        Country GetCountryById(int CountryId);
    }
}
