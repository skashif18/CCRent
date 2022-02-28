using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IStaffCategoryRepository
    {
        IEnumerable<StaffCategory> GetStaffCategory();
        void AddStaffCategory(StaffCategory staffCategory);
        void UpdateStaffCategory(StaffCategory staffCategory);
        void DeleteStaffCategory(int saffCategoryId);
        StaffCategory GetStaffCategoryById(int staffCategoryId);
    }
}
