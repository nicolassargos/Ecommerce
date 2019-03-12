using System;

namespace Ecommerce.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime PublicationDate { get; set; }

        public virtual Category Category { get; set; }
    }
}