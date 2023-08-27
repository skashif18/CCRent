using CoreBusiness.Master;

namespace Appo.Server.Features.ServiceClassValue.Model
{
    public class ServiceClassValueResponseModel
    {

        public int Id { get; set; }


        public int ServiceId { get; set; }
        public int ClassValueId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
        public virtual SrvClassValue ClassValue { get; set; }
    }
}
