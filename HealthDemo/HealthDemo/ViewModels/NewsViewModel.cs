using HealthDemo.Models;
using HealthDemo.Models.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class NewsViewModel : ViewModelBase
    {
        public NewsViewModel()
        {
            NewsList = new List<News>();
        }

        public News SelectedNews { get; set; }
        public List<News> NewsList { get; set; }
        public void LoadNews()
        {
            if (NewsList.Count == 0)
            {
                IsLoading = true;
                WebService.GetList<NewsResponse, News>("news", result =>
                {
                    if (result.Success)
                    {
                        NewsList = result.Result;
                        RaisePropertyChanged("NewsList");
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
