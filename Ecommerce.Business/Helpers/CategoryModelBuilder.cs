using Ecommerce.Entities;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Helpers
{
    public static class CategoryModelBuilder
    {
        public static CategoryModel Create(Category category)
        {
            var result = new CategoryModel
            {
                id = category.Id,
                name = category.Name,
                parentCategoryId = (category.ParentCategory == null) ? 0 : category.ParentCategory.Id
            };

            if (category.SubCategories.Count > 0)
            {
                foreach (var cat in category.SubCategories)
                {
                    if (result.subCategories == null) result.subCategories = new List<CategoryModel>();
                    result.subCategories.Add(CategoryModelBuilder.Create(cat));
                }
            }
            

            return result;
        }
    }
}
