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
            //this.Positions = new List<Position>();
            this.Doctors = new List<Doctor>();            
        }
        public int Id { get; set; }
        public string Name { get; set; }

        //public List<Position> Positions { get; set; }
        public List<Doctor> Doctors { get; set; }
    }
}