using Appo.Server.Features.ServiceBookingRating.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceBookingRating.Service
{
    public interface IServiceBookingRatingService
    {
        Response Create(IEnumerable<ServiceBookingRatingRequestModel> model);
        Response Update(ServiceBookingRatingRequestModel model);

        ServiceBookingRatingResponseModel GetById(int Id);

        IEnumerable<ServiceBookingRatingResponseModel> GetByServiceBookingId(int serviceId);

        Response Delete(int Id);

        public IEnumerable<ServiceBookingRatingResponseModel> GetAll();
    }
}
