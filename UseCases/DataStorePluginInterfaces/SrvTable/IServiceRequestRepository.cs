using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.SrvTable
{
    public interface IServiceRequestRepository
    {
        public Task<Response> Create(SrvServiceRequest model);
        public Task<Response> Update(SrvServiceRequest model);
        public Task<Object> GetById(int id);
        public Task<Object> GetByCatId(int catId);
        public Task<Object> GetByUser(string email);
        public Task<Object> GetAll();
        public Task<Object> GetBySrvTypeId(int srvTypeId);
    }
}
