using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Department
    {
        public Department()
        {          
            this.Doctors = new List<Doctor>();
            this.Localizations = new List<DepartmentLocalization>();
        }
        public int Id { get; set; }
        //public string Name { get; set; }        
        public List<Doctor> Doctors { get; set; }
        public List<DepartmentLocalization> Localizations { get; set; }
    }

    public class DepartmentLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Department Department { get; set; }
    }
}