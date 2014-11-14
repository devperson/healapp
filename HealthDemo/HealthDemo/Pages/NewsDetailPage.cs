using HealthDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HealthDemo.Pages
{
    public class NewsDetailPage:MasterPage
    {
        private NewsViewModel VM { get; set; }
        public NewsDetailPage()
            : base()
        {
            VM = ViewModelLocator.NewsVM;
            BindingContext = VM;
            lblTitle.Text = "News details";
        }


        protected override void RenderContentView(StackLayout parent)
        {
            var rootScrollView = new ScrollView() { Orientation = ScrollOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var stlayout = new StackLayout() { Padding = new Thickness(0, 10, 0, 0), Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand };

            var lblTitle = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(15, FontAttributes.Bold),
            };
            lblTitle.SetBinding(Label.TextProperty, new Binding("Title"));
            var lblDate = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(14)
            };
            lblDate.SetBinding(Label.TextProperty, new Binding("DateFormated"));
            var labelForDate = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(14),
                Text = "Date:"
            };
            var stackDate = new StackLayout() { Orientation = StackOrientation.Horizontal };
            stackDate.Children.Add(labelForDate);
            stackDate.Children.Add(lblDate);

            var header = new StackLayout() {Spacing =0, Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 0, 0, 0) };
            header.Children.Add(lblTitle);
            header.Children.Add(stackDate);

            var lblDescription = new Label()
            {
                TextColor = Color.Black,
                Font = Font.SystemFontOfSize(14),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                MinimumHeightRequest = 150
            };
            lblDescription.SetBinding(Label.TextProperty, new Binding("Description"));

            //var stackLayoutDetails = new StackLayout() { BackgroundColor = Color.White, Orientation = StackOrientation.Vertical, Padding = new Thickness(15, 15, 7, 15), Spacing = 10 };
            //stackLayoutDetails.Children.Add(lblDescription);
            var content = new Frame() { HasShadow = false, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(20, 10, 20, 20) };
            var frmae2 = new Frame() { HasShadow = false, OutlineColor = Color.Black, BackgroundColor = Color.White, HorizontalOptions = LayoutOptions.FillAndExpand, Padding = new Thickness(15, 15, 7, 15) };
            frmae2.Content = lblDescription;
            content.Content = frmae2;

            stlayout.Children.Add(header);
            stlayout.Children.Add(content);
            rootScrollView.Content = stlayout;
            rootScrollView.SetBinding(ScrollView.BindingContextProperty, new Binding("SelectedNews"));
            parent.Children.Add(rootScrollView);
        }
    }
}
