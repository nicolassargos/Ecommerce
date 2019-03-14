using Ecommerce.Business.Helpers;
using Ecommerce.Data;
using Ecommerce.Data.Repositories;
using Ecommerce.Entities;
using Ecommerce.Models;
using System;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryModel GetCategoryById(int id)
        {
            return CategoryModelBuilder.Create(_repository.GetById(id));
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            var allCategories = _repository.GetAll();

            foreach(var cat in allCategories)
            {
                yield return CategoryModelBuilder.CreateWithoutDependancy(cat);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CategoryModel> GetCategoryHierarchy()
        {
            var rootCategories = _repository.GetAll().Where(x => x.ParentCategory == null);

            foreach(var cat in rootCategories)
            {
                yield return CategoryModelBuilder.Create(cat);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public CategoryModel CreateCategory(CategoryModel category)
        {
            var newCategory = new Category() { Name = category.name };

            // Cas où il s'agit d'une catégorie de base
            if (category.parentCategoryId > 0)
                newCategory.ParentCategory = _repository.GetById(category.parentCategoryId);

            var result = _repository.Add(newCategory);

            return CategoryModelBuilder.Create(result);
        }

        public void DeleteCategory(int id)
        {
            var category = _repository.GetById(id);

            // gestion des erreurs
            if (category == null) throw new ArgumentException("La catégorie n'existe pas.");
            if (category.SubCategories != null && category.SubCategories.Count > 0) throw new Exception("La catégorie contient d'autres catégories");
            if (category.Products != null && category.Products.Count > 0) throw new Exception("La catégorie contient des produits");

            _repository.Delete(category);
        }
    }
}
