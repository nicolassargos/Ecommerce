using Ecommerce.Business.Helpers;
using Ecommerce.Data;
using Ecommerce.Data.Repositories;
using Ecommerce.Models;
using System.Collections.Generic;
using System.Linq;
namespace Ecommerce.Business
{
    public class CategoryService
    {
        private CategoryRepository _repository;
        private EcommerceContext _context;

        public CategoryService()
        {
            _context = new EcommerceContext();
            _repository = new CategoryRepository(_context);
        }

        public CategoryModel GetCategoryById(int id)
        {
            return CategoryModelBuilder.Create(_repository.GetById(id));
        }

        public IEnumerable<CategoryModel> GetCategoryHierarchy()
        {
            var rootCategories = _repository.GetByName().Where(x => x.ParentCategory == null);

            foreach(var cat in rootCategories)
            {
                yield return CategoryModelBuilder.Create(cat);
            }
        }
    }
}
