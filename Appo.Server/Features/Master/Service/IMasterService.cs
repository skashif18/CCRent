using Appo.Server.Features.Master.Model;
using CoreBusiness.Master;
using System.Collections.Generic;

namespace Appo.Server.Features.Master.Service
{
    public interface IMasterService
    {
        IEnumerable<SrvClassResponseModel> GetClassesWithValues();

        IEnumerable<SysCountry> GetCountries();
        IEnumerable<SysCity> GetCityByCountryId(int id);
    }
}
