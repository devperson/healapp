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
    /// This class creates UI page for Tip list page.
    /// </summary>
    public class HealthTipListPage : MasterPage
    {        
        private ListView lvTips;
        public HealthTipListPage() : base() 
        {
            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.TipVM;
            lblTitle.Text = AppResources.Tips_Title + " - " + ViewModelLocator.TipVM.SelectedCategoryTitle;

            lvTips.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvTips.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {   
                    var selected = e.SelectedItem as HealthTip;
                    ViewModelLocator.TipVM.SelectedTip = selected;
                    lvTips.SelectedItem = null;

                    if (PageViewLocator.TipDetailPage == null)
                        PageViewLocator.TipDetailPage = new TipDetailPage();
                    PageViewLocator.TipDetailPage.BindingContext = selected;
                    this.Navigation.PushAsync(PageViewLocator.TipDetailPage);       

                    //Navigation.PushAsync(new TipDetailPage());
                }
            };
            
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            lvTips = new ListView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowHeight = 65,
                ItemTemplate = new DataTemplate(typeof(SimpleCell))
            };
            lvTips.SetBinding(ListView.ItemsSourceProperty, new Binding("TipsList"));
            parent.Children.Add(lvTips);
        }

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.TipVM.LoadTips();
            ViewModelLocator.TipVM.ShowAlert = this.DisplayAlert;
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.TipVM.ShowAlert = null;
        }
       
    }
}
