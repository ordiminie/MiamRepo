namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMealTypeEnumToMenuItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MenuItems", "MealType", c => c.Int(nullable: false));
            DropColumn("dbo.MenuItems", "MomentOfDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MenuItems", "MomentOfDay", c => c.String());
            DropColumn("dbo.MenuItems", "MealType");
        }
    }
}
