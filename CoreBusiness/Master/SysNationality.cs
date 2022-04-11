using CoreBusiness.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness.Master
{
    public partial class SysNationality :Entity
    {
        public SysNationality()
        {
            SrvCustomers = new HashSet<SrvCustomer>();
            SrvSuppliers = new HashSet<SrvSupplier>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
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
