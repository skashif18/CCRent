using Appo.Server.Features.ServiceClassValue.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using Plugins.DataStore.SQL;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.ServiceClassValue.Service
{
    public class ServiceClassValueService: IServiceClassValueService
    {
        private readonly CarRentContext db;

        private readonly IServiceClassValueRepository repository;

        private readonly IMapper mapper;

        private SrvServiceClassValue dbmodel = new();

        public ServiceClassValueService(IServiceClassValueRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(ServiceClassValueRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceClassValue>(model);
            return repository.Create(dbmodel);
        }

        public ServiceClassValueResponseModel GetById(int Id)
        {
            var _model = repository.GetById(Id);
            return mapper.Map<ServiceClassValueResponseModel>(_model);
        }
        public IEnumerable<ServiceClassValueResponseModel> GetByServiceId(int serviceId)
        {
            var _model = repository.GetByServiceId(serviceId);
            return mapper.Map <IEnumerable<ServiceClassValueResponseModel>> (_model);
        }

        public Response Update(ServiceClassValueRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceClassValue>(model);
            return repository.Update(dbmodel);
        }
        public Response Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
