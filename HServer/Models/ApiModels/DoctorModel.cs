using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models.ApiModels
{
    //[DataContract]
    public class DoctorModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Bio { get; set; }
        public string ImageUrl { get; set; }
        public string Department { get; set; }
        public string SubDepartment { get; set; }
        public string Position { get; set; }
        public List<string> Qualifications { get; set; }
        public List<string> Languages { get; set; }
    }
}