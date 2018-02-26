namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealModelAndUpdateRecipeModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DayOfWeek = c.String(),
                        MomentOfDay = c.String(),
                        NbServings = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MealRecipes",
                c => new
                    {
                        Meal_Id = c.Int(nullable: false),
                        Recipe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Meal_Id, t.Recipe_Id })
                .ForeignKey("dbo.Meals", t => t.Meal_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .Index(t => t.Meal_Id)
                .Index(t => t.Recipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealRecipes", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.MealRecipes", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.MealRecipes", new[] { "Recipe_Id" });
            DropIndex("dbo.MealRecipes", new[] { "Meal_Id" });
            DropTable("dbo.MealRecipes");
            DropTable("dbo.Meals");
        }
    }
}
