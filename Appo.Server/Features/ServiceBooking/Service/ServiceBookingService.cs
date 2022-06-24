using Appo.Server.Features.ServiceAddOn.Service;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.ServiceClassValue.Service
{
    public class ServiceBookingService : IServiceBookingService
    {
        private readonly CarRentContext db;

        private readonly IServiceBookingRepository repository;

        private readonly IMapper mapper;

        private SrvServiceBooking dbmodel = new();

        public ServiceBookingService(IServiceBookingRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(ServiceBookingRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceBooking>(model);
            return repository.Create(dbmodel);
        }

        public ServiceBookingResponseModel GetById(int Id)
        {
            var _model = repository.GetById(Id);
            return mapper.Map<ServiceBookingResponseModel>(_model);
        }
        public IEnumerable<ServiceBookingResponseModel> GetByServiceId(int serviceId)
        {
            var _model = repository.GetByServiceId(serviceId);
            return mapper.Map<IEnumerable<ServiceBookingResponseModel>>(_model);
        }

        public IEnumerable<ServiceBookingResponseModel> GetByCustomerId(int customerId)
        {
            var _model = repository.GetByCustomerId(customerId);
            return mapper.Map<IEnumerable<ServiceBookingResponseModel>>(_model);
        }

        public Response Update(ServiceBookingRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceBooking>(model);
            return repository.Update(dbmodel);
        }

        IEnumerable<ServiceBookingResponseModel> IServiceBookingService.GetByVendorUserName(string username)
        {
            var _model = repository.GetByVendorUserName(username);
            return mapper.Map<IEnumerable<ServiceBookingResponseModel>>(_model);
        }
    }
}
