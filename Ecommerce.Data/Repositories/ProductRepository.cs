using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private EcommerceContext _context;

        public ProductRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Product Add(Product entity)
        {
            Product newProduct = new Product();

            try
            {
                newProduct = _context.Products.Add(entity);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return newProduct;
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public Product GetById(int Id)
        {
            return _context
                .Products
                .Where(prod => prod.Id == Id)
                .Include(prod=>prod.Category)
                .Single();
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetByName(string name)
        {
            return _context
                .Products
                .Where(prod => prod.Name == name)
                .Include(prod => prod.Category)
                .Single();
        }


        public IQueryable<Product> GetByName()
        {
            return _context.Products;
        }

        public Product GetSingle(Func<Product, bool> predicate)
        {
            return _context.Products.SingleOrDefault(predicate);
        }

        public Product Update(Product entity)
        {

            var productToUpdate = _context.Products.Single(x => x.Id == entity.Id);

            _context.Entry(productToUpdate).CurrentValues.SetValues(entity.Id);
            _context.SaveChanges();
            return _context.Products.Single(x => x.Id == entity.Id);
        }


        IQueryable<Product> IRepository<Product>.GetAll()
        {
            throw new NotImplementedException();
        }


    }
}
