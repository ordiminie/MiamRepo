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
            //Meal meal2 = context.Meal.FirstOrDefault(m => m.DayOfWeek == "jeudi");
            //Menu menu = new Menu
            //{
            //    BeginDate = DateTime.Today,
            //    MealCollection = new List<Meal>()
            //};

            //menu.MealCollection.Add(meal1);
            //menu.MealCollection.Add(meal2);

            //context.Menu.Add(menu);
            #endregion
        }
    }
}
