using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public interface IServiceRepository
    {
        Response Create(SrvService model);
        Response Update(SrvService model);
        Response UpdateLocation(SrvService model);
        IEnumerable<SrvService> GetAll(string email);
        Response Delete(int Id);
        SrvService GetById(int Id);
        IEnumerable<SrvService>GetService();

    }
}
