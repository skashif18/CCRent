using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Appo.Server.Features.Categories
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryRepository category;
        public CategoryController(ICategoryRepository _category)
        {
            category = _category;
        }
        [HttpGet]
        public IEnumerable<SrvCategory> Get()
            => category.GetCategories();

    }
}
