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
        private NewsViewModel VM { get; set; }
        public static string HeaderTitle = "News";
        private ListView lvNews;
        public NewsListPage()
            : base()
        {
            VM = ViewModelLocator.NewsVM;
            BindingContext = VM;
            lblTitle.Text = HeaderTitle;

            lvNews.ItemSelected += (s, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as News;
                    VM.SelectedNews = selected;
                    lvNews.SelectedItem = null;
                    Navigation.PushAsync(new NewsDetailPage());
                }
            };
            VM.ShowAlert = this.DisplayAlert;
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
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            VM.LoadNews();
        }
    }
}
