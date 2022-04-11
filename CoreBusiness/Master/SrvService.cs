using CoreBusiness.Base;
using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvService:Entity
    {
        public SrvService()
        {
            SrvServiceAddOns = new HashSet<SrvServiceAddOn>();
            SrvServiceClassValues = new HashSet<SrvServiceClassValue>();
            SrvServiceClasses = new HashSet<SrvServiceClass>();
        }

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int CategoryId { get; set; }
        public int ServiceTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
       
        public virtual SrvCategory Category { get; set; }
        public virtual SrvServiceType ServiceType { get; set; }
        public virtual ICollection<SrvServiceAddOn> SrvServiceAddOns { get; set; }
        public virtual ICollection<SrvServiceClassValue> SrvServiceClassValues { get; set; }
        public virtual ICollection<SrvServiceClass> SrvServiceClasses { get; set; }
    }
}
