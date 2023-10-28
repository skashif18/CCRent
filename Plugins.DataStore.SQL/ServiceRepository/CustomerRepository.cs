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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();

        public CustomerRepository(CarRentContext _db)
        {
            db = _db;
        }

        public Response Create(SrvCustomer model)
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

        public Response Update(SrvCustomer model)
        {
            throw new NotImplementedException();
        }

        public SrvCustomer GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public SrvCustomer GetByEmail(string email)
        {
            var model = db.SrvCustomers.Where(m => m.Email == email).FirstOrDefault();
            return model;
        }

        public IEnumerable<SrvCustomer> GetSupplierList()
        {
            throw new NotImplementedException();
        }

        public Response ActivateSuplier(int Id)
        {
            throw new NotImplementedException();
        }

    }
}
