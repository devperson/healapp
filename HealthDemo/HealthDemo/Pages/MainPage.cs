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
                    Navigation.PushAsync(new SearchDoctorPage());
                };
            btnTips.Clicked += (s, e) =>
                {
                    Navigation.PushAsync(new CategoryListPage());
                };
        }

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stackLayout = new StackLayout() { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            var itemContent = CreateItemStacklayout();
            btnDoctors = CreateButton(ImageSource.FromFile(Device.OnPlatform("Doctor.png", "Doctor.png", "Images/Doctor.png")), "Find Doctors");
            btnTips = CreateButton(ImageSource.FromFile(Device.OnPlatform("HealthTips.png", "HealthTips.png", "Images/HealthTips.png")), "Health Tips");
            itemContent.Children.Add(btnDoctors);
            itemContent.Children.Add(btnTips);
            stackLayout.Children.Add(itemContent);

            var itemContent2 = CreateItemStacklayout();
            btnInsurance = CreateButton(ImageSource.FromFile(Device.OnPlatform("creditcardicon.png", "creditcardicon.png", "Images/creditcardicon.png")), "Insurance");
            btnNews = CreateButton(ImageSource.FromFile(Device.OnPlatform("news.png", "news.png", "Images/news.png")), "News");
            itemContent2.Children.Add(btnInsurance);
            itemContent2.Children.Add(btnNews);
            stackLayout.Children.Add(itemContent2);

            var itemContent3 = CreateItemStacklayout();
            btnFaq = CreateButton(ImageSource.FromFile(Device.OnPlatform("faq.png", "faq.png", "Images/faq.png")), "Faq");
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
                Padding = new Thickness(0, 50, 0, 0),
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
        }
    }
}
