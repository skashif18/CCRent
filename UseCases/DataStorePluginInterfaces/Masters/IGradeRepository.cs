using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IGradeRepository
    {
        IEnumerable<Grade> GetGrade();
        void AddGrade(Grade grade);
        void UpdateGrade(Grade grade);
        void DeleteGrade(int gradeId);
        Grade GetGradeById(int gradeId);
    }
}
