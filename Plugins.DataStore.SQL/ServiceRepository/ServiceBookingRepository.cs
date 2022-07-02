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
    public class ServiceBookingRepository : IServiceBookingRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceBookingRepository(CarRentContext _db)
        {
            db = _db;
        }


        public Response Create(SrvServiceBooking model)
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

        public Response Cancel(SrvServiceBooking model)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<SrvServiceBooking> GetByCustomerId(int customerId)
         => db.SrvServiceBookings.Where(m => m.CustomerId == customerId);

        public SrvServiceBooking GetById(int Id)
        => db.SrvServiceBookings.Where(m => m.Id == Id).FirstOrDefault();

        public IEnumerable<SrvServiceBooking> GetByServiceId(int serviceId)
        => db.SrvServiceBookings.Where(m => m.ServiceId == serviceId);

        public Response Update(SrvServiceBooking model)
        {
            var _model = db.SrvServiceBookings.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.ServiceId = model.ServiceId;
                _model.CustomerId = model.CustomerId;
                _model.CountryId = model.CountryId;
                _model.CityId = model.CityId;
                _model.GeoCode= model.GeoCode;  
                _model.FromDateTime = model.FromDateTime;
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

        public IEnumerable<SrvServiceBooking> GetByVendorUserName(string username)
        {
            var v = db.SrvServiceBookings
                .Include(m => m.Service)
                .Include(m => m.City)
                .Include(m => m.Country).Where(m => m.Service.CreationUserName == username);
            return v;
        }

        public IEnumerable<SrvServiceBooking> GetByCustomerUserName(string username)
        {
            var v = db.SrvServiceBookings
                .Include(m => m.Service)
                .Include(m => m.City)
                .Include(m => m.Country).Where(m => m.CreationUserName == username);
            return v;
        }
    }
}
