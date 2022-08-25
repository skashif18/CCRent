using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public  class ServiceBookingRatingRepository: IServiceBookingRatingRepository
    {

        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceBookingRatingRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvServiceBookingRating model)
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
            var _model = db.SrvServiceBookingRatings.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.SrvServiceBookingRatings.Remove(_model);
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

        public SrvServiceBookingRating GetById(int Id)
        => db.SrvServiceBookingRatings.Where(m => m.Id == Id).FirstOrDefault();
        public IEnumerable<SrvServiceBookingRating> GetByServiceBookingId(int serviceBookingId)
        => db.SrvServiceBookingRatings.Where(m => m.ServiceBookingId == serviceBookingId);

        public Response Update(SrvServiceBookingRating model)
        {
            var _model = db.SrvServiceBookingRatings.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.ServiceBookingId = model.ServiceBookingId;
                _model.CriteriaId = model.CriteriaId;
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