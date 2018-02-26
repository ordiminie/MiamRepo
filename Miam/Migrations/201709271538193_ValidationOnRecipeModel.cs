namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationOnRecipeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Instructions", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Instructions", c => c.String());
        }
    }
}
