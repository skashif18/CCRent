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
    public class CostCenterRepository : ICostCenterRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public CostCenterRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }
        public Response AddCostCenter(CostCenter costCenter)
        {

            if (costCenter != null)
                try
                {
                    _db.CostCenters.Add(costCenter);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Cost Center is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteCostCenter(int CostCenterId)
        {
            var costCenter = _db.CostCenters.Find(CostCenterId);
            if (costCenter == null) return response;
            try
            {
                _db.CostCenters.Remove(costCenter);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Cost Center is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<CostCenter> GetCostCenter()
        {
            return _db.CostCenters.ToList();
        }

        public CostCenter GetCostCenterById(int CostCenterId)
        {
            return _db.CostCenters.Find(CostCenterId);
        }

        public Response UpdateCostCenter(CostCenter costCenter)
        {
            var costC = _db.CostCenters.Find(costCenter.CostCenterId);
            if (costCenter == null) return response;
            try
            {
                costC.Description = costCenter.Description;
                costC.Code = costCenter.Code;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Cost Center is Updated Successfuly";
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
