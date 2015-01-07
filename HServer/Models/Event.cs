using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Event
    {
        public Event()
        {
            this.Localizations = new List<EventLocalization>();
        }
        public int Id { get; set; }        
        public DateTime Date { get; set; }
        public List<EventLocalization> Localizations { get; set; }        
    }

    public class EventLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Event Event { get; set; }
    }

    public class EventModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Venue { get; set; }
    }
}