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
    /// This class creates UI page for Insurance list page.
    /// </summary>
    public class InsuranceListPage : MasterPage
    {                
        private ListView lvInsurances;
        public InsuranceListPage()
            : base()
        {
            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.InsuranceVM;

            lblTitle.Text = AppResources.InsuranceList_Title;

            lvInsurances.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvInsurances.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as Insurance;
                    ViewModelLocator.InsuranceVM.SelectedInsurance = selected;
                    lvInsurances.SelectedItem = null;

                    if (PageViewLocator.InsuranceDetailPage == null)
                        PageViewLocator.InsuranceDetailPage = new InsuranceDetailPage();
                    PageViewLocator.InsuranceDetailPage.BindingContext = selected;
                    Navigation.PushAsync(PageViewLocator.InsuranceDetailPage);     

                    //Navigation.PushAsync(new InsuranceDetailPage());
                }
            };
            
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            lvInsurances = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 65,
                ItemTemplate = new DataTemplate(typeof(SimpleCell))
            };
            lvInsurances.SetBinding(ListView.ItemsSourceProperty, new Binding("InsuranceList"));
            parent.Children.Add(lvInsurances);
        }

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.InsuranceVM.LoadInsurances();
            ViewModelLocator.InsuranceVM.ShowAlert = this.DisplayAlert;
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.InsuranceVM.ShowAlert = null;
        }
    }
}
