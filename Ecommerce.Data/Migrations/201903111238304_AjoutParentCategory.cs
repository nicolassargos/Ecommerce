namespace Ecommerce.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AjoutParentCategory : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Categories", name: "Category_Id", newName: "ParentCategory_Id");
            RenameIndex(table: "dbo.Categories", name: "IX_Category_Id", newName: "IX_ParentCategory_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Categories", name: "IX_ParentCategory_Id", newName: "IX_Category_Id");
            RenameColumn(table: "dbo.Categories", name: "ParentCategory_Id", newName: "Category_Id");
        }
    }
}
