using HealthDemo.Models;
using HealthDemo.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    /// <summary>
    /// This class represents Appointment view model and contains related data and actions.
    /// </summary>
    public class AppointmentViewModel : ViewModelBase
    {
        public List<ExistingAppointment> SearchedAppointList { get; set; }
        public Appointment NewAppointment { get; set; }
        public string Emirate { get; set; }
        public string Mrn { get; set; }

        /// <summary>
        /// Registers new appointment data on server.
        /// </summary>        
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
            else ShowAlert(AppResources.DLG_Error, AppResources.Appointment_SEND_DLG_Msg, "OK");
        }

        /// <summary>
        /// Retrives appointments from server that matches by mrn and emirate.
        /// </summary>
        public void SearchAppointment()
        {
            IsLoading = true;
            var emirateVal = string.IsNullOrEmpty(Emirate) ? "0" : Emirate;
            WebService.GetList<SearchAppointResponce, ExistingAppointment>(string.Format("ExistAppoint/Search?mrn={0}&emirate={1}", Mrn, emirateVal), result =>
            {
                if (result.Success)
                {
                    SearchedAppointList = result.Result;
                    int i = 0;
                    foreach (var item in SearchedAppointList)
                    {
                        i++;
                        item.Number = i;
                    }
                    RaisePropertyChanged("SearchedAppointList");
                }
                else
                {
                    ShowError(result.ErrorMessage);
                }
                IsLoading = false;
            });
        }

        /// <summary>
        /// Resets all fields
        /// </summary>
        public void ResetFields()
        {
            Emirate = string.Empty;
            Mrn = string.Empty;
            RaisePropertyChanged("Emirate");
            RaisePropertyChanged("Mrn");
        }
    }
}
