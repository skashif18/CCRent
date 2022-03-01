using CoreBusiness;
using CoreBusiness.Masters;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces.Masters
{
    public interface IStaffCategoryRepository
    {
        IEnumerable<StaffCategory> GetStaffCategory();
        Response AddStaffCategory(StaffCategory staffCategory);
        Response UpdateStaffCategory(StaffCategory staffCategory);
        Response DeleteStaffCategory(int saffCategoryId);
        StaffCategory GetStaffCategoryById(int staffCategoryId);
    }
}
