using System;
using System.Collections.Generic;
using CoreBusiness.Base;
namespace CoreBusiness.Master
{
    public partial class SrvServiceTypeAttachment : Entity
    {
        public SrvServiceTypeAttachment()
        {
            SrvServiceAttachments = new HashSet<SrvServiceAttachment>();
        }

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int ServiceTypeId { get; set; }
        public bool IsRequired { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
        

        public virtual SrvServiceType ServiceType { get; set; }
        public virtual ICollection<SrvServiceAttachment> SrvServiceAttachments { get; set; }
    }
}
