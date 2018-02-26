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
    public class MealController : Controller
    {
        ApplicationDbContext _ctx;

        public MealController()
        {
            _ctx = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }


        // GET: Meal
        public ActionResult Index()
        {
            List<Meal> meals = GetListMeals();
            return View(meals);
        }

        public ActionResult Detail(int id)
        {
            Meal meal = GetMealById(id);
            ViewBag.MessageSuccess = TempData["MessageSuccess"];

            return View("Detail", meal);
               
        }

        public ActionResult New()
        {
            MealFormViewModel mealFVM = new MealFormViewModel();
            mealFVM.Meal = new Meal();
            mealFVM.ListRecipesForDropDown = _ctx.Recipe.ToList();

            return View("MealForm", mealFVM);
        }

        public ActionResult Edit(int id)
        {
            MealFormViewModel mealFVM = new MealFormViewModel();
            mealFVM.Meal = GetMealById(id);

            mealFVM.ListRecipesId = new List<int>();
            foreach(var rec in mealFVM.Meal.RecipeCollection)
            {
                mealFVM.ListRecipesId.Add(rec.Id);
            }
            mealFVM.ListRecipesForDropDown = _ctx.Recipe.ToList();

            return View("MealForm", mealFVM);
        }

        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(MealFormViewModel mealFVM)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.MessageError = "Il y a des erreurs dans le formulaire";
                return View("MealForm", mealFVM);

            }
            int mealId = 0;
            if (mealFVM.Meal.Id > 0)
            {
                ////// Edit Mode
                var mealFromDb = GetMealById(mealFVM.Meal.Id);
                var listRecipeFromDb = mealFromDb.RecipeCollection;

                // on récupère les recettes envoyées par le formulaire
                List<Recipe> listRecipeFromForm = GetListRecipesByRecipeIdList(mealFVM.ListRecipesId);
                
                // Recette à supprimer
                List<Recipe> deletedRecipe = listRecipeFromDb.Except(listRecipeFromForm).ToList();
                deletedRecipe.ForEach(r => listRecipeFromDb.Remove(r));

                // Recette à ajouter
                List<Recipe> addedRecipe = listRecipeFromForm.Except(listRecipeFromDb).ToList();
                addedRecipe.ForEach(r => listRecipeFromDb.Add(r));

                // Mise à jour du repas
                mealFromDb.Name = GenerateRecipeName(mealFVM.Meal.Name, listRecipeFromForm);
                mealFromDb.NbServings = mealFVM.Meal.NbServings;

                _ctx.SaveChanges();

                mealId = mealFromDb.Id;
                TempData["MessageSuccess"] = "Le repas a bien été modifié.";
            }
            else
            {
                ///// Add mode
                Meal newMeal = new Meal();

                // on récupère les objets Recettes à partir des Id envoyés par le formulaire
                List<Recipe> listRecipesFromForm = GetListRecipesByRecipeIdList(mealFVM.ListRecipesId);

                // TODO : vérifier que le repas n'existe pas déjà
                // si il existe -> rediriger vers le repas existant ? 
                // ou si on est en train de créer un itemMenu, on peut l'ajouter direct

                // Si le nom est vide, on le créé à partir des noms des recettes
                newMeal.Name = GenerateRecipeName(mealFVM.Meal.Name, listRecipesFromForm);
                
                newMeal.NbServings = mealFVM.Meal.NbServings;
                
                newMeal.RecipeCollection = new List<Recipe>();
                newMeal.RecipeCollection = listRecipesFromForm;

                _ctx.Meal.Add(newMeal);
                _ctx.SaveChanges();

                mealId = newMeal.Id;
                TempData["MessageSuccess"] = "Le repas a bien été ajouté.";
            }


            return RedirectToAction("Detail", new { id = mealId });
        }

        private string GenerateRecipeName(string nameFVM, List<Recipe> listRecipe)
        {
            string name = String.Empty;
            if (String.IsNullOrEmpty(nameFVM) && (listRecipe.Count() > 0))
            {
                foreach (Recipe item in listRecipe)
                {
                    name += item.Name + " + ";
                }
                if (name.Length > 3)
                {
                    name = name.Remove(name.Length - 3, 3);
                }
            }
            else
            {
                name = nameFVM;
            }
            return name;
        }

        private List<Recipe> GetListRecipesByRecipeIdList(ICollection<int> listRecipesId)
        {
            List<Recipe> listRecipes = new List<Recipe>();
            foreach (int id in listRecipesId)
            {
                listRecipes.Add(_ctx.Recipe.FirstOrDefault(m => m.Id == id));
            }
            return listRecipes;
        }

        private List<Meal> GetListMeals()
        {
            return _ctx.Meal.Include("RecipeCollection").ToList();
        }

        private Meal GetMealById(int mealId)
        {
            return _ctx.Meal.Include("RecipeCollection").FirstOrDefault(m => m.Id == mealId);
        }

        //private List<Recipe> GetListRecipesByMealId(int mealId)
        //{
        //    return _ctx.Meal.Where(m => m.Id == mealId).SelectMany(m => m.RecipeCollection).ToList();
        //}

       
}
}