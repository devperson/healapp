using HealthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class InsuranceViewModel : ViewModelBase
    {
        public InsuranceViewModel()
        {
            InsuranceList = new List<Insurance>();
        }
        public Insurance SelectedInsurance { get; set; }
        public List<Insurance> InsuranceList { get; set; }
        public void LoadInsurances()
        {
            if (InsuranceList.Count == 0)
            {
                IsLoading = true;
                WebService.GetInsurances(result =>
                {
                    if (result.Success)
                    {
                        InsuranceList = result.Result;
                        RaisePropertyChanged("InsuranceList");
                    }
                    else
                    {
                        ShowError(result.ErrorMessage);
                    }
                    IsLoading = false;
                });
            }
        }
    }
}
