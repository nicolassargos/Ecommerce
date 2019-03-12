using Ecommerce.Business.Helpers;
using Ecommerce.Data;
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
        private EcommerceContext _context;

        public ProductService()
        {
            _context = new EcommerceContext();
            _repository = new ProductRepository(_context);
        }

        public ProductModel GetProductById(int id)
        {
            return ProductModelBuilder.Create(_repository.Get(id));
        }


    }
}
