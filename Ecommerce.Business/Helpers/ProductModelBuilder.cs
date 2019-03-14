using Ecommerce.Business.Models;
using Ecommerce.Entities;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Helpers
{
    public static class ProductModelBuilder
    {
        public static ProductModel Create(Product product)
        {
            if (product == null) return null;

            return new ProductModel
            {
                id = product.Id,
                name = product.Name,
                price = product.Price,
                description = product.Description,
                publicationDate = product.PublicationDate,
                categoryId = product.Category.Id,
                categoryName = product.Category.Name
            };
        }
    }
}
