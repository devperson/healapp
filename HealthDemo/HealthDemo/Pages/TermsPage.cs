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
    public class TermsPage : MasterPage
    {   
        private Button btnOk;
        //private FileViewModel VM { get; set; }
        public TermsPage():base()
        {
            //VM = ViewModelLocator.FileVM;
            this.BindingContext = ViewModelLocator.FileVM;
            btnOk.Clicked += (s, e) =>
            {
                ViewModelLocator.FileVM.SendFile(success =>
                {
                    if(success)
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                            {
                                await this.DisplayAlert("File has been sent!", "Thank you for submitting the File, you will be contacted shortly", "OK");
                                Navigation.PopToRootAsync();
                            });
                    }
                });
            };
        }
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
            lblTerms.Text = LoadTermsText();

            btnOk = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                TextColor = Color.Black,
                Text = "I agree",
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

		private string LoadTermsText()
		{
			var assembly = typeof(TermsPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("HealthDemo.Terms.txt");
			string text = string.Empty;
			using (var reader = new System.IO.StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}

			return text;

		}


		protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModelLocator.FileVM.ShowAlert = this.DisplayAlert;
		}


		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			ViewModelLocator.FileVM.ShowAlert = null;
		}
	}
}
   