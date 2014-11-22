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
        //private DoctorViewModel VM { get; set; }
        public ProfilePage()
            : base(false)
        {            
            //this.BindingContext = VM.SelectedDoctor;
            lblTitle.Text = "Doctor profile";
        }
        protected override void RenderContentView(StackLayout parent)
        {
            //VM = ViewModelLocator.DoctorVM;            

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
                Padding = new Thickness(15, 5, 5, 10),
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
            stackLayoutDetails.Children.Add(this.CreateQualificationsItem());
            stackLayoutDetails.Children.Add(CreateDetailsItem("Language:", "Language"));
            var frame1 = new ContentView() 
            { 
                //HasShadow = false, 
                HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 10, 20, 20) 
            };
            var frmae2 = new ContentView() 
            { 
                //HasShadow = false, OutlineColor = Color.Black, 
                BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = 1 
            };
            frmae2.Content = stackLayoutDetails;
            var border = new StackLayout() { BackgroundColor = Color.Black, Orientation = StackOrientation.Vertical, Padding = 1 };
            border.Children.Add(frmae2);
            frame1.Content = border;

            stlayout.Children.Add(headerLayout);
            stlayout.Children.Add(frame1);
            rootScrollView.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)//fixig scrollview bug in android(overlapping)
                rootScrollView.IsClippedToBounds = true;
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

        private StackLayout CreateQualificationsItem()
        {
            StackLayout stackQualifications = new StackLayout() { Spacing = 0, Orientation = StackOrientation.Vertical };
            var lblDTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15, FontAttributes.Bold),
                Text = "Qualifications:"
            };

            foreach (var item in ViewModelLocator.DoctorVM.SelectedDoctor.QualifiList)
            {
                var lblDetails = new Label()
                {
                    TextColor = Color.Black,
                    Font = Font.SystemFontOfSize(13),
                    Text = item
                };
                stackQualifications.Children.Add(lblDetails);
            }            

            //if (hasBinding)
            //    lblDetails.SetBinding(Label.TextProperty, new Binding(binding));
            //else lblDetails.Text = binding;

            var stackLayout = new StackLayout() { Spacing = 0, HorizontalOptions = LayoutOptions.FillAndExpand };
            stackLayout.Children.Add(lblDTitle);
            stackLayout.Children.Add(stackQualifications);

            return stackLayout;
        }

        protected override void OnBackPressed()
        {
            //VM.SelectedDoctor = null;
        }
    }
}
