using Appo.Server.Features.ServiceType.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Appo.Server.Features.ServiceType.Service
{
    public class ServiceTypeService: IServiceTypeService
    {
        private readonly IServiceTypeRepository repository;

        private readonly IMapper mapper;

        private SrvServiceType category = new();
        public ServiceTypeService(IServiceTypeRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(ServiceTypeRequestModel model)
        {
            category = mapper.Map<SrvServiceType>(model);
            return repository.Create(category);
        }

        public IList<ServiceTypeResponseModel> GetAll()
        {
            var list = repository.GetAll();
            return mapper.Map<IList<ServiceTypeResponseModel>>(list);
        }

        public IEnumerable<ServiceTypeResponseModel> GetBaseParentAll()
        {
            var list = repository.GetBaseParentAll();
            return mapper.Map<IEnumerable<ServiceTypeResponseModel>>(list);
        }
        public string GetChildToParent(int srvTypeId)
        {
            return repository.GetChildToParent(srvTypeId);
        }

        public ServiceTypeResponseModel GetById(int Id)
        {
            var model = repository.GetById(Id);
            return mapper.Map<ServiceTypeResponseModel>(model);
        }

        public IEnumerable<ServiceTypeResponseModel> GetChildByParentId(int Id)
        {
            var list = repository.GetChildByParentId(Id);
            return mapper.Map<IEnumerable<ServiceTypeResponseModel>>(list);
        }

        public Response Update(ServiceTypeRequestModel model)
        {
            category = mapper.Map<SrvServiceType>(model);
            return repository.Update(category);
        }
    }
}
