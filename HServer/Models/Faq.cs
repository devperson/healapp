using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Faq
    {
        public Faq()
        {
            this.Localizations = new List<FaqLocalization>();
        }
        public int Id { get; set; }        
        public List<FaqLocalization> Localizations { get; set; }
    }

    public class FaqLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Faq Faq { get; set; }
    }

    public class FaqModel
    {        
        public int ID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }        
    }
}