using HealthDemo.Cells;
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
    /// <summary>
    /// This class creates UI page for Calendar list page.
    /// </summary>
    public class CalendarListPage : MasterPage
    {        
        private ListView lvCme;

        public CalendarListPage()
            : base()
        {

            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.CmeVM;
            lblTitle.Text = AppResources.Calendar_Title;

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

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
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

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.CmeVM.ShowAlert = this.DisplayAlert;            
            ViewModelLocator.CmeVM.LoadCme();
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.CmeVM.ShowAlert = null;
        }

    }
}
