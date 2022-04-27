namespace Appo.Server.Features.Service.Model
{
    public class ServiceRequestModel
    {

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int CategoryId { get; set; }
        public int ServiceTypeId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }
    }
}
