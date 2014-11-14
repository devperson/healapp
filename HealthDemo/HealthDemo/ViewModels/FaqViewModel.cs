using HealthDemo.Models;
using HealthDemo.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class FaqViewModel : ViewModelBase
    {
        public FaqViewModel()
        {
            FAQList = new List<Faq>();
        }

        public Faq SelectedFAQ { get; set; }
        public List<Faq> FAQList { get; set; }
        public void LoadFaq()
        {
            if (FAQList.Count == 0)
            {
                IsLoading = true;
                WebService.GetList<FaqResponse,Faq>("faq", result =>
                {
                    if (result.Success)
                    {
                        FAQList = result.Result;
                        RaisePropertyChanged("FAQList");
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
