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
    public class StaffCategoryRepository: IStaffCategoryRepository
    {
        private readonly MarketContext _db;
        private readonly Response response;
        public StaffCategoryRepository(MarketContext db, Response response)
        {
            _db = db;
            this.response = response;
        }

        public Response AddStaffCategory(StaffCategory staffCategory)
        {
            if (staffCategory != null)
                try
                {
                    _db.StaffCategories.Add(staffCategory);
                    _db.SaveChanges();
                    response.IsSuccess = true;
                    response.Message = "Staff Category is Added Successfuly";
                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error:" + ex.Message;
                }

            return response;
        }

        public Response DeleteStaffCategory(int SaffCategoryId)
        {
            var staffCategory = _db.StaffCategories.Find(SaffCategoryId);
            if (staffCategory == null) return response;
            try
            {
                _db.StaffCategories.Remove(staffCategory);
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Staff Category is Removed Successfuly";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error:" + ex.Message;
            }
            return response;
        }

        public IEnumerable<StaffCategory> GetStaffCategory()
        {
            return _db.StaffCategories.ToList();
        }

        public StaffCategory GetStaffCategoryById(int StaffCategoryId)
        {
            return _db.StaffCategories.Find(StaffCategoryId);
        }

        public Response UpdateStaffCategory(StaffCategory staffCategory)
        {
            var staf = _db.StaffCategories.Find(staffCategory.StaffCategoryId);
            if (staffCategory == null) return response;
            try
            {
                staf.Description = staffCategory.Description;
                staf.ShortDescription = staffCategory.ShortDescription;
                _db.SaveChanges();
                response.IsSuccess = true;
                response.Message = "Staff Category is Updated Successfuly";
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
