namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveListRecipesFromMealFormViewModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "MealFormViewModel_Id", "dbo.MealFormViewModels");
            DropIndex("dbo.Recipes", new[] { "MealFormViewModel_Id" });
            DropColumn("dbo.Recipes", "MealFormViewModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "MealFormViewModel_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "MealFormViewModel_Id");
            AddForeignKey("dbo.Recipes", "MealFormViewModel_Id", "dbo.MealFormViewModels", "Id");
        }
    }
}
