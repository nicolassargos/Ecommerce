namespace Ecommerce.Data.Migrations
{
    using Ecommerce.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ecommerce.Data.EcommerceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Ecommerce.Data.EcommerceContext context)
        {
            context.Database.ExecuteSqlCommand("DELETE FROM [ShoppingProducts]");

            context.Database.ExecuteSqlCommand("DELETE FROM [Products]");
            context.Database.ExecuteSqlCommand("DELETE FROM [Categories]");

            context.Database.ExecuteSqlCommand("ALTER TABLE [Categories] NOCHECK CONSTRAINT ALL");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Categories', RESEED, 0)");

            context.Database.ExecuteSqlCommand("ALTER TABLE [Categories] CHECK CONSTRAINT ALL");

            context.Database.ExecuteSqlCommand("ALTER TABLE [Products] NOCHECK CONSTRAINT ALL");

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Products', RESEED, 0)");

            context.Database.ExecuteSqlCommand("ALTER TABLE [Products] CHECK CONSTRAINT ALL");

            


            // Principales catégories
            context.Categories.Add(new Category() { Name = "Informatique", ParentCategory = null, Products = null });
            context.Categories.Add(new Category() { Name = "Tv & Audio", ParentCategory = null, Products = null });
            context.Categories.Add(new Category() { Name = "Téléphonie", ParentCategory = null, Products = null });
            context.SaveChanges();

            // Catégorie Informatique
            var catInfo = context.Categories.Where(c => c.Name == "Informatique").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Ecrans", ParentCategory = catInfo, Products = null });
            context.Categories.Add(new Category() { Name = "Tours", ParentCategory = catInfo, Products = null });
            context.Categories.Add(new Category() { Name = "Accessoires", ParentCategory = catInfo, Products = null });
            context.SaveChanges();

            // Catégorie Ecrans
            var catEcrans = context.Categories.Where(c => c.Name == "Ecrans").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Iiyama", ParentCategory = catEcrans, Products = null });
            context.Categories.Add(new Category() { Name = "Lenovo", ParentCategory = catEcrans, Products = null });
            context.SaveChanges();

            // Catégorie Tours
            var catTours = context.Categories.Where(c => c.Name == "Tours").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Dell", ParentCategory = catTours, Products = null });
            context.Categories.Add(new Category() { Name = "Lenovo", ParentCategory = catTours, Products = null });
            context.Categories.Add(new Category() { Name = "HP", ParentCategory = catTours, Products = null });
            context.SaveChanges();

            // Catégorie Accessoires
            var catAcc = context.Categories.Where(c => c.Name == "Accessoires").SingleOrDefault();
            context.Categories.Add(new Category() { Name = "Souris", ParentCategory = catAcc, Products = null });
            context.Categories.Add(new Category() { Name = "Claviers", ParentCategory = catAcc, Products = null });
            context.SaveChanges();

            var product = context.Products.Add(new Product()
            {
                Name = "Laptop Vaio",
                Description = "Ordinateur Portable",
                Price = 1357,
                PublicationDate = DateTime.Now,
                Category = context.Categories.First(x => x.Name == "Dell")
            });

            context.SaveChanges();

            var product1 = context.Products.Add(new Product()
            {
                Name = "Laptop Apple",
                Description = "Ordinateur Portable",
                Price = 9999,
                PublicationDate = DateTime.Now,
                Category = context.Categories.First(x => x.Name == "Dell")
            });


            context.Database.ExecuteSqlCommand("ALTER TABLE [ShoppingProducts] NOCHECK CONSTRAINT ALL");
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('ShoppingProducts', RESEED, 0)");
            context.Database.ExecuteSqlCommand("ALTER TABLE [ShoppingProducts] CHECK CONSTRAINT ALL");


            context.SaveChanges();

        }
    }
}
