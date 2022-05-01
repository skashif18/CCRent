using CoreBusiness;
using CoreBusiness.Master;
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
            var _model = db.SrvServiceAttachment.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.SrvServiceAttachment.Remove(_model);
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
        =>db.SrvServiceAttachment.Where(m=>m.Id ==Id).FirstOrDefault();
        public IEnumerable<SrvServiceAttachment> GetByServiceId(int serviceId)
        => db.SrvServiceAttachment.Where(m => m.ServiceId == serviceId);

        public Response Update(SrvServiceAttachment model)
        {
            var _model = db.SrvServiceAttachment.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.ServiceId = model.ServiceId;
                _model.ServiceTypeAttachmentId = model.ServiceTypeAttachmentId;
                _model.FileUrlpath = model.FileUrlpath;
                _model.ServerLocalPath = model.ServerLocalPath;
                _model.FileType = model.FileType;
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
    }
}
