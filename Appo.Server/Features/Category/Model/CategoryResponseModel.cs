using System.Collections.Generic;

namespace Appo.Server.Features.Category.Model
{
    public class CategoryResponseModel
    {
        public CategoryResponseModel()
        {
            InverseParentCategory = new HashSet<CategoryResponseModel>();
        }

        public int Id { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public int? ParentCategoryId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public string UserDefined1 { get; set; }
        public string UserDefined2 { get; set; }
        public string UserDefined3 { get; set; }
        public string UserDefined4 { get; set; }

        public virtual CategoryResponseModel ParentCategory { get; set; }

        public virtual ICollection<CategoryResponseModel> InverseParentCategory { get; set; }
    }
}
