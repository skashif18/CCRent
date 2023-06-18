using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvService model)
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
            var _model = db.SrvServices.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.SrvServices.Remove(_model);
                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record Deleted Successfully .";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;
        }

        public IEnumerable<SrvService> GetAll(string email)
             => db.SrvServices.Where(m => m.CreationUserName.Equals(email)).OrderByDescending(m => m.CreationDate)
            .Include(m => m.SrvServiceAttachments)
            .Include(m => m.SrvServiceClassValues);

        public SrvService GetById(int Id)
        => db.SrvServices.Find(Id);

        public Response Update(SrvService model)
        {
            var _model = db.SrvServices.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.NameEn = model.NameEn;
                _model.NameAr = model.NameAr;
                _model.CategoryId = model.CategoryId;
                _model.ServiceTypeId = model.ServiceTypeId;
                _model.Note = model.Note;
                _model.UserDefined1 = model.UserDefined1;
                _model.UserDefined2 = model.UserDefined2;
                _model.UserDefined3 = model.UserDefined3;
                _model.UserDefined4 = model.UserDefined4;
                _model.IsActive = model.IsActive;
                #endregion
                try
                {
                    db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Updated  Successfully";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error: " + ex.Message;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + model.Id;
            }

            return response;
        }

        public Response UpdateLocation(SrvService model)
        {
            var _model = db.SrvServices.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.UserDefined1 = model.UserDefined1;
                _model.UserDefined2 = model.UserDefined2;
                #endregion
                try
                {
                    db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Updated  Successfully";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error: " + ex.Message;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + model.Id;
            }

            return response;
        }
        public IEnumerable<SrvService> GetService()
        {
            return db.SrvServices
                .Include(m => m.SrvServiceAttachments)
                .Include(m => m.SrvServiceClassValues);
        }
    }
}
