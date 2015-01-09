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
    /// <summary>
    /// This class creates UI page for Doctor list page.
    /// </summary>
    public class DoctorListPage : MasterPage
    {
        private ListView lvResult;                

        public DoctorListPage()
            : base()
        {
            //Bind page with data and handle button click events

            lblTitle.Text = AppResources.Doctors_Title;
            
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

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            lvResult = new ListView() 
            { 
                VerticalOptions = LayoutOptions.FillAndExpand, 
                HorizontalOptions = LayoutOptions.FillAndExpand, RowHeight = 110, 
                ItemTemplate = new DataTemplate(typeof(DoctorCell)) 
            };

            lvResult.SetBinding(ListView.ItemsSourceProperty, new Binding("DoctorList"));            
            parent.Children.Add(lvResult);
        }        
    }
}
