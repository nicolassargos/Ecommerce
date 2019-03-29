using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EcommerceMVC.Models
{
    public class CategoryModel
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [ForeignKey("parentCategoryId")]
        public int parentCategoryId { get; set; }
        public List<CategoryModel> subCategories { get; set; }
    }
}