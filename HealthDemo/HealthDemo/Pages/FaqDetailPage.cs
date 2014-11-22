using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class FaqDetailPage : MasterPage
    {
        //private FaqViewModel VM { get; set; }
        public FaqDetailPage()
            : base(false)
        {                        
            lblTitle.Text = "FAQ item";
        }

        protected override void RenderContentView(StackLayout parent)
        {
            //VM = ViewModelLocator.FaqVM;

            var rootScrollView = new ScrollView() { Orientation = ScrollOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Padding = new Thickness(0, 0, 0, 0), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };

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
                //VerticalOptions = LayoutOptions.FillAndExpand
            };
            lblDescription.SetBinding(Label.TextProperty, new Binding("Description"));

            //var stackLayoutDetails = new StackLayout() { BackgroundColor = Color.White, Orientation = StackOrientation.Vertical, Padding = new Thickness(15, 15, 7, 15), Spacing = 10 };
            //stackLayoutDetails.Children.Add(lblDescription);
            var frame1 = new StackLayout() //Frame
            { 
                //HasShadow = false, 
                HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 10, 20, 40) 
            };
            var frmae2 = new StackLayout() //Frame
            { 
                //HasShadow = false, 
                //OutlineColor = Color.Black, 
                BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(15, 15, 7, 15) 
            };
            frmae2.Children.Add(lblDescription);
            var border = new StackLayout() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, BackgroundColor = Color.Black, Orientation = StackOrientation.Vertical, Padding = 1 };
            border.Children.Add(frmae2);
            frame1.Children.Add(border);

            stlayout.Children.Add(stkl);
            stlayout.Children.Add(frame1);
            rootScrollView.Content = stlayout;
            if (Device.OS == TargetPlatform.Android)
                rootScrollView.IsClippedToBounds = true;
            //rootScrollView.SetBinding(ScrollView.BindingContextProperty, new Binding("SelectedFAQ"));
            parent.Children.Add(rootScrollView);
        }
    }
}
