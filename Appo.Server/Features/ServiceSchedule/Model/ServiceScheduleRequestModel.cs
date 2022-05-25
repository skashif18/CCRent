namespace Appo.Server.Features.ServiceSchedule.Model;
using System;
public class ServiceScheduleRequestModel
{
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public DateTime FromDatetime { get; set; }
    public DateTime ToDateTime { get; set; }
    public bool? IsActive { get; set; }
    public string Note { get; set; }
    public string UserDefined1 { get; set; }
    public string UserDefined2 { get; set; }
    public string UserDefined3 { get; set; }
    public string UserDefined4 { get; set; }
}

