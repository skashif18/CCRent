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
        => from item in db.SysGenders
           select new IdNameModel
           {
               Id = item.Id,
               Name = item.NameEn
           };

        public IEnumerable<IdNameModel> GetLanguages()
        => from item in db.SysLanguages
           select new IdNameModel
           {
               Id = item.Id,
               Name = item.NameEn
           };

        public IEnumerable<IdNameModel> GetNationalities()
        => from item in db.SysNationalities
           select new IdNameModel
           {
               Id = item.Id,
               Name = item.NameEn
           };
        public IEnumerable<IdNameModel> GetReligions()
        => from item in db.SysReligions
           select new IdNameModel
           {
               Id = item.Id,
               Name = item.NameEn
           };
    }
}
