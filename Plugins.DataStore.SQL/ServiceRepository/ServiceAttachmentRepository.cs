using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.SQL.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class ServiceAttachmentRepository : IServiceAttachmentRepository
    {

        private readonly CarRentContext db;
        private readonly Response response = new();
        private readonly ICurrentUserService currentUser;
        public ServiceAttachmentRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvServiceAttachment model)
        {
            try
            {
                db.Add(model);
                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Added Successfully";
                response.Id = model.Id;
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
            var _model = db.SrvServiceAttachments.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.SrvServiceAttachments.Remove(_model);
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

        public SrvServiceAttachment GetById(int Id)
        => db.SrvServiceAttachments.Where(m => m.Id == Id).FirstOrDefault();
        public IEnumerable<SrvServiceAttachment> GetByServiceId(int serviceId)
        => db.SrvServiceAttachments.Where(m => m.ServiceId == serviceId);

        public Response Update(SrvServiceAttachment model)
        {
            var _model = db.SrvServiceAttachments.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.FileUrlpath = model.FileUrlpath;
                _model.ServerLocalPath = model.ServerLocalPath;
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

        public SrvServiceAttachment? CheckDuplicate(int attachmentTypeId, int serviceId, string userName)
        {
            var _check = db.SrvServiceAttachments.Where(m => m.ServiceTypeAttachmentId == attachmentTypeId
            && m.ServiceId == serviceId && m.CreationUserName == userName).FirstOrDefault();
            if(_check != null)
            {
                return _check;
            }
            return null;
        }
    }
}
