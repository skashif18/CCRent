using System;
using System.Collections.Generic;

namespace CoreBusiness.Master
{
    public partial class SrvServiceAttachment
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int ServiceTypeAttachmentId { get; set; }
        public string FileUrlpath { get; set; }
        public string ServerLocalPath { get; set; }
        public int FileType { get; set; }
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

        public virtual SrvFileType FileTypeNavigation { get; set; }
        public virtual SrvService Service { get; set; }
        public virtual SrvServiceTypeAttachment ServiceTypeAttachment { get; set; }
    }
}
