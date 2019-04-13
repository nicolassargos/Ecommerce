using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceMVC.Models
{
    public class CheckOutModel
    {
        public ShoppingCartModel Cart { get; set; }

        public UserDetailsModel User { get; set; }
    }
}