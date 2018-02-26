namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSizeEnumToRecipeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IngredientRecipes", "SizeTmp", c => c.Int());
            DropColumn("dbo.IngredientRecipes", "Size");
            RenameColumn("dbo.IngredientRecipes", "SizeTmp", "Size");

        }
        
        public override void Down()
        {
            AddColumn("dbo.IngredientRecipes", "SizeBack", c => c.String());
            DropColumn("dbo.IngredientRecipes", "Size");
            RenameColumn("dbo.IngredientRecipes", "SizeBack", "Size");
        }
    }
}
