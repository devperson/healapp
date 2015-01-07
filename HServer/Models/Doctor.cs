using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Localizations = new List<DoctorLocalization>();
            this.Languages = new List<Language>();
            this.Qualifications = new List<Qualification>();
        }

        public int Id { get; set; }
        //public string Name { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? SubDepartmentId { get; set; } 
        //public string Bio { get; set; }
        public string ImageFileName { get; set; }


        public Position Position { get; set; }
        public Department Department { get; set; }
        public SubDepartment SubDepartment { get; set; }
        public List<Language> Languages { get; set; }
        public List<Qualification> Qualifications { get; set; }

        public List<DoctorLocalization> Localizations { get; set; }
    }

    public class DoctorLocalization
    {        
        public int Id { get; set; }
        public int LocalizationId { get; set; }
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }

        public LocalizationLanguage Localization { get; set; }
        public Doctor Doctor { get; set; }
    }
}