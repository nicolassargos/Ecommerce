using EcommerceMVC.Models;
using EcommerceMVC.Helper;
using EcommerceMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Threading.Tasks;
using Ecommerce.Common;
using AllowAnonymousAttribute = System.Web.Mvc.AllowAnonymousAttribute;
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace EcommerceMVC.Controllers
{
    [IdentityBasicAuthentication]
    [AllowAnonymous]
    public class ProductController : Controller
    {
        ProductService productService = new ProductService(new UrlBuilder());

        // GET: api/Product
        
        public async Task<ActionResult> Index()
        {
            var result = await productService.GetAllProducts();

            return View("Index", result);
        }

        // GET by name
        public async Task<ActionResult> GetByName(string name)
        {
            var result = await productService.GetProductByName(name);
            
            return View("Index", result);
        }

        //Create Product
        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Create(ProductModel product)
        {
            try
            {
                var result = await productService.CreateProduct(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        //show created product
        public ActionResult Create()
        {
            ViewBag.selectId = "categoryId";

            return View(new ProductModel());
        }

        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var result = await productService.GetProduct(id ?? 0);
            ViewBag.selectId = "categoryId";
            ViewBag.categoryId = result.categoryId;
            return View("Edit", result);
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(int Id, FormCollection collection)
        {
            try
            {
                ProductModel productModel = new ProductModel()
                {
                    id = Id,
                    categoryId = int.Parse(collection.GetValue("categoryId").AttemptedValue),
                    name = collection.GetValue("name").AttemptedValue,
                    description = collection.GetValue("description").AttemptedValue,
                    price = decimal.Parse(collection.GetValue("price").AttemptedValue),
                    publicationDate = DateTime.Parse(collection.GetValue("publicationdate").AttemptedValue)
                };

                var result = await productService.ModifyProduct(productModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }


        // GET: api/Product/5
        public async Task<ViewResult> Details(int id)
        {
            var result = await productService.GetProduct(id);
            ViewBag.qtd = 1;
            return View("Details", result);
        }

        // POST: api/Product
        public void Post(string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, string value)
        {
        }

        // DELETE: api/Product/5


    }
}
