using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Ecommerce.Models
{
    public class ProductsModel
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public DateTime publicationDate { get; set; }
        [ForeignKey("categoryId")]
        [Required]
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}