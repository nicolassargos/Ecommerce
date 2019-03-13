using Ecommerce.Business.Models;
using Ecommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Helpers
{
    public static class ShoppingCartModelBuilder
    {
        public static ShoppingCartModel Create(ShoppingCart cart)
        {
            var cartModel = new ShoppingCartModel
            {
                id = cart.Id,
                userId = cart.User == null ? 0 : cart.User.Id,
                shoppingProducts = new List<ShoppingProductModel>()
            };

            if (cart.ShoppingProducts != null && cart.ShoppingProducts.Count > 0)
            {
                foreach (var prod in cart.ShoppingProducts)
                {
                    cartModel.shoppingProducts.Add(ShoppingProductModelBuilder.Create(prod));
                }
            }

            return cartModel;
        }
    }
}
