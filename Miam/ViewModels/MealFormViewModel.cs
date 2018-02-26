using Miam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.ViewModels
{
    public class MealFormViewModel
    {
        public int Id { get; set; }

        public Meal Meal { get; set; }

        public IEnumerable<Recipe> ListRecipesForDropDown { get; set; }

        [Required(ErrorMessage = "Sélectionnez au moins une recette")]
        public ICollection<int> ListRecipesId { get; set; }

        public string Title
        {
            get
            {
                return ((this.Meal != null) && (this.Meal.Id > 0)) ? "Modifier le repas" : "Ajouter un repas";
            }
        }
    }
}