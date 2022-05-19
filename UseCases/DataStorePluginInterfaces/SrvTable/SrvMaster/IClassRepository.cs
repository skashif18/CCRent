using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public  interface IClassRepository
    {
        Response Create(SrvClass model);
        Response Update(SrvClass model);
        IEnumerable<SrvClass> GetAll();
        SrvClass GetById(int id);
        Response Delete(int Id);
        IEnumerable<SrvClass> GetClassesWithValues();
    }
}
