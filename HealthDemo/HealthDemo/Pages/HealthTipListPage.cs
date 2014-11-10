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
        private TipViewModel VM { get; set; }
        private ListView lvTips;
        public HealthTipListPage() : base() 
        {   
            VM = ViewModelLocator.TipVM;
            BindingContext = VM;
            lblTitle.Text = "Health Tip " + VM.SelectedCategoryTitle;

            lvTips.ItemSelected += (s, e) =>
            {
                if (e.SelectedItem != null)
                {   
                    var selected = e.SelectedItem as HealthTip;
                    VM.SelectedTip = selected;
                    lvTips.SelectedItem = null;
                    Navigation.PushAsync(new TipDetailPage());
                }
            };
            VM.ShowAlert = this.DisplayAlert;
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

            VM.LoadTips();
        }

        protected override void OnBackPressed()
        {
            VM.SelectedCategory = null;
        }
    }
}
