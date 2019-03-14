namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modifs : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.Users", "CreationDate");
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "CompanyName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "CompanyName", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String());
        }
    }
}
