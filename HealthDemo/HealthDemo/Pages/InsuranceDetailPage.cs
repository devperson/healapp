using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class InsuranceDetailPage : MasterPage
    {
        //private InsuranceViewModel VM { get; set; }
        public InsuranceDetailPage()
            : base(false)
        {            
            //BindingContext = VM;
            lblTitle.Text = "Insurance details";
        }

        protected override void RenderContentView(StackLayout parent)
        {
            //VM = ViewModelLocator.InsuranceVM;

            var rootScrollView = new ScrollView() { Orientation = ScrollOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Padding = new Thickness(0, 10, 0, 0), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };

            var lblTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(16)
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            var stkl = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 0, 0, 0), Children = { lblTitle } };

            var lblDescription = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(14),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HeightRequest = 150
            };
            lblDescription.SetBinding(Label.TextProperty, new Binding("Description"));

            //var stackLayoutDetails = new StackLayout() { BackgroundColor = Color.White, Orientation = StackOrientation.Vertical, Padding = new Thickness(15, 15, 7, 15), Spacing = 10 };
            //stackLayoutDetails.Children.Add(lblDescription);
            var frame1 = new ContentView() //Frame
            { 
                //HasShadow = false, 
                HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 10, 20, 20) };
            var frmae2 = new ContentView() 
            { 
                //HasShadow = false, 
                //OutlineColor = Color.Black, 
                BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(15, 15, 7, 15) };
            frmae2.Content = lblDescription;
            var border = new StackLayout() { BackgroundColor = Color.Black, Orientation = StackOrientation.Vertical, Padding = 1 };
            border.Children.Add(frmae2);
            frame1.Content = border;

            stlayout.Children.Add(stkl);
            stlayout.Children.Add(frame1);
            rootScrollView.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
                rootScrollView.IsClippedToBounds = true;
            //rootScrollView.SetBinding(ScrollView.BindingContextProperty, new Binding("SelectedInsurance"));
            parent.Children.Add(rootScrollView);
        }
 
    }
}
