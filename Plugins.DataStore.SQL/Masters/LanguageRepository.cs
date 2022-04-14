namespace Plugins.DataStore.SQL.Masters
{
    using CoreBusiness;
    using CoreBusiness.Master;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UseCases.DataStorePluginInterfaces.Masters;
    public  class LanguageRepository: ILanguageRepository
    {
        private readonly CarRentContext db;
        private readonly Response response = new();
        public LanguageRepository(CarRentContext _db)
        => db = _db;
        public Response Create(SysLanguage model)
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

        public IEnumerable<SysLanguage> GetAll()
        => db.SysLanguages;

        public SysLanguage GetById(int id)
        => db.SysLanguages.Where(m => m.Id == id).FirstOrDefault();

        public Response Update(SysLanguage model)
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