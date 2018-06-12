namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTestDateToMenuFVM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuFormViewModels", "TestDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MenuFormViewModels", "TestDate");
        }
    }
}
