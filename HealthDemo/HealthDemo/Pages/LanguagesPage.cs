using HealthDemo.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class LanguagesPage : ContentPage
    {
        IAppLoader _appLoader;
        public LanguagesPage(IAppLoader appLoader)
        {
            _appLoader = appLoader;
            this.Content = this.CreateLayout();
        }

        private View CreateLayout()
        {            
            StackLayout verticalStack = new StackLayout();
            verticalStack.Orientation = StackOrientation.Vertical;       
            verticalStack.VerticalOptions = LayoutOptions.CenterAndExpand;
            verticalStack.HorizontalOptions = LayoutOptions.FillAndExpand;                 

            Image logo = new Image();
            logo.Source = ImageSource.FromFile("logo.jpg");
            verticalStack.Children.Add(logo);

            var buttonsStack = MainPage.CreateItemStacklayout();
            buttonsStack.Spacing = Device.OnPlatform(25, 25, 10);

            var btnEn = this.GetImageButton("eng.png");          
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                btnEn.Opacity = 0.6;
                App.SelectedLocal = "En";
                _appLoader.ShowMainPage();
            };
            btnEn.GestureRecognizers.Add(tapGestureRecognizer);
            buttonsStack.Children.Add(btnEn);

            var btnAr = this.GetImageButton("ar.png");
            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                btnAr.Opacity = 0.6;
                App.SelectedLocal = "Ar";
                _appLoader.ShowMainPage();
            };
            btnAr.GestureRecognizers.Add(tapGestureRecognizer);
            buttonsStack.Children.Add(btnAr);
            
            verticalStack.Children.Add(buttonsStack);
            var contentControl = new ContentView();
            contentControl.VerticalOptions = LayoutOptions.FillAndExpand;
            contentControl.HorizontalOptions = LayoutOptions.FillAndExpand;
            contentControl.BackgroundColor = Color.White;
            contentControl.Content = verticalStack;

            return contentControl;
        }
       
        private Image GetImageButton(string imgFile)
        {
            var btn = new Image();
            btn.WidthRequest = Device.OnPlatform(80, 100, 60);
            btn.HeightRequest = Device.OnPlatform(90, 80, 80);
            btn.Source = ImageSource.FromFile(imgFile);
            if (Device.OS == TargetPlatform.Android)
                btn.Aspect = Aspect.AspectFit;
            else
                btn.Aspect = Aspect.AspectFill;

            return btn;
        }
    }
}
