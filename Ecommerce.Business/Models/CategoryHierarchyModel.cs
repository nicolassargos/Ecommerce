using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Business.Helpers
{
    public class CategoryHierarchyModel
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public List<CategoryHierarchyModel> subCategories { get; set; }
    }
}