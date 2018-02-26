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
        public int MealId { get; set; }
        public int MenuId { get; set; }

        // Navigation property
        public Meal Meal { get; set; }
        public Menu Menu { get; set; }

        [Display(Name="Date")]
        public DateTime Date { get; set; }

        [Display(Name ="Moment (matin/midi/soir)")]
        public string MomentOfDay { get; set; }

        [Display(Name = "Petit déj'")]
        public static string Morning = "Morning";
        [Display(Name = "Midi")]
        public static string Noon = "Noon";
        [Display(Name = "Soir")]
        public static string Evening = "Evening";
    }
}