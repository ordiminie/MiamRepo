namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMealIdFromMenuEntity : DbMigration
    {
        //// migration fait manuellement pour supprimer la cl� �trang�re 
        //// � jouer si cette cl� ne sert � rien (doute)
        public override void Up()
        {
        //    DropForeignKey("dbo.Menus", "Meal_Id", "dbo.Meals");
        //    DropIndex("dbo.Menus", new[] { "Meal_Id" });
        //    DropColumn("dbo.Menus", "Meal_Id");
        }

        public override void Down()
        {
        }
    }
}
