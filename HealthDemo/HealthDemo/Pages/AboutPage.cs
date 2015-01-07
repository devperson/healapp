//using HealthDemo.Resx;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class AboutPage : MasterPage
    {
        public static string HeaderTitle;
        public AboutPage()
            : base(false)
        {            
            HeaderTitle = AppResources.About_HeaderTitle;
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
                Text = AppResources.About_Content,
                XAlign = TextAlignment.Center
            };

            stackLayout.Children.Add(label);
            parent.Children.Add(stackLayout);
        }        
    }
}
