using CoreBusiness.Base;
using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SysCountry:Entity
    {
        public SysCountry()
        {
            SysCities = new HashSet<SysCity>();
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
        

        public virtual ICollection<SysCity> SysCities { get; set; }
    }
}
