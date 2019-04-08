using EcommerceMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMVC.Infrastructure
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext context, ModelBindingContext bindingContext)
        {
            ShoppingCartModel cart = null;
            if (context.HttpContext.Session != null)
            {
                cart = (ShoppingCartModel)context.HttpContext.Session[sessionKey];
            }

            // create cart if there wasn't one already
            if (cart == null)
            {
                cart = new ShoppingCartModel();
                cart.shoppingProducts = new List<ShoppingProductModel>();
                if (context.HttpContext.Session != null)
                {
                    context.HttpContext.Session[sessionKey] = cart;
                }
            }

            return cart;
        }
    }
}