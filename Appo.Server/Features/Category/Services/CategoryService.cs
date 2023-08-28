using Appo.Server.Features.Category.Model;
using AutoMapper;
using CoreBusiness;
using CoreBusiness.Master;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces.SrvTable.SrvMaster;

namespace Appo.Server.Features.Category.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository repository;

        private readonly IMapper mapper;

        private SrvCategory category = new();
        public CategoryService(ICategoryRepository _repository, IMapper _mapper)
        {
            repository = _repository;
            mapper = _mapper;
        }

        public Response Create(CategoryRequestModel model)
        {
            category = mapper.Map<SrvCategory>(model);
            return repository.Create(category);
        }

        public IList<CategoryResponseModel> GetAll()
        {
            var list = repository.GetAll();
            return mapper.Map<IList<CategoryResponseModel>>(list);
        }

        public IEnumerable<CategoryResponseModel> GetBaseParentAll()
        {
            var list = repository.GetBaseParentAll();
            return mapper.Map<IEnumerable<CategoryResponseModel>>(list);
        }

        public string GetChildToParent(int catId)
        {
            return repository.GetChildToParent(catId);
        }
        public CategoryResponseModel GetById(int Id)
        {
            var model = repository.GetById(Id);
            return mapper.Map<CategoryResponseModel>(model);
        }

        public IEnumerable<CategoryResponseModel> GetChildByParentId(int Id)
        {
            var list = repository.GetChildByParentId(Id);
            return mapper.Map<IEnumerable<CategoryResponseModel>>(list);
        }

        public Response Update(CategoryRequestModel model)
        {
            category = mapper.Map<SrvCategory>(model);
            return repository.Update(category);
        }
    }
}
