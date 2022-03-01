using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;
namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCity();
        Response AddCity(City city);
        Response UpdateCity(City city);
        Response DeleteCity(int cityId);
        City GetCityById(int cityId);
    }
}
