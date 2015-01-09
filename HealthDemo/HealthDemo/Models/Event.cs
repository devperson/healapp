using System;
using System.Collections.Generic;
using System.Linq;


namespace HealthDemo.Models
{
    /// <summary>
    /// This class represents Event object, and contains event related informations.
    /// </summary>
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }
        public string Venue { get; set; }
        public string DateFormated
        {
            get { return Date.ToString("MM/dd/yyyy"); }
        }
    }
}