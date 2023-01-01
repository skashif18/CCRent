using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvServiceRequestClassValue
    {
        public int Id { get; set; }
        public int ServiceRequestId { get; set; }
        public int ClassId { get; set; }
        public int ClassValueId { get; set; }
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

        public virtual SrvClass Class { get; set; }
        public virtual SrvClassValue ClassValue { get; set; }
        public virtual SrvService ServiceRequest { get; set; }
    }
}
