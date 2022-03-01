using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGrade();
        Response AddGrade(Grade grade);
        Response UpdateGrade(Grade grade);
        Response DeleteGrade(int gradeId);
        Grade GetGradeById(int gradeId);
    }
}
