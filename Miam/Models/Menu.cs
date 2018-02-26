using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Miam.Models
{
    public class Menu
    {
        private int _duration;

        public int Id { get; set; }

        [Display(Name = "Nom")]
        [StringLength(50)]
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [StringLength(500)]
        [MaxLength(500)]
        public string Description { get; set; }

        // TODO rendre éditable pour faire des menus de x jours (ou rendre éditable la date de fin et calculer automatiquement la durée)
        [Display(Name="Nombre de jours")]
        public int Duration {
            get
            {
                return _duration;
            }
            set
            {
                _duration = 14;
            }
        }

        // le menu commence un dimanche (vu que les courses sont le samedi)
        // Note : sans "set", EF ne créé pas la colonne en base
        [Display(Name = "Doit commencer un")]
        public DayOfWeek BeginDay
        {
            get
            {
                return DayOfWeek.Sunday;
            }
        }

        [Display(Name = "Début")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Fin")]
        public DateTime EndDate {
            get
            {
                return this.BeginDate.AddDays(this.Duration);
            }
        }


    }
}