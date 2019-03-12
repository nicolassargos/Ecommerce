using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Ecommerce.Business;
using Ecommerce.Business.Models;
using Ecommerce.Models;

namespace Ecommerce.Controllers
{
    public class ProductController : ApiController
    {

        ProductService productService = new ProductService();
        [Route("api/product/{name}")]
        public IHttpActionResult GetProductByName(string name)
        {
        return Ok(productService.GetProductByName(name));
        }

        public IHttpActionResult GetByPartialName(string name)
        {
            return Ok(productService.GetByPartialName(name));
        }

        public IHttpActionResult GetProductById(int id)
        {
            return Ok(productService.GetProductById(id));
        }


    }
}