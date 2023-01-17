using Appo.Server.Features.ServiceRequest.Model;
using AutoMapper;
using CoreBusiness.Master;
using CoreBusiness;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable;
using Appo.Server.Features.ServiceRequestQuotation.Model;

namespace Appo.Server.Features.ServiceRequestQuotation.Service
{
    public class ServiceRequestQuotationService: IServiceRequestQuotationService
    {
        private readonly IServiceRequestQuotationRepository repository;

        private readonly IMapper mapper;

        private SrvServiceRequestQuotation dbmodel = new();
        public ServiceRequestQuotationService(IServiceRequestQuotationRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<Response> Create(ServiceRequestQuotationRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceRequestQuotation>(model);
            return await repository.Create(dbmodel);
        }

        //public Response Delete(int Id)
        //{
        //    return repository.Delete(Id);
        //}

        //public IEnumerable<ServiceResponseModel> GetAll(string email)
        //{
        //    var list = repository.GetAll(email);
        //    return mapper.Map<IEnumerable<ServiceResponseModel>>(list);
        //}


        public async Task<Response> Update(ServiceRequestQuotationRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceRequestQuotation>(model);
            return await repository.Update(dbmodel);
        }

        public async Task<Response> UpdateStatus(ServiceRequestQuotationStatusModel model)
        {
            return await repository.UpdateStatus(model.Id, model.QuotationStatusId);
        }

        public async Task<object> GetById(int id)
        {
            var list = await repository.GetById(id);
            return list;//mapper.Map<IEnumerable<ServiceRequestQuotationResponseModel>>(list);
        }

        public async Task<object> GetBySupplierId(int suppId)
        {
            var list = await repository.GetBySupplierId(suppId);
            return list;//mapper.Map<IEnumerable<ServiceRequestQuotationResponseModel>>(list);
        }

        public async Task<object> GetBySrvReqId(int srvReqId)
        {
            var list = await repository.GetBySrvReqId(srvReqId);
            return list;//mapper.Map<IEnumerable<ServiceRequestQuotationResponseModel>>(list);
        }

        public async Task<object> GetBySrvId(int srvId)
        {
            var list = await repository.GetBySrvId(srvId);
            return list;//mapper.Map<IEnumerable<ServiceRequestQuotationResponseModel>>(list);
        }
    }
}
