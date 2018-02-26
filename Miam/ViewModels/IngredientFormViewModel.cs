using Miam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miam.ViewModels
{
    public class IngredientFormViewModel
    {
        public string Title {
            get
            {
                return (this.Ingredient.Id > 0) ? "Modifier un ingrédient" : "Ajouter un ingrédient";
            }
        } 
        public IngredientIndex Ingredient { get; set; }
    }
}