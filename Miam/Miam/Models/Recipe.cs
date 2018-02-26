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
        public int Id { get; set; }

        public ICollection<Meal> MealCollection { get; set; }

        [Required]
        [MaxLength(250)]
        [Display(Name = "Nom de la recette")]
        public string Name { get; set; }

        [Display(Name = "Nombre de couverts")]
        public int NbServing { get; set; }

        [Display(Name = "Instructions")]
        public string Instructions { get; set; }

        [Display(Name = "Temps de cuisson")]
        public int CookingTime { get; set; }

        [Display(Name = "Temps de préparation")]
        public int PreparationTime { get; set; }

        [Display(Name = "Niveau")]
        public LevelEnum? Level { get; set; }
    }
}