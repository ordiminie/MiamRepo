namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuFormViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Menu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menus", t => t.Menu_Id)
                .Index(t => t.Menu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuFormViewModels", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.MenuFormViewModels", new[] { "Menu_Id" });
            DropTable("dbo.MenuFormViewModels");
        }
    }
}
