using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.Models
{
    public class IngredientRecipe
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key
        public int RecipeId { get; set; }
        public int IngredientIndexId { get; set; }

        // Navigation property 
        public Recipe Recipe { get; set; }
        //[Required]
        public IngredientIndex IngredientIndex { get; set; }

        [Display(Name = "Poids (g)")]
        public int? WeightGrams { get; set; }

        [Display(Name = "Poids (cl)")]
        public int? WeightCl { get; set; }

        [Display(Name = "Quantité")]
        public int? Quantity { get; set; }

        [Display(Name = "Taille")]
        //public SizeEnum? Size { get; set; }
        public string Size { get; set; }
    }
}