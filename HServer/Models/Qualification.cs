using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Qualification
    {
        public Qualification()
        {
            this.Doctors = new List<Doctor>();
            this.Localizations = new List<QualificationLocalization>();
        }

        public int Id { get; set; }
        //public string Name { get; set; }
        public List<Doctor> Doctors { get; set; }
        public List<QualificationLocalization> Localizations { get; set; }
    }

    public class QualificationLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int QualificationId { get; set; }
        public string Name { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Qualification Qualification { get; set; }
    }
}