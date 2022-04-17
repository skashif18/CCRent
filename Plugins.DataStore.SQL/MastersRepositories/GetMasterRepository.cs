using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Plugins.DataStore.SQL.MastersRepositories
{
    public class GetMasterRepository : IGetMasterRepository
    {
        private readonly CarRentContext db;
        public GetMasterRepository(CarRentContext _db)
        {
            db = _db;
        }

        public IEnumerable<IdNameModel> GetCities()
        => from item in db.SysCities
           select new IdNameModel
           {
               Id = item.Id,
               Name = item.NameEn
           };

        public IEnumerable<IdNameModel> GetGenders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdNameModel> GetLanguages()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdNameModel> GetNationalities()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdNameModel> GetReligions()
        {
            throw new NotImplementedException();
        }
    }
}
