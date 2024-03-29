﻿using CoreBusiness.Base;
using CoreBusiness.Master;

namespace Appo.Server.Features.ServiceBookingReview.Model
{
    public class ServiceBookingReviewResponseModel : Entity
    {
        public int Id { get; set; }
        public int ServiceBookingId { get; set; }
        public string ReviewValue { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }

        public virtual SrvServiceTypeEvaluationCriterion Criteria { get; set; }
        public virtual SrvServiceBooking ServiceBooking { get; set; }
    }
}
