﻿using HealthDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace HealthDemo.Pages
{
    /// <summary>
    /// This class creates page with Map UI control.
    /// </summary>
    public class LocationPage : MasterPage
    {        
        public LocationPage() : base(false, Device.OnPlatform(false, true, true)) { }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(Xamarin.Forms.StackLayout parent)
        {
            lblTitle.Text = AppResources.Location_Title;
            var position = new Position(24.230388, 55.733529);
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = position,
                Label = AppResources.Location_Pin
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
