using Appo.Server.Features.Master.Model;
using System.Collections.Generic;

namespace Appo.Server.Features.Master.Service
{
    public interface IMasterService
    {
        IEnumerable<SrvClassResponseModel> GetClassesWithValues();
    }
}
