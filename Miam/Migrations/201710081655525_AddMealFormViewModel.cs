namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealFormViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MealFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Meal_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Meals", t => t.Meal_Id)
                .Index(t => t.Meal_Id);
            
            AddColumn("dbo.Recipes", "MealFormViewModel_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "MealFormViewModel_Id");
            AddForeignKey("dbo.Recipes", "MealFormViewModel_Id", "dbo.MealFormViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MealFormViewModels", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.Recipes", "MealFormViewModel_Id", "dbo.MealFormViewModels");
            DropIndex("dbo.MealFormViewModels", new[] { "Meal_Id" });
            DropIndex("dbo.Recipes", new[] { "MealFormViewModel_Id" });
            DropColumn("dbo.Recipes", "MealFormViewModel_Id");
            DropTable("dbo.MealFormViewModels");
        }
    }
}
