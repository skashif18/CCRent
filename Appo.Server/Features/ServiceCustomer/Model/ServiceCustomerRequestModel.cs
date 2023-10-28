using CoreBusiness.Master;
using System.Collections.Generic;
using System;

namespace Appo.Server.Features.ServiceCustomer.Model
{
    public class ServiceCustomerRequestModel
    {
        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string Email { get; set; }
        public string Mobileno { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phoneno { get; set; }
        public int? GenderId { get; set; }
        public int? NationalityId { get; set; }
        public int? ReligionId { get; set; }
        public int? LanguageId { get; set; }
        public int? CityId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }

    }
}
