using CoreBusiness.Masters;
using System.Collections.Generic;
namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCity();
        void AddCity(City city);
        void UpdateCity(City city);
        void DeleteCity(int cityId);
        City GetCityById(int cityId);
    }
}
