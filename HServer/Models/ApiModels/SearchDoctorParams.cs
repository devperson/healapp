using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models.ApiModels
{
    public class SearchDoctorParams
    {
        //public int QualificationId { get; set; }
        public string Title { get; set; }
        //public int DepartmentId { get; set; }
        public int PositionId { get; set; }
    }
}