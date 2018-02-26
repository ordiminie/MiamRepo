using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.Shared
{
    public class Enumeration
    {
        public enum SizeEnum
        {
            [Display(Name = "Petit")]
            Small,
            [Display(Name = "Moyen")]
            Medium,
            [Display(Name = "Gros")]
            Big
        }

        public enum LevelEnum
        {
            [Display(Name = "Facile")]
            Easy,
            [Display(Name = "Moyen")]
            Regular,
            [Display(Name = "Difficile")]
            Difficult
        }
    }
}