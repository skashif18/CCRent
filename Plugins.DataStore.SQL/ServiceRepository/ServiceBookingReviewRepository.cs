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
    public class ServiceBookingReviewRepository : IServiceBookingReviewRepository
    {

        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceBookingReviewRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvServiceBookingReview model)
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
            var _model = db.SrvServiceBookingReviews.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.SrvServiceBookingReviews.Remove(_model);
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

        public SrvServiceBookingReview GetById(int Id)
        => db.SrvServiceBookingReviews.Where(m => m.Id == Id).FirstOrDefault();
        public IEnumerable<SrvServiceBookingReview> GetByServiceBookingId(int serviceBookingId)
        => db.SrvServiceBookingReviews.Where(m => m.ServiceBookingId == serviceBookingId);

        public Response Update(SrvServiceBookingReview model)
        {
            var _model = db.SrvServiceBookingReviews.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.ServiceBookingId = model.ServiceBookingId;
                _model.ReviewValue = model.ReviewValue;
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