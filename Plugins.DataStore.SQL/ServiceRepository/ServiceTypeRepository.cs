using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceTypeRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvServiceType model)
        {
            try
            {
                db.Add(model);
                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Added Successfully";
                response.Objects = model;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }

            return response;
        }

        public IList<SrvServiceType> GetAll()
        {
            var v = db.SrvServiceTypes.AsNoTrackingWithIdentityResolution()
                              .Include(category => category.InverseServiceType).ToList();
            IList<SrvServiceType> tree = v.Where(c => c.ServiceTypeId == null)
                                                 .AsParallel()
                                                 .ToList();
            return tree;

        }
        public IEnumerable<SrvServiceType> GetBaseParentAll()
            => db.SrvServiceTypes.Where(m => m.ServiceTypeId == null || m.ServiceTypeId == 0);

        public string GetChildToParent(int catId)
        {
            var model = db.SrvServiceTypes;
            string catHie = "";
            int _catId = catId;
            var strList = new List<string>();
            while (true)
            {
                var newModel = model.Where(m => m.Id == _catId).FirstOrDefault();
                if (newModel != null)
                {
                    if (!strList.Contains(catHie))
                    {
                        strList.Add(newModel.NameEn);
                    }

                    _catId = newModel.ServiceTypeId ?? 0;
                    if (_catId == 0)
                    {
                        break;
                    }
                }
            }
            strList.Reverse();
            foreach (var item in strList)
            {
                catHie = catHie + item;
                if (!strList.Last().Equals(item))
                {
                    catHie = catHie + " " + "> ";
                }
            }
            return catHie;
        }

        public IEnumerable<SrvServiceType> GetChildByParentId(int Id)
            => db.SrvServiceTypes.Where(m => m.ServiceTypeId == Id);

        public SrvServiceType GetById(int id)
            =>db.SrvServiceTypes.Where((m) => m.Id == id).FirstOrDefault();

        public Response Delete(int id)
        {
            var _model = db.SrvCategories.Find(id);
            if (_model != null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + id;
            }
            try
            {
                db.SrvCategories.Remove(_model);
                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Deleted  Successfully";
            }
            catch
            {
                response.IsSuccess = false;
                response.Message = "Deletion Failed";
            }
            return response;
        }

        public Response Update(SrvServiceType model)
        {
            var _model = db.SrvServiceTypes.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.NameEn = model.NameEn;
                _model.NameAr = model.NameAr;
                _model.ServiceTypeId = model.ServiceTypeId;
                _model.Note = model.Note;
                _model.UserDefined1 = model.UserDefined1;
                _model.UserDefined2 = model.UserDefined2;
                _model.UserDefined3 = model.UserDefined3;
                _model.UserDefined4 = model.UserDefined4;
                _model.IsActive = model.IsActive;
                #endregion
                try
                {
                    db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Updated  Successfully";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error: " + ex.Message;
                }
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + model.Id;
            }

            return response;
        }
    }
}
