using Miam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miam.ViewModels
{
    public class MenuFormViewModel
    {
        public Menu Menu { get; set; }
        public IEnumerable<MenuItem> ListMenuItems { get; set; }

        public string Title {
            get
            {
                return (Menu.Id > 0) ? "Modifier le menu" : "Créer un nouveau menu";
            }
        }
    }
}