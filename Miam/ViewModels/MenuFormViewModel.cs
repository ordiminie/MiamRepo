using Miam.Models;
using Miam.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.ViewModels
{
    public class MenuFormViewModel
    {
        public int Id { get; set; }
        public Menu Menu { get; set; }
        public IEnumerable<MenuItem> ListMenuItems { get; set; }
        public ILookup<DayOfWeek, MenuItem> ListMenuItemsWeek1ByDay { get; set; }
        public ILookup<DayOfWeek, MenuItem> ListMenuItemsWeek2ByDay { get; set; }

        public string Title {
            get
            {
                return ((this.Menu != null) && (this.Menu.Id > 0)) ? "Modifier le menu" : "Créer un menu";
            }
        }
    }
}