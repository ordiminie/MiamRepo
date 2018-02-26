namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WhenEverYouHaveToUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Level", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Level", c => c.Int(nullable: false));
        }
    }
}
