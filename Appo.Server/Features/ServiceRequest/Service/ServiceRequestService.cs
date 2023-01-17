using Appo.Server.Features.Service.Model;
using AutoMapper;
using CoreBusiness.Master;
using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;
using Appo.Server.Features.ServiceRequest.Model;
using System.Threading.Tasks;
using System;

namespace Appo.Server.Features.ServiceRequest.Service
{
    public class ServiceRequestService: IServiceRequestService
    {
        private readonly IServiceRequestRepository repository;

        private readonly IMapper mapper;

        private SrvServiceRequest dbmodel = new();
        public ServiceRequestService(IServiceRequestRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public async Task<Response> Create(ServiceRequestRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceRequest>(model);
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


        public async Task<Response> Update(ServiceRequestRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceRequest>(model);
            return await repository.Update(dbmodel);
        }

        public async Task<object> GetById(int id)
        {
            var list = await repository.GetById(id);
            return mapper.Map<IEnumerable<ServiceRequestResponseModel>>(list);
        }

        public async Task<object> GetByUser(string email)
        {
            var list = await repository.GetByUser(email);
            return list;
        }

        public async Task<object> GetByCatId(int catId)
        {   var list = await repository.GetByCatId(catId);
            return list;
        }

        public async Task<object> GetBySrvTypeId(int srvTypeId)
        {
            var list = await repository.GetBySrvTypeId(srvTypeId);
            return list;
        }

        public async Task<object> GetAll()
        {
            var list = await repository.GetAll();
            try
            {
            return list;

            } 
            catch(Exception e)
            {
                return mapper.Map<IEnumerable<ServiceRequestResponseModel>>(list);
            }
        }
    }
}
