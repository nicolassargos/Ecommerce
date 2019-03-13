using Ecommerce.Business.Models;
using Ecommerce.Business.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ecommerce.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ShoppingController : ApiController
    {
        private ShoppingService _service;

        public ShoppingController()
        {
            _service = new ShoppingService();
        }

        // GET: api/Shopping
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Shopping/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Shopping
        [HttpPost]
        public IHttpActionResult Post([FromBody]ShoppingCartModel shoppingCartModel)
        {
            try
            {
                var cart = _service.CreateShoppingCart(shoppingCartModel);
                return Ok(cart);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Shopping/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Shopping/5
        public void Delete(int id)
        {
        }
    }
}
