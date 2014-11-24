using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    public class Appointment : ViewModelBase
    {
        public string Name { get; set; }
        public string MRN { get; set; }
        public string Phone { get; set; }

        bool _thiqaYes;
        public bool ThiqaYes
        { 
            get 
            { 
                return _thiqaYes;
            }
            set 
            {
                _thiqaYes = value;
                this.RaisePropertyChanged(p => p.ThiqaYes);
            }
        }               

        public string Refference { get; set; }
        public string ID { get; set; }
        public string Clinic { get; set; }
        public string Email { get; set; }


    }
}
