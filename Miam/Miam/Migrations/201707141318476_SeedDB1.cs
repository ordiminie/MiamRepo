namespace Miam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDB1 : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO dbo.Ingredients (Name, Description) VALUES ('pomme de terre', 'Pomme de terre ferme')");
            Sql("INSERT INTO dbo.Ingredients (Name, Description) VALUES ('oeuf', null)");
            Sql("INSERT INTO dbo.Ingredients (Name, Description) VALUES ('crème', 'crème liquide 15% max')");
            Sql("INSERT INTO dbo.Ingredients (Name, Description) VALUES ('fromage', null)");
            Sql("INSERT INTO dbo.Ingredients (Name, Description) VALUES ('sel', null)");
            Sql("INSERT INTO dbo.Ingredients (Name, Description) VALUES ('poivre', null)");
            Sql("INSERT INTO dbo.Ingredients (Name, Description) VALUES ('beurre', null)");
            
            Sql("INSERT INTO dbo.Recipes (Name) VALUES ('omelette de pommes de terre')");
            Sql("INSERT INTO dbo.Recipes (Name) VALUES ('gratin dauphinois')");
        }
        
        public override void Down()
        {
        }
    }
}
