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
    public class ServiceClassValueRepository: IServiceClassValueRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceClassValueRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvServiceClassValue model)
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
            var _model = db.SrvServiceClassValues.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.Remove(_model);
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

        public SrvServiceClassValue GetById(int Id)
        => db.SrvServiceClassValues.Where(m => m.Id == Id).FirstOrDefault();
        public IEnumerable<SrvServiceClassValue> GetByServiceId(int serviceId)
        => db.SrvServiceClassValues.Where(m => m.ServiceId == serviceId && m.IsActive == true).Select(m => new SrvServiceClassValue
        {
            Id = m.Id,
            ClassValueId = m.ClassValueId,
            ServiceId = m.ServiceId,
            Note = m.Note,
            ClassValue = new SrvClassValue
            {
                Id = m.ClassValue.Id,
                NameEn = m.ClassValue.NameEn,
                NameAr = m.ClassValue.NameAr,
                ClassId = m.ClassValue.ClassId,
                Class = db.SrvClasses.Where(n => n.Id == m.ClassValue.ClassId)
                        .Select(n => new SrvClass
                        {
                            Id = n.Id,
                            NameEn  =   n.NameEn,
                            NameAr = n.NameAr, 
                        })
                        .FirstOrDefault()
            },
        });

        public Response Update(SrvServiceClassValue model)
        {
            var _model = db.SrvServiceClassValues.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.ServiceId = model.ServiceId;
                _model.ClassValueId = model.ClassValueId;
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