using Ecommerce.Business.Models;
using Ecommerce.Data;
using Ecommerce.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class ShoppingService
    {
        private ShoppingProductRepository _productRepository;
        private ShoppingCartRepository _cartRepository;
        private EcommerceContext _context;

        public ShoppingService()
        {
            _context = new EcommerceContext();
            _productRepository = new ShoppingProductRepository(_context);
            _cartRepository = new ShoppingCartRepository(_context);
        }

        //public ShoppingCartModel GetShoppingCart(int id)
        //{

        //}
    }
}
