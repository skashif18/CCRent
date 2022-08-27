using System;
using System.Collections.Generic;
using Appo.Server.Features.ServiceEvaluationCriteria.Model;
using CoreBusiness;

namespace Appo.Server.Features.ServiceEvaluationCriteria.Service
{
    public interface IServiceEvaluationCriteriaService
    {
        public IEnumerable<ServiceEvaluationCriteriaResponseModel> GetByServiceTypeId(int id);

        public Response Create(ServiceEvaluationCriteriaRequestModel model);
    }
}

