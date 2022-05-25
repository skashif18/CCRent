namespace Appo.Server.Features.ServiceSchedule.Service;
using Appo.Server.Features.ServiceSchedule.Model;
using CoreBusiness;
using System.Collections.Generic;
public interface IServiceScheduleService
{
    Response Create(ServiceScheduleRequestModel model);
    Response Update(ServiceScheduleRequestModel model);
    ServiceScheduleResponseModel GetById(int Id);
    IEnumerable<ServiceScheduleResponseModel> GetByServiceId(int serviceId);
    Response Delete(int Id);
}

