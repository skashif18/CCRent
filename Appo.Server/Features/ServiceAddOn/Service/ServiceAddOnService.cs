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
    public class ServiceAddOnService : IServiceAddOnService
    {
        private readonly CarRentContext db;

        private readonly IServiceAddOnRepository repository;

        private readonly IMapper mapper;

        private SrvServiceAddOn dbmodel = new();

        public ServiceAddOnService(IServiceAddOnRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(ServiceAddOnRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceAddOn>(model);
            return repository.Create(dbmodel);
        }

        public ServiceAddOnResponseModel GetById(int Id)
        {
            var _model = repository.GetById(Id);
            return mapper.Map<ServiceAddOnResponseModel>(_model);
        }
        public IEnumerable<ServiceAddOnResponseModel> GetByServiceId(int serviceId)
        {
            var _model = repository.GetByServiceId(serviceId);
            return mapper.Map<IEnumerable<ServiceAddOnResponseModel>>(_model);
        }

        public Response Update(ServiceAddOnRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceAddOn>(model);
            return repository.Update(dbmodel);
        }
        public Response Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
