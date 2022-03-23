using CoreBusiness;
using CoreBusiness.EmployeeRelations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces.EmployeesEmployeeRelations
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetBranch();
        Response AddBranch(Employee employee);
        Response UpdateBranch(Employee employee);
        Response DeleteBranch(int EmployeeId);
        Employee GetBranchById(int EmployeeId);
    }
}
