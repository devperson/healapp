﻿using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    /// <summary>
    /// This class creates UI page for Cme details page.
    /// </summary>
    public class CMEDetailsPage : MasterPage
    {
        private Grid contentGrid;
        private Button btnRegister;
        public CMEDetailsPage()
            : base(false)
        {
            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.CmeVM.SelectedCme;
            lblTitle.Text = AppResources.CME_Head;
            btnRegister.Clicked += (s, e) =>
            {
                Navigation.PushAsync(new RegisterCmePage());
            };
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Spacing = 0, Padding = new Thickness(0, 0, 0, 15), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };
            contentGrid = new Grid
            {
                Padding = new Thickness(5, 10, 15, 25),
                ColumnSpacing = 7,
                RowSpacing = 15,
                VerticalOptions = LayoutOptions.Start,
                RowDefinitions = 
                {
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto },
                    new RowDefinition { Height = GridLength.Auto }                    
                },
                ColumnDefinitions = 
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)}
                }
            };
            if (!this.IsEn())
            {
                contentGrid.ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition { Width =  new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition { Width = GridLength.Auto }
                };
            }

            contentGrid.AddLabel(AppResources.CME_Title, 0);
            contentGrid.AddLabelWithBinding("Title", 0, 1);
            contentGrid.AddLabel(AppResources.CME_Speaker, 1);
            contentGrid.AddLabelWithBinding("Speaker", 1, 1);
            contentGrid.AddLabel(AppResources.CME_Venue, 2);
            contentGrid.AddLabelWithBinding("Venue", 2, 1);
            contentGrid.AddLabel(AppResources.CME_Description, 3);
            contentGrid.AddLabelWithBinding("Description", 3, 1);
            contentGrid.AddLabel(AppResources.CME_CreditHour, 4);
            contentGrid.AddLabelWithBinding("CreditHour", 4, 1);
            contentGrid.AddLabel(AppResources.CME_DT, 5);
            contentGrid.AddLabelWithBinding("DateFormated", 5, 1);

            btnRegister = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 200,
                HeightRequest = 40,
                TextColor = Color.Black,
                Text = AppResources.CME_Register
            };

            stlayout.Children.Add(contentGrid);
            stlayout.Children.Add(btnRegister);

            scrollview.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
            {
                btnRegister.Font = Font.SystemFontOfSize(16);
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);
        }
    }
}
