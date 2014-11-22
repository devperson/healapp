using HealthDemo.Cells;
using HealthDemo.Models;
using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;

namespace HealthDemo.Pages
{
    public class DoctorListPage : MasterPage
    {
        private ListView lvResult;
        //private DoctorViewModel VM { get; set; }
        

        public DoctorListPage()
            : base()
        {
            lblTitle.Text = "Search Result";
            //VM = ViewModelLocator.DoctorVM;            
            BindingContext = ViewModelLocator.DoctorVM;

            lvResult.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                {
                    lvResult.SelectedItem = null;
                    return;
                }

                if (e.SelectedItem != null)
                {
                    var selected = e.SelectedItem as Doctor;
                    ViewModelLocator.DoctorVM.SelectedDoctor = selected;
                    lvResult.SelectedItem = null;

                    if (PageViewLocator.ProfilePage == null)
                        PageViewLocator.ProfilePage = new ProfilePage();
                    PageViewLocator.ProfilePage.BindingContext = selected;
                    Navigation.PushAsync(PageViewLocator.ProfilePage);
                }                
            };
        }

        protected override void RenderContentView(StackLayout parent)
        {
            lvResult = new ListView() 
            { 
                VerticalOptions = LayoutOptions.FillAndExpand, 
                HorizontalOptions = LayoutOptions.FillAndExpand, RowHeight = 110, 
                ItemTemplate = new DataTemplate(typeof(DoctorCell)) 
            };

            lvResult.SetBinding(ListView.ItemsSourceProperty, new Binding("DoctorList"));
            //lvResult.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedDoctor", BindingMode.TwoWay));
            parent.Children.Add(lvResult);
        }

        protected override void OnMasterViewRendered()
        {
            //there seems some bug in xamarin because title and toolbar image croped to ten px
            //titleLayout.HeightRequest += 10;
            //titleImage.HeightRequest += 10;
            //toolbarLayout.HeightRequest += 10;
            //toolbarBackground.HeightRequest += 10;
        }
    }
}
