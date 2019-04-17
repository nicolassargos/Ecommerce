using EcommerceMVC.Helper;
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
        public object BindModel(ControllerContext context, ModelBindingContext bindingContext)
        {
            return EcommerceSession.ShoppingCart;
        }
    }
}