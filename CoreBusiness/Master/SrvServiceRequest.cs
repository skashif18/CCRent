using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvServiceRequest
    {
        public SrvServiceRequest()
        {
            SrvServiceRequestClasses = new HashSet<SrvServiceRequestClass>();
            SrvServiceRequestQuotations = new HashSet<SrvServiceRequestQuotation>();
        }

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
        public string CreationUserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastUpdateUserName { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual SrvCategory Category { get; set; }
        public virtual SrvServiceType ServiceType { get; set; }
        public virtual ICollection<SrvServiceRequestClass> SrvServiceRequestClasses { get; set; }
        public virtual ICollection<SrvServiceRequestQuotation> SrvServiceRequestQuotations { get; set; }
    }
}
