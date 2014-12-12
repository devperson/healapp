using HealthDemo.Cells;
using HealthDemo.Utils;
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
        protected DoubleClickDetecter DoubleClickDetecter = new DoubleClickDetecter();
        protected ImageButton btnBack, btnMenu;
        protected TransparentButton btnInfo, btnContact, btnLocation, btnEServices;
        protected Label lblTitle;
        protected StackLayout contentStack, menuLayout;
        protected AbsoluteLayout titleLayout, toolbarLayout;
        protected Image titleImage, toolbarBackground;
        public ContentView LoadingIndicator; //Frame
        protected ListView lvMenu;
        private bool WithLoadIndecator = true, WIthMenu;
        
        public MasterPage(bool withLoadIndicator=true, bool withMenu = true)
        {
            WithLoadIndecator = withLoadIndicator;
            WIthMenu = withMenu;
            NavigationPage.SetHasNavigationBar(this, false);
            RenderTemplateView();            			

            btnBack.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                OnBackPressed();
                PageViewLocator.ReadyToPush = false;
                if (lblTitle.Text != MainPage.HeaderTitle)                    
					Navigation.PopAsync();                
            };

            btnInfo.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != AboutPage.HeaderTitle)
                {
                    PageViewLocator.ReadyToPush = true;                    
                    PushWithClear(new AboutPage());                    
				}                
            };

            btnContact.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != ContactPage.HeaderTitle)
                {
                    PageViewLocator.ReadyToPush = true;                    
                    PushWithClear(new ContactPage());                       
                }                
            };

            btnLocation.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != LocationPage.HeaderTitle)
                {
                    PageViewLocator.ReadyToPush = true;
                    PushWithClear(new LocationPage());
                }                
            };

            btnEServices.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != ServicesPage.HeaderTitle)
                {
                    PageViewLocator.ReadyToPush = true;
                    PushWithClear(new ServicesPage());
                }                
            };

           	           
        }

        public void PushWithClear(Page page)
        {            
            if (this is MainPage)
            {   
                PageViewLocator.NavigationPage.PushAsync(page);
            }
            else
            {   
                PageViewLocator.PushingPage = page;
                PageViewLocator.NavigationPage.PopToRootAsync();
            }            
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
                Source = ImageSource.FromFile(Device.OnPlatform("arrow.jpg", "arrow.jpg", "Images/arrow.jpg")),
                Orientation = ImageOrientation.ImageToLeft,
            };
            var banner = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = Device.OnPlatform("logo.jpg", "logo.jpg", "Images/logo.jpg"),
                HeightRequest = 80,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            var menuHeight = Device.OnPlatform(55, 75, 55);
            var menuWidth = Device.OnPlatform(35, 50, 35);
            btnMenu = new ImageButton()
            {
                Orientation = ImageOrientation.ImageToRight,
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
                Source = Device.OnPlatform("downhealth.jpg", "downhealth.jpg", "Images/downhealth.jpg"),
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
            btnEServices = new TransparentButton() { Text = "e-Services", WidthRequest = 100 };
            toolbarStack.Children.Add(btnInfo);
            toolbarStack.Children.Add(btnContact);
            toolbarStack.Children.Add(btnLocation);
            toolbarStack.Children.Add(btnEServices);

            toolbarLayout.Children.Add(toolbarBackground, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            toolbarLayout.Children.Add(toolbarStack, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            OnMasterViewRendered();

            rootStack.Children.Add(headerStack);
            rootStack.Children.Add(titleLayout);
            rootStack.Children.Add(contentStack);
            rootStack.Children.Add(toolbarLayout);

            
            rootAbsoluteLAyout.Children.Add(rootStack, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            if (this.WithLoadIndecator)
            {
                LoadingIndicator = CreateActivityIndicator();
				LoadingIndicator.SetBinding(ContentView.IsVisibleProperty, new Binding("IsLoading"));
                rootAbsoluteLAyout.Children.Add(LoadingIndicator, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            }


            if (WIthMenu)
            {
                menuLayout = CreateMenuLayout();
                rootAbsoluteLAyout.Children.Add(menuLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
                btnMenu.Source = ImageSource.FromFile(Device.OnPlatform("menu.png", "menu.png", "Images/menu.png"));
                btnMenu.Clicked += (s, e) =>
                {
                    if (this.DoubleClickDetecter.IsDoubleClick())
                        return;
                    //there is bug in android - Translate doesn't work
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

            this.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            this.Content = rootAbsoluteLAyout;
            
        }

        private ContentView CreateActivityIndicator()
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
            
            var frame = new ContentView()
            {
                //HasShadow = false,
                Padding = new Thickness(40, 20, 40, 20),
                //OutlineColor = Color.White,
                BackgroundColor = Color.Black,
                //VerticalOptions = LayoutOptions.Center,
                //HorizontalOptions = LayoutOptions.Center
            };
            

            stackLayout.Children.Add(activityIndicator);
            stackLayout.Children.Add(lblLoading);
            frame.Content = stackLayout;
            var border = new StackLayout()
            {
                BackgroundColor = Color.White,
                Orientation = StackOrientation.Vertical,
                Padding = 1,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };
            border.Children.Add(frame);


            var backgroundLayout = new ContentView()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("BF000000"),
                IsVisible = false,
                Padding = 0
            };

            backgroundLayout.Content = border;

            return backgroundLayout;
        }

        public StackLayout CreateMenuLayout()
        {
            var rootStack = new StackLayout() { Spacing = 0, TranslationX = 400, BackgroundColor = Color.FromHex("52000000"), Orientation = StackOrientation.Horizontal, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            var titleHeight = Device.OnPlatform(30, 40, 30);
            var lblMenuTitle = new Label()
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                MinimumHeightRequest = titleHeight,
                HeightRequest = titleHeight,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center,
                BackgroundColor = Color.FromHex("FF4EA3D2"),
                Font = Font.SystemFontOfSize(15),
                Text = "  Menu"
            };
            lvMenu = new ListView() { BackgroundColor = Color.White, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            lvMenu.ItemTemplate = new DataTemplate(typeof(SimpleCell2));
            lvMenu.RowHeight = Device.OnPlatform(60, 70, 60);

            lvMenu.ItemsSource = MenuItems;
            lvMenu.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;                

                var selected = e.SelectedItem as MenuItem;
                switch (selected.PageType)
                {
                    case PageType.Main:
                        if (lblTitle.Text != MainPage.HeaderTitle)
                        {
                            PageViewLocator.ReadyToPush = false;
                            Navigation.PopToRootAsync();
                        }
                        break;
                    case PageType.SearchDoctor:
                        if (lblTitle.Text != SearchDoctorPage.HeaderTitle)
                        {
                            PageViewLocator.ReadyToPush = true;
                            //if (PageViewLocator.SearchDoctorPage == null)
                                //PageViewLocator.SearchDoctorPage = new SearchDoctorPage();
                                this.PushWithClear(new SearchDoctorPage());                                
                        }
                        break;
                    case PageType.HealthTipList:
                        if (lblTitle.Text != CategoryListPage.HeaderTitle)
                        {
                            PageViewLocator.ReadyToPush = true;
                            //if (PageViewLocator.CategoryListPage == null)
                                //PageViewLocator.CategoryListPage = new CategoryListPage();

                            this.PushWithClear(new CategoryListPage());                                
                        }
                        break;
                    case PageType.Insurances:
                        if (lblTitle.Text != InsuranceListPage.HeaderTitle)
                        {
                            PageViewLocator.ReadyToPush = true;
                            //if (PageViewLocator.InsuranceListPage == null)
                                //PageViewLocator.InsuranceListPage = new InsuranceListPage();

                                this.PushWithClear(new InsuranceListPage());                                
                        }
                        break;
                    case PageType.FAQ:
                        if (lblTitle.Text != FaqListPage.HeaderTitle)
                        {
                            PageViewLocator.ReadyToPush = true;
                            //if (PageViewLocator.FaqListPage == null)
                                //PageViewLocator.FaqListPage = new FaqListPage();

                            this.PushWithClear(new FaqListPage());                                
                        }
                        break;
                    case PageType.News:
                        if (lblTitle.Text != NewsListPage.HeaderTitle)
                        {
                            PageViewLocator.ReadyToPush = true;
                            //if (PageViewLocator.NewsListPage == null)
                                //PageViewLocator.NewsListPage = new NewsListPage();

                                this.PushWithClear(new NewsListPage());                                
                        }
                        break;
                    default:
                        break;
                }
                HideMenu();                
            };

            var menuContent = new StackLayout() { Spacing = 0, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            menuContent.Children.Add(lblMenuTitle);
            menuContent.Children.Add(lvMenu);

            var hideButton = new Button() { VerticalOptions = LayoutOptions.FillAndExpand, WidthRequest = 79, BackgroundColor = Color.Transparent };
            hideButton.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                HideMenu();
            };
            rootStack.Children.Add(hideButton);
            rootStack.Children.Add(menuContent);
            return rootStack;
        }

        public MenuItem GetCurrentPageAsMenu()
        {
            return MenuItems.FirstOrDefault(s => s.Title == lblTitle.Text);
        }

        private void HideMenu()
        {
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
        }

        public List<MenuItem> MenuItems = new List<MenuItem>()
        {   
            new MenuItem(){Title = CategoryListPage.HeaderTitle, PageType = Pages.PageType.HealthTipList},
            new MenuItem(){Title = SearchDoctorPage.HeaderTitle, PageType = Pages.PageType.SearchDoctor},
            new MenuItem(){Title = InsuranceListPage.HeaderTitle, PageType = Pages.PageType.Insurances},
            new MenuItem(){Title = FaqListPage.HeaderTitle, PageType = Pages.PageType.FAQ},
            new MenuItem(){Title = NewsListPage.HeaderTitle, PageType = Pages.PageType.News},
            new MenuItem(){Title = MainPage.HeaderTitle, PageType = Pages.PageType.Main}
        };

        protected virtual void RenderContentView(StackLayout parent) { }
        protected virtual void OnMasterViewRendered() { }
        protected virtual void OnBackPressed() { }
       

        public virtual void ClearObjects()
        {

        }
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

    public class MenuItem
    {
        public string Title { get; set; }
        public PageType PageType { get; set; }
    }

    public static class ImagesourceExtension
    {
        public static ImageSource FromFilePlatform(this ImageSource s, string filename)
        {
            return ImageSource.FromFile(Device.OnPlatform(filename, filename, "Images/" + filename));
        }
    }

    public enum PageType
    {
        Main,
        SearchDoctor,
        HealthTipList,
        Insurances,
        FAQ,
        News
    }
}
