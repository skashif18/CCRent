using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ISubDepartmentRepository
    {
        IEnumerable<SubDepartment> GetSubDepartment();
        void AddSubDepartment(SubDepartment subDepartment);
        void UpdateSubDepartment(SubDepartment subDepartment);
        void DeleteSubDepartment(int subDepartmentId);
        SubDepartment GetSubDepartmentById(int subDepartmentId);
    }
}
