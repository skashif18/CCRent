using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public interface IServiceStatusRepository
    {
        Response Create(SrvServiceStatus model);
        Response Update(SrvServiceStatus model);
        IEnumerable<SrvServiceStatus> GetAll();
        SrvServiceStatus GetById(int id);
        Response Delete(int Id);
    }
}
