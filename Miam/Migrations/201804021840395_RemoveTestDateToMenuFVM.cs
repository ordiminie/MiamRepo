namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveTestDateToMenuFVM : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MenuFormViewModels", "TestDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuFormViewModels", "TestDate", c => c.DateTime(nullable: false));
        }
    }
}
