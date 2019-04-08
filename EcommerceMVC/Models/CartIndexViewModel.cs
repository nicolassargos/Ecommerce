using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceMVC.Models
{
    public class CartIndexViewModel
    {
        public string ReturnUrl { get; set; }
        public ShoppingCartModel Cart { get; set; }
    }
}