using CoreBusiness.Base;
using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SysReligion:Entity
    {
        public SysReligion()
        {
            SrvCustomers = new HashSet<SrvCustomer>();
            SrvSuppliers = new HashSet<SrvSupplier>();
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
        

        public virtual ICollection<SrvCustomer> SrvCustomers { get; set; }
        public virtual ICollection<SrvSupplier> SrvSuppliers { get; set; }
    }
}
