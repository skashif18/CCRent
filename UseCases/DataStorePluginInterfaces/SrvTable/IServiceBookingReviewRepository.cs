using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public interface IServiceBookingReviewRepository
    {
        Response Create(SrvServiceBookingReview model);
        Response Update(SrvServiceBookingReview model);

        SrvServiceBookingReview GetById(int Id);

        IEnumerable<SrvServiceBookingReview> GetByServiceBookingId(int ServiceBokkingId);

        Response Delete(int Id);

    }
}
