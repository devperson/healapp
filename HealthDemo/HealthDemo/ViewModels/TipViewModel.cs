using HealthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthDemo.ViewModels
{
    public class TipViewModel : ViewModelBase
    {
        public TipViewModel()
        {
            CategoryList = new List<HealthCategory>();
            TipsList = new List<HealthTip>();
        }

        public string SelectedCategoryTitle { get; set; }
        private HealthCategory _category;
        public HealthCategory SelectedCategory
        {
            get { return _category; }
            set 
            { 
                _category = value;
                RaisePropertyChanged("SelectedCategory");
                if (_category != null) SelectedCategoryTitle = _category.Title;
            }
        }

        HealthTip _selectedTip;
        public HealthTip SelectedTip 
        {
            get { return _selectedTip; }
            set
            {
                _selectedTip = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }
        public List<HealthCategory> CategoryList { get; set; }
        public List<HealthTip> TipsList { get; set; }

        public void LoadCategories()
        {
            if (CategoryList.Count == 0)
            {
                IsLoading = true;
                WebService.GetCategories(result =>
                    {
                        if (result.Success)
                        {
                            CategoryList = result.Result;
                            RaisePropertyChanged("CategoryList");
                        }
                        else
                        {
                            ShowError(result.ErrorMessage);
                        }
                        IsLoading = false;
                    });
            }
        }

        public void LoadTips()
        {
            if (TipsList.Count == 0 || (TipsList.Count > 0 && !TipsList.All(s => s.CategoryID == SelectedCategory.ID)))
            {
                IsLoading = true;
                WebService.GetHealthTipsByCategory(SelectedCategory.ID, result =>
                {
                    if (result.Success)
                    {
                        TipsList = result.Result;
                        RaisePropertyChanged("TipsList");
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
