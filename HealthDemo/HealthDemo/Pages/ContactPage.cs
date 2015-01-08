using HealthDemo.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class ContactPage : MasterPage
    {        
        public ContactPage()
            : base(false)
        {            
            lblTitle.Text = AppResources.Contact_Title;
        }

        protected override void RenderContentView(StackLayout parent)
        {
            var stackLayout = new StackLayout()
            {
                Spacing = 6,
                Padding = new Thickness(20, 15, 20, 10),
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            if (!this.IsEn())
                stackLayout.HorizontalOptions = LayoutOptions.EndAndExpand;

            var label = new Label()
            {   
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(16),
                TextColor = Color.Black,
                Text = AppResources.Contact_Content,
                XAlign = TextAlignment.Center
            };

            var numbersLayout = new StackLayout()
            {
                Spacing = 0,
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            if (!this.IsEn())
                stackLayout.HorizontalOptions = LayoutOptions.EndAndExpand;

            var lbltitle = new Label()
            {   
                HorizontalOptions = LayoutOptions.Center,
                Font = Font.SystemFontOfSize(16),
                TextColor = Color.Black,
                Text = AppResources.Contact_Outline
            };
            numbersLayout.Children.Add(lbltitle);
            numbersLayout.Children.Add(CreateTelItem(AppResources.Contact_CallCenter, "03-7022000"));
            numbersLayout.Children.Add(CreateTelItem(AppResources.Contact_Ambulance, "03-7022555"));
            numbersLayout.Children.Add(CreateTelItem(AppResources.Contact_Thiqa, "03-7023669"));
            numbersLayout.Children.Add(CreateTelItem(AppResources.Contact_Police, "03-7022446"));

            stackLayout.Children.Add(label);
            stackLayout.Children.Add(numbersLayout);
            parent.Children.Add(stackLayout);
        }

        public StackLayout CreateTelItem(string title, string number)
        {
            var telLayout = new StackLayout()
            {
                Spacing = Device.OnPlatform(5, 0, 5),
                Orientation = StackOrientation.Horizontal
            };

            if (!this.IsEn())
                telLayout.HorizontalOptions = LayoutOptions.EndAndExpand;

            var lblcenter = new Label()
            {
                VerticalOptions = LayoutOptions.Center,
                Font = Font.SystemFontOfSize(15),
                TextColor = Color.Black,
                Text = title
            };
            var lblNumber = new Button()
            {
                Font = Font.SystemFontOfSize(Device.OnPlatform(16, 13, 13)),
                TextColor = Color.Blue,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.Center,
                Text = number,
                HeightRequest = 30
            };

            lblNumber.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                var telFeature = DependencyService.Get<ITel>();
                telFeature.Tel(lblNumber.Text);
            };

            if (this.IsEn())
            {
                telLayout.Children.Add(lblcenter);
                telLayout.Children.Add(lblNumber);
            }
            else
            {
                lblNumber.HorizontalOptions = LayoutOptions.End;
                telLayout.Children.Add(lblNumber);
                telLayout.Children.Add(lblcenter);                
            }
            
            return telLayout;
        }        
    }
}
