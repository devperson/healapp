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
    public class FaqListPage : MasterPage
    {
        //private FaqViewModel VM { get; set; }
        public static string HeaderTitle = "FAQ";
        private ListView lvFaq;
        public FaqListPage()
            : base()
        {
            //VM = ViewModelLocator.FaqVM;
            BindingContext = ViewModelLocator.FaqVM;
            lblTitle.Text = HeaderTitle;

            lvFaq.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvFaq.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as Faq;
                    ViewModelLocator.FaqVM.SelectedFAQ = selected;
                    lvFaq.SelectedItem = null;

                    if (PageViewLocator.FaqDetailPage == null)
                        PageViewLocator.FaqDetailPage = new FaqDetailPage();
                    PageViewLocator.FaqDetailPage.BindingContext = selected;
                    Navigation.PushAsync(PageViewLocator.FaqDetailPage);
                }
            };            
        }

        protected override void RenderContentView(StackLayout parent)
        {
            lvFaq = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 65,
                ItemTemplate = new DataTemplate(typeof(SimpleCell))
            };
            lvFaq.SetBinding(ListView.ItemsSourceProperty, new Binding("FAQList"));
            parent.Children.Add(lvFaq);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.FaqVM.LoadFaq();
            ViewModelLocator.FaqVM.ShowAlert = this.DisplayAlert;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.FaqVM.ShowAlert = null;
        }
    }
}
