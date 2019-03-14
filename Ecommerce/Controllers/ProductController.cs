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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("name/{name}")]
        [HttpGet]
        public IHttpActionResult GetProductByName(string name)
        {
        return Ok(productService.GetProductByName(name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [Route("partial/{name}")]
        [HttpGet]
        public IHttpActionResult GetByPartialName(string name)
        {
            return Ok(productService.GetByPartialName(name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            return Ok(productService.GetProductById(id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [Route("category/{categoryId}")]
        [HttpGet]
        public IHttpActionResult GetAllProductsByCategoryId(int categoryId)
        {
            return Ok(productService.GetAllProductsByCategory(categoryId));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateProduct([FromBody]ProductModel product)
        {
            return Ok(productService.CreateProduct(product));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [Route("modify")]
        [HttpPut]
        public IHttpActionResult ModifyProduct([FromBody]ProductModel product)
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("all")]
        [HttpGet]
        public IHttpActionResult GetAllProduct()
        {
            return Ok(productService.GetAllProducts());
        }


    }
}