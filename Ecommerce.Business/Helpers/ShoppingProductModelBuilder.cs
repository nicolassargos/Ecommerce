using Ecommerce.Business.Models;
using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Helpers
{
    public static class ShoppingProductModelBuilder
    {

        public static ShoppingProductModel Create(ShoppingProduct product)
        {
            if (product == null) return null;

            var productModel = new ShoppingProductModel
            {
                id = product.Id,
                name = product.Name,
                pricePerUnit = product.Price,
                productId = product.Product == null ? 0 : product.Product.Id,
                quantity = product.Quantity
            };

            return productModel;
        }
    }
}
