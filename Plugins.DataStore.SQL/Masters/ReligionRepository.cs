using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Plugins.DataStore.SQL.Masters
{
    internal class ReligionRepository : IReligionRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public ReligionRepository(CarRentContext _db)
        => db = _db;

        public Response Create(SysReligion model)
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

        public IEnumerable<SysReligion> GetAll()
        => db.SysReligions;

        public SysReligion GetById(int id)
        => db.SysReligions.Where(m => m.Id == id).FirstOrDefault();

        public Response Update(SysReligion model)
        {
            var _model = db.SysNationalities.Find(model.Id);
            if (model == null)
            {
                #region Updating the field
                _model.NameEn = model.NameEn;
                _model.NameAr = model.NameAr;
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

        public Response Delete(int Id)
        {
            var _model = db.SysNationalities.Find(Id);
            if (_model == null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + Id;
                return response;
            }
            try
            {

                db.SysNationalities.Remove(_model);
                db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Record Deleted Successfully .";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error: " + ex.Message;
            }
            return response;

        }
    }
}
