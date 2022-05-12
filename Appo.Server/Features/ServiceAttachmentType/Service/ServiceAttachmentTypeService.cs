using Appo.Server.Features.ServiceAttachmentType.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Appo.Server.Features.ServiceAttachmentType.Service
{
    public class ServiceAttachmentTypeService : IServiceAttachmentTypeService
    {
       
        private readonly IServiceTypeAttachmentRepository repository;

        private readonly IMapper mapper;

        private SrvServiceAttachment dbmodel = new();
       
        public ServiceAttachmentTypeService(IServiceTypeAttachmentRepository _repository, IMapper _mapper)
        { 
            repository = _repository;
            mapper = _mapper;
        }


        public ServiceAttachmentTypeResponseModel GetById(int Id)
        {
            var model = repository.GetById(Id);
            return mapper.Map<ServiceAttachmentTypeResponseModel>(model);
        }

        public IEnumerable<ServiceAttachmentTypeResponseModel> GetByServiceTypeId(int serviceId)
        {
            var list = repository.GetByServiceTypeId(serviceId);
            return mapper.Map<IEnumerable<ServiceAttachmentTypeResponseModel>>(list);
        }
    }
}
