namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIngredientRecipeFormViewModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientRecipeFormViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientsRecipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IngredientRecipes", t => t.IngredientsRecipe_Id)
                .Index(t => t.IngredientsRecipe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientRecipeFormViewModels", "IngredientsRecipe_Id", "dbo.IngredientRecipes");
            DropIndex("dbo.IngredientRecipeFormViewModels", new[] { "IngredientsRecipe_Id" });
            DropTable("dbo.IngredientRecipeFormViewModels");
        }
    }
}
