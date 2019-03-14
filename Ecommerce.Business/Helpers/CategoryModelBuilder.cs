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
            if (category == null) return null;

            var result = new CategoryModel
            {
                id = category.Id,
                name = category.Name,
                parentCategoryId = (category.ParentCategory == null) ? 0 : category.ParentCategory.Id
            };


            if (category.SubCategories == null || category.SubCategories.Count == 0)
            {
                return result;
            }

            foreach (var cat in category.SubCategories)
            {
                if (result.subCategories == null) result.subCategories = new List<CategoryModel>();
                result.subCategories.Add(CategoryModelBuilder.Create(cat));
            }
            
            return result;
        }

        public static CategoryModel CreateWithoutDependancy(Category category)
        {
            if (category == null) return null;

            return new CategoryModel
            {
                id = category.Id,
                name = category.Name,
                parentCategoryId = (category.ParentCategory == null) ? 0 : category.ParentCategory.Id
            };
        }
    }
}
