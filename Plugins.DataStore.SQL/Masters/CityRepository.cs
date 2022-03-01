using CoreBusiness;
using CoreBusiness.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Plugins.DataStore.SQL.Masters
{
    public class CityRepository : ICityRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public CityRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }
        public Response AddCity(City city)
        {
            if (city != null)
                try
                {
                    _db.Cities.Add(city);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "City is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteCity(int CityId)
        {
            var city = _db.Cities.Find(CityId);
            if (city == null) return response;
            else
                try
                {
                    _db.Cities.Remove(city);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "City is Removed Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }
            return response;
        }

        public IEnumerable<City> GetCity()
        {
            return _db.Cities.ToList();
        }

        public City GetCityById(int CityId)
        {
            return _db.Cities.Find(CityId);
        }

        public Response UpdateCity(City city)
        {
            var bar = _db.Cities.Find(city.CityId);
            if (city == null) return response;
            try
            {
                bar.Name = city.Name;
                bar.Code = city.Code;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "City is Updated Successfuly";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }

            return response;
        }
    }
}
