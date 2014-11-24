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
    public class SearchDoctorPage : MasterPage
    {
        private Button btnSearch;
        private Picker btnCombo;
        public static string HeaderTitle = "Find a Doctor";
        //private DoctorViewModel VM { get; set; }
        public SearchDoctorPage() : base() 
        {
            //VM = ViewModelLocator.DoctorVM;
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
            doctorLayout.Children.Add(new Label() { HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black, Text = "Find Doctor"});
            var txt = new CustomTextBox() { HorizontalOptions = LayoutOptions.FillAndExpand, TextColor = Color.Black };
            txt.SetBinding(CustomTextBox.TextProperty, "SearchText", BindingMode.TwoWay);
            doctorLayout.Children.Add(txt);

            var specLayout = new StackLayout() { Spacing = 5, Orientation = StackOrientation.Vertical };
            specLayout.Children.Add(new Label() { HorizontalOptions = LayoutOptions.StartAndExpand, TextColor = Color.Black, Text = "Speicalties" });
            specLayout.Children.Add(this.CreateComboBox(ref btnCombo));

            btnSearch = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
                Text = "Search"
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

            lblTitle.Text = HeaderTitle;
        }

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

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            ViewModelLocator.DoctorVM.ShowAlert = null;
        }
    }

    public class CustomTextBox : Entry { }
    public class CustomPicker : Picker { }

   
}
