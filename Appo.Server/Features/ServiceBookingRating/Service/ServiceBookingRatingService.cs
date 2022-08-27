using Appo.Server.Features.ServiceBookingRating.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.ServiceBookingRating.Service
{
    public class ServiceBookingRatingService: IServiceBookingRatingService
    {
      
        private readonly IServiceBookingRatingRepository repository;

        private readonly IMapper mapper;

        private SrvServiceBookingRating dbmodel = new();

        public ServiceBookingRatingService(IServiceBookingRatingRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public Response Create(IEnumerable<ServiceBookingRatingRequestModel> model)
        {
            var _dbmodel = mapper.Map<IEnumerable<SrvServiceBookingRating>>(model);
            return repository.Create(_dbmodel);
        }

        public Response Delete(int Id)
        {
            return repository.Delete(Id);
        }

        public ServiceBookingRatingResponseModel GetById(int Id)
        {
            var _model = repository.GetById(Id);
            return mapper.Map<ServiceBookingRatingResponseModel>(_model);
        }

        public IEnumerable<ServiceBookingRatingResponseModel> GetByServiceBookingId(int serviceBookingId)
        {
            var _model = repository.GetByServiceBookingId(serviceBookingId);
            return mapper.Map<IEnumerable<ServiceBookingRatingResponseModel>>(_model);
        }

        public Response Update(ServiceBookingRatingRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceBookingRating>(model);
            return repository.Update(dbmodel);
        }

        public IEnumerable<ServiceBookingRatingResponseModel> GetAll()
        {
            var _model = repository.GetAll();
            return mapper.Map<IEnumerable<ServiceBookingRatingResponseModel>>(_model);
        }
    }
}
