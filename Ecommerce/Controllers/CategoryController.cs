﻿using Ecommerce.Business;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ecommerce.Controllers
{
    public class CategoryController : ApiController
    {
        private CategoryService _service;

        public CategoryController()
        {
            _service = new CategoryService();
        }

        // GET: api/Category
        public IEnumerable<CategoryModel> Get()
        {
            return _service.GetCategoryHierarchy();
        }

        // GET: api/Category/5
        public CategoryModel Get(int id)
        {
            return _service.GetCategoryById(id);
        }

        // POST: api/Category
        public void Post([FromBody]CategoryModel value)
        {

        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]CategoryModel value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
