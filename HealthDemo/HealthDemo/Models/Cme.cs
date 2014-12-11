using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthDemo.Models
{
    public class Cme
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string Speaker { get; set; }
        public string Venue { get; set; }
        public string CreditHours { get; set; }
        public string Description { get; set; }
        public string DateFormated
        {
            get { return Date.ToString("MM/dd/yyyy") + " " + Date.TimeOfDay.ToString(@"hh\:mm"); }
        }
    }
}