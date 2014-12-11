using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class CMEDetailsPage : MasterPage
    {
        private Grid contentGrid;
        private Button btnRegister;
        public CMEDetailsPage()
            : base(false)
        {
            BindingContext = ViewModelLocator.CmeVM.SelectedCme;
            lblTitle.Text = "CME";
            btnRegister.Clicked += (s, e) =>
            {
                Navigation.PushAsync(new RegisterCmePage());
            };
        }

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Spacing = 0, Padding = new Thickness(0, 0, 0, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };
            contentGrid = new Grid
            {
                Padding = new Thickness(5, 10, 15, 25),
                ColumnSpacing = 7,
                RowSpacing = 15,
                VerticalOptions = LayoutOptions.Start,
                RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }                    
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)}
                }
            };

            contentGrid.AddLabel("Title:", 0);
            contentGrid.AddLabelWithBinding("Title", 0, 1);
            contentGrid.AddLabel("Speaker:", 1);
            contentGrid.AddLabelWithBinding("Speaker", 1, 1);
            contentGrid.AddLabel("Venue:", 2);
            contentGrid.AddLabelWithBinding("Venue", 2, 1);
            contentGrid.AddLabel("Description:", 3);
            contentGrid.AddLabelWithBinding("Description", 3, 1);
            contentGrid.AddLabel("Credit Hour:", 4);
            contentGrid.AddLabelWithBinding("CreditHour", 4, 1);
            contentGrid.AddLabel("Time and Date:", 5);
            contentGrid.AddLabelWithBinding("DateFormated", 5, 1);

            btnRegister = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 200,
                HeightRequest = 40,
                TextColor = Color.Black,
                Text = "Register"
            };

            stlayout.Children.Add(contentGrid);
            stlayout.Children.Add(btnRegister);

            scrollview.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
            {
                btnRegister.Font = Font.SystemFontOfSize(16);
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);
        }
    }
}
