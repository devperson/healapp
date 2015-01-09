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
    /// This class creates UI page for Event list page.
    /// </summary>
    public class EventListPage : MasterPage
    {        
        private ListView lvEvent;

        public EventListPage()
            : base()
        {
            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.EventVM;
            
            lblTitle.Text = AppResources.Event_Title;

            lvEvent.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvEvent.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as Event;
                    ViewModelLocator.EventVM.SelectedEvent = selected;
                    lvEvent.SelectedItem = null;
                    Navigation.PushAsync(new EventDetailPage());                    
                }
            };

            ViewModelLocator.EventVM.ShowAlert = this.DisplayAlert;
            ViewModelLocator.EventVM.LoadEvents();
            
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            lvEvent = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 100,
                ItemTemplate = new DataTemplate(typeof(SimpleCell))
            };
            lvEvent.SetBinding(ListView.ItemsSourceProperty, new Binding("EventsList"));
            parent.Children.Add(lvEvent);
        }

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.EventVM.ShowAlert = this.DisplayAlert;          
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.EventVM.ShowAlert = null;
        }
    }
}
