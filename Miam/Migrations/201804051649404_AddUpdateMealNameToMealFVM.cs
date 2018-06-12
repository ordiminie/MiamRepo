namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUpdateMealNameToMealFVM : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MealFormViewModels", "UpdateMealName", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MealFormViewModels", "UpdateMealName");
        }
    }
}
