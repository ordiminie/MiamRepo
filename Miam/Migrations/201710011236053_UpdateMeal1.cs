namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeal1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "NbServings", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "NbServings");
        }
    }
}
