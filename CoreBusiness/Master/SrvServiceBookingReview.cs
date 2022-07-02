using CoreBusiness.Base;
using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvServiceBookingReview :Entity
    {
        public int Id { get; set; }
        public int ServiceBookingId { get; set; }
        public int CriteriaId { get; set; }
        public string ReviewValue { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }

        public virtual SrvServiceBooking ServiceBooking { get; set; }
    }
}
