using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Miam.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miam.Models
{
    public class Menu
    {
        private int _duration;
        private DayOfWeekEnum _beginDay = DayOfWeekEnum.Sunday;

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

        // TODO rendre éditable pour faire des menus de x semaines (ou rendre éditable la date de fin et calculer automatiquement la durée)
        [Display(Name="Nombre de semaines")]
        public int Duration {
            get
            {
                return (_duration == 0)? 2 : _duration;
            }
            set
            {
                _duration = 2;
            }
        }
          
        // le menu commence un dimanche (vu que les courses sont le samedi)
        // Note : sans "set", EF ne créé pas la colonne en base
        [Display(Name = "Commence un")]
        public DayOfWeekEnum BeginDay
        {
            get
            {
                return _beginDay;
            }
            set
            {
                _beginDay = value;
            }
        }

        //[DataType(DataType.Date)] utilisé pour EditorFor uniquement (donc plus utile car j'utilise TextBoxFor compatible avec jQuery _ champ de type Text)
        [Display(Name = "Début")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Veuillez sélectionner une date correspondant à un dimanche")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Fin")]
        public DateTime EndDate {
            get
            {
                return this.BeginDate.AddDays(this.Duration * 7);
            }
        }


    }
}