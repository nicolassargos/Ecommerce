namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoifsShppingCart : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShoppingProducts", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShoppingProducts", "Quantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
