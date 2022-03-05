using CoreBusiness;
using CoreBusiness.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.Masters;

namespace Plugins.DataStore.SQL.Masters
{
    public class GradeRepository: IGradeRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public GradeRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddGrade(Grade grade)
        {
            if (grade != null)
                try
                {
                    _db.Grades.Add(grade);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Grade is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteGrade(int GradeId)
        {
            var grade = _db.Grades.Find(GradeId);
            if (grade == null) return response;
            try
            {
                _db.Grades.Remove(grade);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Grade is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Grade> GetGrade()
        {
            return _db.Grades.ToList();
        }

        public Grade GetGradeById(int GradeId)
        {
            return _db.Grades.Find(GradeId);
        }

        public Response UpdateGrade(Grade grade)
        {
            var grd = _db.Grades.Find(grade.GradeId);
            if (grade == null) return response;
            try
            {
                grd.Description = grade.Description;
                grd.Code = grade.Code;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Grade is Updated Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }
    }
}
