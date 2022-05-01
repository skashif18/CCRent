using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public  interface IServiceTypeAttachmentRepository
    {
        Response Create(SrvServiceTypeAttachment model);

        Response Update(SrvServiceTypeAttachment model);

        Response Delete(int Id);

        IEnumerable<SrvServiceTypeAttachment> GetAll();

        SrvServiceTypeAttachment GetById(int Id);

        IEnumerable<SrvServiceTypeAttachment> GetByServiceTypeId(int Id);

    }
}
