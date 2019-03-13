using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Models
{
    public class ShoppingCartModel
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public List<ShoppingProductModel> ShoppingProducts { get; set; }
    }
}
