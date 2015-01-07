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
            this.Localizations = new List<CmeLocalization>();
        }

        public int Id { get; set; }        
        public DateTime Date { get; set; }
        public List<CmeLocalization> Localizations { get; set; }        
    }

    public class CmeLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int CmeId { get; set; }

        public string Title { get; set; }
        public string Speaker { get; set; }
        public string Venue { get; set; }
        public string CreditHours { get; set; }
        public string Description { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Cme Cme { get; set; }
    }

    public class CmeModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Speaker { get; set; }
        public string Venue { get; set; }
        public string CreditHours { get; set; }
        public string Description { get; set; }        
    }
}