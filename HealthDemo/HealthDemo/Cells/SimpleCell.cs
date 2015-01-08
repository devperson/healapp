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
                VerticalOptions = LayoutOptions.Center,
                XAlign = this.IsEn() ? TextAlignment.Start : TextAlignment.End
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));

            var imgSource = this.IsEn() ? "accesory.png" : "left_accesory.png";
            var imgAccesory = new Image
            {
                Source = imgSource,
                WidthRequest = 26,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            if (this.IsEn())
            {
                rootLayout.Children.Add(lblTitle);
                rootLayout.Children.Add(imgAccesory);
            }
            else
            {
                rootLayout.Children.Add(imgAccesory);
                rootLayout.Children.Add(lblTitle);
            }

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
                VerticalOptions = LayoutOptions.Center,
                XAlign = this.IsEn() ? TextAlignment.Start : TextAlignment.End
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            rootLayout.Children.Add(lblTitle);
            View = rootLayout;
        }
    }
}
