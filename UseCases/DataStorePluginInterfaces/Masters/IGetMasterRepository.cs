using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public  interface IGetMasterRepository
    {

        IEnumerable<IdNameModel> GetGenders();
        IEnumerable<IdNameModel> GetNationalities();
        IEnumerable<IdNameModel> GetReligions();
        IEnumerable<IdNameModel> GetLanguages();
        IEnumerable<IdNameModel> GetCities();


        IEnumerable<IdNameModel> GetClass();
        IEnumerable<IdNameModel> GetValuesByClassId(int Id);
        IEnumerable<IdNameModel> GetAddOn();

    }
}
