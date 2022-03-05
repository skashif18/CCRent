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
    public class DesignationRepository : IDesignationRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public DesignationRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddDesignation(Designation designation)
        {
            if (designation != null)
                try
                {
                    _db.Designations.Add(designation);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Designation is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteDesignation(int DesignationId)
        {
            var designation = _db.Designations.Find(DesignationId);
            if (designation == null) return response;
            try
            {
                _db.Designations.Remove(designation);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Designation is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Designation> GetDesignation()
        {
            return _db.Designations.ToList();
        }

        public Designation GetDesignationById(int DesignationId)
        {
            return _db.Designations.Find(DesignationId);
        }
        public Response UpdateDesignation(Designation designation)
        {
            var des = _db.Designations.Find(designation.DesignationId);
            if (designation == null) return response;
            try
            {
                des.Description = designation.Description;
                des.ShortDescription = designation.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Designation is Updated Successfuly";
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
