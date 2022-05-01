using Appo.Server.Features.ServiceAttachment.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Appo.Server.Features.ServiceAttachment.Service
{
    public class ServiceAttachmentService : IServiceAttachmentService
    {

        private readonly IServiceAttachmentRepository repository;

        private readonly IMapper mapper;

        private SrvServiceAttachment dbmodel = new();

        public ServiceAttachmentService(IServiceAttachmentRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(ServiceAttachmentRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceAttachment>(model);
            return repository.Create(dbmodel);
        }

        public Response Delete(int Id)
        {
            return repository.Delete(Id);
        }

        public ServiceAttachmentResponseModel GetById(int Id)
        {
            var model = repository.GetById(Id);
            return mapper.Map<ServiceAttachmentResponseModel>(model);
        }

        public IEnumerable<ServiceAttachmentResponseModel> GetByServiceId(int serviceId)
        {
            var model = repository.GetByServiceId(serviceId);
            return mapper.Map<IEnumerable<ServiceAttachmentResponseModel>>(model);
        }

        public Response Update(ServiceAttachmentRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceAttachment>(model);
            return repository.Create(dbmodel);
        }
    }
}
