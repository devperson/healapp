using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class ProfilePage : MasterPage
    {
        private DoctorViewModel VM { get; set; }
        public ProfilePage()
            : base()
        {
            VM = ViewModelLocator.DoctorVM;
            this.BindingContext = VM.SelectedDoctor;
        }
        protected override void RenderContentView(StackLayout parent)
        {
            var rootScrollView = new ScrollView() { Orientation = ScrollOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Padding = new Thickness(0, 10, 0, 0), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };

            var headerLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Padding = new Thickness(0, 0, 17, 0)
            };

            var stackLayout1 = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(15, 20, 0, 0),
                Spacing = 0
            };

            var lblDTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15)
            };
            lblDTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            var lblPosition = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(13)
            };
            lblPosition.SetBinding(Label.TextProperty, new Binding("Position"));
            var lblDepartament = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(13)
            };
            lblDepartament.SetBinding(Label.TextProperty, new Binding("Department"));

            var imgDoctor = new Image
            {
                WidthRequest = 75,
                HeightRequest = 75,
                VerticalOptions = LayoutOptions.Center
            };
            imgDoctor.SetBinding(Image.SourceProperty, new Binding("ImageUrl"));
            stackLayout1.Children.Add(lblDTitle);
            stackLayout1.Children.Add(lblPosition);
            stackLayout1.Children.Add(lblDepartament);
            headerLayout.Children.Add(stackLayout1);
            headerLayout.Children.Add(imgDoctor);

            var stackLayoutDetails = new StackLayout() { BackgroundColor = Color.White, Orientation = StackOrientation.Vertical, Padding = new Thickness(15, 15, 7, 15), Spacing = 10 };
            stackLayoutDetails.Children.Add(CreateDetailsItem("Bio:", "Bio"));
            stackLayoutDetails.Children.Add(CreateDetailsItem("Qualifications:", "Qualification"));
            stackLayoutDetails.Children.Add(CreateDetailsItem("Language:", "Language"));
            var frame1 = new Frame() { HasShadow = false, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 10, 20, 20) };
            var frmae2 = new Frame() { HasShadow = false, OutlineColor = Color.Black, BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = 1 };
            frmae2.Content = stackLayoutDetails;
            frame1.Content = frmae2;

            stlayout.Children.Add(headerLayout);
            stlayout.Children.Add(frame1);
            rootScrollView.Content = stlayout;

            parent.Children.Add(rootScrollView);
        }


        private StackLayout CreateDetailsItem(string title, string binding, bool hasBinding = true)
        {
            var lblDTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15,FontAttributes.Bold),
                Text = title
            };

            var lblDetails = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(13)
            };
            if (hasBinding)
                lblDetails.SetBinding(Label.TextProperty, new Binding(binding));
            else lblDetails.Text = binding;

            var stackLayout = new StackLayout() {Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
            stackLayout.Children.Add(lblDTitle);
            stackLayout.Children.Add(lblDetails);

            return stackLayout;
        }


        protected override void OnBackPressed()
        {
            VM.SelectedDoctor = null;
        }
    }
}
