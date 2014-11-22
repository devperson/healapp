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
    }
}
