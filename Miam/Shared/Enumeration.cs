using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Miam.Shared
{
    // Taille
    public enum SizeEnum
    {
        [Display(Name = "Petit")]
        Small,
        [Display(Name = "Moyen")]
        Medium,
        [Display(Name = "Gros")]
        Big
    }

    // Niveau de difficulté
    public enum LevelEnum
    {
        [Display(Name = "Facile")]
        Easy,
        [Display(Name = "Moyen")]
        Regular,
        [Display(Name = "Difficile")]
        Difficult
    }


    // Spécifie le jour de la semaine.
    public enum DayOfWeekEnum
    {
        [Display(Name = "Dimanche")]
        Sunday = 0,
        [Display(Name = "Lundi")]
        Monday = 1,
        [Display(Name = "Mardi")]
        Tuesday = 2,
        [Display(Name = "Mercredi")]
        Wednesday = 3,
        [Display(Name = "Jeudi")]
        Thursday = 4,
        [Display(Name = "Vendredi")]
        Friday = 5,
        [Display(Name = "Samedi")]
        Saturday = 6
    }

    // Les repas de la journée 
    public enum MealTypeEnum
    {
        [Display(Name = "Petit déj'")]
        Morning,
        [Display(Name = "Midi")]
        Noon,
        [Display(Name = "Soir")]
        Evening
    }

    public static class Enumeration
    {
        public static string DisplayName(this Enum value)
        {
            var outString = string.Empty;
            if (value != null)
            {
                Type enumType = value.GetType();
                var enumValue = Enum.GetName(enumType, value);
                MemberInfo member = enumType.GetMember(enumValue)[0];

                var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);
                outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                {
                    outString = ((DisplayAttribute)attrs[0]).GetName();
                }
            }

            return outString;
        }
    }
}