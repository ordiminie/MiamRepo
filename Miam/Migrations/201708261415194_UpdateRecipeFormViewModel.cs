namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRecipeFormViewModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id)
                .Index(t => t.Recipe_Id);
            
            AddColumn("dbo.IngredientRecipes", "RecipeFormViewModel_Id", c => c.Int());
            CreateIndex("dbo.IngredientRecipes", "RecipeFormViewModel_Id");
            AddForeignKey("dbo.IngredientRecipes", "RecipeFormViewModel_Id", "dbo.RecipeFormViewModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeFormViewModels", "Recipe_Id", "dbo.Recipes");
            DropForeignKey("dbo.IngredientRecipes", "RecipeFormViewModel_Id", "dbo.RecipeFormViewModels");
            DropIndex("dbo.RecipeFormViewModels", new[] { "Recipe_Id" });
            DropIndex("dbo.IngredientRecipes", new[] { "RecipeFormViewModel_Id" });
            DropColumn("dbo.IngredientRecipes", "RecipeFormViewModel_Id");
            DropTable("dbo.RecipeFormViewModels");
        }
    }
}
