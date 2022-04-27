using Appo.Server.Features.Service.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.Service.Service
{
    public class ServiceService: IServiceService
    {
        private readonly IServiceRepository repository;

        private readonly IMapper mapper;

        private SrvService dbmodel = new();
        public ServiceService(IServiceRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(ServiceRequestModel model)
        {
            dbmodel = mapper.Map<SrvService>(model);
            return repository.Create(dbmodel);
        }

        public Response Delete(int Id)
        {
            return repository.Delete(Id);   
        }

        public IEnumerable<ServiceResponseModel> GetAll(string email)
        {
            var list = repository.GetAll(email);
            return mapper.Map<IEnumerable<ServiceResponseModel>>(list);
        }

        public ServiceResponseModel GetById(int Id)
        {
            var model = repository.GetById(Id);
            return mapper.Map<ServiceResponseModel>(model);
        }

        public Response Update(ServiceRequestModel model)
        {
            dbmodel = mapper.Map<SrvService>(model);
            return repository.Update(dbmodel);
        }
    }
}
