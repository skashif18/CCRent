﻿using CoreBusiness.Base;
using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class ServiceBookingResponseModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int CustomerId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string GeoCode { get; set; }
        public DateTime FromDateTime { get; set; }
        public DateTime ToDateTime { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreationDate { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }

        public virtual SysCity City { get; set; }
        public virtual SysCountry Country { get; set; }
        public virtual SrvCustomer Customer { get; set; }
        public virtual SrvService Service { get; set; }

    }
}
