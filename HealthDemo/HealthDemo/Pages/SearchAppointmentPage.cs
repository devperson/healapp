using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class SearchAppointmentPage : MasterPage
    {
        private Button btnSearch, btnReset;
        public SearchAppointmentPage()
            : base(false)
        {
            ViewModelLocator.AppointmentVM.ResetFields();
            this.BindingContext = ViewModelLocator.AppointmentVM;

            btnSearch.Clicked += (s, e) =>
                {
                    if (!string.IsNullOrEmpty(ViewModelLocator.AppointmentVM.Emirate) &&
                        !string.IsNullOrEmpty(ViewModelLocator.AppointmentVM.Mrn))
                    {
                        Navigation.PushAsync(new AppointResultPage());
                    }
                    else DisplayAlert("Error", "Please fill the form. All fields are required", "OK");
                };
            btnReset.Clicked += (s, e) =>
                {
                    ViewModelLocator.AppointmentVM.ResetFields();
                };
        }

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Spacing = 0, Padding = new Thickness(0, 15, 0, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };
            var contentGrid = new Grid
            {
                Padding = new Thickness(5, 10, 15, 0),
                ColumnSpacing = 7,
                RowSpacing = 15,
                VerticalOptions = LayoutOptions.Start,
                RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)}
                }
            };

            contentGrid.AddLabel("Emirates ID:", 0);
            contentGrid.AddTextField("Emirate", 0, Keyboard.Numeric);
            contentGrid.AddLabel("MRN:", 1);
            contentGrid.AddTextField("Mrn", 1);

            var stackButtons = new StackLayout() { Spacing = 15, Padding = new Thickness(0, 15, 0, 0), HorizontalOptions = LayoutOptions.CenterAndExpand, Orientation = StackOrientation.Horizontal };
            btnSearch = this.CreateButton("Search");
            btnReset = this.CreateButton("Reset");
            stackButtons.Children.Add(btnSearch);
            stackButtons.Children.Add(btnReset);
            

            stlayout.Children.Add(contentGrid);
            stlayout.Children.Add(stackButtons);

            scrollview.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
            {   
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);
        }
    }
}
