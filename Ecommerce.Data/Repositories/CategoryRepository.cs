using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private EcommerceContext _context;

        public CategoryRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Category Add(Category entity)
        {
            Category newCategory = new Category();

            try
            {
                newCategory = _context.Categories.Add(entity);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return newCategory;
        }

        public void Delete(Category entity)
        {
            _context.Categories.Remove(entity);

            _context.SaveChanges();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Category> GetAll()
        {
            return _context.Categories;
        }

        public Category GetById(int Id)
        {
            var category = _context.Categories.Single(cat => cat.Id == Id);

            _context.Entry(category).Collection(x => x.SubCategories).Load();

            return category;
        }

        public Category GetByName(string name)
        {
            var result = _context.Categories.Single(cat => cat.Name == name);
            _context.Entry(result).Reference(x => x.SubCategories).Load();

            return result;
        }



        public IQueryable<Category> GetByName()
        {
            throw new NotImplementedException();
        }

        public Category GetSingle(Func<Category, bool> predicate)
        {
            return _context.Categories.SingleOrDefault(predicate);
        }

        public Category Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
