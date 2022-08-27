using Appo.Server.Features.ServiceBookingReview.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.ServiceBookingReview.Service
{
    public interface IServiceBookingReviewService
    {
        Response Create(ServiceBookingReviewRequestModel model);
        Response Update(ServiceBookingReviewRequestModel model);

        ServiceBookingReviewResponseModel GetById(int Id);

        IEnumerable<ServiceBookingReviewResponseModel> GetByServiceBookingId(int serviceId);

        Response Delete(int Id);
    }
}
