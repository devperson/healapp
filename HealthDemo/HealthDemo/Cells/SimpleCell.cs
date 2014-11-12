using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Cells
{
    public class SimpleCell : CustomCell
    {
        public SimpleCell()
            : base()
        {
            var rootLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(8, 0, 8, 0)
            };

            var lblTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(17),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));

            var imgAccesory = new Image
            {
                Source = Device.OnPlatform("accesory.png", "accesory.png", "Images/accesory.png"),
                WidthRequest = 26,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            rootLayout.Children.Add(lblTitle);
            rootLayout.Children.Add(imgAccesory);

            View = rootLayout;
        }
    }

    public class SimpleCell2 : CustomCell
    {
        public SimpleCell2()
            : base()
        {
            var topMargin = Device.OnPlatform(10, 15, 10);
            var rootLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(8, topMargin, 8, topMargin)
            };

            var lblTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(17),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            rootLayout.Children.Add(lblTitle);
            View = rootLayout;
        }
    }
}
