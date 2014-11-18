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
        private InsuranceViewModel VM { get; set; }
        public static string HeaderTitle = "Insurances";
        private ListView lvInsurances;
        public InsuranceListPage()
            : base()
        {
            VM = ViewModelLocator.InsuranceVM;
            BindingContext = VM;
            lblTitle.Text = HeaderTitle;

            lvInsurances.ItemSelected += (s, e) =>
            {
                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as Insurance;
                    VM.SelectedInsurance = selected;
                    lvInsurances.SelectedItem = null;

                    if (PageViewLocator.InsuranceDetailPage == null)
                        PageViewLocator.InsuranceDetailPage = new InsuranceDetailPage();
                    PageViewLocator.InsuranceDetailPage.BindingContext = selected;
                    Navigation.PushAsync(PageViewLocator.InsuranceDetailPage);     

                    //Navigation.PushAsync(new InsuranceDetailPage());
                }
            };
            VM.ShowAlert = this.DisplayAlert;
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
            VM.LoadInsurances();
        }

        //protected override void OnBackPressed()
        //{
        //    VM.SelectedCategory = null;
        //}
    }
}
