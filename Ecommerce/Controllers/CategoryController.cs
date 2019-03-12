using Ecommerce.Business;
using Ecommerce.Models;
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
    public class CategoryController : ApiController
    {
        private CategoryService _service;

        public CategoryController()
        {
            _service = new CategoryService();
        }

        // GET: api/Category
        public IHttpActionResult Get()
        {
            return Ok(_service.GetCategoryHierarchy());
        }

        // GET: api/Category/5
        //[EnableCors("*", "*", "*")]
        //public IHttpActionResult Get(int id)
        //{
        //    return Ok(_service.GetCategoryById(id));
        //}

        // POST: api/Category
        public IHttpActionResult Post([FromBody]CategoryModel category)
        {
            return Ok(_service.CreateCategory(category));
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]CategoryModel value)
        {
        }

        // DELETE: api/Category/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _service.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
            
            return Ok();
        }
    }
}
