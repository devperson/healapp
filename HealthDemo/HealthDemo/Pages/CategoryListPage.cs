using HealthDemo.Cells;
using HealthDemo.Models;
using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class CategoryListPage : MasterPage
    {
        //private TipViewModel VM { get; set; }
        private ListView lvCategories;
        public static string HeaderTitle = "Categories";
        public CategoryListPage()
            : base()
        {
            //VM = ViewModelLocator.TipVM;
            BindingContext = ViewModelLocator.TipVM;

            lvCategories.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvCategories.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as HealthCategory;
                    ViewModelLocator.TipVM.SelectedCategory = selected;
                    lvCategories.SelectedItem = null;

                    if (PageViewLocator.HealthTipListPage == null)
                        PageViewLocator.HealthTipListPage = new HealthTipListPage();
                    this.Navigation.PushAsync(PageViewLocator.HealthTipListPage);                    
                }
            };
           
            lblTitle.Text = HeaderTitle;
        }

        protected override void RenderContentView(StackLayout parent)
        {
            lvCategories = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 65,
                ItemTemplate = new DataTemplate(typeof(SimpleCell))
            };
            lvCategories.SetBinding(ListView.ItemsSourceProperty, new Binding("CategoryList"));
            //lvCategories.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedCategory", BindingMode.TwoWay));
            parent.Children.Add(lvCategories);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.TipVM.LoadCategories();
            ViewModelLocator.TipVM.ShowAlert = this.DisplayAlert;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.TipVM.ShowAlert = null;
        }
    }
}
