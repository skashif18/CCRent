using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Plugins.DataStore.SQL.Masters
{
    public class NationalityRepository : INationalityRepository
    {
        private readonly CarRentContext db;
        private  Response response = new Response();
        public NationalityRepository(CarRentContext _db)
        {
            db = _db;
           
        }
        public Response Create(SysNationality sysNationality)
        {
            try
            {
                db.Add(sysNationality);
                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Added Successfully";
                response.Objects = sysNationality;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;

        }

        public IEnumerable<SysNationality> GetAll()
        {
            return db.SysNationalities;    
        }

        public SysNationality GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Response Update(SysNationality sysNationality)
        {
            throw new NotImplementedException();
        }
    }
}
