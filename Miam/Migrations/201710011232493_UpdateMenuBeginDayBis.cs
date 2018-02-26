namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuBeginDayBis : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Duration", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "BeginDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Menus", "BeginDay", c => c.Int(nullable: false));
            DropColumn("dbo.Menus", "Duration");
        }
    }
}
