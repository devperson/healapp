using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class AboutPage : MasterPage
    {
        public static string HeaderTitle = "About us";
        public AboutPage()
            : base(false)
        {
            lblTitle.Text = HeaderTitle;
        }

        protected override void RenderContentView(StackLayout parent)
        {
            var stackLayout = new StackLayout() 
            {
                Padding = new Thickness(20, 35, 20, 10),
                Orientation = StackOrientation.Vertical, 
                VerticalOptions = LayoutOptions.FillAndExpand, 
                HorizontalOptions = LayoutOptions.FillAndExpand 
            };

            var label = new Label() 
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Font = Font.SystemFontOfSize(16),
                TextColor = Color.Black,
                Text = "Al Ain Hospital, a highly specialized acute care and emergency hospital with 402 beds and more than 35 medical departments and divisions, is one of two major hospitals in the AI Ain region of the Emirate of Abu Dhabi belonging to the health system of the Abu Dhabi Health Services Company SEHA (www.seha.ae)",
                XAlign = TextAlignment.Center
            };

            stackLayout.Children.Add(label);
            parent.Children.Add(stackLayout);
        }

        //protected override void OnMasterViewRendered()
        //{
        //    if (Device.OS == TargetPlatform.iOS)
        //    {
        //        //there seems some bug in xamarin because title croped to ten px
        //        titleLayout.HeightRequest += 10;
        //        titleImage.HeightRequest += 10;
        //    }
        //}
    }
}
