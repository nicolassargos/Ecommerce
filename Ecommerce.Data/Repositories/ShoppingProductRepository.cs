using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class ShoppingProductRepository : IRepository<ShoppingProduct>
    {
        private EcommerceContext _context;

        public ShoppingProductRepository(EcommerceContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ShoppingProduct Add(ShoppingProduct entity)
        {
            var newShoppingProduct = new ShoppingProduct();

            try
            {
                newShoppingProduct = _context.ShoppingProducts.Add(entity);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }

            return newShoppingProduct;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(ShoppingProduct entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ShoppingProduct> GetAll()
        {
            throw new NotImplementedException();
        }

        public ShoppingProduct GetById(int id)
        {
            return _context
                    .ShoppingProducts
                    .Where(spp => spp.Id == id)
                    .Include(spp => spp.Product)
                    .Include(spp => spp.ShoppingCart)
                    .Single();
        }

        public ShoppingProduct GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ShoppingProduct> GetByName()
        {
            throw new NotImplementedException();
        }

        public ShoppingProduct GetSingle(Func<ShoppingProduct, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ShoppingProduct Update(ShoppingProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
