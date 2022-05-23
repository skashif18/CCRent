using System;
using System.Collections.Generic;
using CoreBusiness.Base;
namespace CoreBusiness.Master
{
    public partial class SrvClassValue : Entity
    {
        public SrvClassValue()
        {
            SrvServiceClassValues = new HashSet<SrvServiceClassValue>();
        }

        public int Id { get; set; }
        public int? ClassId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
        

        public virtual SrvClass Class { get; set; }
        public virtual ICollection<SrvServiceClassValue> SrvServiceClassValues { get; set; }
    }
}
