using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class RegisterCmePage : MasterPage
    {
        private Button btnRegister, btnReset;
        public RegisterCmePage()
            : base()
        {
            btnRegister.Clicked += (sender, args) =>
            {
                ViewModelLocator.CmeVM.RegisterCME(async (success) =>
                {
                    if (success)
                    {
                        await this.DisplayAlert("Request has been sent!", "Thank you for submitting your request, you will be contracted shortly", "OK");
                        Navigation.PopToRootAsync();
                    }
                });
            };

            btnReset.Clicked += (sender, args) =>
            {
                ViewModelLocator.CmeVM.ResetReg();
            };

        }

        protected override void RenderContentView(StackLayout parent)
        {
            ViewModelLocator.CmeVM.NewCMERegistration = new Models.CMEReg();

            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Spacing = 5, Padding = new Thickness(30, 15, 30, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };


            stlayout.Children.Add(CreateItem("Title", "SelectedCme.Title", ViewModelLocator.CmeVM.SelectedCme, isLabel: true));
            stlayout.Children.Add(CreateItem("Name", "NewCMERegistration.Name",ViewModelLocator.CmeVM.NewCMERegistration));
            stlayout.Children.Add(CreateItem("Employer","NewCMERegistration.Employer",ViewModelLocator.CmeVM.NewCMERegistration));
            stlayout.Children.Add(CreateItem("Contact Number", "NewCMERegistration.ContactNumber",ViewModelLocator.CmeVM.NewCMERegistration,Keyboard.Numeric));
            stlayout.Children.Add(CreateItem("Email", "NewCMERegistration.Email", ViewModelLocator.CmeVM.NewCMERegistration, Keyboard.Email));

            var stackButtons = new StackLayout() { Spacing = 15, Padding = new Thickness(0, 15, 0, 0), HorizontalOptions = LayoutOptions.CenterAndExpand, Orientation = StackOrientation.Horizontal };
            btnRegister = CreateButton("Register");
            btnReset = CreateButton("Reset");
            stackButtons.Children.Add(btnRegister);
            stackButtons.Children.Add(btnReset);
            stlayout.Children.Add(stackButtons);

            scrollview.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
            {
                btnRegister.Font = Font.SystemFontOfSize(16);
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);
        }

        private Button CreateButton(string title)
        {
            return new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                WidthRequest = 120,
                HeightRequest = 40,
                TextColor = Color.Black,
                Text = title
            };
        }

        private StackLayout CreateItem(string title, string binding, object context,Keyboard key = null, bool isLabel = false)
        {
            var titleStack = new StackLayout() { Orientation = StackOrientation.Vertical };
            titleStack.BindingContext = context;
            titleStack.Children.Add(new Label()
            {
                Text = title
            });
            if (isLabel)
            {
                var lblTitle = new Label();
                lblTitle.SetBinding(Label.TextProperty, new Binding(binding));
                titleStack.Children.Add(lblTitle);
            }
            else
            {
                var txtName = new CustomTextBox() { HorizontalOptions = LayoutOptions.FillAndExpand };
                txtName.SetBinding(Entry.TextProperty, binding, BindingMode.TwoWay);
                if (key != null)
                    txtName.Keyboard = key;
                titleStack.Children.Add(txtName);
            }
            return titleStack;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.CmeVM.ShowAlert = this.DisplayAlert;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.CmeVM.ShowAlert = null;
        }
    }
}
