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

        public async Task<ActionResult> GetByName(string name)
        {
            ProductService productService = new ProductService(new UrlBuilder());

            var result = await productService.GetProductByName(name);

            return View("Index", result);
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
        public void Delete(int id)
        {
        }
    }
}
