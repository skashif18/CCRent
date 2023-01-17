using CoreBusiness.Master;
using System.Collections.Generic;
using System;

namespace Appo.Server.Features.ServiceRequest.Model
{
    public class ServiceRequestRequestModel
    {

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ServiceTypeId { get; set; }
        public DateTime FromDatetime { get; set; }
        public DateTime ToDateTime { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
    }
}
