using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceMVC.Models
{
    public class ShoppingCartModel
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public List<ShoppingProductModel> shoppingProducts { get; set; }
        public decimal totalAmount
        {
            get
            {
                if (shoppingProducts.Count == 0) return 0L;

                decimal total = 0;
                foreach (var elt in shoppingProducts)
                {
                    total += elt.pricePerUnit * elt.quantity;
                }
                return total;
            }
        }
    }
}
