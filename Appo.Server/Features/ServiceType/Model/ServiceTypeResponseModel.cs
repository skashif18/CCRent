using System.Collections.Generic;

namespace Appo.Server.Features.ServiceType.Model
{
    public class ServiceTypeResponseModel
    {
        public ServiceTypeResponseModel()
        {
            InverseServiceType = new HashSet<ServiceTypeResponseModel>();
           
        }

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int? ServiceTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }


        public virtual ServiceTypeResponseModel ServiceType { get; set; }
        public virtual ICollection<ServiceTypeResponseModel> InverseServiceType { get; set; }
    }
}
