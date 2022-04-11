using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface INationalityRepository
    {
        Response Create(SysNationality sysNationality);
        Response Update(SysNationality sysNationality);
        IEnumerable<SysNationality> GetAll();
        SysNationality GetById(int id);
    }
}
