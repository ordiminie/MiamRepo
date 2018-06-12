namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeNullableMealIntoMenuItemModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuItems", "MealId", "dbo.Meals");
            DropIndex("dbo.MenuItems", new[] { "MealId" });
            AlterColumn("dbo.MenuItems", "MealId", c => c.Int());
            CreateIndex("dbo.MenuItems", "MealId");
            AddForeignKey("dbo.MenuItems", "MealId", "dbo.Meals", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuItems", "MealId", "dbo.Meals");
            DropIndex("dbo.MenuItems", new[] { "MealId" });
            AlterColumn("dbo.MenuItems", "MealId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenuItems", "MealId");
            AddForeignKey("dbo.MenuItems", "MealId", "dbo.Meals", "Id", cascadeDelete: true);
        }
    }
}
