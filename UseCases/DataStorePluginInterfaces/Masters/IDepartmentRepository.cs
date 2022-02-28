using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartment();
        void AddDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
        Department GetDepartmentById(int departmentId);
    }
}
