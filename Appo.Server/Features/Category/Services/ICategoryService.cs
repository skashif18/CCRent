using Appo.Server.Features.Category.Model;
using CoreBusiness;
using System.Collections.Generic;

namespace Appo.Server.Features.Category.Services
{
    public interface ICategoryService
    {
        Response Create(CategoryRequestModel model);

        IList<CategoryResponseModel> GetAll();

        Response Update(CategoryRequestModel model);
        string GetChildToParent(int catId);
        CategoryResponseModel GetById(int id);

        IEnumerable<CategoryResponseModel> GetBaseParentAll();

        IEnumerable<CategoryResponseModel> GetChildByParentId(int Id);
    }
}
