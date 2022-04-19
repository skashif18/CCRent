using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster
{
    public interface IClassValueRepository
    {
        Response Create(SrvClassValue model);
        Response Update(SrvClassValue model);
        IEnumerable<SrvClassValue> GetAll();
        SrvClassValue GetById(int id);
        Response Delete(int Id);
    }
}