using Appo.Server.Features.ServiceRequestQuotation.Model;
using CoreBusiness;
using System.Threading.Tasks;

namespace Appo.Server.Features.ServiceRequestQuotation.Service
{
    public interface IServiceRequestQuotationService
    {
        public Task<Response> Create(ServiceRequestQuotationRequestModel model);
        public Task<Response> Update(ServiceRequestQuotationRequestModel model);
        public Task<Response> UpdateStatus(ServiceRequestQuotationStatusModel model);
        public Task<object> GetById(int id);
        public Task<object> GetBySupplierId(int suppId);
        public Task<object> GetBySrvReqId(int srvReqId);
        public Task<object> GetBySrvId(int srvId);
    }
}
