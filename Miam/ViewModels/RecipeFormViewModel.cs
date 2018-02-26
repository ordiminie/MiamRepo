using Miam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miam.ViewModels
{
    public class RecipeFormViewModel
    {
        public int Id { get; set; }

        public Recipe Recipe { get; set; }
        
        public IEnumerable<IngredientRecipe> IngredientsRecipe { get; set; }
        
        public string Title
        {
            get { return (Recipe.Id > 0)? "Modifier la recette" : "Créer une nouvelle recette"; }
        }

    }
}