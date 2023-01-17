using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class ServiceRequestRepository: IServiceRequestRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceRequestRepository(CarRentContext _db)
        {
            db = _db;
        }

        public async Task<Response> Create(SrvServiceRequest model)
        {
            try
            {
                db.Add(model);
                await db.SaveChangesAsync();
                response.IsSuccess = true;
            }
            catch (Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response> Update(SrvServiceRequest model)
        {
            var _model = db.SrvServiceRequests.Where(m => m.Id == model.Id).FirstOrDefaultAsync();
            if (_model != null)
            {
                try
                {
                    db.Add(model);
                    await db.SaveChangesAsync();
                    response.IsSuccess = true;
                }
                catch (Exception e)
                {
                    response.IsSuccess = false;
                    response.Message = e.Message;
                }
                return response;
            }
            else
            {
                response.Message = "Not found";
            }
            return response;
        }

        public async Task<Object> GetByUser(string email)
        {
            var _model = await db.SrvServiceRequests.Where(m => m.CreationUserName == email).Select(m => new
            {
                m.Id,
                m.CategoryId,
                m.DescriptionAr,
                m.DescriptionEn,
                m.CreationDate,
                m.CreationUserName,
                m.ToDateTime,
                quotationCount = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id && n.QuotationStatusId == 1 ).Count(),
                m.FromDatetime,
                m.ServiceTypeId,
                serviceType = db.SrvServiceTypes.Where(n => n.Id == m.ServiceTypeId).FirstOrDefault(),
                category = db.SrvCategories.Where(n => n.Id == m.CategoryId).FirstOrDefault(),
                srvServiceRequestQuotations = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id).Select(n => new
                {
                    n.Id,
                    n.ServiceRequestId,
                    n.ServiceId,
                    n.SupplierId,
                    n.Price,
                    n.QuotationStatusId,
                    n.Note,
                    supplier = db.SrvSuppliers.Where(o => o.Id == n.SupplierId).FirstOrDefault(),
                    service = db.SrvServices.Where(o => o.Id == n.ServiceId).FirstOrDefault()
                }).ToList(),
            }).ToListAsync();
            if (_model != null)
            {
                return _model;
            }
            return new Dictionary<string, dynamic>();
        }
        public async Task<Object> GetById(int id)
        {
            var _model = await db.SrvServiceRequests.Where(m => m.Id == id).Select(m => new
            {
                m.Id,
                m.CategoryId,
                m.DescriptionAr,
                m.DescriptionEn,
                m.CreationDate,
                m.ToDateTime,
                m.FromDatetime,
                m.CreationUserName,
                quotationCount = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id && n.QuotationStatusId == 1).Count(),
                m.ServiceTypeId,
                serviceType = db.SrvServiceTypes.Where(n => n.Id == m.ServiceTypeId).FirstOrDefault(),
                category = db.SrvCategories.Where(n => n.Id == m.CategoryId).FirstOrDefault(),
                srvServiceRequestQuotations = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id).Select(n => new
                {
                    n.Id,
                    n.ServiceRequestId,
                    n.ServiceId,
                    n.SupplierId,
                    n.Price,
                    n.QuotationStatusId,
                    n.Note,
                    supplier = db.SrvSuppliers.Where(o => o.Id == n.SupplierId).FirstOrDefault(),
                    service = db.SrvServices.Where(o => o.Id == n.ServiceId).FirstOrDefault()
                }).ToList(),
            }).FirstOrDefaultAsync();
            if(_model != null)
            {
                return _model;
            }
            return new Dictionary<string, dynamic>();
        }

        public async Task<Object> GetAll()
        {
            try
            {


                var _model = await db.SrvServiceRequests.Where(m => m.Id != 0).Select(m => new
                {
                    m.Id,
                    m.CategoryId,
                    m.DescriptionAr,
                    m.DescriptionEn,
                    m.CreationDate,
                    m.CreationUserName,
                    m.FromDatetime,
                    m.ToDateTime,
                    quotationCount = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id && n.QuotationStatusId == 1).Count(),
                    m.ServiceTypeId,
                    serviceType = db.SrvServiceTypes.Where(n => n.Id == m.ServiceTypeId).FirstOrDefault(),
                    category = db.SrvCategories.Where(n => n.Id == m.CategoryId).FirstOrDefault(),
                    srvServiceRequestQuotations = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id).Select(n => new
                    {
                        n.Id,
                        n.ServiceRequestId,
                        n.ServiceId,
                        n.SupplierId,
                        n.Price,
                        n.QuotationStatusId,
                        n.Note,
                        supplier = db.SrvSuppliers.Where(o => o.Id == n.SupplierId).FirstOrDefault(),
                        service = db.SrvServices.Where(o => o.Id == n.ServiceId).FirstOrDefault()
                    }).ToList(),
                }).ToListAsync();
                if (_model != null)
                {
                    return _model;
                }
            }
            catch (Exception e)
            {

            }
            return new Dictionary<string, dynamic>();
        }

        public async Task<Object> GetByCatId(int catId)
        {
            var _model = await db.SrvServiceRequests.Where(m => m.CategoryId == catId).Select(m => new
            {
                m.Id,
                m.CategoryId,
                m.DescriptionAr,
                m.DescriptionEn,
                m.CreationDate,
                m.CreationUserName,
                m.ToDateTime,
                m.FromDatetime,
                quotationCount = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id && n.QuotationStatusId == 1).Count(),
                serviceType = db.SrvServiceTypes.Where(n => n.Id == m.ServiceTypeId).FirstOrDefault(),
                category = db.SrvCategories.Where(n => n.Id == m.CategoryId).FirstOrDefault(),
                srvServiceRequestQuotations = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id).Select(n => new
                {
                    n.Id,
                    n.ServiceRequestId,
                    n.ServiceId,
                    n.SupplierId,
                    n.Price,
                    n.QuotationStatusId,
                    n.Note,
                    supplier = db.SrvSuppliers.Where(o => o.Id == n.SupplierId).FirstOrDefault(),
                    service = db.SrvServices.Where(o => o.Id == n.ServiceId).FirstOrDefault()
                }).ToList(),
            }).ToListAsync();
            if (_model != null)
            {
                return _model;
            }
            return new Dictionary<string, dynamic>();
        }

        public async Task<Object> GetBySrvTypeId(int srvTypeId)
        {
            var _model = await db.SrvServiceRequests.Where(m => m.ServiceTypeId == srvTypeId).Select(m => new
            {
                m.Id,
                m.CategoryId,
                m.DescriptionAr,
                m.DescriptionEn,
                m.CreationDate,
                m.CreationUserName,
                m.ToDateTime,
                m.FromDatetime,
                quotationCount = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id && n.QuotationStatusId == 1).Count(),
                serviceType = db.SrvServiceTypes.Where(n => n.Id == m.ServiceTypeId).FirstOrDefault(),
                category = db.SrvCategories.Where(n => n.Id == m.CategoryId).FirstOrDefault(),
                srvServiceRequestQuotations = db.SrvServiceRequestQuotations.Where(n => n.ServiceRequestId == m.Id).Select(n => new
                {
                    n.Id,
                    n.ServiceRequestId,
                    n.ServiceId,
                    n.SupplierId,
                    n.Price,
                    n.QuotationStatusId,
                    n.Note,
                    supplier = db.SrvSuppliers.Where(o => o.Id == n.SupplierId).FirstOrDefault(),
                    service = db.SrvServices.Where(o => o.Id == n.ServiceId).FirstOrDefault()
                }).ToList(),
            }).ToListAsync();

            if (_model != null)
            {
                return _model;
            }
            return new Dictionary<string, dynamic>();
        }

    }
}
