using Miam.Models;
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

        List<Meal> GetListMeals()
        {
            return _ctx.Meal.Include(m => m.RecipesCollection).ToList();
        }
    }
}