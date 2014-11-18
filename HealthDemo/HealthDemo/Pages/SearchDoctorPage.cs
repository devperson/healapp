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
        private DoctorViewModel VM { get; set; }
        public SearchDoctorPage() : base() 
        {
            VM = ViewModelLocator.DoctorVM;
            BindingContext = VM;
            

            btnCombo.SelectedIndexChanged += (sender, args) =>
            {
                if (btnCombo.SelectedIndex != -1)
                {
                    var title = btnCombo.Items[btnCombo.SelectedIndex];
                    VM.SelectedSpeicalties = VM.SpeicaltyList.FirstOrDefault(s => s.Title == title);
                }
            };

            btnSearch.Clicked += (s, e) =>
                {
                    VM.DoSearch(() =>
                    {
                        if (PageViewLocator.DoctorListPage == null)
                            PageViewLocator.DoctorListPage = new DoctorListPage();
                        this.Navigation.PushAsync(PageViewLocator.DoctorListPage);
                         
                    });
                };
            VM.ShowAlert = this.DisplayAlert;
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
            specLayout.Children.Add(CreateComboBox());

            btnSearch = new Button()
            {
                BackgroundColor = Color.FromHex("FF54A6D3"),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.Black,
                Text = "Search"
            }; 
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

        private  AbsoluteLayout CreateComboBox()
        {
            var comboLayout = new AbsoluteLayout() { HeightRequest = 35, HorizontalOptions = LayoutOptions.FillAndExpand };
            var comboBackground = new Image()
            {
                Aspect = Aspect.Fill,
                Source = Device.OnPlatform("comboback.png", "comboback.png", "Images/comboback.png"),
                HeightRequest = 35,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            btnCombo = new CustomPicker() { HeightRequest = 35, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Transparent, Title = string.Empty };

            comboLayout.Children.Add(comboBackground, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            comboLayout.Children.Add(btnCombo, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            return comboLayout;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();
            VM.LoadSpeicalties(() =>
                {
                    if (btnCombo.Items == null || (btnCombo.Items != null && btnCombo.Items.Count == 0))
                    {
                        foreach (var item in VM.SpeicaltyList)
                        {
                            btnCombo.Items.Add(item.Title);
                        }
                    }
                    btnCombo.SelectedIndex = VM.SelectedSpeicalties != null ? VM.SpeicaltyList.IndexOf(VM.SelectedSpeicalties) : 0;
                });
        }
    }

    public class CustomTextBox : Entry { }
    public class CustomPicker : Picker { }
}
