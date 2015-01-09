using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using HealthDemo.ViewModels;

namespace HealthDemo.Pages
{
    /// <summary>
    /// This class creates UI page for Terms page.
    /// </summary>
    public class TermsPage : MasterPage
    {   
        private Button btnOk;        
        public TermsPage():base()
        {            
            //Bind page with data and handle events

            this.BindingContext = ViewModelLocator.FileVM;
            btnOk.Clicked += (s, e) =>
            {
                ViewModelLocator.FileVM.SendFile(success =>
                {
                    if(success)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                            {
                                await this.DisplayAlert(AppResources.TermsPage_DLG_Title, AppResources.TermsPage_DLG_Msg, "OK");
                                Navigation.PopToRootAsync();
                            });
                    }
                });
            };
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            var rootLayout = new StackLayout() { Spacing = 5, Padding = new Thickness(15, 10, 15, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            
            var lblTerms = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(16),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };
            lblTerms.Text = AppResources.TermsPage_TermsText;//LoadTermsText();

            btnOk = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                TextColor = Color.Black,
                Text = AppResources.TermsPage_Agree,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 200,
                HeightRequest = 40,
            }; 

            scrollview.Content = lblTerms;
			if (Device.OS == TargetPlatform.Android)
				scrollview.IsClippedToBounds = true;
            rootLayout.Children.Add(scrollview);
            rootLayout.Children.Add(btnOk);

			parent.Children.Add(rootLayout);
        }

        //private string LoadTermsText()
        //{
        //    var assembly = typeof(TermsPage).GetTypeInfo().Assembly;
        //    Stream stream = assembly.GetManifestResourceStream("HealthDemo.Terms.txt");
        //    string text = string.Empty;
        //    using (var reader = new System.IO.StreamReader(stream))
        //    {
        //        text = reader.ReadToEnd();
        //    }

        //    return text;
        //}

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModelLocator.FileVM.ShowAlert = this.DisplayAlert;
		}

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			ViewModelLocator.FileVM.ShowAlert = null;
		}
	}
}
   