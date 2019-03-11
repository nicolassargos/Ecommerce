using Ecommerce.Common;
using Ecommerce.Data.Repositories;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business
{
    public class ProductService
    {
        private ProductRepository _repository;

        public ProductService()
        {

        }

        //public ProductDto GetProductById(int id)
        //{
        //    var product = _repository.Get(id);
        //}
    }
}
