using EcommerceMVC.Models;
using System.Web;

namespace EcommerceMVC.Helper
{
    public class EcommerceSession
    {
        public static AccountModel UserCredentials {
            get
            {
                if (HttpContext.Current.Session["userCredentials"] == null)
                {
                    HttpContext.Current.Session.Add("userCredentials", new AccountModel());
                }
                return (AccountModel)HttpContext.Current.Session["userCredentials"];
            }

            set
            {
                if (HttpContext.Current.Session["userCredentials"] == null)
                {
                    HttpContext.Current.Session.Add("userCredentials", new AccountModel());
                }
                HttpContext.Current.Session["userCredentials"] = value;
            }
        }

        public static ShoppingCartModel ShoppingCart
        {
            get
            {
                if (HttpContext.Current.Session["cart"] == null)
                {
                    HttpContext.Current.Session.Add("cart", new ShoppingCartModel());

                }
                return (ShoppingCartModel)HttpContext.Current.Session["cart"];
            }

            set
            {
                if (HttpContext.Current.Session["cart"] == null)
                {
                    HttpContext.Current.Session.Add("cart", new ShoppingCartModel());
                }
                HttpContext.Current.Session["cart"] = value;
            }
        }
    }
}