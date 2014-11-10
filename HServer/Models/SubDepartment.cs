using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HServer.Models
{
    public class SubDepartment
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public List<Doctor> Doctors { get; set; }    
    }
}