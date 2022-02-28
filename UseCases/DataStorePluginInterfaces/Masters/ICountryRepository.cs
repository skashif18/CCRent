using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    internal interface ICountryRepository
    {
        IEnumerable<Country> GetCountry();
        void AddCountry(Country Country);
        void UpdateCountry(Country Country);
        void DeleteCountry(int CountryId);
        Country GetCountryById(int CountryId);
    }
}
