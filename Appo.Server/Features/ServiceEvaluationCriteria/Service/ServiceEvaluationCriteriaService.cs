using System;
using System.Collections.Generic;
using Appo.Server.Features.ServiceEvaluationCriteria.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Appo.Server.Features.ServiceEvaluationCriteria.Service
{
    public class ServiceEvaluationCriteriaService : IServiceEvaluationCriteriaService
    {

        private readonly IServiceTypeEvaluationCriterionRepository repository;

        private readonly IMapper mapper;

        private SrvServiceTypeEvaluationCriterion dbmodel = new();

        public ServiceEvaluationCriteriaService(IServiceTypeEvaluationCriterionRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(ServiceEvaluationCriteriaRequestModel model)
        {
            dbmodel = mapper.Map<SrvServiceTypeEvaluationCriterion>(model);
            return repository.Create(dbmodel);
        }

        public IEnumerable<ServiceEvaluationCriteriaResponseModel> GetByServiceTypeId(int id)
        {
            var _model = repository.GetByServiceTypeId(id);
            return mapper.Map<IEnumerable<ServiceEvaluationCriteriaResponseModel>>(_model);
        }
    }
}

