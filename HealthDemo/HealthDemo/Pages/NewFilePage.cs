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
    public class NewFilePage : MasterPage
    {
        private Grid contentGrid;
        private Button btnUpload, btnSubmit;
        public NewFilePage()
            : base()
        {            
            ViewModelLocator.FileVM.NewFile = new FileModel();
            this.BindingContext = ViewModelLocator.FileVM;
            this.contentGrid.BindingContext = ViewModelLocator.FileVM.NewFile;

            lblTitle.Text = AppResources.NewFile_Title;

            btnUpload.Clicked += async (s, e) =>
            {
                await ViewModelLocator.FileVM.ShowMediaPicker();
            };

            btnSubmit.Clicked += (s, e) =>
            {
                if (ViewModelLocator.FileVM.CheckValidation())
                    Navigation.PushAsync(new TermsPage());
                else DisplayAlert(AppResources.DLG_Error, AppResources.NewFile_SUBMIT_DLG_Msg, "OK");
            };
        }

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Spacing = 0, Padding = new Thickness(0, 0, 0, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };

            contentGrid = new Grid
            {
                Padding = new Thickness(5, 10, 15, 5),
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
                    new RowDefinition { Height = GridLength.Auto },
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = new GridLength(80, GridUnitType.Absolute)},//GridLength.Auto },
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)}
                }
            };

            if (!this.IsEn())
            {   
                contentGrid.ColumnDefinitions = new ColumnDefinitionCollection()
                {   
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = new GridLength(80, GridUnitType.Absolute)}
                };
            }

            contentGrid.AddLabel(AppResources.NewFile_Head, 0);
            contentGrid.AddLabel(string.Empty, 0, 1);
            contentGrid.AddLabel(AppResources.NewFile_Name, 1);
            contentGrid.AddTextField("Name", 1);
            contentGrid.AddLabel(AppResources.NewFile_Emirate, 2);
            contentGrid.AddTextField("EmirateID", 2, Keyboard.Numeric);
            contentGrid.AddLabel(AppResources.NewFile_Thiqa, 3);
            contentGrid.AddTextField("Thiqa", 3);
            contentGrid.AddLabel(AppResources.NewFile_Attach, 4);

            var txtUpload = new CustomTextBox
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                IsEnabled = false
            };
            txtUpload.SetBinding(Entry.TextProperty, "Path", BindingMode.TwoWay);
            btnUpload = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 75,
                HeightRequest = Device.OnPlatform(30, 35, 35),
                TextColor = Color.Black,
                Text = AppResources.NewFile_Upload
            };

            var uploadStack = new StackLayout() { Spacing = 2, Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand};
            uploadStack.Children.Add(txtUpload);
            uploadStack.Children.Insert(this.IsEn() ? 1 : 0, btnUpload);
            contentGrid.Children.Add(uploadStack, this.IsEn() ? 1 : 0, 4);

            btnSubmit = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Start,
                WidthRequest = 200,
                HeightRequest = 40,
                TextColor = Color.Black,
                Text = AppResources.NewFile_Submit
            };

            stlayout.Children.Add(contentGrid);
            stlayout.Children.Add(btnSubmit);

            scrollview.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
            {
                btnSubmit.Font = Font.SystemFontOfSize(16);
                btnUpload.Font = Font.SystemFontOfSize(14);
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);
        }
        
    }
}
