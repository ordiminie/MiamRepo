namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIngredientIdToIngredientIndexIdInIngredientRecipeModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngredientRecipes", "IngredientIndex_Id", "dbo.IngredientIndexes");
            DropIndex("dbo.IngredientRecipes", new[] { "IngredientIndex_Id" });
            RenameColumn(table: "dbo.IngredientRecipes", name: "IngredientIndex_Id", newName: "IngredientIndexId");
            AlterColumn("dbo.IngredientRecipes", "IngredientIndexId", c => c.Int(nullable: false));
            CreateIndex("dbo.IngredientRecipes", "IngredientIndexId");
            AddForeignKey("dbo.IngredientRecipes", "IngredientIndexId", "dbo.IngredientIndexes", "Id", cascadeDelete: true);
            DropColumn("dbo.IngredientRecipes", "IngredientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IngredientRecipes", "IngredientId", c => c.Int(nullable: false));
            DropForeignKey("dbo.IngredientRecipes", "IngredientIndexId", "dbo.IngredientIndexes");
            DropIndex("dbo.IngredientRecipes", new[] { "IngredientIndexId" });
            AlterColumn("dbo.IngredientRecipes", "IngredientIndexId", c => c.Int());
            RenameColumn(table: "dbo.IngredientRecipes", name: "IngredientIndexId", newName: "IngredientIndex_Id");
            CreateIndex("dbo.IngredientRecipes", "IngredientIndex_Id");
            AddForeignKey("dbo.IngredientRecipes", "IngredientIndex_Id", "dbo.IngredientIndexes", "Id");
        }
    }
}
