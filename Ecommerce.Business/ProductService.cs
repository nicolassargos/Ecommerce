using Ecommerce.Business.Helpers;
using Ecommerce.Business.Models;
using Ecommerce.Data;
using Ecommerce.Data.Repositories;
using Ecommerce.Entities;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

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
            return ProductModelBuilder.Create(_repository.GetById(id));
        }

        public ProductModel GetProductByName(string name)
        {
            return ProductModelBuilder.Create(_repository.GetSingle(x => x.Name == name));
        }

        public List<ProductModel> GetByPartialName(string name)
        {
            var productModels = new List<ProductModel>();

            foreach (var product in _repository.GetByName().Where(x => x.Name.Contains(name)))
            {
                productModels.Add(ProductModelBuilder.Create(product));
            }
            return productModels;
        }


        public ProductModel CreateProduct (ProductModel productC)
        {
            Product newProduct = new Product
            {
                Name = productC.name,
                Description = productC.description,
                Price = productC.price,
                PublicationDate = DateTime.Now
            };


            newProduct.Category = _context.Categories.Single(c => c.Id == productC.categoryId);

            return ProductModelBuilder.Create(_repository.Add(newProduct));

        }

        public ProductModel ModifyProduct(ProductModel productU)
        {
            Product productToUpdate = _repository.GetById(productU.id);
            if (productToUpdate == null)
            {
                throw new ArgumentException("Le produit est introuvable.");
            }
            else
            {
                productToUpdate.Name = productU.name;
                productToUpdate.Price = productU.price;
                productToUpdate.PublicationDate = DateTime.Now;
                productToUpdate.Description = productU.description;
            }
            return ProductModelBuilder.Create(_repository.Update(productToUpdate));           
        }

        public List<ProductModel> GetAllProducts()
        {
            var productModelList = new List<ProductModel>();

            foreach (var p in _repository.GetAll())
            {
                productModelList.Add(ProductModelBuilder.Create(p));
            }

            return productModelList;
        }    
        
    }
}
