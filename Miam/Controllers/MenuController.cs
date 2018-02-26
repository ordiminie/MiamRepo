using Miam.Models;
using Miam.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
            return View(listMenu);
        }

        public ActionResult Detail(int id)
        {
            List<MenuItem> listMenuItems = GetMenuItemsByMenuId(id);
            Menu menu = ExtractMenuFromMenuItem(listMenuItems[0]);
            //Menu menu = GetMenuById(id);

            MenuFormViewModel menuFVM = new MenuFormViewModel()
            {
                ListMenuItems = listMenuItems,
                Menu = menu
            };


            return View(menuFVM);
        }


        public ActionResult Edit(int id)
        {
            List<MenuItem> listMenuItems = GetMenuItemsByMenuId(id);
            Menu menu = ExtractMenuFromMenuItem(listMenuItems[0]);

            MenuFormViewModel menuFVM = new MenuFormViewModel()
            {
                ListMenuItems = listMenuItems,
                Menu = menu
            };


            return View("MenuForm", menuFVM);
        }

        public ActionResult AddMenuItem()
        {
            // TODO REPRENDRE ICI
            // récupérer un objet vide menu Item
            // ensuite faire le add qui va ajouter spéciquement le repas au menu
            // pour l'instant, ne couvrir que le cas où le repas existe (on ne peut pas le créer à la volée)

            return View();
        }



        // Utiliser cette méthode pour avoir le menu rattaché aux autres objets récupérés du contexte : menuItems, et meal (pour EF)
        private Menu ExtractMenuFromMenuItem(MenuItem menuItem)
        {
            return menuItem.Menu;
        }

        // Menu détaché
        private Menu GetMenuById(int menuId)
        {
            return _ctx.Menu.FirstOrDefault(m => m.Id == menuId);
        }
        
        private List<MenuItem> GetMenuItemsByMenuId(int menuId)
        {
            List<MenuItem> listMenuItems = _ctx.MenuItem.Include("Menu").Include("Meal").Where(m => m.MenuId == menuId).ToList();

            // Récup les recettes
            foreach (MenuItem menuItem in listMenuItems)
            {
                // en utilisant Include, EF comprend mieux les relations entre les objets lors de l'Edit
                Meal meal = _ctx.Meal.Include("RecipeCollection").FirstOrDefault(m => m.Id == menuItem.MealId);
                // _ctx.Meal.Where(m => m.Id == menuItem.MealId).SelectMany(m => m.RecipeCollection).ToList();

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