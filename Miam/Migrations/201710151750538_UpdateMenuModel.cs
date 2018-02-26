namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMenuModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "Name", c => c.String(maxLength: 50));
        }
    }
}
