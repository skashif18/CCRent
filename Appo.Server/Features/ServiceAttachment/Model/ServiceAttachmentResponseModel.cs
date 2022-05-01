namespace Appo.Server.Features.ServiceAttachment.Model
{
    public class ServiceAttachmentResponseModel
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
    }
}
