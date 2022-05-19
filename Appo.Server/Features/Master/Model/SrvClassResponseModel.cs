using CoreBusiness.Master;
using System.Collections.Generic;

namespace Appo.Server.Features.Master.Model
{
    public class SrvClassResponseModel
    {

        public SrvClassResponseModel()
        {
            SrvClassValues = new HashSet<SrvClassValue>();
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

        public virtual ICollection<SrvClassValue> SrvClassValues { get; set; }
    }
}
