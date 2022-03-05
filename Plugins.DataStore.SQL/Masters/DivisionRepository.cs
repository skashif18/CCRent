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
    public class DivisionRepository: IDivisionRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public DivisionRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddDivision(Division division)
        {
            if (division != null)
                try
                {
                    _db.Divisions.Add(division);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Division is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteDivision(int DivisionId)
        {

            var division = _db.Divisions.Find(DivisionId);
            if (division == null) return response;
            try
            {
                _db.Divisions.Remove(division);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Division is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Division> GetDivision()
        {
            return _db.Divisions.ToList();
        }

        public Division GetDivisionById(int DivisionId)
        {
            return _db.Divisions.Find(DivisionId);
        }

        public Response UpdateDivision(Division division)
        {
            var div = _db.Divisions.Find(division.DivisionId);
            if (division == null) return response;
            try
            {
                div.Description = division.Description;
                div.ShortDescription = division.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Division is Updated Successfuly";
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
