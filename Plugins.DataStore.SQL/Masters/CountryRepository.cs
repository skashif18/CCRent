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
    public class CountryRepository : ICountryRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public CountryRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }
        public Response AddCountry(Country country)
        {
            if (country != null)
                try
                {
                    _db.Countries.Add(country);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Country is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteCountry(int CountryId)
        {
            var country = _db.Countries.Find(CountryId);
            if (country == null) return response;
            try
            {
                _db.Countries.Remove(country);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Country is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Country> GetCountry()
        {
            return _db.Countries.ToList();
        }

        public Country GetCountryById(int CountryId)
        {
            return _db.Countries.Find(CountryId);
        }

        public Response UpdateCountry(Country country)
        {
            var ctry = _db.Countries.Find(country.CountryId);
            if (country == null) return response;
            try
            {
                ctry.Name = country.Name;
                ctry.Code = country.Code;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Country is Updated Successfuly";
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
