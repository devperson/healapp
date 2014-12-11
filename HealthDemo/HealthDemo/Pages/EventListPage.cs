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
    public class EventListPage : MasterPage
    {
        public static string HeaderTitle = "Events";
        private ListView lvEvent;
        public bool IsCME { get; set; }
        public EventListPage(bool isCME = false)
            : base()
        {
            IsCME = isCME;
            //VM = ViewModelLocator.NewsVM;
            BindingContext = ViewModelLocator.EventVM;
            lblTitle.Text = HeaderTitle;

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
                    if (IsCME)
                    {
                        Navigation.PushAsync(new CMEDetailsPage());
                    }
                    else
                    {
                        Navigation.PushAsync(new EventDetailPage());
                    }
                    //if (PageViewLocator.NewsDetailPage == null)
                    //    PageViewLocator.NewsDetailPage = new NewsDetailPage();
                    //PageViewLocator.NewsDetailPage.BindingContext = selected;
                    //Navigation.PushAsync(PageViewLocator.NewsDetailPage);
                }
            };

            ViewModelLocator.EventVM.ShowAlert = this.DisplayAlert;
            if (IsCME)
                ViewModelLocator.EventVM.LoadEvents(ViewModelLocator.CmeVM.SelectedCme.Id);
            else ViewModelLocator.EventVM.LoadEvents();
            
        }

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.EventVM.ShowAlert = this.DisplayAlert;
            //lvMenu.SelectedItem = GetCurrentPageAsMenu();
            //if (IsCME)
            //    ViewModelLocator.EventVM.LoadEvents(ViewModelLocator.CmeVM.SelectedCme.Id);
            //else ViewModelLocator.EventVM.LoadEvents();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.EventVM.ShowAlert = null;
        }
    }
}
