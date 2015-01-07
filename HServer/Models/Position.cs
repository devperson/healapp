using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Position
    {
        public Position()
        {
            this.Doctors = new List<Doctor>();
            this.Localizations = new List<PositionLocalization>();
        }

        public int Id { get; set; }        
        //public string Name { get; set; }        
        public List<Doctor> Doctors { get; set; }
        public List<PositionLocalization> Localizations { get; set; }
    }

    public class PositionLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int PositionId { get; set; }
        public string Name { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Position Position { get; set; }
    }

    public class PositionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}