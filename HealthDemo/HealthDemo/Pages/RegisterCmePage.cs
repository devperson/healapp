using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HealthDemo.Utils;

namespace HealthDemo.Pages
{
    /// <summary>
    /// This class creates UI page for Cme registraction page.
    /// </summary>
    public class RegisterCmePage : MasterPage
    {
        private Button btnRegister, btnReset;
        public RegisterCmePage()
            : base()
        {
            //Handle button click events

            btnRegister.Clicked += (sender, args) =>
            {
                ViewModelLocator.CmeVM.RegisterCME(async (success) =>
                {
                    if (success)
                    {
                        await this.DisplayAlert(AppResources.Appointment_SUBMIT_DLG_Title, AppResources.Appointment_SUBMIT_DLG_Msg, "OK");
                        Navigation.PopToRootAsync();
                    }
                });
            };

            btnReset.Clicked += (sender, args) =>
            {
                ViewModelLocator.CmeVM.ResetReg();
            };
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            ViewModelLocator.CmeVM.NewCMERegistration = new Models.CMEReg();

            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Spacing = 5, Padding = new Thickness(30, 15, 30, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };


            stlayout.Children.Add(CreateItem(AppResources.RegCme_Title, "SelectedCme.Title", ViewModelLocator.CmeVM.SelectedCme, isLabel: true));
            stlayout.Children.Add(CreateItem(AppResources.RegCme_Name, "NewCMERegistration.Name",ViewModelLocator.CmeVM.NewCMERegistration));
            stlayout.Children.Add(CreateItem(AppResources.RegCme_Employer,"NewCMERegistration.Employer",ViewModelLocator.CmeVM.NewCMERegistration));
            stlayout.Children.Add(CreateItem(AppResources.RegCme_Contact, "NewCMERegistration.ContactNumber",ViewModelLocator.CmeVM.NewCMERegistration,Keyboard.Numeric));
            stlayout.Children.Add(CreateItem(AppResources.RegCme_Email, "NewCMERegistration.Email", ViewModelLocator.CmeVM.NewCMERegistration, Keyboard.Email));

            var stackButtons = new StackLayout() { Spacing = 15, Padding = new Thickness(0, 15, 0, 0), HorizontalOptions = LayoutOptions.CenterAndExpand, Orientation = StackOrientation.Horizontal };
            btnRegister = this.CreateButton(AppResources.RegCme_Register);
            btnReset = this.CreateButton(AppResources.RegCme_Reset);
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

        
        /// <summary>
        /// Helper method for creating labeled Text box control for user input.        
        /// </summary>        
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

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.CmeVM.ShowAlert = this.DisplayAlert;
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.CmeVM.ShowAlert = null;
        }
    }
}
