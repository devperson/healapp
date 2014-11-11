using HealthDemo.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
using Xamarin.Forms.Labs.Enums;

namespace HealthDemo.Pages
{
    public class MasterPage : ContentPage
    {
        protected ImageButton btnBack, btnMenu;
        protected TransparentButton btnInfo, btnContact, btnLocation;
        protected Label lblTitle;
        protected StackLayout contentStack, menuLayout;
        protected AbsoluteLayout titleLayout, toolbarLayout;
        protected Image titleImage, toolbarBackground;
        public Frame LoadingIndicator;
        public MasterPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            RenderTemplateView();
            LoadingIndicator.SetBinding(Frame.IsVisibleProperty, new Binding("IsLoading"));

            btnBack.Clicked += (s, e) =>
            {
                OnBackPressed();
                if (lblTitle.Text != MainPage.HeaderTitle)
                    Navigation.PopAsync();
            };

            btnInfo.Clicked += (s, e) =>
            {
                if (lblTitle.Text != AboutPage.HeaderTitle)
                    Navigation.PushAsync(new AboutPage());
            };

            btnContact.Clicked += (s, e) =>
            {
                if (lblTitle.Text != ContactPage.HeaderTitle)
                    Navigation.PushAsync(new ContactPage());
            };

            btnLocation.Clicked += (s, e) =>
            {
                if (lblTitle.Text != LocationPage.HeaderTitle)
                    Navigation.PushAsync(new LocationPage());
            };

            btnMenu.Clicked += (s, e) =>
            {
                if (Device.OS == TargetPlatform.Android)
                {
                    Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
                    {

                        if (menuLayout.TranslationX == 0)
                        {
                            //menuLayout.Opacity = 1;
                            return false;
                        }
                        else
                        {
                            menuLayout.TranslationX -= 20;
                            return true;
                        }
                    });
                }
                else
                {
                    menuLayout.TranslateTo(0, 0);
                }
            };
        }

        private void RenderTemplateView()
        {   
            var rootAbsoluteLAyout = new AbsoluteLayout(){VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var rootStack = new StackLayout() { Spacing = 0, BackgroundColor = Color.White, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            //header
            var headerStack = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.FillAndExpand, Spacing = 0, Padding = new Thickness(0, 0, 5, 0) };
            var backHeight = Device.OnPlatform(45, 65, 45);
            btnBack = new ImageButton() 
            { 
                BackgroundColor =  Color.White,
                HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center,
                HeightRequest = backHeight,
                WidthRequest = backHeight,
                ImageHeightRequest = backHeight,
                ImageWidthRequest = backHeight,
                Source = ImageSource.FromFile(Device.OnPlatform("arrow.png", "arrow.png", "Images/arrow.png")),
                Orientation = ImageOrientation.ImageToLeft,
            };
            var banner = new Image 
            { 
                Aspect = Aspect.AspectFit, Source = Device.OnPlatform("logo.png", "logo.png", "Images/logo.png"),
                HeightRequest = 80, HorizontalOptions = LayoutOptions.CenterAndExpand 
            };
            var menuHeight = Device.OnPlatform(55, 75, 55);
            var menuWidth = Device.OnPlatform(35, 50, 35);
            btnMenu = new ImageButton()
            {
                Orientation = ImageOrientation.ImageToRight,
                Source = ImageSource.FromFile(Device.OnPlatform("menu.png", "menu.png", "Images/menu.png")),
                BackgroundColor = Color.White,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = menuHeight,
                WidthRequest = menuWidth,
                ImageHeightRequest = menuHeight,
                ImageWidthRequest = menuWidth
            };

            headerStack.Children.Add(btnBack);
            headerStack.Children.Add(banner);
            headerStack.Children.Add(btnMenu);

            //title
            var titleHeight = Device.OnPlatform(30, 40, 30);
            titleLayout = new AbsoluteLayout() { MinimumHeightRequest = titleHeight, HeightRequest = titleHeight, HorizontalOptions = LayoutOptions.FillAndExpand };
            titleImage = new Image
            {
                Aspect = Aspect.Fill,
                Source = Device.OnPlatform("upper.png", "upper.png", "Images/upper.png"),
                HeightRequest = titleHeight,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            
            lblTitle = new Label() 
            { 
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand, VerticalOptions = LayoutOptions.CenterAndExpand, 
                Font = Font.SystemFontOfSize(15)
            };
            var stackLayoutTitle = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                Padding = new Thickness(10, 0, 0, 0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            stackLayoutTitle.Children.Add(lblTitle);
            titleLayout.Children.Add(titleImage, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            titleLayout.Children.Add(stackLayoutTitle, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            
            //content
            contentStack = new StackLayout() 
            { 
                Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, 
                HorizontalOptions = LayoutOptions.FillAndExpand, Spacing = 0, Padding = 0
            };

            RenderContentView(contentStack);
            
            //toolbar
            toolbarLayout = new AbsoluteLayout() { MinimumHeightRequest = 40, HeightRequest = 40, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.End };
            toolbarBackground = new Image() 
            {
                Aspect = Aspect.Fill,
                HeightRequest = 40, HorizontalOptions = LayoutOptions.FillAndExpand, 
                Source = Device.OnPlatform("downhealth.png", "downhealth.png", "Images/downhealth.png"),
            };
            var toolbarStack = new StackLayout() 
            { 
                Orientation = StackOrientation.Horizontal, Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand, 
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            btnInfo = new TransparentButton() { Text = "INFO"};
            btnContact = new TransparentButton() { Text = "Contact" };
            btnLocation = new TransparentButton() { Text = "Location", WidthRequest = 80 };
            toolbarStack.Children.Add(btnInfo);
            toolbarStack.Children.Add(btnContact);
            toolbarStack.Children.Add(btnLocation);

            toolbarLayout.Children.Add(toolbarBackground, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            toolbarLayout.Children.Add(toolbarStack, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            OnMasterViewRendered();

            rootStack.Children.Add(headerStack);
            rootStack.Children.Add(titleLayout);
            rootStack.Children.Add(contentStack);
            rootStack.Children.Add(toolbarLayout);

            LoadingIndicator = CreateActivityIndicator();
            menuLayout = CreateMenuLayout();
            rootAbsoluteLAyout.Children.Add(rootStack, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            rootAbsoluteLAyout.Children.Add(LoadingIndicator, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            rootAbsoluteLAyout.Children.Add(menuLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.Content = rootAbsoluteLAyout;
            
        }

        private Frame CreateActivityIndicator()
        {
            ActivityIndicator activityIndicator = new ActivityIndicator
            {
                Color = Color.White,
                IsRunning = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start
            };

            var lblLoading = new Label()
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Start,
                Font = Font.SystemFontOfSize(15),
                Text = "Loading . . ."
            };

            var stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10
            };
            var frame = new Frame()
            {
                HasShadow = false,
                Padding = new Thickness(40, 20, 40, 20),
                OutlineColor = Color.White,
                BackgroundColor = Color.Black,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            stackLayout.Children.Add(activityIndicator);
            stackLayout.Children.Add(lblLoading);
            frame.Content = stackLayout;

            var backgroundLayout = new Frame()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("BF000000"),
                IsVisible = false,
                Padding = 0
            };

            backgroundLayout.Content = frame;

            return backgroundLayout;
        }

        public StackLayout CreateMenuLayout()
        {
            var rootStack = new StackLayout() { Spacing = 0, TranslationX = 400, BackgroundColor = Color.FromHex("52000000"), Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            var listview = new ListView() { BackgroundColor = Color.White, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            listview.ItemTemplate = new DataTemplate(typeof(SimpleCell2));
            listview.ItemsSource = new List<string>()
            {
                "Section1",
                "Section2",
                "Section3",
                "Section4",
                "Section5",
            }.Select(s => new { Title = s});
            
            listview.ItemSelected += (s, e) =>
                {

                };
            var hideButton = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, WidthRequest = 79, BackgroundColor = Color.Transparent };
            hideButton.Clicked += (s, e) =>
                {
                    listview.SelectedItem = null;
                    if (Device.OS == TargetPlatform.Android)
                    {
                        Device.StartTimer(TimeSpan.FromMilliseconds(10), () =>
                        {

                            if (menuLayout.TranslationX == 400)
                                return false;
                            else
                            {
                                menuLayout.TranslationX += 20;
                                return true;
                            }
                        });
                    }
                    else
                    {
                        menuLayout.TranslateTo(400, 0);
                    }
                };
            rootStack.Children.Add(hideButton);
            rootStack.Children.Add(listview);
            return rootStack;
        }

        protected virtual void RenderContentView(StackLayout parent) { }
        protected virtual void OnMasterViewRendered() { }
        protected virtual void OnBackPressed() { }
    }

    public class TransparentButton: Button
    {
        public TransparentButton() : base() 
        {
            BackgroundColor = Color.Transparent;
            TextColor = Color.Black;
            WidthRequest = 75;
            VerticalOptions = LayoutOptions.CenterAndExpand;
            Font = Font.SystemFontOfSize(14);
        }
    }
}
