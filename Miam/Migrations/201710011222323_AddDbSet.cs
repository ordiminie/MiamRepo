namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MealId = c.Int(nullable: false),
                        MenuId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        MomentOfDay = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.MealId, cascadeDelete: true)
                .ForeignKey("dbo.Menus", t => t.MenuId, cascadeDelete: true)
                .Index(t => t.MealId)
                .Index(t => t.MenuId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MenuId", "dbo.Menus");
            DropForeignKey("dbo.MenuItems", "MealId", "dbo.Meals");
            DropIndex("dbo.MenuItems", new[] { "MenuId" });
            DropIndex("dbo.MenuItems", new[] { "MealId" });
            DropTable("dbo.MenuItems");
        }
    }
}
