﻿using System;
using System.Collections.Generic;
using CoreBusiness.Base;
namespace CoreBusiness.Master
{
    public partial class SysCountry : Entity
    {
        public SysCountry()
        {
            SysCities = new HashSet<SysCity>();
            SrvServiceBookings = new HashSet<SrvServiceBooking>();
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

        public virtual ICollection<SrvServiceBooking> SrvServiceBookings { get; set; }
        public virtual ICollection<SysCity> SysCities { get; set; }
    }
}
