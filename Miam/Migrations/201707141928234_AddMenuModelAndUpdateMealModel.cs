namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuModelAndUpdateMealModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuMeals",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Meal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Meal_Id })
                .ForeignKey("dbo.Menus", t => t.Menu_Id, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Meal_Id, cascadeDelete: true)
                .Index(t => t.Menu_Id)
                .Index(t => t.Meal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuMeals", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.MenuMeals", "Menu_Id", "dbo.Menus");
            DropIndex("dbo.MenuMeals", new[] { "Meal_Id" });
            DropIndex("dbo.MenuMeals", new[] { "Menu_Id" });
            DropTable("dbo.MenuMeals");
            DropTable("dbo.Menus");
        }
    }
}
