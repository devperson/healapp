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
    /// This class creates UI page for Faq list page.
    /// </summary>
    public class FaqListPage : MasterPage
    {                
        private ListView lvFaq;

        public FaqListPage()
            : base()
        {
            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.FaqVM;
            
            lblTitle.Text = AppResources.FaqList_Title;

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

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
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

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = this.MenuItems.FirstOrDefault(s => s.Title == lblTitle.Text);
            ViewModelLocator.FaqVM.LoadFaq();
            ViewModelLocator.FaqVM.ShowAlert = this.DisplayAlert;
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.FaqVM.ShowAlert = null;
        }
    }
}
