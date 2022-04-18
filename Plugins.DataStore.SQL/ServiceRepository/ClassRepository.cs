using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class ClassRepository : IClassRepository
    {
        private readonly CarRentContext db;
        private readonly Response response;
        public ClassRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvClass model)
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

        public Response Delete(int Id)
        {
            throw new System.NotImplementedException();
        }   

        public IEnumerable<SrvClass> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public SrvClass GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Response Update(SrvClass model)
        {
            throw new System.NotImplementedException();
        }

    }
}
