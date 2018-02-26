using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.Models
{
    public class IngredientIndex
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [MaxLength(50, ErrorMessage = "50 caractères maximum")]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [MaxLength(500, ErrorMessage = "500 caractères maximum")]
        public string Description { get; set; }
    }
}