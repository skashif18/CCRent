using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public interface IAddOnRepository
    {
        Response Create(SrvAddOn model);
        Response Update(SrvAddOn model);
        IEnumerable<SrvAddOn> GetAll();
        SrvAddOn GetById(int id);
        Response Delete(int Id);
    }
}
