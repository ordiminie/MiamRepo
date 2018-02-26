using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Miam.Models
{
    public class Menu
    {

        public int Id { get; set; }
        public ICollection<Meal> MealCollection { get; set; }

        public string DayOfWeek { get; set; }
        public string MomentOfDay { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DayOfWeek BeginDay { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate {
            get
            {
                return this.BeginDate.AddDays(7);
            }
        }
    }
}