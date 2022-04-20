using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public  interface ICategoryRepository
    {
        Response Create(SrvCategory model);

        IList<SrvCategory> GetAll();

        Response Delete(int id);

        Response Update(SrvCategory model);

        SrvCategory GetById(int id);

        IEnumerable<SrvCategory> GetBaseParentAll();

        IEnumerable<SrvCategory> GetChildByParentId(int Id);
    }
}
