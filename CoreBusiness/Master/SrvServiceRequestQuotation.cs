using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvServiceRequestQuotation
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
        public string CreationUserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastUpdateUserName { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual SrvQuotationStatus QuotationStatus { get; set; }
        public virtual SrvService Service { get; set; }
        public virtual SrvServiceRequest ServiceRequest { get; set; }
        public virtual SrvSupplier Supplier { get; set; }
    }
}
