using Miam.Models;
using Miam.Shared;
using Miam.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Miam.Controllers
{
    public class MenuController : Controller
    {
        ApplicationDbContext _ctx;
        public MenuController()
        {
            _ctx = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _ctx.Dispose();
        }

        // GET: Menu
        public ActionResult Index()
        {
            List<Menu> listMenu = GetListMenus();
            ViewBag.MessageSuccess = TempData["MessageSuccess"];
            ViewBag.MessageError = TempData["MessageError"];

            return View(listMenu);
        }

        public ActionResult Detail(int id)
        {
            Menu menu = GetMenuById(id);
            List<MenuItem> listMenuItems = GetMenuItemsByMenuId(id);

            List<MenuItem> listMenuItemsWeek1 = listMenuItems.Where(m => m.WeekNumber == 1).ToList();
            List<MenuItem> listMenuItemsWeek2 = listMenuItems.Where(m => m.WeekNumber == 2).ToList();



            // regroupe les repas par jour (tous les lundis ensemble, les mardis ensemble....)
            ILookup<DayOfWeek, MenuItem> listMenuItemsWeek1ByDayTest = listMenuItemsWeek1.OrderBy(m => m.MealType).ToLookup(m => m.Date.DayOfWeek);
            ILookup<DayOfWeek, MenuItem> listMenuItemsWeek1ByDay = listMenuItemsWeek1.OrderBy(m => m.MealType).ToLookup(m => m.Date.DayOfWeek);

            ILookup<DayOfWeek, MenuItem> listMenuItemsWeek2ByDay = listMenuItemsWeek2.OrderBy(m => m.MealType).ToLookup(m => m.Date.DayOfWeek);

            MenuFormViewModel menuFVM = new MenuFormViewModel()
            {
                ListMenuItems = listMenuItems,
                ListMenuItemsWeek1ByDay = listMenuItemsWeek1ByDay,
                ListMenuItemsWeek2ByDay = listMenuItemsWeek2ByDay,
                Menu = menu
            };
            ViewBag.MessageSuccess = TempData["MessageSuccess"];
            ViewBag.MessageError = TempData["MessageError"];

            return View(menuFVM);
        }

        public ActionResult New()
        {
            MenuFormViewModel menuFVM = new MenuFormViewModel();
            menuFVM.Menu = new Menu();
            return View("MenuForm", menuFVM);
        }

        public ActionResult Edit(int id)
        {
            Menu menu = GetMenuById(id);
            List<MenuItem> listMenuItems = GetMenuItemsByMenuId(id);

            MenuFormViewModel menuFVM = new MenuFormViewModel()
            {
                ListMenuItems = listMenuItems,
                Menu = menu
            };


            return View("MenuForm", menuFVM);
        }

        [ValidateAntiForgeryToken]
        public ActionResult AddOrUpdate(MenuFormViewModel menuFVM)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MessageError = "Il y a des erreurs dans le formulaire";
                return View("MenuForm", menuFVM);

            }

            DateTime minDateTime = SqlDateTime.MinValue.Value;
            if ((menuFVM.Menu.BeginDate).CompareTo(minDateTime) <= 0)
            {
                ViewBag.MessageError = "La date doit être supérieure au 01/01/1753";
                return View("MenuForm", menuFVM);
            }

            int menuId;

            if (menuFVM.Menu.Id > 0)
            {
                ////// Edit Mode
                Menu menuFromDb = GetMenuById(menuFVM.Menu.Id);

                menuFromDb.Name = menuFVM.Menu.Name;
                menuFromDb.Description = menuFVM.Menu.Description;
                menuFromDb.BeginDate = menuFVM.Menu.BeginDate;
                menuFromDb.Duration = menuFVM.Menu.Duration;
                
                _ctx.SaveChanges();

                menuId = menuFVM.Menu.Id;
                TempData["MessageSuccess"] = "Le menu a bien été modifié.";
            }
            else
            {
                ////// Add Mode
                Menu menu = new Menu();
                menu.Name = menuFVM.Menu.Name;
                menu.Description = menuFVM.Menu.Description;
                menu.BeginDate = menuFVM.Menu.BeginDate;
                menu.Duration = menuFVM.Menu.Duration;
                                
                _ctx.Menu.Add(menu);
                _ctx.SaveChanges();

                menuId = menu.Id;

                // Add Meal
                MenuItem menuItem = new MenuItem();
                menuItem.MenuId = menuId;
                for (int i = 0; i < (menu.Duration * 7); i++)
                {
                    menuItem.Date = menu.BeginDate.AddDays((double)i);
                    menuItem.WeekNumber = (i < 7) ? 1 : 2;
                    menuItem.MealId = null;
                    _ctx.MenuItem.Add(menuItem);
                    _ctx.SaveChanges();
                }

                
                

                TempData["MessageSuccess"] = "Le menu a bien été créé.";
            }
             

            return RedirectToAction("Detail", new { id = menuId });

        }
        
        public ActionResult Delete(int id)
        {
            Menu menuToDelete = GetMenuById(id);
            List<MenuItem> listMenusItems = GetMenuItemsByMenuId(id);

            if (menuToDelete == null)
                return HttpNotFound();
            
            _ctx.Menu.Remove(menuToDelete);
            
            foreach(MenuItem menuItem in listMenusItems)
            {
                _ctx.MenuItem.Remove(menuItem);

            }
            _ctx.SaveChanges();

            TempData["MessageSuccess"] = "Le menu a bien été supprimé.";


            return RedirectToAction("Index");
        }





        //// Utiliser cette méthode pour avoir le menu rattaché aux autres objets récupérés du contexte : menuItems, et meal (pour EF)
        //private Menu ExtractMenuFromMenuItem(MenuItem menuItem)
        //{
        //    return menuItem.Menu;
        //}

        // Menu détaché
        private Menu GetMenuById(int menuId)
        {
            return _ctx.Menu.FirstOrDefault(m => m.Id == menuId);
        }
        
        private List<MenuItem> GetMenuItemsByMenuId(int menuId)
        {
            //List<MenuItem> listMenuItems = _ctx.MenuItem.Include("Menu").Include("Meal").Where(m => m.MenuId == menuId).ToList();
            List<MenuItem> listMenuItems = _ctx.MenuItem.Include("Meal").Where(m => m.MenuId == menuId).ToList();


            // Récup les recettes
            foreach (MenuItem menuItem in listMenuItems)
            {
                // en utilisant Include, EF comprend mieux les relations entre les objets lors de l'Edit
                Meal meal = _ctx.Meal.Include("RecipeCollection").FirstOrDefault(m => m.Id == menuItem.MealId);
                // _ctx.Meal.Where(m => m.Id == menuItem.MealId).SelectMany(m => m.RecipeCollection).ToList();
                if (meal != null)
                    menuItem.Meal.RecipeCollection = meal.RecipeCollection;               
            }
            return listMenuItems;
        }



        private List<Menu> GetListMenus()
        {
            return _ctx.Menu.ToList();       
        }
    }
}