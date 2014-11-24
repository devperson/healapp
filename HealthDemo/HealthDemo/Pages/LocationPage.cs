using HealthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HealthDemo.Pages
{
    public class LocationPage : MasterPage
    {
        public static string HeaderTitle = "Find us";
        public LocationPage() : base(false, Device.OnPlatform(false, true, true)) { }

        protected override void RenderContentView(Xamarin.Forms.StackLayout parent)
        {
            lblTitle.Text = HeaderTitle;
            var position = new Position(24.230388, 55.733529);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = "Al-Ain Hospital"
            };

            var map = new Map(MapSpan.FromCenterAndRadius(pin.Position, Distance.FromMiles(0.2)))
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                IsShowingUser = true
            };

            map.Pins.Add(pin);
            
            var stackLayout = new StackLayout() {Padding = 15, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            stackLayout.Children.Add(map);
            parent.Children.Add(stackLayout);
        }

    }


    
}
