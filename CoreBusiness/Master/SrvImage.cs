using CoreBusiness.Base;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvImage :Entity 
    {
        public SrvImage()
        {
            SrvAddOns = new HashSet<SrvAddOn>();
            SrvServiceAddOns = new HashSet<SrvServiceAddOn>();
        }

        public int Id { get; set; }
        public string FileUrlpath { get; set; }
        public string ServerLocalPath { get; set; }
        public int FileType { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }

        public virtual SrvFileType FileTypeNavigation { get; set; }
        public virtual ICollection<SrvAddOn> SrvAddOns { get; set; }
        public virtual ICollection<SrvServiceAddOn> SrvServiceAddOns { get; set; }
    }
}
