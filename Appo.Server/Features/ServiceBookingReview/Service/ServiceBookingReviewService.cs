using Appo.Server.Features.ServiceBookingReview.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.ServiceBookingReview.Service
{
    public class ServiceBookingReviewService: IServiceBookingReviewService
    {
      
        private readonly IServiceBookingReviewRepository repository;

        private readonly IMapper mapper;

        private SrvServiceBookingReview dbmodel = new();

        public ServiceBookingReviewService(IServiceBookingReviewRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public Response Create(ServiceBookingReviewRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceBookingReview>(model);
            return repository.Create(dbmodel);
        }

        public Response Delete(int Id)
        {
            return repository.Delete(Id);
        }

        public ServiceBookingReviewResponseModel GetById(int Id)
        {
            var _model = repository.GetById(Id);
            return mapper.Map<ServiceBookingReviewResponseModel>(_model);
        }

        public IEnumerable<ServiceBookingReviewResponseModel> GetByServiceBookingId(int serviceBookingId)
        {
            var _model = repository.GetByServiceBookingId(serviceBookingId);
            return mapper.Map<IEnumerable<ServiceBookingReviewResponseModel>>(_model);
        }

        public Response Update(ServiceBookingReviewRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceBookingReview>(model);
            return repository.Update(dbmodel);
        }
    }
}
