using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;

namespace HealthDemo.Pages
{
    /// <summary>
    /// This class creates UI page for Doctor search page.
    /// </summary>
    public class SearchDoctorPage : MasterPage
    {
        private Button btnSearch;
        private Picker btnCombo;
        
        public SearchDoctorPage() : base() 
        {
            //Bind page with data and handle button click events

            BindingContext = ViewModelLocator.DoctorVM;            
            btnCombo.SelectedIndexChanged += (sender, args) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (btnCombo.SelectedIndex != -1)
                {
                    var title = btnCombo.Items[btnCombo.SelectedIndex];
                    ViewModelLocator.DoctorVM.SelectedSpeicalties = ViewModelLocator.DoctorVM.SpeicaltyList.FirstOrDefault(s => s.Title == title);
                }
            };

            btnSearch.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                ViewModelLocator.DoctorVM.DoSearch(() =>
                {
                    if (PageViewLocator.DoctorListPage == null)
                        PageViewLocator.DoctorListPage = new DoctorListPage();
                    this.Navigation.PushAsync(PageViewLocator.DoctorListPage);
                         
                });
            };           
        }

        /// <summary>
        /// This method is used for providing page content.
        /// </summary>
        /// <param name="parent">Panel which represents content area on page.</param>
        protected override void RenderContentView(StackLayout parent)
        {
            var content = new StackLayout()
            {
                Padding = 40,
                Orientation = StackOrientation.Vertical,
                Spacing = 15,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var doctorLayout = new StackLayout() { Spacing = 5, Orientation = StackOrientation.Vertical };
            doctorLayout.Children.Add(new Label() 
            {
                HorizontalOptions = LayoutOptions.StartAndExpand, 
                TextColor = Color.Black, 
                Text = AppResources.SearchDoctor_Find                
            });
            var txt = new CustomTextBox() { HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.Black };
            txt.SetBinding(CustomTextBox.TextProperty, "SearchText", BindingMode.TwoWay);
            doctorLayout.Children.Add(txt);

            var specLayout = new StackLayout() { Spacing = 5, Orientation = StackOrientation.Vertical };
            specLayout.Children.Add(new Label() 
            {
                HorizontalOptions = LayoutOptions.StartAndExpand, 
                TextColor = Color.Black, 
                Text = AppResources.SearchDoctor_Spec,                
            });
            specLayout.Children.Add(this.CreateComboBox(ref btnCombo));

            btnSearch = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
                Text = AppResources.SearchDoctor_Search
            };
            if (Device.OS == TargetPlatform.Android)
                btnSearch.Font = Font.SystemFontOfSize(16);
            var searchStack = new StackLayout() 
            { 
                Orientation = StackOrientation.Horizontal, HeightRequest = 40, 
                Children = { btnSearch }, Padding = new Thickness(10, 15, 10, 0) 
            };

            content.Children.Add(doctorLayout);
            content.Children.Add(specLayout);
            content.Children.Add(searchStack);

            parent.Children.Add(content);

            lblTitle.Text = AppResources.SearchDoctor_Title;
        }

        /// <summary>
        /// This is a system method and is executed right before page appears.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            ViewModelLocator.DoctorVM.LoadSpeicalties(() =>
            {
                if (btnCombo.Items == null || (btnCombo.Items != null && btnCombo.Items.Count == 0))
                {
                    foreach (var item in ViewModelLocator.DoctorVM.SpeicaltyList)
                    {
                        btnCombo.Items.Add(item.Title);
                    }
                }
                btnCombo.SelectedIndex = ViewModelLocator.DoctorVM.SelectedSpeicalties != null ? ViewModelLocator.DoctorVM.SpeicaltyList.IndexOf(ViewModelLocator.DoctorVM.SelectedSpeicalties) : 0;
            });
            ViewModelLocator.DoctorVM.ShowAlert = this.DisplayAlert;
        }

        /// <summary>
        /// This is a system method and is executed right before page disappears.
        /// </summary>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.DoctorVM.ShowAlert = null;
        }
    }

    
    public class CustomTextBox : Entry { }    
    public class CustomPicker : Picker { }

   
}
