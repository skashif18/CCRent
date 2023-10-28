using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        private readonly ICategoryRepository categoryRepository;
        public ServiceRepository(CarRentContext _db, ICategoryRepository _categoryRepository)
        {
            db = _db;
            categoryRepository = _categoryRepository;
        }
        public Response Create(SrvService model)
        {
            try
            {
                model.IsActive = false;
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
                _model.IsActive = false;
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
             => db.SrvServices.Where(m => m.CreationUserName.Equals(email))
            .Include(m=>m.SrvServiceAttachments).OrderByDescending(m => m.CreationDate);

        public Response Toggle(bool val ,int id, String?reason)
        {
            var model = db.SrvServices.Find(id);
            if (model != null)
            {
                #region Updating the field
                model.IsActive = val;
                if(val == false)
                {
                    model.UserDefined3 = reason;
                }
                else
                {
                    model.UserDefined3 = "";
                }
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
            var y = db.SrvServices.Where(m => m.IsActive != false)
                .Include(m => m.SrvServiceAttachments)
                .Include(m => m.SrvServiceBookings)
                .Select(m => new SrvServiceResponse
                {
                    Id = m.Id,
                    CategoryId = m.CategoryId,
                    ServiceTypeId = m.ServiceTypeId,
                    NameAr = m.NameAr,
                    NameEn = m.NameEn,
                    UserDefined1 = m.UserDefined1,
                    UserDefined2 = m.UserDefined2,
                    UserDefined3 = m.UserDefined3,
                    IsActive = m.IsActive,
                    SrvServiceAttachments =new List<SrvServiceAttachment> 
                    {
                        m.SrvServiceAttachments.Select(n => new SrvServiceAttachment {
                            Id = n.Id,
                            ServerLocalPath = n.ServerLocalPath,
                            FileType = n.FileType,
                            FileUrlpath = n.FileUrlpath,
                            ServiceTypeAttachmentId = n.ServiceTypeAttachmentId,
                            ServiceId = n.ServiceId,
                            IsActive = n.IsActive,
                        }).FirstOrDefault() 
                    },
                    ReviewNum = m.SrvServiceBookings
                    .Where(n => n.ServiceId == m.Id).Select(n => new
                    {
                        Ratings = n.SrvServiceBookingReviews.Select(t => t.Id).Count(), //== 0? new List<int> { 0 }.Sum() : n.SrvServiceBookingRatings.Select(t => t.RatingValue).Sum()

                    }).Select(t => t.Ratings).FirstOrDefault(),

                    AvgRating = m.SrvServiceBookings
                    .Where(n => n.ServiceId == m.Id).Select(n => new
                    {
                        Ratings = n.SrvServiceBookingRatings.Select(t => t.RatingValue).Average(), //== 0? new List<int> { 0 }.Sum() : n.SrvServiceBookingRatings.Select(t => t.RatingValue).Sum()

                    }).Select(t => t.Ratings).FirstOrDefault(),

                    CategoryHie = categoryRepository.GetChildToParentNoDb(m.CategoryId,db.SrvCategories.Where(t => t.Id != 0).AsParallel())
                }).AsParallel().ToList();
            return y;
        }
        public IEnumerable<SrvService> GetServiceAdmin()
        {
            return db.SrvServices
                .Include(m => m.SrvServiceAttachments)
                .Include(m => m.SrvServiceClassValues);
        }
    }
}
