using System;
using System.Collections.Generic;
using CoreBusiness.Base;
namespace CoreBusiness.Master
{
    public partial class SrvClass : Entity
    {
        public SrvClass()
        {
            SrvClassValues = new HashSet<SrvClassValue>();
            SrvServiceRequestClasses = new HashSet<SrvServiceRequestClass>();
            SrvServiceRequestClassValues = new HashSet<SrvServiceRequestClassValue>();
        }

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }

        public virtual ICollection<SrvServiceRequestClassValue> SrvServiceRequestClassValues { get; set; }
        public virtual ICollection<SrvServiceRequestClass> SrvServiceRequestClasses { get; set; }
        public virtual ICollection<SrvClassValue> SrvClassValues { get; set; }
    }
}
