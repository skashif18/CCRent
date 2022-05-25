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
    public class ServiceScheduleRepository : IServiceScheduleRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceScheduleRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvServiceSchedule model)
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

        public IEnumerable<SrvServiceSchedule> GetAll()
       => db.SrvServiceSchedules;

        public IEnumerable<SrvServiceSchedule> GetByServiceId(int serviceId)
       => db.SrvServiceSchedules.Where(m => m.ServiceId == serviceId);

        public SrvServiceSchedule GetById(int id)
        => db.SrvServiceSchedules.Where(m => m.Id == id).FirstOrDefault();

        public Response Update(SrvServiceSchedule model)
        {
            var _model = db.SrvServiceSchedules.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.ServiceId = model.ServiceId;
                _model.FromDatetime = model.FromDatetime;
                _model.ToDateTime = model.ToDateTime;
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

        public Response Delete(int Id)
        {
            var _model = db.SrvServiceSchedules.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.SrvServiceSchedules.Remove(_model);
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
    }

}
