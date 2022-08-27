using System;
using System.Collections.Generic;
using CoreBusiness.Master;

namespace Appo.Server.Features.ServiceEvaluationCriteria.Model
{
    public class ServiceEvaluationCriteriaRequestModel
    {
        public ServiceEvaluationCriteriaRequestModel()
        {
        }

        public int Id { get; set; }
        public int ServiceTypeId { get; set; }
        public string CriteriaEn { get; set; }
        public string CriteriaAr { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
     
    }
}

