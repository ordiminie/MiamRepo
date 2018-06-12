namespace Miam.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Miam.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            #region AJOUT DES INGREDIENTS POUR 2 RECETTES
            //context.IngredientRecipe.AddOrUpdate(
            //    i => i.Id,
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "pomme de terre").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "omelette de pommes de terre").Id,
            //        Quantity = 3,
            //        Size = "petites"
            //    },
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "oeuf").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "omelette de pommes de terre").Id,
            //        Quantity = 6
            //    },
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "sel").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "omelette de pommes de terre").Id
            //    },
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "poivre").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "omelette de pommes de terre").Id
            //    }
            //);

            //context.IngredientRecipe.AddOrUpdate(
            //    i => i.Id,
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "pomme de terre").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "gratin dauphinois").Id,
            //        Quantity = 3,
            //        Size = "petites"
            //    },
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "crème").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "gratin dauphinois").Id,
            //        WeightCl = 25
            //    },
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "sel").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "gratin dauphinois").Id
            //    },
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "poivre").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "gratin dauphinois").Id
            //    },
            //    new IngredientRecipe
            //    {
            //        IngredientIndexId = context.IngredientIndex.FirstOrDefault(i => i.Name == "beurre").Id,
            //        RecipeId = context.Recipe.FirstOrDefault(r => r.Name == "gratin dauphinois").Id,
            //        WeightGrams = 10
            //    }
            //);
            #endregion

            #region AJOUT DONNEES MEAL + TABLE DE LIAISON MEALRECIPE
            //// Lundi midi
            //Meal meal1 = new Meal
            //{
            //    DayOfWeek = "lundi",
            //    MomentOfDay = "midi",
            //    NbServings = 4,
            //    RecipesCollection = new List<Recipe>()

            //};
            //Recipe omelette = context.Recipe.FirstOrDefault(r => r.Name == "omelette de pommes de terre");
            //meal1.RecipesCollection.Add(omelette);


            //// jeudi soir
            //Meal meal2 = new Meal
            //{
            //    DayOfWeek = "jeudi",
            //    MomentOfDay = "soir",
            //    NbServings = 4,
            //    RecipesCollection = new List<Recipe>()

            //};
            //Recipe gratin = context.Recipe.FirstOrDefault(r => r.Name == "gratin dauphinois");
            //meal2.RecipesCollection.Add(gratin);
            //meal2.RecipesCollection.Add(omelette);


            //context.Meal.AddOrUpdate(meal1);
            //context.Meal.AddOrUpdate(meal2);
            #endregion


            #region AJOUT DONNEES MENU + TABLE DE LIAISON MENUMEAL
            //Meal meal1 = context.Meal.FirstOrDefault(m => m.DayOfWeek == "lundi");
            //Meal meal2 = context.Meal.firstordefault(m => m.dayofweek == "jeudi");
            //Menu menu = new Menu
            //{
            //    begindate = datetime.today,
            //    mealcollection = new list<meal>()
            //};

            //menu.mealcollection.add(meal1);
            //menu.mealcollection.add(meal2);

            //context.menu.add(menu);


            #endregion

            #region AJOUT DONNEES MEAL + TABLE DE LIAISON RECIPEMEAL
            //Recipe recipe14 = context.Recipe.FirstOrDefault(m => m.Id == 14);
            //Recipe recipe15 = context.Recipe.FirstOrDefault(m => m.Id == 15);
            //Meal meal1 = new Meal();
            //meal1.RecipeCollection = new List<Recipe>();
            //meal1.RecipeCollection.Add(recipe15);
            //meal1.RecipeCollection.Add(recipe14);
            //meal1.Name = "repas 2";

            //context.Meal.AddOrUpdate(meal1);
            #endregion

            #region AJOUT DONNEES MENU + MENUITEM
            //// Menu menu1 = context.Menu.FirstOrDefault(m => m.Id == 3);
            //Menu menu1 = new Menu();
            //menu1.Name = "été 2016";
            //menu1.Duration = 14;
            //menu1.BeginDate = new DateTime(2017, 06, 23);
            //menu1.Description = "14 jours de repas programmé";
            //context.Menu.AddOrUpdate(menu1);

            //MenuItem menuItem = new MenuItem
            //{
            //    Date = new DateTime(2017, 06, 05),
            //    MenuId = context.Menu.FirstOrDefault(m => m.Name == "été 2016").Id,
            //    MealId = 4
            //    , MealType = Shared.MealTypeEnum.Evening
            //};
            //context.MenuItem.AddOrUpdate(menuItem);

            //MenuItem menuItem2 = new MenuItem
            //{
            //    Date = new DateTime(2017, 10, 18),
            //    MenuId = context.Menu.FirstOrDefault(m => m.Name == "été 2016").Id,
            //    MealId = 22
            //    , MealType = Shared.MealTypeEnum.Noon
            //};
            //context.MenuItem.AddOrUpdate(menuItem2);

            #endregion

        }
    }
}
