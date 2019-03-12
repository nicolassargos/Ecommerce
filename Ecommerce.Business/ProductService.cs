using Ecommerce.Business.Helpers;
using Ecommerce.Business.Models;
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

        public ProductModel GetProductByName(string name)
        {
            return ProductModelBuilder.Create(_repository.GetSingle(x => x.Name == name));
        }

        public List<ProductModel> GetByPartialName(string name ="")
        {
            var productModels = new List<ProductModel>();

            if (!string.IsNullOrEmpty(name))
            {
                foreach (var product in _repository.GetAll())
                {
                    productModels.Add(ProductModelBuilder.Create(product));
                }

                return productModels;
            }

            foreach (var product in _repository.GetAll().Where(x => x.Name.Contains(name)))
            {
                productModels.Add(ProductModelBuilder.Create(product));
            }

            return productModels;
        }
    }
}
