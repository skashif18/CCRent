using CoreBusiness;
using CoreBusiness.EmployeeRelations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.EmployeesEmployeeRelations;

namespace Plugins.DataStore.SQL.EmployeeRelations
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public EmployeeRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddBranch(Employee employee)
        {
            if (employee != null)
                try
                {
                    _db.Employees.Add(employee);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Employee is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteBranch(int EmployeeId)
        {
            var employee = _db.Employees.Find(EmployeeId);
            if (employee == null) return response;
            try
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Employee is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Employee> GetBranch()
        {
            return _db.Employees.ToList();
        }

        public Employee GetBranchById(int EmployeeId)
        {
            return _db.Employees.Find(EmployeeId);
        }

        public Response UpdateBranch(Employee employee)
        {
            var emp = _db.Employees.Find(employee.EmployeeId);
            if (employee == null) return response;
            try
            {
                emp.FirstName = employee.FirstName;
                emp.EmployeeCode = employee.EmployeeCode;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Employee is Updated Successfuly";
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

