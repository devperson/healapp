using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HealthDemo;


namespace HealthDemo.Cells
{
    /// <summary>
    /// This class represents UI cell for Doctor list.
    /// </summary>
    public class DoctorCell : CustomCell
    {        
        public DoctorCell()
            : base()
        {
            // Create layout for cell and bind with data.

            var rootLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0, 0, 8, 0)
            };

            var stackLayout1 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = this.IsEn() ? LayoutOptions.FillAndExpand : LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10, 20, 0, 0),
                Spacing = 0
            };

            var lblDTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(17),                
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
                Source = this.IsEn() ? "accesory.png" : "left_accesory.png",
                WidthRequest = 26,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            stackLayout1.Children.Add(lblDTitle);
            stackLayout1.Children.Add(lblPosition);
            stackLayout1.Children.Add(lblDepartament);

            rootLayout.Children.Add(stackLayout1);
            rootLayout.Children.Insert(this.IsEn() ? 1 : 0, imgAccesory);

            if (!this.IsEn())
            {
                rootLayout.ReverseLabelesAligment();
                rootLayout.ReverseLayoutPaddings();
            }
            
            View = rootLayout;
        }
    }

    public class CustomCell : ViewCell { }
}
