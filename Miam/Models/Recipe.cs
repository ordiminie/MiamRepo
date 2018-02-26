using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Miam.Shared.Enumeration;

namespace Miam.Models
{
    public class Recipe
    {
        private int _nbServing;

        public int Id { get; set; }

        public ICollection<Meal> MealCollection { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Nom de la recette")]
        [StringLength(250)]
        public string Name { get; set; }
        
        // on force le nombre de couvert à 2 pour commencer (TODO : rendre éditable en v2)
        [Display(Name = "Nombre de couverts")]
        public int NbServing {
            get { return _nbServing; }
            set { _nbServing = 2; }
        }

        [Display(Name = "Instructions")]
        [Required(ErrorMessage = "Les instructions sont obligatoires.")]
        public string Instructions { get; set; }

        [Display(Name = "Temps de cuisson (en min)")]
        [Required]
        public int CookingTime { get; set; }

        [Display(Name = "Temps de préparation (en min)")]
        public int PreparationTime { get; set; }

        [Display(Name = "Niveau")]
        public LevelEnum? Level { get; set; }
    }
}