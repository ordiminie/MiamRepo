namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWeightToQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.IngredientRecipes", "WeightGrams", c => c.Int());
            AddColumn("dbo.IngredientRecipes", "WeightCl", c => c.Int());
            DropColumn("dbo.IngredientRecipes", "Weight");
        }
        
        public override void Down()
        {
            AddColumn("dbo.IngredientRecipes", "Weight", c => c.Int());
            DropColumn("dbo.IngredientRecipes", "WeightCl");
            DropColumn("dbo.IngredientRecipes", "WeightGrams");
        }
    }
}
