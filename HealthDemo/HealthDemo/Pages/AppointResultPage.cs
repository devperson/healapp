using HealthDemo.Cells;
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
    /// This class creates UI page for Appointment result page.
    /// </summary>
    public class AppointResultPage : MasterPage
    {
        public AppointResultPage()
            : base()
        {
            BindingContext = ViewModelLocator.AppointmentVM;
        }
        private ListView lvResult;

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            var rootlayout = new StackLayout() { Spacing = 0, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand};
            var headerLayout = new StackLayout()
            {
                BackgroundColor = Color.FromHex("FF3C3C3C"),
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(0, 10, 0, 10)
            };

            headerLayout.Children.Add(CreateLabel("№", 30));
            headerLayout.Children.Add(CreateLabel(AppResources.Appointment_FORM_Clinical, 140));
            headerLayout.Children.Add(CreateLabel(AppResources.AppointmentResult_Date, 75));
            headerLayout.Children.Add(CreateLabel(AppResources.AppointmentResult_Time, 75));

            lvResult = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                ItemTemplate = new DataTemplate(typeof(AppointResultCell))
            };

            lvResult.SetBinding(ListView.ItemsSourceProperty, new Binding("SearchedAppointList"));

            rootlayout.Children.Add(headerLayout);
            rootlayout.Children.Add(lvResult);
            parent.Children.Add(rootlayout);
        }


        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.AppointmentVM.ShowAlert = this.DisplayAlert;
            ViewModelLocator.AppointmentVM.SearchAppointment();
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.AppointmentVM.ShowAlert = null;
        }

        /// <summary>
        /// helper method for creating lables with specified width and text.
        /// </summary>        
        private Label CreateLabel(string title, double width = 0)
        {
            var lbl = new Label()
            {
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(16),
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                Text = title
            };
            if (width != 0)
                lbl.WidthRequest = width;
            else lbl.HorizontalOptions = LayoutOptions.FillAndExpand;
            return lbl;
        }
    }
}
