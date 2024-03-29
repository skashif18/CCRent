﻿using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvQuotationStatus
    {
        public SrvQuotationStatus()
        {
            SrvServiceRequestQuotations = new HashSet<SrvServiceRequestQuotation>();
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
        public string CreationUserName { get; set; }
        public DateTime CreationDate { get; set; }
        public string LastUpdateUserName { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public virtual ICollection<SrvServiceRequestQuotation> SrvServiceRequestQuotations { get; set; }
    }
}
