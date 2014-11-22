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
    public class InsuranceListPage : MasterPage
    {
        //private InsuranceViewModel VM { get; set; }
        public static string HeaderTitle = "Insurances";
        private ListView lvInsurances;
        public InsuranceListPage()
            : base()
        {
            //VM = ViewModelLocator.InsuranceVM;
            BindingContext = ViewModelLocator.InsuranceVM;
            lblTitle.Text = HeaderTitle;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.InsuranceVM.LoadInsurances();
            ViewModelLocator.InsuranceVM.ShowAlert = this.DisplayAlert;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.InsuranceVM.ShowAlert = null;
        }
    }
}
