using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Cme
    {
        public Cme()
        {
            
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public string Speaker { get; set; }
        public string Venue { get; set; }
        public string CreditHours { get; set; }
        public string Description { get; set; }
    }
}