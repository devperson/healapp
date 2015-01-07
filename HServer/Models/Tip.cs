using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Tip
    {
        public Tip()
        {
            this.Localizations = new List<TipLocalization>();
        }
        public int Id { get; set; }
        
        //public string Name { get; set; }
        //public string Description { get; set; }
        public TipCategory Category { get; set; }
        public int CategoryId { get; set; }
        public List<TipLocalization> Localizations { get; set; }
    }

    public class TipLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int TipId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Tip Tip { get; set; }
    }
}