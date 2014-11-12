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
        private TipViewModel VM { get; set; }
        private ListView lvCategories;
        public static string HeaderTitle = "Categories";
        public CategoryListPage()
            : base()
        {
            VM = ViewModelLocator.TipVM;
            BindingContext = VM;

            lvCategories.ItemSelected += (s, e) =>
            {
                //var selected = e.SelectedItem as HealthCategory;
                //VM.SelectedCategory = selected;
                if (e.SelectedItem != null)
                    Navigation.PushAsync(new HealthTipListPage());
            };
            VM.ShowAlert = this.DisplayAlert;
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
            lvCategories.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedCategory", BindingMode.TwoWay));
            parent.Children.Add(lvCategories);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            VM.LoadCategories();
        }
    }
}
