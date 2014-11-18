using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;

namespace HealthDemo.Pages
{
    public class MainPage : MasterPage
    {
        public static string HeaderTitle = "Main Page";
        ImageButton btnDoctors, btnTips, btnInsurance, btnNews, btnFaq;
        public MainPage() : base() 
        {
            btnDoctors.Clicked += (s, e) =>
            {
                //if (PageViewLocator.SearchDoctorPage == null)
                    //PageViewLocator.SearchDoctorPage = new SearchDoctorPage();
                Navigation.PushAsync(new SearchDoctorPage());
            };
            btnTips.Clicked += (s, e) =>
            {
                //if (PageViewLocator.CategoryListPage == null)
                    //PageViewLocator.CategoryListPage = new CategoryListPage();
                Navigation.PushAsync(new CategoryListPage());
            };
            btnInsurance.Clicked += (s, e) =>
            {
                //if (PageViewLocator.InsuranceListPage == null)
                    //PageViewLocator.InsuranceListPage = new InsuranceListPage();
                Navigation.PushAsync(new InsuranceListPage());
            };
            btnNews.Clicked += (s, e) =>
            {
                //if (PageViewLocator.NewsListPage == null)
                    //PageViewLocator.NewsListPage = new NewsListPage();
                    Navigation.PushAsync(new NewsListPage());
            };
            btnFaq.Clicked += (s, e) =>
            {
                //if (PageViewLocator.FaqListPage == null)
                    //PageViewLocator.FaqListPage = new FaqListPage();
                Navigation.PushAsync(new FaqListPage());              
            };

        }

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stackLayout = new StackLayout() { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            var itemContent = CreateItemStacklayout();
            btnDoctors = CreateButton(ImageSource.FromFile(Device.OnPlatform("Doctor.jpg", "Doctor.jpg", "Images/Doctor.jpg")), "Find Doctors");
            btnTips = CreateButton(ImageSource.FromFile(Device.OnPlatform("HealthTips.jpg", "HealthTips.jpg", "Images/HealthTips.jpg")), "Health Tips");
            itemContent.Children.Add(btnDoctors);
            itemContent.Children.Add(btnTips);
            stackLayout.Children.Add(itemContent);

            var itemContent2 = CreateItemStacklayout();
            btnInsurance = CreateButton(ImageSource.FromFile(Device.OnPlatform("creditcardicon.png", "creditcardicon.jpg", "Images/creditcardicon.jpg")), "Insurance");
            btnNews = CreateButton(ImageSource.FromFile(Device.OnPlatform("news.jpg", "news.jpg", "Images/news.jpg")), "News");
            itemContent2.Children.Add(btnInsurance);
            itemContent2.Children.Add(btnNews);
            stackLayout.Children.Add(itemContent2);

            var itemContent3 = CreateItemStacklayout();
            btnFaq = CreateButton(ImageSource.FromFile(Device.OnPlatform("faq.jpg", "faq.jpg", "Images/faq.jpg")), "Faq");
            itemContent3.Children.Add(btnFaq);
            stackLayout.Children.Add(itemContent3);

            scrollview.Content = stackLayout;
            parent.Children.Add(scrollview);

            btnBack.Source = null;
            lblTitle.Text = HeaderTitle;
        }

        private static StackLayout CreateItemStacklayout()
        {
            var itemContent = new StackLayout()
            {
                Padding = new Thickness(0, 20, 0, 0),
                Orientation = StackOrientation.Horizontal,
                Spacing = Device.OnPlatform(0, 25, 10),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            return itemContent;
        }

        private ImageButton CreateButton(ImageSource imgSource, string text)
        {
            
            return new ImageButton()
            {
                Source = imgSource,
                Orientation = Xamarin.Forms.Labs.Enums.ImageOrientation.ImageOnTop,
                HeightRequest = Device.OnPlatform(120, 100, 100),
                WidthRequest = Device.OnPlatform(150, 120, 120),
                ImageHeightRequest = Device.OnPlatform(60,90,60),
                ImageWidthRequest = Device.OnPlatform(60, 90, 60),
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                Text = text
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();

            if (PageViewLocator.ReadyToPush)
            {
                PageViewLocator.NavigationPage.PushAsync(PageViewLocator.PushingPage);
            }
        }
    }
}
