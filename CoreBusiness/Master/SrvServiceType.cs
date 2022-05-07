using CoreBusiness.Base;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvServiceType:Entity
    {
        public SrvServiceType()
        {
            InverseServiceType = new HashSet<SrvServiceType>();
            SrvServiceTypeAttachments = new HashSet<SrvServiceTypeAttachment>();
            SrvServices = new HashSet<SrvService>();
        }

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int? ServiceTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
        

        public virtual SrvServiceType ServiceType { get; set; }
        public virtual ICollection<SrvServiceType> InverseServiceType { get; set; }
        public virtual ICollection<SrvServiceTypeAttachment> SrvServiceTypeAttachments { get; set; }
        public virtual ICollection<SrvService> SrvServices { get; set; }
    }
}
