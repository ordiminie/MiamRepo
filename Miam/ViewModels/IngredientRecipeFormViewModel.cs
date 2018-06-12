using Miam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miam.ViewModels
{
    public class IngredientRecipeFormViewModel
    {
        public int Id { get; set; }
        public IngredientRecipe IngredientsRecipe { get; set; } 
        
        // pour afficher sous forme de liste TOUTES les options (et pas QUE celle de l'objet courant)
        public IEnumerable<IngredientIndex> IngredientsIndexForDropDown { get; set; }

        public string Title
        {
            get { return ((IngredientsRecipe != null) && (IngredientsRecipe.IngredientIndexId > 0)) ? "Modifier l'ingrédient" : "Ajouter un ingrédient"; }
        }
    }
}