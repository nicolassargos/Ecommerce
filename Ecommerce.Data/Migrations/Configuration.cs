namespace Ecommerce.Data.Migrations
{
    using Ecommerce.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EcommerceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EcommerceContext context)
        {
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
            //var catTours = context.Categories.Where(c => c.Name == "Tours").SingleOrDefault();
            //context.Categories.Add(new Category() { Name = "Dell", ParentCategory = catTours, Products = null });
            //context.Categories.Add(new Category() { Name = "Lenovo", ParentCategory = catTours, Products = null });
            //context.Categories.Add(new Category() { Name = "HP", ParentCategory = catTours, Products = null });
            //context.SaveChanges();
        }
    }
}
