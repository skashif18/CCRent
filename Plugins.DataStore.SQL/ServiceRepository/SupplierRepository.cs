using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable.Supplier;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
       
        public SupplierRepository(CarRentContext _db)
        {
            db = _db;
        }

        public Response Create(SrvSupplier model)
        {
            try
            {
                db.Add(model);
                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Added Successfully";
                response.Objects = model;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public Response Update(SrvSupplier model)
        {
            throw new NotImplementedException();
        }

        public SrvSupplier GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SrvSupplier> GetSupplierList()
        {
            throw new NotImplementedException();
        }
      
        public Response ActivateSuplier(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
