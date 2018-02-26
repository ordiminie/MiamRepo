namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuBeginDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "BeginDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "BeginDay");
        }
    }
}
