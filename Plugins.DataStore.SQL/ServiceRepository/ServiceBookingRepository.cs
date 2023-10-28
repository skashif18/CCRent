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
    public class ServiceBookingRepository : IServiceBookingRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        private readonly ICurrentUserService currentUserService;
        private readonly IServiceScheduleRepository serviceScheduleRepository;
        public ServiceBookingRepository(CarRentContext _db, IServiceScheduleRepository serviceScheduleRepository)
        {
            db = _db;
            this.serviceScheduleRepository = serviceScheduleRepository;
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
        {
            return db.SrvServiceBookings.Where(m => m.CustomerId == customerId);
        }

        public IEnumerable<SrvServiceBooking> GetByCustomerEmail(string customerEmail)
        {
            var email = db.SrvCustomers.Where(m => m.Email == customerEmail).FirstOrDefault();
            int custId = 0;
            if (email != null)
            {
                custId = email.Id;

                var v = db.SrvServiceBookings
                    .Where(m => m.CustomerId == custId)
                    .Include(m => m.Service).ThenInclude(m => m.SrvServiceAttachments)
                    .Include(m => m.City)
                    .Include(m => m.Country).Select(n => new SrvServiceBooking
                    {
                        Id = n.Id,
                        City = new SysCity
                        {
                            Id = n.City.Id,
                            NameEn = n.City.NameEn,
                            NameAr = n.City.NameAr,
                        },
                        CityId = n.CityId,
                        Country = new SysCountry 
                        { 
                            Id = n.Country.Id,
                            NameEn = n.Country.NameEn,
                            NameAr = n.Country.NameAr,
                        },

                        CountryId = n.CountryId,
                        FromDateTime = n.FromDateTime,
                        ToDateTime = n.ToDateTime,
                        ServiceId = n.ServiceId,
                        UserDefined1 = n.UserDefined1,
                        UserDefined2 = n.UserDefined2,
                        CreationDate = n.CreationDate,
                        LastUpdateDate = n.LastUpdateDate,
                    
                        Service = new SrvService
                        {
                            Id = n.Service.Id,
                            NameEn = n.Service.NameEn,
                            NameAr = n.Service.NameAr,
                            SrvServiceAttachments = new List<SrvServiceAttachment>() 
                            {
                                n.Service.SrvServiceAttachments.Select(m => new SrvServiceAttachment
                                {
                                    Id = m.Id,
                                    FileType   = m.FileType,
                                    FileUrlpath = m.FileUrlpath,
                                    ServiceId = m.ServiceId,
                                    ServerLocalPath = m.ServerLocalPath,
                                    ServiceTypeAttachmentId = m.ServiceTypeAttachmentId,

                                }).FirstOrDefault()
                            }
                        }
                    });
                return v;
            }
            return new List<SrvServiceBooking>();
        }

        public SrvServiceBooking GetById(int Id)
        => db.SrvServiceBookings.Where(m => m.Id == Id).FirstOrDefault();

        public IEnumerable<SrvServiceBooking> GetByServiceId(int serviceId)
        => db.SrvServiceBookings.Where(m => m.ServiceId == serviceId).Select(n => new SrvServiceBooking
        {
            Id = n.Id,
            City = n.City,
            CityId = n.CityId,
            Country = n.Country,
            CountryId = n.CountryId,
            FromDateTime = n.FromDateTime,
            ToDateTime = n.ToDateTime,
            ServiceId = serviceId,
            UserDefined1 = n.UserDefined1,
        });

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
                .Include(m => m.Service).ThenInclude(m=>m.SrvServiceAttachments)
                .Include(m => m.City)
                .Include(m => m.Country).Where(m => m.CreationUserName == username).Select(n => new SrvServiceBooking
                {
                    Id = n.Id,
                    City = n.City,
                    CityId = n.CityId,
                    Country = n.Country,
                    CountryId = n.CountryId,
                    FromDateTime = n.FromDateTime,
                    ToDateTime = n.ToDateTime,
                    ServiceId = n.ServiceId,
                    UserDefined1 = n.UserDefined1,
                });
            return v;
        }

        public AvailableDateTimeResponseModel GetBookingDates(int srvId)
        {
            var model = serviceScheduleRepository.GetByServiceId(srvId);
            var bookedModel = db.SrvServiceBookings.Where(m => m.ServiceId == srvId);
            var allFromDate = bookedModel.Select(m => new{ 
                fromDate =  m.FromDateTime.Date,
                toDate = m.ToDateTime.Date
            }).ToList();
            var bookedDates = new List<DateTime>();
            foreach (var date in allFromDate)
            {
                var startDate = date.fromDate;
                while (startDate != date.toDate)
                {
                    bookedDates.Add(startDate);
                    startDate = startDate.AddDays(1);
                }
                bookedDates.Add(date.toDate);
            }
            var allToDate = bookedModel.Select(m => m.ToDateTime.Date).ToList();

            var availableFromDate = model.Where(m => !bookedDates.Contains(m.FromDatetime) && !bookedDates.Contains(m.ToDateTime)
                && (m.FromDatetime.Date >= DateTime.Now.Date) && (m.ToDateTime.Date >= DateTime.Now.Date)
            )
                .Select(m => new
                {
                    fromDate = m.FromDatetime.Date,
                    toDate = m.ToDateTime.Date
                }
                ).ToList();

            var response = new AvailableDateTimeResponseModel
            {
                FromDateTime = availableFromDate.Select(m => m.fromDate).ToList(),
                ToDateTime = availableFromDate.Where(m => !availableFromDate.Select(m => m.fromDate).ToList().Contains(m.toDate)).Select(m => m.toDate).ToList(),
            };
            var listOfDate = response.FromDateTime.Concat(response.ToDateTime).ToList();
            return new AvailableDateTimeResponseModel
            {
                FromDateTime = listOfDate,
                ToDateTime = listOfDate
            }; ;
        }
    }
}
