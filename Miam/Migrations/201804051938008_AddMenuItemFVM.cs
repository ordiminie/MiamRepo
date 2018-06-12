namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuItemFVM : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItemFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuItems", t => t.MenuItem_Id)
                .Index(t => t.MenuItem_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItemFormViewModels", "MenuItem_Id", "dbo.MenuItems");
            DropIndex("dbo.MenuItemFormViewModels", new[] { "MenuItem_Id" });
            DropTable("dbo.MenuItemFormViewModels");
        }
    }
}
