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
    public class CalendarListPage : MasterPage
    {
        public static string HeaderTitle = "Calendar";
        private ListView lvCme;

        public CalendarListPage(bool isCME = false)
            : base()
        {
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
                    Navigation.PushAsync(new EventListPage(isCME));
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
