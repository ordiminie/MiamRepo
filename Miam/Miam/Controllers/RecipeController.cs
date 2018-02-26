using Miam.Models;
using Miam.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miam.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext _ctx;

        public RecipeController()
        {
            _ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }


        // Display all recipe
        public ActionResult Index()
        {
            DbSet<Recipe> recipes = GetRecipes();
            return View(recipes.ToList());
        }

        public ActionResult Detail(int id)
        {
            RecipeFormViewModel recipe = new RecipeFormViewModel
            {
                Recipe = _ctx.Recipe.FirstOrDefault(r => r.Id == id),
                IngredientsRecipe = _ctx.IngredientRecipe.Include(i => i.IngredientIndex).Where(i => i.RecipeId == id)
            };
            
            return View(recipe);
        }

        public ActionResult New()
        {
            List<IngredientRecipe> ingRecipe = new List<IngredientRecipe>();
            ingRecipe.Add(new IngredientRecipe());

            RecipeFormViewModel recipeFVM = new RecipeFormViewModel()
            {
                Recipe = new Recipe(),
                IngredientsRecipe = ingRecipe
            };
            
            return View("RecipeForm", recipeFVM);
        }
        public ActionResult Edit(int id)
        {
            Recipe recipe =_ctx.Recipe.FirstOrDefault(m => m.Id == id);

            RecipeFormViewModel recipeFVM = new RecipeFormViewModel()
            {
                Recipe = recipe,
                IngredientsRecipe = _ctx.IngredientRecipe.Include(m => m.IngredientIndex).Where(m => m.RecipeId == recipe.Id).ToList()
            };


            return View("RecipeForm", recipeFVM);
        }

        //[HttpPost]
        public ActionResult AddOrUpdate(RecipeFormViewModel recipeFVM)
        {
            int recipeId = 0;
            if (recipeFVM.Recipe == null)
                ViewBag.MessageError = "Il n'y a aucune recette à ajouter";

            //// on est en train d'éditer la recette, on récupère les ingrédients associés
            //if (recipeFVM.IngredientsRecipe == null)
            //    recipeFVM.IngredientsRecipe = _ctx.IngredientRecipe.Where(m => m.Recipe.Id == recipeFVM.Recipe.Id).ToList();

            if (recipeFVM.Recipe.Id > 0)
            {
                // Edit recipe
                Recipe recipeFromDb = _ctx.Recipe.FirstOrDefault(m => m.Id == recipeFVM.Recipe.Id);

                if (recipeFromDb == null)
                    return HttpNotFound();

                // pas utile recipeFromDb.Id = recipeFVM.Recipe.Id;
                recipeFromDb.Instructions = recipeFVM.Recipe.Instructions;
                recipeFromDb.CookingTime = recipeFVM.Recipe.CookingTime;
                recipeFromDb.Level = recipeFVM.Recipe.Level;
                recipeFromDb.Name = recipeFVM.Recipe.Name;
                recipeFromDb.NbServing = recipeFVM.Recipe.NbServing;
                recipeFromDb.PreparationTime = recipeFVM.Recipe.PreparationTime;

                _ctx.SaveChanges();

                recipeId = recipeFromDb.Id;
                ViewBag.MessageSuccess = "La recette a bien été modifiée.";
            }
            else
            {
                // Add recipe
                Recipe newRecipe = new Recipe()
                {
                    Id = recipeFVM.Recipe.Id,
                    Instructions = recipeFVM.Recipe.Instructions,
                    CookingTime = recipeFVM.Recipe.CookingTime,
                    Level = recipeFVM.Recipe.Level,
                    Name = recipeFVM.Recipe.Name,
                    NbServing = recipeFVM.Recipe.NbServing,
                    PreparationTime = recipeFVM.Recipe.PreparationTime
                };

                _ctx.Recipe.Add(newRecipe);
                _ctx.SaveChanges();

                recipeId = newRecipe.Id;
                ViewBag.MessageSuccess = "La recette a bien été ajoutée.";
            }


            return RedirectToAction("Detail", new { id = recipeId });
        }

    

        public ActionResult Delete(int id)
        {
            // Delete ingredients
            List<IngredientRecipe> ListIngredient = _ctx.IngredientRecipe.Where(m => m.RecipeId == id).ToList();

            if (ListIngredient != null)
            {
                // TODO Afficher un message de confirmation client-side
                
                foreach(IngredientRecipe ing in ListIngredient)
                {
                    _ctx.IngredientRecipe.Remove(ing);
                }
            }

            // Delete recipe
            Recipe recipeToDelete = _ctx.Recipe.FirstOrDefault(m => m.Id == id);

            if (recipeToDelete == null)
                return HttpNotFound();
            
            _ctx.Recipe.Remove(recipeToDelete);

            // Save all the changes in db
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }


        // Get all recipes
        private DbSet<Recipe> GetRecipes()
        {
            return _ctx.Recipe;
        }
    }
}