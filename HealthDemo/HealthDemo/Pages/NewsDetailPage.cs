﻿using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HealthDemo;

namespace HealthDemo.Pages
{
    /// <summary>
    /// This class creates UI page for News details page.
    /// </summary>
    public class NewsDetailPage:MasterPage
    {        
        public NewsDetailPage()
            : base(false)
        {           
            lblTitle.Text = AppResources.News_Title;
        }


        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            var rootScrollView = new ScrollView() { Orientation = ScrollOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Padding = new Thickness(0, 10, 0, 0), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };

            var lblTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15, FontAttributes.Bold),
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            var lblDate = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(14)
            };
            lblDate.SetBinding(Label.TextProperty, new Binding("DateFormated"));
            var labelForDate = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(14),
                Text = AppResources.News_Date
            };
            var stackDate = new StackLayout() { Orientation = StackOrientation.Horizontal };
            if (!this.IsEn())
                stackDate.HorizontalOptions = LayoutOptions.EndAndExpand;
            stackDate.Children.Add(labelForDate);
            stackDate.Children.Insert(this.IsEn() ? 1 : 0, lblDate);

            var header = new StackLayout() {Spacing =0, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 0, 20, 0) };
            header.Children.Add(lblTitle);
            header.Children.Add(stackDate);

            var lblDescription = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(14),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                MinimumHeightRequest = 150
            };
            lblDescription.SetBinding(Label.TextProperty, new Binding("Description"));

            
            var content = new ContentView() 
            {   
                HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 10, 20, 20) 
            };
            
            var frmae2 = new ContentView() 
            {   
                BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(15, 15, 7, 15) 
            };
            frmae2.Content = lblDescription;
            var border = new StackLayout() { BackgroundColor = Color.Black, Orientation = StackOrientation.Vertical, Padding = 1 };
            border.Children.Add(frmae2);
            content.Content = border;

            stlayout.Children.Add(header);
            stlayout.Children.Add(content);
            rootScrollView.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
                rootScrollView.IsClippedToBounds = true;            
            parent.Children.Add(rootScrollView);
        }
    }
}
