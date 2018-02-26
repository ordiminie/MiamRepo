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
    public class IngredientRecipeController : Controller
    {
        private ApplicationDbContext _ctx;

        public IngredientRecipeController()
        {
            _ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

        // GET: IngredientRecipe
        public ActionResult Index()
        {
            List<IngredientRecipe> ingRecipe = _ctx.IngredientRecipe.Include(m => m.IngredientIndex)
                                                                    .Include(m => m.Recipe)
                                                                    .ToList();
            return View(ingRecipe);
        }


        public ActionResult New(int recipeId)
        {
            IngredientRecipeFormViewModel ingRecipeFVM = new IngredientRecipeFormViewModel();
            ingRecipeFVM.IngredientsRecipe = new IngredientRecipe() { RecipeId = recipeId };
            ingRecipeFVM.IngredientsIndexForDropDown = _ctx.IngredientIndex.ToList();
            return View("Form", ingRecipeFVM);
                
        }

        public ActionResult Edit(int id)
        {
            if (id == 0)
                return HttpNotFound();

            IngredientRecipe ingRecipeInDb = _ctx.IngredientRecipe.Include(m => m.IngredientIndex)
                                                                  .FirstOrDefault(m => m.Id == id);
            IngredientRecipeFormViewModel ingRecipeFVM = new IngredientRecipeFormViewModel()
            {
                IngredientsRecipe = ingRecipeInDb,
                IngredientsIndexForDropDown = _ctx.IngredientIndex.ToList()
            };

            return View("Form", ingRecipeFVM);

            
        }

        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(IngredientRecipeFormViewModel ingredient)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MessageError = "Il y a des erreurs dans le formulaire";
                return View("Form", ingredient);
            }

            if (ingredient == null)
            {
                return HttpNotFound();
            }

            if (ingredient.IngredientsRecipe.Id > 0)
            {
                IngredientRecipe ingredientFromDb = _ctx.IngredientRecipe.Include(m => m.IngredientIndex).FirstOrDefault(m => m.Id == ingredient.IngredientsRecipe.Id);

                if (ingredientFromDb == null)
                    return HttpNotFound();

                ingredientFromDb.IngredientIndexId = ingredient.IngredientsRecipe.IngredientIndexId;
                ingredientFromDb.Quantity = ingredient.IngredientsRecipe.Quantity;
                ingredientFromDb.Size = ingredient.IngredientsRecipe.Size;
                ingredientFromDb.WeightCl = ingredient.IngredientsRecipe.WeightCl;
                ingredientFromDb.WeightGrams = ingredient.IngredientsRecipe.WeightGrams;

                _ctx.SaveChanges();

                TempData["MessageSuccess"] = "L'ingrédient a bien été modifiée.";
            }
            else
            {
                IngredientRecipe newIngredient = new IngredientRecipe()
                {
                    RecipeId = ingredient.IngredientsRecipe.RecipeId,
                    IngredientIndexId = ingredient.IngredientsRecipe.IngredientIndexId,
                    Quantity = ingredient.IngredientsRecipe.Quantity,
                    Size = ingredient.IngredientsRecipe.Size,
                    WeightCl = ingredient.IngredientsRecipe.WeightCl,
                    WeightGrams = ingredient.IngredientsRecipe.WeightGrams                    
                };
                
                _ctx.IngredientRecipe.Add(newIngredient);
                _ctx.SaveChanges();

                TempData["MessageSuccess"] = "L'ingrédient a bien été ajouté.";
            }
            

            return RedirectToAction("Detail", "Recipe", new { id = ingredient.IngredientsRecipe.RecipeId });
        }

        public ActionResult Delete(int id)
        {
            IngredientRecipe ingRecipe = _ctx.IngredientRecipe.FirstOrDefault(m => m.Id == id);

            if (ingRecipe == null)
                return HttpNotFound();

            _ctx.IngredientRecipe.Remove(ingRecipe);
            _ctx.SaveChanges();

            TempData["MessageSuccess"] = "L'ingrédient a bien été supprimé.";

            return RedirectToAction("Detail", "Recipe", new { id = ingRecipe.RecipeId });
        }

    }
}