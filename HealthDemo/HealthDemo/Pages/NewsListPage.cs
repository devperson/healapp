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
    public class NewsListPage:MasterPage
    {
        //private NewsViewModel VM { get; set; }
        public static string HeaderTitle = "News";
        private ListView lvNews;
        public NewsListPage()
            : base()
        {
            //VM = ViewModelLocator.NewsVM;
            BindingContext = ViewModelLocator.NewsVM;
            lblTitle.Text = HeaderTitle;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.NewsVM.ShowAlert = this.DisplayAlert;
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.NewsVM.LoadNews();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.NewsVM.ShowAlert = null;
        }
    }
}
