namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddWeekNumberToMenuItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItems", "WeekNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuItems", "WeekNumber");
        }
    }
}
