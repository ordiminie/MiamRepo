using Miam.Models;
using Miam.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.ViewModels
{
    public class MenuItemFormViewModel
    {
        public int Id { get; set; }

        public MenuItem MenuItem { get; set; }

        [Display(Name = "Choisissez les repas")]
        public IEnumerable<Meal> ListMealsForDropDown { get; set; }

        public string Title
        {
            get
            {
                return ((this.MenuItem != null) && (this.MenuItem.MealId > 0)) ? "Modifier le repas" : "Ajouter un repas";
            }
        }
    }
}