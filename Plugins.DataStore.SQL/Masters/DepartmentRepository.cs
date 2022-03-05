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
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly MarketContext _db;
        private readonly Response response;
        public DepartmentRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }
        public Response AddDepartment(Department department)
        {
            if (department != null)
                try
                {
                    _db.Departments.Add(department);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Bankepartment is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteDepartment(int DepartmentId)
        {
            var department = _db.Departments.Find(DepartmentId);
            if (department == null) return response;
            try
            {
                _db.Departments.Remove(department);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Departmnet is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<Department> GetDepartment()
        {
            return _db.Departments.ToList();
        }
        public Department GetDepartmentById(int DepartmentId)
        {
            return _db.Departments.Find(DepartmentId);
        }

        public Response UpdateDepartment(Department department)
        {
            var dprt = _db.Departments.Find(department.DepartmentId);
            if (department == null) return response;
            try
            {
                dprt.DepartmentName = department.DepartmentName;
                dprt.ACCode = dprt.ACCode;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Departmnet is Updated Successfuly";
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
