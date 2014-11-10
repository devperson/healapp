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
        }

        public int Id { get; set; }
        //public int DepartmentId { get; set; }
        public string Name { get; set; }

        //public Department Department { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}