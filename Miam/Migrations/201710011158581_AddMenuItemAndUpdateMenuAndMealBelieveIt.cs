namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMenuItemAndUpdateMenuAndMealBelieveIt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuMeals", "Menu_Id", "dbo.Menus");
            DropForeignKey("dbo.MenuMeals", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.MenuMeals", new[] { "Menu_Id" });
            DropIndex("dbo.MenuMeals", new[] { "Meal_Id" });
            AddColumn("dbo.Menus", "Meal_Id", c => c.Int());
            AlterColumn("dbo.Menus", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Menus", "Description", c => c.String(maxLength: 500));
            CreateIndex("dbo.Menus", "Meal_Id");
            AddForeignKey("dbo.Menus", "Meal_Id", "dbo.Meals", "Id");
            DropColumn("dbo.Meals", "NbServings");
            DropColumn("dbo.Menus", "DayOfWeek");
            DropColumn("dbo.Menus", "MomentOfDay");
            DropColumn("dbo.Menus", "BeginDay");
            DropTable("dbo.MenuMeals");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MenuMeals",
                c => new
                    {
                        Menu_Id = c.Int(nullable: false),
                        Meal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Menu_Id, t.Meal_Id });
            
            AddColumn("dbo.Menus", "BeginDay", c => c.Int(nullable: false));
            AddColumn("dbo.Menus", "MomentOfDay", c => c.String());
            AddColumn("dbo.Menus", "DayOfWeek", c => c.String());
            AddColumn("dbo.Meals", "NbServings", c => c.Int(nullable: false));
            DropForeignKey("dbo.Menus", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.Menus", new[] { "Meal_Id" });
            AlterColumn("dbo.Menus", "Description", c => c.String());
            AlterColumn("dbo.Menus", "Name", c => c.String());
            DropColumn("dbo.Menus", "Meal_Id");
            CreateIndex("dbo.MenuMeals", "Meal_Id");
            CreateIndex("dbo.MenuMeals", "Menu_Id");
            AddForeignKey("dbo.MenuMeals", "Meal_Id", "dbo.Meals", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MenuMeals", "Menu_Id", "dbo.Menus", "Id", cascadeDelete: true);
        }
    }
}
