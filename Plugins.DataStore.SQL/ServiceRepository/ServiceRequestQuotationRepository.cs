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
    public class ServiceRequestQuotationRepository: IServiceRequestQuotationRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceRequestQuotationRepository(CarRentContext _db)
        {
            db = _db;
        }

        public async Task<Response> Create(SrvServiceRequestQuotation model)
        {
            try
            {
                db.Add(model);
                await db.SaveChangesAsync();
                response.IsSuccess = true;
            } 
            catch(Exception e)
            {
                response.IsSuccess = false;
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response> Update(SrvServiceRequestQuotation model)
        {
            var _model = db.SrvServiceRequestQuotations.Where(m => m.Id == model.Id).FirstOrDefaultAsync();
            if(_model != null)
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

        public async Task<Response> UpdateStatus(int id, int status)
        {
            var _model = await db.SrvServiceRequestQuotations.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (_model != null)
            {
                try
                {
                    _model.QuotationStatusId = status;
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

        public async Task<Object> GetById(int id)
        {
            var _model = await db.SrvServiceRequestQuotations.Where(m => m.Id == id).Select(m => new
            {
                m.Id,
                m.ServiceRequestId,
                m.ServiceId,
                m.SupplierId,
                m.QuotationStatusId,
                m.Price,
                serviceRequest = db.SrvServiceRequests.Where(n => n.Id == m.ServiceRequestId).Select(n => new
                {
                    n.Id,
                    n.DescriptionEn,
                    n.DescriptionAr,
                    n.CreationDate,
                    n.CreationUserName,
                    n.Note,
                    n.CategoryId,
                    n.ToDateTime,
                    n.FromDatetime,
                }).FirstOrDefault(),
                srvServices = db.SrvServices.Where(p => p.Id == m.ServiceId).Select(p => new
                {
                    p.Id,
                    p.CategoryId,
                    p.ServiceTypeId,
                    p.NameEn,
                    p.NameAr,
                    srvServiceAttachments = db.SrvServiceAttachments.Where(q => q.ServiceId == p.Id).Select(r => new
                    {
                        r.Id,
                        r.ServiceId,
                        r.ServerLocalPath,
                        r.ServiceTypeAttachmentId,
                        r.FileUrlpath,
                        r.FileType,
                    }).ToList(),
                    serviceType = db.SrvServiceTypes.Where(q => q.Id == p.ServiceTypeId).FirstOrDefault(),
                    category = db.SrvCategories.Where(q => q.Id == p.CategoryId).FirstOrDefault(),
                }).FirstOrDefault(),
                supplier = db.SrvSuppliers.Where(q => q.Id == m.SupplierId).FirstOrDefault(),
            }).ToListAsync();
            if (_model != null)
            {
                return _model;
            }
            return new Dictionary<string, dynamic>();
        }

        public async Task<Object> GetBySrvId(int srvId)
        {
            var _model = await db.SrvServiceRequestQuotations.Where(m => m.SupplierId == srvId).Select(m => new
            {
                m.Id,
                m.ServiceRequestId,
                m.ServiceId,
                m.SupplierId,
                m.QuotationStatusId,
                m.Price,
                serviceRequest = db.SrvServiceRequests.Where(n => n.Id == m.ServiceRequestId).Select(n => new
                {
                    n.Id,
                    n.DescriptionEn,
                    n.DescriptionAr,
                    n.CreationDate,
                    n.CreationUserName,
                    n.Note,
                    n.CategoryId,
                    n.ToDateTime,
                    n.FromDatetime,
                }).FirstOrDefault(),
                srvServices = db.SrvServices.Where(p => p.Id == m.ServiceId).Select(p => new
                {
                    p.Id,
                    p.CategoryId,
                    p.ServiceTypeId,
                    p.NameEn,
                    p.NameAr,
                    srvServiceAttachments = db.SrvServiceAttachments.Where(q => q.ServiceId == p.Id).Select(r => new
                    {
                        r.Id,
                        r.ServiceId,
                        r.ServerLocalPath,
                        r.ServiceTypeAttachmentId,
                        r.FileUrlpath,
                        r.FileType,
                    }).ToList(),
                    serviceType = db.SrvServiceTypes.Where(q => q.Id == p.ServiceTypeId).FirstOrDefault(),
                    category = db.SrvCategories.Where(q => q.Id == p.CategoryId).FirstOrDefault(),
                }).FirstOrDefault(),
                supplier = db.SrvSuppliers.Where(q => q.Id == m.SupplierId).FirstOrDefault(),
            }).ToListAsync();
            if (_model != null)
            {
                return _model;
            }
            return new List<Object>();
        }

        public async Task<Object> GetBySrvReqId(int srvReqId)
        {
            var _model = await db.SrvServiceRequestQuotations.Where(m => m.ServiceRequestId == srvReqId).Select(m => new
            {
                m.Id,
                m.ServiceRequestId,
                m.ServiceId,
                m.SupplierId,
                m.QuotationStatusId,
                m.Price,
                serviceRequest = db.SrvServiceRequests.Where(n => n.Id == m.ServiceRequestId).Select(n => new
                {
                    n.Id,
                    n.DescriptionEn,
                    n.DescriptionAr,
                    n.CreationDate,
                    n.CreationUserName,
                    n.Note,
                    n.CategoryId,
                    n.ToDateTime,
                    n.FromDatetime,
                }).FirstOrDefault(),
                srvServices = db.SrvServices.Where(p => p.Id == m.ServiceId).Select(p => new
                {
                    p.Id,
                    p.CategoryId,
                    p.ServiceTypeId,
                    p.NameEn,
                    p.NameAr,
                    srvServiceAttachments = db.SrvServiceAttachments.Where(q => q.ServiceId == p.Id).Select(r => new
                    {
                        r.Id,
                        r.ServiceId,
                        r.ServerLocalPath,
                        r.ServiceTypeAttachmentId,
                        r.FileUrlpath,
                        r.FileType,
                    }).ToList(),
                    serviceType = db.SrvServiceTypes.Where(q => q.Id == p.ServiceTypeId).FirstOrDefault(),
                    category = db.SrvCategories.Where(q => q.Id == p.CategoryId).FirstOrDefault(),
                }).FirstOrDefault(),
                supplier = db.SrvSuppliers.Where(q => q.Id == m.SupplierId).FirstOrDefault(),
            }).ToListAsync();

            if (_model != null)
            {
                return _model;
            }
            return new List<Object>();
        }

        public async Task<Object> GetBySupplierId(int supplierId)
        {
            var _model = await db.SrvServiceRequestQuotations.Where(m => m.SupplierId == supplierId).Select(m => new
            {
                m.Id,
                m.ServiceRequestId,
                m.ServiceId,
                m.SupplierId,
                m.QuotationStatusId,
                m.Price,
                serviceRequest = db.SrvServiceRequests.Where(n => n.Id == m.ServiceRequestId).Select(n => new
                {
                    n.Id,
                    n.DescriptionEn,
                    n.DescriptionAr,
                    n.CreationDate,
                    n.CreationUserName,
                    n.Note,
                    n.CategoryId,
                    n.ToDateTime,
                    n.FromDatetime,
                }).FirstOrDefault(),
                srvServices = db.SrvServices.Where(p => p.Id == m.ServiceId).Select(p => new
                {
                    p.Id,
                    p.CategoryId,
                    p.ServiceTypeId,
                    p.NameEn,
                    p.NameAr,
                    srvServiceAttachments = db.SrvServiceAttachments.Where(q => q.ServiceId == p.Id).Select(r => new
                    {
                        r.Id,
                        r.ServiceId,
                        r.ServerLocalPath,
                        r.ServiceTypeAttachmentId,
                        r.FileUrlpath,
                        r.FileType,
                    }).ToList(),
                    serviceType = db.SrvServiceTypes.Where(q => q.Id == p.ServiceTypeId).FirstOrDefault(),
                    category = db.SrvCategories.Where(q => q.Id == p.CategoryId).FirstOrDefault(),
                }).FirstOrDefault(),
                supplier = db.SrvSuppliers.Where(q => q.Id == m.SupplierId).FirstOrDefault(),
            }).ToListAsync();

            if (_model != null)
            {
                return _model;
            }
            return new List<Object>();
        }
    }
}
