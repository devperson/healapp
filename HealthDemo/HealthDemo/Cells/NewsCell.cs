using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Cells
{
    public class 
        NewsCell: CustomCell
    {
        public NewsCell()
            : base()
        {
            var rootLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(8, 8, 8, 5)
            };

            var lblTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15,FontAttributes.Bold),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            var lblDate = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15)
            };
            lblDate.SetBinding(Label.TextProperty, new Binding("DateFormated"));
            var labelForDate = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15),
                Text = "Date:"
            };
            var stackDate = new StackLayout() { Orientation = StackOrientation.Horizontal};
            stackDate.Children.Add(labelForDate);
            stackDate.Children.Add(lblDate);
            var stackLayoutTitle = new StackLayout() {Spacing = 0, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            stackLayoutTitle.Children.Add(lblTitle);
            stackLayoutTitle.Children.Add(stackDate);

            var imgAccesory = new Image
            {
                Source = Device.OnPlatform("accesory.png", "accesory.png", "Images/accesory.png"),
                WidthRequest = 26,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            rootLayout.Children.Add(stackLayoutTitle);
            rootLayout.Children.Add(imgAccesory);

            View = rootLayout;
        }
    }
}
