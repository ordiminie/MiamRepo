namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropToRecipeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "NbServing", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "Instructions", c => c.String());
            AddColumn("dbo.Recipes", "CookingTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "PreparationTime", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "Level", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Level");
            DropColumn("dbo.Recipes", "PreparationTime");
            DropColumn("dbo.Recipes", "CookingTime");
            DropColumn("dbo.Recipes", "Instructions");
            DropColumn("dbo.Recipes", "NbServing");
        }
    }
}
