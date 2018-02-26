using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.Models
{
    public class Meal
    {
        private int _nbServings;
        private string _name = string.Empty;

        public int Id { get; set; }

        [Display(Name="Liste des recettes")]
        public ICollection<Recipe> RecipeCollection { get; set; }

        [Display(Name = "Nom du repas")]
        public string Name { get; set; }        

        // TODO
        // pour commencer tous les repas sont pour 2 personnes (et les recettes aussi)
        // je créé un repas, je dis qu'il est pour 6 personnes, 
        // et le programme calcule les ingrédients en fonction pour générer la bonne liste de courses
        // si une recette est pour 2, il multiplie par 3 les ingrédients
        [Display(Name = "Nombre de couverts")]
        public int NbServings {
            get
            {
                return _nbServings;
            }
            set
            {
                _nbServings = 2;
            }
        }
    }
}