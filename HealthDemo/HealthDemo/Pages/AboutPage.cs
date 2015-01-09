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
    /// <summary>
    /// This class creates UI page for About us page.
    /// </summary>
    public class AboutPage : MasterPage
    {        
        public AboutPage()
            : base(false)
        {                        
            lblTitle.Text = AppResources.About_HeaderTitle;
        }
        

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
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
