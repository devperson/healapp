using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class SubDepartment
    {
        public SubDepartment()
        {
            this.Localizations = new List<SubDepartmentLocalization>();
            this.Doctors = new List<Doctor>();
        }
        public int Id { get; set; }
        //public string Name { get; set; }        
        public List<Doctor> Doctors { get; set; }
        public List<SubDepartmentLocalization> Localizations { get; set; }
    }

    public class SubDepartmentLocalization
    {
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int SubDepartmentId { get; set; }
        public string Name { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public SubDepartment SubDepartment { get; set; }
    }
}