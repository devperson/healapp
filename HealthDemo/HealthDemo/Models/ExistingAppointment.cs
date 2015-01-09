using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.Models
{
    /// <summary>
    /// This class represents ExistingAppointment object, and contains appointment related informations.
    /// </summary>
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
        public string FormattedApptLocation
        {
            get
            {
                return ApptLocation.Replace("AA ", string.Empty).Replace(" Clinic", string.Empty);
            }
        }
        public int Number { get; set; }
        public string DateFormated
        {
            get { return AppointmentDate.ToString("MM/dd/yyyy"); }
        }
        public string TimeFormatted
        {
            get { return AppointmentTime.TimeOfDay.ToString(@"hh\:mm"); }
        }
    }
}
