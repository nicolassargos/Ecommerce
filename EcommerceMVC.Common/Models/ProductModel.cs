using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcommerceMVC.Models
{
    public class ProductModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string description { get; set; }
        [Required]
        public decimal price { get; set; }
        [Required]
        public DateTime publicationDate { get; set; }
        [Required]
        public int categoryId { get; set; }
        public string categoryName { get; set; }
    }
}