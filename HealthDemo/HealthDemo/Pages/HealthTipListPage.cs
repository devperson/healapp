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
    public class HealthTipListPage : MasterPage
    {
        //private TipViewModel VM { get; set; }
        private ListView lvTips;
        public HealthTipListPage() : base() 
        {   
            //VM = ViewModelLocator.TipVM;
            BindingContext = ViewModelLocator.TipVM;
            lblTitle.Text = "Health Tip - " + ViewModelLocator.TipVM.SelectedCategoryTitle;

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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ViewModelLocator.TipVM.LoadTips();
            ViewModelLocator.TipVM.ShowAlert = this.DisplayAlert;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.TipVM.ShowAlert = null;
        }

        protected override void OnBackPressed()
        {
            //VM.SelectedCategory = null;
        }
    }
}
