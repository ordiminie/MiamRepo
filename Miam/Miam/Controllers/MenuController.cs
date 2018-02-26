using Miam.Models;
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

        private List<Menu> GetListMenus()
        {
            //return _ctx.Menu.Include(path => path.)
            // TODO récupérer les repas du menu avec .Include()
            return _ctx.Menu.ToList();
       
        }
    }
}