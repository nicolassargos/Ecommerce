namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Phone", c => c.String());
            AddColumn("dbo.Users", "CreationDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Users", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "CreationDate");
            DropColumn("dbo.Users", "Phone");
        }
    }
}
