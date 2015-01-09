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
    /// <summary>
    /// This class creates UI page for Tip categories list page.
    /// </summary>
    public class CategoryListPage : MasterPage
    {        
        private ListView lvCategories;
        
        public CategoryListPage() : base()
        {
            //Bind page with data and handle button click events

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

            lblTitle.Text = AppResources.Category_Title;
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
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
            parent.Children.Add(lvCategories);
        }

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.TipVM.LoadCategories();
            ViewModelLocator.TipVM.ShowAlert = this.DisplayAlert;
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.TipVM.ShowAlert = null;
        }
    }
}
