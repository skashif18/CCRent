using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public  interface IServiceTypeRepository
    {
        Response Create(SrvServiceType model);

        IList<SrvServiceType> GetAll();
        string GetChildToParent(int catId);

        Response Delete(int id);

        Response Update(SrvServiceType model);

        SrvServiceType GetById(int id);

        IEnumerable<SrvServiceType> GetBaseParentAll();

        IEnumerable<SrvServiceType> GetChildByParentId(int Id);
    }
}
