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

        public Response CreateNew(ServiceScheduleNewModel model)
        {
            var resp = new Response();
            try

            {
                var delMode = db.SrvServiceSchedules.Where(m => m.ServiceId == model.SrvId);
                db.RemoveRange(delMode);
                int len = (model.EndtDate - model.StartDate).Days;
                if (model.ScheduleType.ToLower() == "daily")
                {
                    if (len < model.Interval)
                    {
                        resp.Message = "Invalid logic";
                        return resp;
                    }
                    int increment = model.Interval;
                    int i = 0;
                    while (i <= len)
                    {

                        var _model = new SrvServiceSchedule();
                        _model.ServiceId = model.SrvId;
                        _model.FromDatetime = model.StartDate.AddDays(i);
                        _model.ToDateTime = model.StartDate.AddDays(i + 1);
                        db.Add(_model);
                        i = i + increment;


                    }
                }
                else if (model.ScheduleType.ToLower() == "monthly")
                {
                    len = (model.EndtDate - model.StartDate).Days / 30;
                    if (len < model.Interval)
                    {
                        resp.Message = "Invalid logic";
                        return resp;
                    }
                    int increment = model.Interval;
                    int i = 0;
                    var _model = new SrvServiceSchedule();
                    while (i <= len)
                    {

                        _model = new SrvServiceSchedule();
                        _model.ServiceId = model.SrvId;
                        _model.FromDatetime = model.StartDate.AddMonths(i);
                        _model.ToDateTime = _model.FromDatetime.AddDays(1);
                        db.Add(_model);
                        i = i + increment;


                    }
                }
                else if (model.ScheduleType.ToLower() == "weekly")
                {
                    len = (model.EndtDate - model.StartDate).Days / 7;
                    if (len < model.Interval)
                    {
                        resp.Message = "Invalid logic";
                        return resp;
                    }
                    int increment = model.Interval;
                    var _model = new SrvServiceSchedule();
                    int i = 0;
                    while (i <= len)
                    {


                        for (int j = 0; j < 7; j++)
                        {

                            if (model.InvervalDay.Contains(((int)model.StartDate.AddDays((i * 7) + j).DayOfWeek)))
                            {
                                _model = new SrvServiceSchedule();
                                _model.ServiceId = model.SrvId;
                                _model.FromDatetime = model.StartDate.AddDays((i * 7) + j);
                                _model.ToDateTime = _model.FromDatetime.AddDays(1);
                                db.Add(_model);
                            }
                        }
                        i = i + increment;


                    }
                }

                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Added Successfully";
                response.Objects = db.SrvServiceSchedules.Where(m => m.ServiceId == model.SrvId).ToList();
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
