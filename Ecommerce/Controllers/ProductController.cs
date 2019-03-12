using System.Web.Http;
using System.Web.Http.Cors;
using Ecommerce.Business;

namespace Ecommerce.Controllers
{
    [EnableCors("*", "*", "*")]
    //[RoutePrefix("api/[controller]")]
    public class ProductController : ApiController
    {
        ProductService productService = new ProductService();

        [Route("api/product/{name}")]
        [HttpGet]
        public IHttpActionResult GetProductByName(string name)
        {
        return Ok(productService.GetProductByName(name));
        }

        public IHttpActionResult GetByPartialName(string name)
        {
            return Ok(productService.GetByPartialName(name));
        }

        [HttpGet]
        public IHttpActionResult GetProductById(int id)
        {
            return Ok(productService.GetProductById(id));
        }


    }
}