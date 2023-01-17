using Appo.Server.Features.ServiceRequest.Model;
using CoreBusiness;
using System;
using System.Threading.Tasks;

namespace Appo.Server.Features.ServiceRequest.Service
{
    public interface IServiceRequestService
    {
        public Task<Response> Create(ServiceRequestRequestModel model);
        public Task<Response> Update(ServiceRequestRequestModel model);
        public Task<object> GetById(int id);
        public Task<object> GetByCatId(int catId);
        public Task<Object> GetByUser(string email);
        public Task<Object> GetAll();
        public Task<object> GetBySrvTypeId(int srvTypeId);
    }
}
