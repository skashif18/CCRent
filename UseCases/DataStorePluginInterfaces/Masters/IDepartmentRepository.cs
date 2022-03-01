using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartment();
        Response AddDepartment(Department department);
        Response UpdateDepartment(Department department);
        Response DeleteDepartment(int departmentId);
        Department GetDepartmentById(int departmentId);
    }
}
