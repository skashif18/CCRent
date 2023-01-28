using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public  interface IServiceAttachmentRepository
    {
        Response Create(SrvServiceAttachment model);
        Response Update(SrvServiceAttachment model);

        SrvServiceAttachment GetById(int Id);

        IEnumerable<SrvServiceAttachment> GetByServiceId(int serviceId);

        Response Delete(int Id);
       bool CheckDuplicate(int attachmentTypeId, int _attachmentTypeId, string userName);

    }
}
