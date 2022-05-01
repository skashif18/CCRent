using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public  interface IServiceScheduleRepository
    {
        Response Create(SrvServiceSchedule model);
        Response Update(SrvServiceSchedule model);
        SrvServiceSchedule GetById(int Id);
        IEnumerable<SrvServiceSchedule> GetByServiceId(int serviceId);
        Response Delete(int Id);
    }
}
