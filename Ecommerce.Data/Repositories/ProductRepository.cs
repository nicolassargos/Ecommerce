using Ecommerce.Domain;
using System;
using System.Collections.Generic;
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

        public Product Get(int Id)
        {
            return _context.Products.Single(prod => prod.Id == Id);
        }

        public IQueryable<Product> GetAll()
        {
            return _context.Products;
        }

        public Product GetSingle(Func<Product, bool> predicate)
        {
            return _context.Products.SingleOrDefault(predicate);
        }

        public Product Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
