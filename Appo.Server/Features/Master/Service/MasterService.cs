using Appo.Server.Features.Master.Model;
using AutoMapper;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Appo.Server.Features.Master.Service
{

   
    public class MasterService : IMasterService
    {
        private readonly IClassRepository repository;
        private readonly IMapper mapper;
        public MasterService(IClassRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }
        public IEnumerable<SrvClassResponseModel> GetClassesWithValues()
        {
            var model = repository.GetClassesWithValues();
            return mapper.Map<IEnumerable<SrvClassResponseModel>>(model);
        }
    }
}
