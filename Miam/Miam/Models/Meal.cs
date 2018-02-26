using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miam.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public ICollection<Recipe> RecipesCollection { get; set; }
        public ICollection<Menu> MenuCollection { get; set; }
        public string DayOfWeek { get; set; }
        public string MomentOfDay { get; set; }

        // TODO
        // je créé un repas, je dis qu'il est pour 6 personnes, 
        // et le programme calcule les ingrédients en fonction pour générer la bonne liste de courses
        // si une recette est pour 2, il multiplie par 3 les ingrédients
        public int NbServings { get; set; }
    }
}