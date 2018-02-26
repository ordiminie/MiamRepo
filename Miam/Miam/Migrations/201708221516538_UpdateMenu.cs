namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Menus", "Name", c => c.String());
            AddColumn("dbo.Menus", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Menus", "Description");
            DropColumn("dbo.Menus", "Name");
        }
    }
}
