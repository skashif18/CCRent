namespace Appo.Server.Features.ServiceSchedule.Service;
using Appo.Server.Features.ServiceSchedule.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable;

public class ServiceScheduleService : IServiceScheduleService
{

    private readonly IServiceScheduleRepository repository;

    private readonly IMapper mapper;

    private SrvServiceSchedule dbmodel = new();

    public ServiceScheduleService(IServiceScheduleRepository _repository, IMapper _mapper)
    {
        repository = _repository;
        mapper = _mapper;
    }

    public Response Create(ServiceScheduleRequestModel model)
    {
        dbmodel = mapper.Map<SrvServiceSchedule>(model);
        return repository.Create(dbmodel);
    }
    public Response CreateNew(ServiceScheduleNewModel model)
    {
        return repository.CreateNew(model);
    }
    public Response Delete(int Id)
    {
        return repository.Delete(Id);
    }

    public ServiceScheduleResponseModel GetById(int Id)
    {
        var _model = repository.GetById(Id);
        return mapper.Map<ServiceScheduleResponseModel>(_model);
    }
    public IEnumerable<ServiceScheduleResponseModel> GetByServiceId(int serviceId)
    {
        var _model = repository.GetByServiceId(serviceId);
        return mapper.Map<IEnumerable<ServiceScheduleResponseModel>>(_model);
    }

    public Response Update(ServiceScheduleRequestModel model)
    {
        dbmodel = mapper.Map<SrvServiceSchedule>(model);
        return repository.Update(dbmodel);
    }
}

