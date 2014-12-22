﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Cells
{
    public class AppointResultCell: CustomCell
    {
        public AppointResultCell()
            : base()
        {
            var rootLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //BackgroundColor = Color.White,
                Padding = new Thickness(0, 10, 0, 10)
            };

            rootLayout.Children.Add(CreateLabel("Number", 30));
            rootLayout.Children.Add(CreateLabel("FormattedApptLocation", 140));
            rootLayout.Children.Add(CreateLabel("DateFormated", 75));
            rootLayout.Children.Add(CreateLabel("TimeFormatted", 75));
            View = rootLayout;
        }

        private Label CreateLabel(string binding, double width = 0)
        {
            var lbl = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(17),
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };
            if (width != 0)
                lbl.WidthRequest = width;
            else lbl.HorizontalOptions = LayoutOptions.FillAndExpand;
            lbl.SetBinding(Label.TextProperty, new Binding(binding));
            return lbl;
        }

    }
}