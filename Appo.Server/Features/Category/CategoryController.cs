using Appo.Server.Features.Category.Model;
using Appo.Server.Features.Category.Services;
using CoreBusiness;
using CoreBusiness.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Appo.Server.Features.Category
{
    public class CategoryController : ApiController
    {

        private readonly ICategoryService repository;
        public CategoryController(ICategoryService _repository)
        {
            repository = _repository;

        }

        [HttpGet]
        [Route("all")]
        public IList<CategoryResponseModel> GetAll()
            => repository.GetAll();

        [HttpGet]
        [Route("root")]
        public IEnumerable<CategoryResponseModel> GetBaseParent()
            => repository.GetBaseParentAll();

        [HttpGet]
        [Route("childs-by-parent")]
        public IEnumerable<CategoryResponseModel> GetChildParentByPrentId(int Id)
            => repository.GetChildByParentId(Id);

        [HttpGet]
        [Route("by-Id")]
        public CategoryResponseModel GetById(int Id)
            => repository.GetById(Id);

        [HttpGet]
        [Route("heirarchy")]
        public string GetChildToParent(int catId)
            => repository.GetChildToParent(catId);

        [HttpGet]
        [Route("heirarchyObj")]
        public Response GetChildToParentObj(int catId)
           => repository.GetChildToParentObj(catId);


        [HttpPost]
        [Route("create")]
        public IActionResult Create(CategoryRequestModel model)
        {
            var result = repository.Create(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(CategoryRequestModel model)
        {
            var result = repository.Update(model);

            if (!result.IsSuccess) return BadRequest(result.Message);

            return Ok(result);
        }

    }
}
