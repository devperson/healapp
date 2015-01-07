﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;

namespace HealthDemo.Pages
{
    public class MainPage : MasterPage
    {
        public static string HeaderTitle;
        ImageButton btnDoctors, btnTips, btnInsurance, btnNews, btnFaq, btnEcommerce,btnCME,btnEvent;
        public MainPage() : base() 
        {
            HeaderTitle = AppResources.MainPage_Title;
            btnDoctors.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                Navigation.PushAsync(new SearchDoctorPage());
            };
            btnTips.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                Navigation.PushAsync(new CategoryListPage());
            };
            btnInsurance.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                Navigation.PushAsync(new InsuranceListPage());
            };
            btnNews.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                    Navigation.PushAsync(new NewsListPage());
            };
            btnFaq.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                Navigation.PushAsync(new FaqListPage());              
            };
            btnEcommerce.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                Navigation.PushAsync(new ServicesPage());              
            };

            btnEvent.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                Navigation.PushAsync(new EventListPage());
            };

            btnCME.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                Navigation.PushAsync(new CalendarListPage());
            };

            Constants.NoInternetMessage = AppResources.NO_INTERNET_MSG;
        }

        protected override void RenderContentView(StackLayout parent)
        {
            ScrollView scrollview = new ScrollView() { HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            var stackLayout = new StackLayout() { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            var itemContent = CreateItemStacklayout();
            btnDoctors = CreateButton(ImageSource.FromFile(Device.OnPlatform("Doctor.jpg", "Doctor.jpg", "Images/Doctor.jpg")), AppResources.SearchDoctor_Title);
            btnTips = CreateButton(ImageSource.FromFile(Device.OnPlatform("HealthTips.jpg", "HealthTips.jpg", "Images/HealthTips.jpg")), AppResources.Tips_Title);
            itemContent.Children.Add(btnDoctors);
            itemContent.Children.Add(btnTips);
            stackLayout.Children.Add(itemContent);

            var itemContent2 = CreateItemStacklayout();
            btnInsurance = CreateButton(ImageSource.FromFile(Device.OnPlatform("creditcardicon.jpg", "creditcardicon.jpg", "Images/creditcardicon.jpg")), AppResources.InsuranceList_Title);
            btnNews = CreateButton(ImageSource.FromFile(Device.OnPlatform("news.jpg", "news.jpg", "Images/news.jpg")), AppResources.NewsList_Title);
            itemContent2.Children.Add(btnInsurance);
            itemContent2.Children.Add(btnNews);
            stackLayout.Children.Add(itemContent2);

            var itemContent3 = CreateItemStacklayout();
            btnFaq = CreateButton(ImageSource.FromFile(Device.OnPlatform("faq.jpg", "faq.jpg", "Images/faq.jpg")), AppResources.FaqList_Title);
            btnEcommerce = CreateButton(ImageSource.FromFile(Device.OnPlatform("shopcart.png", "shopcart.png", "Images/shopcart.png")), AppResources.MasterPage_FOOTER_Service);
            itemContent3.Children.Add(btnFaq);
            itemContent3.Children.Add(btnEcommerce);
            stackLayout.Children.Add(itemContent3);

            var itemContent4 = CreateItemStacklayout();
            btnCME = CreateButton(ImageSource.FromFile(Device.OnPlatform("calendar.png", "calendar.png", "Images/calendar.png")), AppResources.CME_Head);
            btnEvent = CreateButton(ImageSource.FromFile(Device.OnPlatform("events.jpg", "events.jpg", "Images/events.jpg")), AppResources.Event_Title);
            itemContent4.Children.Add(btnCME);
            itemContent4.Children.Add(btnEvent);
            stackLayout.Children.Add(itemContent4);

            scrollview.Content = stackLayout;
            if (Device.OS == TargetPlatform.Android)
            {
                var f = Font.SystemFontOfSize(14);
                btnDoctors.Font = f;
                btnTips.Font = f;
                btnInsurance.Font = f;
                btnNews.Font = f;
                btnFaq.Font = f;
                btnEcommerce.Font = f;
                btnEvent.Font = f;
                btnCME.Font = f;
                scrollview.IsClippedToBounds = true;
            }
            parent.Children.Add(scrollview);

            btnBack.Source = null;
            lblTitle.Text = HeaderTitle;
        }

        public static StackLayout CreateItemStacklayout()
        {
            var itemContent = new StackLayout()
            {
                Padding = new Thickness(0, 20, 0, 0),
                Orientation = StackOrientation.Horizontal,
                Spacing = Device.OnPlatform(0, 25, 10),
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            return itemContent;
        }

        public static ImageButton CreateButton(ImageSource imgSource, string text)
        {
            return new ImageButton()
            {
                Source = imgSource,
                Orientation = Xamarin.Forms.Labs.Enums.ImageOrientation.ImageOnTop,
                HeightRequest = Device.OnPlatform(120, 100, 100),
                WidthRequest = Device.OnPlatform(160, 120, 120),
                ImageHeightRequest = Device.OnPlatform(60,90,60),
                ImageWidthRequest = Device.OnPlatform(60, 90, 60),
                TextColor = Color.Black,
                BackgroundColor = Color.White,
                Text = text
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            lvMenu.SelectedItem = GetCurrentPageAsMenu();

            if (PageViewLocator.ReadyToPush)
            {
                PageViewLocator.NavigationPage.PushAsync(PageViewLocator.PushingPage);
            }
        }
    }
}
