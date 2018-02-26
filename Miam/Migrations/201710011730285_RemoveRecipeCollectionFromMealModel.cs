namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRecipeCollectionFromMealModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Menus", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.Menus", new[] { "Meal_Id" });
            DropColumn("dbo.Menus", "Meal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "Meal_Id", c => c.Int());
            CreateIndex("dbo.Menus", "Meal_Id");
            AddForeignKey("dbo.Menus", "Meal_Id", "dbo.Meals", "Id");
        }
    }
}
