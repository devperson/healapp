using HealthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class AppointmentViewModel : ViewModelBase
    {
        public Appointment NewAppointment { get; set; }
        public void SendAppointment(Action<bool> oncomplete)
        {
            if (!string.IsNullOrEmpty(NewAppointment.Name) ||
                !string.IsNullOrEmpty(NewAppointment.Clinic) ||
                !string.IsNullOrEmpty(NewAppointment.Email) ||
                !string.IsNullOrEmpty(NewAppointment.MRN) ||
                !string.IsNullOrEmpty(NewAppointment.Phone) ||
                !string.IsNullOrEmpty(NewAppointment.Refference))
            {
                IsLoading = true;
                WebService.CreateAppointment(NewAppointment, result =>
                    {
                        IsLoading = false;
                        if (!result.Success)
                        {
                            ShowError(result.ErrorMessage);
                        }
                        oncomplete(result.Success);
                    });
            }
            else ShowAlert("Error", "Please fill the form", "OK");
        }
    }
}
