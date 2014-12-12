using HealthDemo.Models;
using HealthDemo.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class CmeViewModel : ViewModelBase
    {
        public CmeViewModel()
        {
            CmesList = new List<Cme>();
        }

        public CMEReg NewCMERegistration { get; set; }
        public Cme SelectedCme { get; set; }
        public List<Cme> CmesList { get; set; }
        public void LoadCme()
        {
            if (CmesList.Count == 0)
            {
                IsLoading = true;
                WebService.GetList<CmeResponse, Cme>("cme", result =>
                {
                    if (result.Success)
                    {
                        CmesList = result.Result;
                        RaisePropertyChanged("CmesList");
                    }
                    else
                    {
                        ShowError(result.ErrorMessage);
                    }
                    IsLoading = false;
                });
            }
        }

        public void RegisterCME(Action<bool> oncomplete)
        {
            if (!string.IsNullOrEmpty(NewCMERegistration.Name) ||
                !string.IsNullOrEmpty(NewCMERegistration.Employer) ||
                !string.IsNullOrEmpty(NewCMERegistration.Email) ||
                !string.IsNullOrEmpty(NewCMERegistration.ContactNumber))
            {
                IsLoading = true;
                WebService.PostObject<CMEReg>("cme/registercme", NewCMERegistration, result =>
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

        public void ResetReg()
        {
            NewCMERegistration.Name = string.Empty;
            NewCMERegistration.ContactNumber = string.Empty;
            NewCMERegistration.Employer = string.Empty;
            NewCMERegistration.Email = string.Empty;

            NewCMERegistration.RaisePropertyChanged("Name");
            NewCMERegistration.RaisePropertyChanged("ContactNumber");
            NewCMERegistration.RaisePropertyChanged("Employer");
            NewCMERegistration.RaisePropertyChanged("Email");
        }
    }
}
