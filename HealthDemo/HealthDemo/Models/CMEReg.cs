using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    public class CMEReg : ViewModelBase
    {
        public string Name { get; set; }
        public string Employer { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
    }
}
