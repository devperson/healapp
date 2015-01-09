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
    /// This class represents Cme view model and contains related data and actions.
    /// </summary>
    public class CmeViewModel : ViewModelBase
    {
        public CmeViewModel()
        {
            CmesList = new List<Cme>();
        }

        public CMEReg NewCMERegistration { get; set; }
        public Cme SelectedCme { get; set; }
        public List<Cme> CmesList { get; set; }

        /// <summary>
        /// Retrives all cme objects from server.
        /// </summary>
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

        /// <summary>
        /// Registers new Cme on server.
        /// </summary>        
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
            else ShowAlert(AppResources.DLG_Error, AppResources.Cme_REGISTER_DLG_Msg, "OK");
        }

        /// <summary>
        /// Resets all fields
        /// </summary>
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
