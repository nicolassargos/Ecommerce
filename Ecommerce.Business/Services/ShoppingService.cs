using Ecommerce.Business.Helpers;
using Ecommerce.Business.Models;
using Ecommerce.Data;
using Ecommerce.Data.Entities;
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
        private ShoppingProductRepository _shoppingProductRepository;
        private ShoppingCartRepository _shoppingCartRepository;
        private ProductRepository _productRepository;
        private EcommerceContext _context;

        public ShoppingService()
        {
            _context = new EcommerceContext();
            _shoppingProductRepository = new ShoppingProductRepository(_context);
            _shoppingCartRepository = new ShoppingCartRepository(_context);
            _productRepository = new ProductRepository(_context);
        }

        public ShoppingCartModel GetShoppingCart(int id)
        {
            return ShoppingCartModelBuilder.Create(_shoppingCartRepository.GetById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shoppingCartModel"></param>
        /// <returns></returns>
        public ShoppingCartModel CreateShoppingCart(ShoppingCartModel shoppingCartModel)
        {
            var newShoppingCart = new ShoppingCart()
            {
                Id = shoppingCartModel.id,
                Date = DateTime.Now,
                ShoppingProducts = new List<ShoppingProduct>()
            };

            _shoppingCartRepository.Add(newShoppingCart);

            _context.SaveChanges();

            if (shoppingCartModel.shoppingProducts != null && shoppingCartModel.shoppingProducts.Count > 0)
            {
                foreach (var prod in shoppingCartModel.shoppingProducts)
                {
                    newShoppingCart.ShoppingProducts.Add(CreateShoppingProduct(prod));
                }
            }

            _context.SaveChanges();

            return ShoppingCartModelBuilder.Create(newShoppingCart);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shoppingProductModel"></param>
        /// <returns></returns>
        public ShoppingProduct CreateShoppingProduct(ShoppingProductModel shoppingProductModel)
        {
            var newShoppingProduct = new ShoppingProduct
            {
                Name = shoppingProductModel.name,
                Price = shoppingProductModel.pricePerUnit,
                Product = _productRepository.GetById(shoppingProductModel.productId),
                Quantity = shoppingProductModel.quantity
            };

            _shoppingProductRepository.Add(newShoppingProduct);

            _context.SaveChanges();

            return newShoppingProduct;
        }
    }
}
