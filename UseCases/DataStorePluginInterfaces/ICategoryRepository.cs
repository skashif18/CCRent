using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<SrvCategory> GetCategories();
        void AddCategory(SrvCategory category);
        void UpdateCategory(SrvCategory category);
        SrvCategory GetCategoryById(int categoryId);
        void DeleteCategory(int categoryId);
    }
}
