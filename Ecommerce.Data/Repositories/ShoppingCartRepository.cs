using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repositories
{
    public class ShoppingCartRepository : IRepository<ShoppingCart>
    {
        private EcommerceContext _context;

        public ShoppingCartRepository(EcommerceContext context)
        {
            _context = context;
        }

        public ShoppingCart Add(ShoppingCart entity)
        {
            return _context.ShoppingCarts.Add(entity);
        }

        public void Delete(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ShoppingCart> GetAll()
        {
            return _context.ShoppingCarts;
        }

        public ShoppingCart GetById(int id)
        {
            var cart = _context.ShoppingCarts.Single(cat => cat.Id == id);

            _context.Entry(cart).Collection(x => x.ShoppingProducts).Load();

            return cart;
        }

        public ShoppingCart GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ShoppingCart> GetByName()
        {
            throw new NotImplementedException();
        }

        public ShoppingCart GetSingle(Func<ShoppingCart, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public ShoppingCart Update(ShoppingCart entity)
        {
            throw new NotImplementedException();
        }
    }
}
