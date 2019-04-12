using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using EcommerceMVC.Services;
using EcommerceMVC.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EcommerceMVC.Controllers
{
    public class CartController : Controller
    {
        CartService service = new CartService(new UrlBuilder());
        ProductService productService = new ProductService(new UrlBuilder());

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ViewResult Index(ShoppingCartModel cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddToCart(ShoppingCartModel cart, int productId, int quantity, string returnUrl)
        {
            var productModel = await productService.GetProduct(productId);

            ShoppingProductModel shoppingProductModel = new ShoppingProductModel()
            {
                name = productModel.name,
                pricePerUnit = productModel.price,
                productId = productModel.id,
                quantity = quantity
            };

            cart.shoppingProducts.Add(shoppingProductModel);

            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(ShoppingCartModel cart, int productId, int quantity, string returnUrl)
        {
            service.RemoveItems(cart, productId, quantity);

            return RedirectToAction("Index", new { returnUrl });
        }

        [HttpPost]
        [Route("/proceedPayment")]
        public async Task<ActionResult> ProceedPayment(ShoppingCartModel cart)
        {
            string redirectUrl = "";

            try
            {
                redirectUrl = await service.GetPaymentAuthorizationId(cart);
            }
            catch (Exception ex)
            {
                throw;
            }

            return Redirect(redirectUrl);
        }
    }
}