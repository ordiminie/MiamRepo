using Miam.Models;
using Miam.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Miam.Controllers
{
    public class MenuItemController : Controller
    {
        ApplicationDbContext _ctx;
        public MenuItemController()
        {
            _ctx = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

        // GET: MenuItem
        public ActionResult Index()
        {
            return View();
        }
        
        
        public ActionResult AddFirstMeal(int menuItemId)
        {
            MenuItem menuItem = GetMenuItemById(menuItemId);
            
            MenuItemFormViewModel menuItemFVM = new MenuItemFormViewModel();
            menuItemFVM.MenuItem = menuItem;

            menuItemFVM.ListMealsForDropDown = _ctx.Meal.ToList();

            return View("MenuItemForm", menuItemFVM);
        }

        public ActionResult AddAnotherMeal(int menuId, int weekNumber, DateTime date)
        {
            MenuItemFormViewModel menuItemFVM = new MenuItemFormViewModel();
            menuItemFVM.MenuItem = new MenuItem();
            
            menuItemFVM.MenuItem.WeekNumber = weekNumber;
            menuItemFVM.MenuItem.Date = date;

            menuItemFVM.MenuItem.MenuId = menuId;

            menuItemFVM.ListMealsForDropDown = _ctx.Meal.ToList();

            return View("MenuItemForm", menuItemFVM);
        }


        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(MenuItemFormViewModel menuItemFVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MessageError = "Il y a des erreurs dans le formulaire";
                return View("MenuItemForm", menuItemFVM);
            }

            DateTime minDateTime = SqlDateTime.MinValue.Value;
            if (menuItemFVM.MenuItem.Date.CompareTo(minDateTime) <= 0)
            {
                ViewBag.MessageError = "La date doit être supérieure au 01/01/1753";
                return View("MenuForm", menuItemFVM);
            }

            int menuId;

            if (menuItemFVM.MenuItem.Id > 0)
            {
                // Edit Mode 
                MenuItem menuItemFromDb = GetMenuItemById(menuItemFVM.MenuItem.Id);
                menuItemFromDb.Date = menuItemFVM.MenuItem.Date;
                menuItemFromDb.MealId = menuItemFVM.MenuItem.MealId;
                menuItemFromDb.MenuId = menuItemFVM.MenuItem.MenuId;
                menuItemFromDb.MealType = menuItemFVM.MenuItem.MealType;
                menuItemFromDb.WeekNumber = menuItemFVM.MenuItem.WeekNumber;

                _ctx.SaveChanges();

                menuId = menuItemFromDb.MenuId;

                TempData["MessageSuccess"] = "Le repas a bien été modifié.";
            }
            else
            {
                // Add Mode
                MenuItem menuItem = new MenuItem();
                menuItem.Date = menuItemFVM.MenuItem.Date;
                menuItem.MealId = menuItemFVM.MenuItem.MealId;
                menuItem.MenuId = menuItemFVM.MenuItem.MenuId;
                menuItem.MealType = menuItemFVM.MenuItem.MealType;
                menuItem.WeekNumber = menuItemFVM.MenuItem.WeekNumber;

                _ctx.MenuItem.Add(menuItem);
                _ctx.SaveChanges();

                //menuItemId = menuItem.Id;
                menuId = menuItem.MenuId;

                TempData["MessageSuccess"] = "Le repas a bien été ajouté au menu.";
            }


            return RedirectToAction("Detail", "Menu", new { id = menuId });
        }

        public ActionResult Edit (int id)
        {
            MenuItem menuItemFromDb = GetMenuItemById(id);

            if (menuItemFromDb == null)
                return HttpNotFound();

            MenuItemFormViewModel menuItemFVM = new MenuItemFormViewModel();

            menuItemFVM.MenuItem = new MenuItem();
            menuItemFVM.MenuItem.Id = menuItemFromDb.Id;
            menuItemFVM.MenuItem.Meal = menuItemFromDb.Meal;
            menuItemFVM.MenuItem.MealId = menuItemFromDb.MealId;
            menuItemFVM.MenuItem.MealType = menuItemFromDb.MealType;
            menuItemFVM.MenuItem.Date = menuItemFromDb.Date;
            menuItemFVM.MenuItem.MenuId = menuItemFromDb.MenuId;
            menuItemFVM.MenuItem.WeekNumber = menuItemFromDb.WeekNumber;

            menuItemFVM.ListMealsForDropDown = _ctx.Meal.ToList();

            return View("MenuItemForm", menuItemFVM);
        }

        public ActionResult Delete (int id)
        {
            MenuItem menuItemFromDb = GetMenuItemById(id);

            if (menuItemFromDb == null)
                return HttpNotFound();

            // on récupère tous les menuItems du même jour que le menuItem à supprimer
            List<MenuItem> listMenuItems = _ctx.MenuItem.Where(m => m.Date == menuItemFromDb.Date).ToList();
            
            if(listMenuItems.Count > 1)
            {
                // on supprime le menuItem
                _ctx.MenuItem.Remove(menuItemFromDb);
            }
            else
            {
                // on vide le menuItem
                menuItemFromDb.MealId = null;
                menuItemFromDb.Meal = null;
                menuItemFromDb.MealType = Shared.MealTypeEnum.Noon;
            }
            
            _ctx.SaveChanges();

            TempData["MessageSuccess"] = "Le repas a bien été supprimé.";


            return RedirectToAction("Detail", "Menu", new { id = menuItemFromDb.MenuId });
        }


        private MenuItem GetMenuItemById(int menuItemId)
        {
            return _ctx.MenuItem.Include("Meal").Where(m => m.Id == menuItemId).FirstOrDefault();
        }

    }
}