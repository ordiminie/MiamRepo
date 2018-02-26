namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMealModel : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Meals", "DayOfWeek");
            DropColumn("dbo.Meals", "MomentOfDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "MomentOfDay", c => c.String());
            AddColumn("dbo.Meals", "DayOfWeek", c => c.String());
        }
    }
}
