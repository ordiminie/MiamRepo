namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeRequiredBeginDateInMenuModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Menus", "BeginDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Menus", "BeginDate", c => c.DateTime());
        }
    }
}
