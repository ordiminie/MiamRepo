using Miam.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.Models
{
    public class MenuItem
    {
        // Primary key
        public int Id { get; set; }

        // Foreign key
        public int? MealId { get; set; }
        public int MenuId { get; set; }

        // Navigation property
        public Meal Meal { get; set; }
        public Menu Menu { get; set; }

        [Display(Name="Date")]
        public DateTime Date { get; set; }

        [Display(Name ="Type de repas")]
        public MealTypeEnum MealType { get; set; }

        public int WeekNumber { get; set; }
    }
}