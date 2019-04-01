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

namespace EcommerceMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: api/Product
        public async Task<ActionResult> Index(int? id)
        {
            ProductService productService = new ProductService(new UrlBuilder());

            var result = await productService.GetProducts(id ?? 0);

            return View("Index", result);
        }

        // GET by name
        public async Task<ActionResult> GetByName(string name)
        {
            ProductService productService = new ProductService(new UrlBuilder());

            var result = await productService.GetProductByName(name);

            return View("Index", result);
        }

        //Create Product
        [System.Web.Mvc.HttpPost]
        public ActionResult Create(ProductModel product)
        {
            try
            {
                ProductService productService = new ProductService(new UrlBuilder());

                var result = productService.CreateProduct(product);

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
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            ProductService productService = new ProductService(new UrlBuilder());

            var result = await productService.GetProducts(id ?? 0);

            return View("Edit", result); 
        }

        [System.Web.Mvc.HttpPost]
        public async Task<ActionResult> Edit(int Id, FormCollection collection)
        {
            ProductService productService = new ProductService(new UrlBuilder());
            try
            {
                ProductModel productModel = new ProductModel
                {
                    id = Id,
                    categoryId = int.Parse(collection.GetValue("categoryId").AttemptedValue),
                    categoryName = collection.GetValue("categoryName").AttemptedValue,
                    name = collection.GetValue("name").AttemptedValue,
                    description = collection.GetValue("description").AttemptedValue,
                    price = decimal.Parse(collection.GetValue("price").AttemptedValue),
                    publicationDate = DateTime.Parse(collection.GetValue("publicationdate").AttemptedValue),
                    
                };

                var result = await productService.ModifyProduct(productModel);

                return View("Edit", result);
            }
            catch
            {
                return View();
            }
           
        }


        // GET: api/Product/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Product
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5


    }
}
