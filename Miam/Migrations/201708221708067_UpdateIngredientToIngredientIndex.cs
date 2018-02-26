namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIngredientToIngredientIndex : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Ingredients", newName: "IngredientIndexes");
            DropForeignKey("dbo.IngredientRecipes", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.IngredientRecipes", new[] { "IngredientId" });
            AddColumn("dbo.IngredientRecipes", "IngredientIndex_Id", c => c.Int());
            CreateIndex("dbo.IngredientRecipes", "IngredientIndex_Id");
            AddForeignKey("dbo.IngredientRecipes", "IngredientIndex_Id", "dbo.IngredientIndexes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientRecipes", "IngredientIndex_Id", "dbo.IngredientIndexes");
            DropIndex("dbo.IngredientRecipes", new[] { "IngredientIndex_Id" });
            DropColumn("dbo.IngredientRecipes", "IngredientIndex_Id");
            CreateIndex("dbo.IngredientRecipes", "IngredientId");
            AddForeignKey("dbo.IngredientRecipes", "IngredientId", "dbo.Ingredients", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.IngredientIndexes", newName: "Ingredients");
        }
    }
}
