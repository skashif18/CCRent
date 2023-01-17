using CoreBusiness.Master;
using System;

namespace Appo.Server.Features.ServiceRequestQuotation.Model
{
    public class ServiceRequestQuotationRequestModel
    {
        public int Id { get; set; }
        public int ServiceRequestId { get; set; }
        public int ServiceId { get; set; }
        public int SupplierId { get; set; }
        public double Price { get; set; }
        public int QuotationStatusId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
    }
}
