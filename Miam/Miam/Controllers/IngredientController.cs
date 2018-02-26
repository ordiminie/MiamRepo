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
    public class IngredientController : Controller
    {
        private ApplicationDbContext _ctx;

        public IngredientController()
        {
            _ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

        // Display all ingredients
        public ActionResult Index()
        {
            DbSet<IngredientIndex> dbIngredient =  GetDbSetIngredient();
            return View(dbIngredient.ToList());
        }

        public ActionResult Detail(int Id)
        {
            IngredientIndex ingredient = GetDbSetIngredient().FirstOrDefault(i => i.Id == Id);
            if (ingredient == null)
                return new HttpNotFoundResult("Ingrédient non trouvé");

            return View(ingredient);
        }
        
        public ActionResult New()
        {
            return View("IngredientForm", new IngredientFormViewModel() { Ingredient = new IngredientIndex() });
        }

        public ActionResult Edit(int Id)
        {
            IngredientIndex ingredient = _ctx.IngredientIndex.FirstOrDefault(m => m.Id == Id);

            if (ingredient == null)
                return HttpNotFound();

            IngredientFormViewModel ingredientFormViewModel = new IngredientFormViewModel() { Ingredient = new IngredientIndex() };
            ingredientFormViewModel.Ingredient.Id = ingredient.Id;
            ingredientFormViewModel.Ingredient.Name = ingredient.Name;
            ingredientFormViewModel.Ingredient.Description = ingredient.Description;

            return View("IngredientForm", ingredientFormViewModel);
        }


        public ActionResult AddOrUpdate(IngredientIndex ingredient)
        {
            if (ingredient.Id > 0)
            {
                // Màj de l'ingrédient
                IngredientIndex ingredientFromDb = _ctx.IngredientIndex.FirstOrDefault(m => m.Id == ingredient.Id);

                if (ingredientFromDb == null)
                    return HttpNotFound();

                ingredientFromDb.Name = ingredient.Name;
                ingredientFromDb.Description = ingredient.Description;
            }
            else
            {
                // Ajout d'un ingrédient
                _ctx.IngredientIndex.Add(ingredient);
            }
            
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete (int Id)
        {
            IngredientIndex ingredient = _ctx.IngredientIndex.FirstOrDefault(m => m.Id == Id);

            if (ingredient == null)
                return HttpNotFound();

            _ctx.IngredientIndex.Remove(ingredient);
            _ctx.SaveChanges();
            return RedirectToAction("Index");
        }


        private DbSet<IngredientIndex> GetDbSetIngredient()
        {
            return _ctx.IngredientIndex;
        }
 
    }
}