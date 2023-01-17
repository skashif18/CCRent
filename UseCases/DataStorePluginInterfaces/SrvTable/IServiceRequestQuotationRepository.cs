using CoreBusiness.Master;
using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public interface IServiceRequestQuotationRepository
    {
        public Task<Response> Create(SrvServiceRequestQuotation model);
        public Task<Response> Update(SrvServiceRequestQuotation model);
        public Task<Response> UpdateStatus(int id, int status);
        public Task<Object> GetById(int id);
        public Task<Object> GetBySrvId(int srvId);
        public Task<Object> GetBySrvReqId(int srvTypeId);
        public Task<Object> GetBySupplierId(int supplierId);
    }
}
