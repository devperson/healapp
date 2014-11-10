using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Cells
{
    public class DoctorCell : CustomCell
    {
        public DoctorCell()
            : base()
        {
            var rootLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //BackgroundColor = Color.White,
                Padding = new Thickness(0, 0, 8, 0) 
            };

            var stackLayout1 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10, 20, 0, 0),
                Spacing = 0
            };

            var lblDTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(17)
            };
            lblDTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            var lblPosition = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(13)
            };
            lblPosition.SetBinding(Label.TextProperty, new Binding("Position"));
            var lblDepartament = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(13)
            };
            lblDepartament.SetBinding(Label.TextProperty, new Binding("Department"));

            var imgAccesory = new Image
            {   
                Source = Device.OnPlatform("accesory.png", "accesory.png", "Images/accesory.png"),
                WidthRequest = 26,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            stackLayout1.Children.Add(lblDTitle);
            stackLayout1.Children.Add(lblPosition);
            stackLayout1.Children.Add(lblDepartament);
            rootLayout.Children.Add(stackLayout1);
            rootLayout.Children.Add(imgAccesory);

            View = rootLayout;
        }
    }

    public class CustomCell : ViewCell { }
}
