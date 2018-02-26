namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecipeFormViewModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id", c => c.Int());
            CreateIndex("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id");
            AddForeignKey("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id", "dbo.IngredientRecipes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id", "dbo.IngredientRecipes");
            DropIndex("dbo.RecipeFormViewModels", new[] { "NewIngredientRecipe_Id" });
            DropColumn("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id");
        }
    }
}
