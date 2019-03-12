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
            return new CategoryModel
            {
                id = category.Id,
                name = category.Name,
                parentCategoryId = category.ParentCategory.Id,
                subCategories = category.SubCategories
            };
        }

        //public static CategoryHierarchyModel CreateWithHierarchy(Category category)
        //{
        //    //return new CategoryHierarchyModel
        //    //{
        //    //    id = category.Id,
        //    //    name = category.Name,
        //    //    subCategories = category.SubCategories;
        //    //};
        //}
    }
}
