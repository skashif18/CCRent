using CoreBusiness.Base;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvFileType : Entity
    {
        public SrvFileType()
        {
            SrvDocuments = new HashSet<SrvDocument>();
            SrvImages = new HashSet<SrvImage>();
            SrvServiceAttachments = new HashSet<SrvServiceAttachment>();
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
        

        public virtual ICollection<SrvDocument> SrvDocuments { get; set; }
        public virtual ICollection<SrvImage> SrvImages { get; set; }
        public virtual ICollection<SrvServiceAttachment> SrvServiceAttachments { get; set; }
    }
}
