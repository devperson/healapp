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
        ImageButton btnDoctors, btnTips;
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
            var content = new StackLayout()
            {
                Padding = new Thickness(0, 50, 0, 0),
                Orientation = StackOrientation.Horizontal,
                Spacing = Device.OnPlatform(0, 25, 10),
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            btnDoctors = CreateButton(ImageSource.FromFile(Device.OnPlatform("Doctor.png", "Doctor.png", "Images/Doctor.png")), "Find Doctors");
            btnTips = CreateButton(ImageSource.FromFile(Device.OnPlatform("HealthTips.png", "HealthTips.png", "Images/HealthTips.png")), "Health Tips");
            content.Children.Add(btnDoctors);
            content.Children.Add(btnTips);

            parent.Children.Add(content);

            btnBack.Source = null;
            lblTitle.Text = HeaderTitle;
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
