namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifNico : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "Email", c => c.String());
            DropColumn("dbo.Users", "UserName");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "UserName", c => c.String());
            DropColumn("dbo.Users", "Email");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "Name");
        }
    }
}
