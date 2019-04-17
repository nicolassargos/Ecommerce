using EcommerceMVC.Helper;
using EcommerceMVC.Models;
using EcommerceMVC.Services;
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

        [HttpPost]
        public RedirectToRouteResult Index(ShoppingCartModel cart)
        {
            return RedirectToAction("CheckOut", cart);
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
        public async Task<ActionResult> AddToCart(ShoppingCartModel cart, int productId, int quantity)
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

            return RedirectToAction("Index");
        }

        public RedirectToRouteResult RemoveFromCart(ShoppingCartModel cart, int productId, int quantity, string returnUrl)
        {
            
            service.RemoveItems(cart, productId, quantity);

            return RedirectToAction("Index", new { returnUrl });
        }


        [HttpGet]
        public ViewResult CheckOut(ShoppingCartModel cart)
        {
            var checkOut = new CheckOutModel();
            checkOut.Cart = cart;

            return View(checkOut);
        }

        [HttpPost]
        public async Task<ActionResult> ProcessPayment(ShoppingCartModel cart)
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

            return Redirect($"{redirectUrl}&returnUrl={Url.Action("EmptyCart", "Cart", null, Request.Url.Scheme)}");
        }

        [HttpGet]
        [Route("empty/{paymentId}")]
        public async Task<ActionResult> EmptyCart(int paymentId)
        {
            try
            {
                bool result = await service.CheckPayment(paymentId);
                if (result)
                {
                    service.EmptyCart();
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Index", "Cart");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}