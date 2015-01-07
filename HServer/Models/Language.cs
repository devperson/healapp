using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Language
    {
        public Language()
        {
            this.Doctors = new List<Doctor>();
            this.Localizations = new List<LanguageLocalization>();
        }
        public int Id { get; set; }        

        public List<Doctor> Doctors { get; set; }
        public List<LanguageLocalization> Localizations { get; set; }
    }

    public class LanguageLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Language Language { get; set; }
    }
}