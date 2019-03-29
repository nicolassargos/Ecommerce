using System.ComponentModel.DataAnnotations;

namespace EcommerceMVC.Models
{
    public class ShoppingProductModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public int productId { get; set; }
        public int quantity { get; set; }
        public decimal pricePerUnit { get; set; }
    }
}