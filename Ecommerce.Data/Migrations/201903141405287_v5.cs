namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String());
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "Name");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Users", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Email", c => c.String());
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "Password");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
