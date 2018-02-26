namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMeal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Meals", "DayOfWeek", c => c.String());
            AddColumn("dbo.Meals", "MomentOfDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Meals", "MomentOfDay");
            DropColumn("dbo.Meals", "DayOfWeek");
        }
    }
}
