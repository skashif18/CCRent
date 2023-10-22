using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public CategoryRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvCategory model)
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

        public IList<SrvCategory> GetAll()
        {
            var v = db.SrvCategories.AsNoTrackingWithIdentityResolution()
                              .Include(category => category.InverseParentCategory).ToList();
            IList<SrvCategory> tree = v.Where(c => c.ParentCategoryId == null)
                                                 .AsParallel()
                                                 .ToList();
            return tree;

        }
        public IEnumerable<SrvCategory> GetBaseParentAll()
            => db.SrvCategories.Where(m => m.ParentCategoryId == null || m.ParentCategoryId == 0);

        public string GetChildToParent(int catId)
        {
            var model = db.SrvCategories;
            string catHie = "";
            int _catId = catId;
            var strList = new List<string>();
            while (true)
            {
                var newModel = model.Where(m => m.Id == _catId).FirstOrDefault();
                if (newModel != null)
                {
                    strList.Add(newModel.NameEn);
                   
                    _catId = newModel.ParentCategoryId?? 0;
                    if(_catId == 0)
                    {
                        break;
                    }
                }
            }
            strList.Reverse();
            foreach(var item in strList)
            {
                catHie = catHie + item;
                if (!strList.Last().Equals(item))
                {
                    catHie = catHie + " " + "> ";
                }
            }
            return catHie;
        }

        public Response GetChildToParentObj(int catId)
        {
            var resp = new Response();
            var model = db.SrvCategories;
            string catHie = "";
            int _catId = catId;
            var strList = new List<string>();
            while (true)
            {
                var newModel = model.Where(m => m.Id == _catId).FirstOrDefault();
                if (newModel != null)
                {
                    strList.Add(newModel.NameEn);

                    _catId = newModel.ParentCategoryId ?? 0;
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
            resp.Objects = catHie;

            return resp;
        }
        public IEnumerable<SrvCategory> GetChildByParentId(int Id)
            => db.SrvCategories.Where(m => m.ParentCategoryId == Id);

        public SrvCategory GetById(int id)
            =>db.SrvCategories.Where((m) => m.Id == id).FirstOrDefault();

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

        private Response HttpNotFound()
        {
            throw new NotImplementedException();
        }

        public Response Update(SrvCategory model)
        {
            var _model = db.SrvCategories.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.NameEn = model.NameEn;
                _model.NameAr = model.NameAr;
                _model.ParentCategoryId = model.ParentCategoryId;
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
