﻿using HealthDemo.Cells;
using HealthDemo.Models;
using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class CalendarListPage : MasterPage
    {
        public static string HeaderTitle;
        private ListView lvCme;

        public CalendarListPage()
            : base()
        {
            HeaderTitle = AppResources.Calendar_Title;
            BindingContext = ViewModelLocator.CmeVM;
            lblTitle.Text = HeaderTitle;

            lvCme.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvCme.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as Cme;
                    ViewModelLocator.CmeVM.SelectedCme = selected;
                    lvCme.SelectedItem = null;
                    Navigation.PushAsync(new CMEDetailsPage());
                }
            };
        }

        protected override void RenderContentView(StackLayout parent)
        {
            lvCme = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 100,
                ItemTemplate = new DataTemplate(typeof(NewsCell))
            };
            lvCme.SetBinding(ListView.ItemsSourceProperty, new Binding("CmesList"));
            parent.Children.Add(lvCme);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.CmeVM.ShowAlert = this.DisplayAlert;
            //lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.CmeVM.LoadCme();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.CmeVM.ShowAlert = null;
        }

    }
}
