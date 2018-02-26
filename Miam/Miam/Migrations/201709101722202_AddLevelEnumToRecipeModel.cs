namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLevelEnumToRecipeModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Level", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Level", c => c.String());
        }
    }
}
