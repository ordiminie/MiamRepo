namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMealAndMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "DayOfWeek", c => c.String());
            AddColumn("dbo.Menus", "MomentOfDay", c => c.String());
            AddColumn("dbo.Menus", "BeginDay", c => c.Int(nullable: false));
            DropColumn("dbo.Meals", "DayOfWeek");
            DropColumn("dbo.Meals", "MomentOfDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Meals", "MomentOfDay", c => c.String());
            AddColumn("dbo.Meals", "DayOfWeek", c => c.String());
            DropColumn("dbo.Menus", "BeginDay");
            DropColumn("dbo.Menus", "MomentOfDay");
            DropColumn("dbo.Menus", "DayOfWeek");
        }
    }
}
