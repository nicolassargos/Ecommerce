using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Ecommerce.Business;
using Ecommerce.Business.Models;

namespace Ecommerce.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        ProductService productService = new ProductService();

        [Route("name")]
        //[Route("api/product/{name}")]
        [HttpGet]
        public IHttpActionResult GetProductByName(string name)
        {
        return Ok(productService.GetProductByName(name));
        }
        [Route("partial")]
        //[Route("api/product/partialname")]
        [HttpGet]
        public IHttpActionResult GetByPartialName(string name)
        {
            return Ok(productService.GetByPartialName(name));
        }

        //[Route("api/product/productid")]
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            return Ok(productService.GetProductById(id));
        }

        [Route("create")]
        [HttpPost]
        public IHttpActionResult CreateProduct(ProductModel product)
        {
            return Ok(productService.CreateProduct(product));
        }

        [Route("modify")]
        [HttpPut]
        public IHttpActionResult ModifyProduct(ProductModel product)
        {
            try
            {
                return Ok(productService.ModifyProduct(product));
                //return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllProduct()
        {
            return Ok(productService.GetAllProducts());
        }


    }
}