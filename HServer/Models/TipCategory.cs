using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    
    public class TipCategory
    {
        public TipCategory()
        {
            this.Tips = new List<Tip>();
            this.Localizations = new List<TipCategoryLocalization>();
        }
        public int Id { get; set; }
        //public string Name { get; set; }
        public List<Tip> Tips { get; set; }
        public List<TipCategoryLocalization> Localizations { get; set; }
    }

    public class TipCategoryLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int TipCategoryId { get; set; }
        public string Name { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public TipCategory TipCategory { get; set; }
    }
}