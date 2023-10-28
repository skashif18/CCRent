using Appo.Server.Features.ServiceClassValue.Model;
using Appo.Server.Features.ServiceCustomer.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using UseCases.DataStorePluginInterfaces.SrvTable;
using UseCases.DataStorePluginInterfaces.SrvTable.Supplier;

namespace Appo.Server.Features.ServiceCustomer.Services
{
    public class ServiceCustomerService: IServiceCustomerService
    {
        private readonly ICustomerRepository repository;

        private readonly IMapper mapper;
        public ServiceCustomerService(ICustomerRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public ServiceCustomerResponseModel GetByServiceEmail(string email)
        {
            var _model = repository.GetByEmail(email);
            return mapper.Map<ServiceCustomerResponseModel>(_model);
        }

        public Response Update(ServiceCustomerRequestModel model)
        {
            var _model = mapper.Map<SrvCustomer>(model);
            var respose = repository.Update(_model);
            return respose;
        }
    }
}
