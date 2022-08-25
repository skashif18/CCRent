using CoreBusiness;
using CoreBusiness.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Plugins.DataStore.SQL.ServiceRepository
{
    public class ServiceTypeEvaluationCriterionRepository: IServiceTypeEvaluationCriterionRepository
    {

        private readonly CarRentContext db;
        private readonly Response response = new();
        public ServiceTypeEvaluationCriterionRepository(CarRentContext _db)
        {
            db = _db;
        }
        public Response Create(SrvServiceTypeEvaluationCriterion model)
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

        public IEnumerable<SrvServiceTypeEvaluationCriterion> GetAll()
        {
            return db.SrvServiceTypeEvaluationCriteria;
        }
       
        public SrvServiceTypeEvaluationCriterion GetById(int id)
            => db.SrvServiceTypeEvaluationCriteria.Where((m) => m.Id == id).FirstOrDefault();

        public Response Delete(int id)
        {
            var _model = db.SrvServiceTypeEvaluationCriteria.Find(id);
            if (_model != null)
            {
                response.IsSuccess = false;
                response.Message = "Error: Data not found with this Id:  - " + id;
            }
            try
            {
                db.SrvServiceTypeEvaluationCriteria.Remove(_model);
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

        public Response Update(SrvServiceTypeEvaluationCriterion model)
        {
            var _model = db.SrvServiceTypeEvaluationCriteria.Find(model.Id);
            if (model != null)
            {
                #region Updating the field
                _model.CriteriaEn = model.CriteriaEn;
                _model.CriteriaAr = model.CriteriaAr;
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

        public IEnumerable<SrvServiceTypeEvaluationCriterion> GetByServiceTypeId(int id)
        {
           return db.SrvServiceTypeEvaluationCriteria.Where(model=>model.ServiceTypeId == id);
        }
    }
}