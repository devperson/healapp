using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Insurance
    {
        public Insurance()
        {
            this.Localizations = new List<InsuranceLocalization>();
        }

        public int Id { get; set; }        
        public List<InsuranceLocalization> Localizations { get; set; }
    }

    public class InsuranceLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int InsuranceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Insurance Insurance { get; set; }
    }

    public class InsuranceModel
    {
        public int ID { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
    }
}