namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecipeFVM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngredientRecipes", "RecipeFormViewModel_Id", "dbo.RecipeFormViewModels");
            DropForeignKey("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id", "dbo.IngredientRecipes");
            DropIndex("dbo.IngredientRecipes", new[] { "RecipeFormViewModel_Id" });
            DropIndex("dbo.RecipeFormViewModels", new[] { "NewIngredientRecipe_Id" });
            DropColumn("dbo.IngredientRecipes", "RecipeFormViewModel_Id");
            DropColumn("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id", c => c.Int());
            AddColumn("dbo.IngredientRecipes", "RecipeFormViewModel_Id", c => c.Int());
            CreateIndex("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id");
            CreateIndex("dbo.IngredientRecipes", "RecipeFormViewModel_Id");
            AddForeignKey("dbo.RecipeFormViewModels", "NewIngredientRecipe_Id", "dbo.IngredientRecipes", "Id");
            AddForeignKey("dbo.IngredientRecipes", "RecipeFormViewModel_Id", "dbo.RecipeFormViewModels", "Id");
        }
    }
}
