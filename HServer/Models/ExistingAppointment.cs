using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HServer.Models
{
    public class ExistingAppointment
    {
        public int Id { get; set; }
        public int ScheduleEventID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentTime { get; set; }
        public string MRN { get; set; }
        public string EmiratesID { get; set; }
        public string Resource { get; set; }
        public string ApptLocation { get; set; }
        public string Language { get; set; }
        public string Nationality { get; set; }
    }
}
