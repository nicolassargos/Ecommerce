using Ecommerce.Data.Entities;
using Ecommerce.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Ecommerce.Data
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext() : base("name=EcommerceContext")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ShoppingProduct> ShoppingProducts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
    }
}
