using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public  interface IServiceBookingRatingRepository
    {
        Response Create(IEnumerable<SrvServiceBookingRating> model);
        Response Update(SrvServiceBookingRating model);

        SrvServiceBookingRating GetById(int Id);

        IEnumerable<SrvServiceBookingRating> GetByServiceBookingId(int serviceId);

        Response Delete(int Id);

        public IEnumerable<SrvServiceBookingRating> GetAll();

    }
}
