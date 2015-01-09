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
    /// This class creates UI page for News list page.
    /// </summary>
    public class NewsListPage:MasterPage
    {                
        private ListView lvNews;
        public NewsListPage()
            : base()
        {
            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.NewsVM;            
            lblTitle.Text = AppResources.NewsList_Title;

            lvNews.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvNews.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as News;
                    ViewModelLocator.NewsVM.SelectedNews = selected;
                    lvNews.SelectedItem = null;
                    if (PageViewLocator.NewsDetailPage == null)
                        PageViewLocator.NewsDetailPage = new NewsDetailPage();
                    PageViewLocator.NewsDetailPage.BindingContext = selected;
                    Navigation.PushAsync(PageViewLocator.NewsDetailPage);
                }
            };
            
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            lvNews = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 100,
                ItemTemplate = new DataTemplate(typeof(NewsCell))
            };
            lvNews.SetBinding(ListView.ItemsSourceProperty, new Binding("NewsList"));
            parent.Children.Add(lvNews);
        }

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.NewsVM.ShowAlert = this.DisplayAlert;
            lvMenu.SelectedItem = this.MenuItems.FirstOrDefault(s => s.Title == lblTitle.Text);
            ViewModelLocator.NewsVM.LoadNews();
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.NewsVM.ShowAlert = null;
        }
    }
}
