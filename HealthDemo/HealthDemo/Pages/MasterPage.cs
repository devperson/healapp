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
    /// <summary>
    /// This class represents functionality and UI which are used by all pages in app, e.g heading, footer and e.t.c.
    /// </summary>
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
        public List<MenuItem> MenuItems;
        
        public MasterPage(bool withLoadIndicator=true, bool withMenu = true)
        {
            WithLoadIndecator = withLoadIndicator;
            WIthMenu = withMenu;
            NavigationPage.SetHasNavigationBar(this, false);
            this.MenuItems = this.GetMenuItems();
            RenderTemplateView();            			

            btnBack.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;
                OnBackPressed();
                PageViewLocator.ReadyToPush = false;
                if (lblTitle.Text != AppResources.MainPage_Title)                    
					Navigation.PopAsync();                
            };

            btnInfo.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != AppResources.About_HeaderTitle)
                {
                    PageViewLocator.ReadyToPush = true;                    
                    PushWithClear(new AboutPage());                    
				}                
            };

            btnContact.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != AppResources.Contact_Title)
                {
                    PageViewLocator.ReadyToPush = true;                    
                    PushWithClear(new ContactPage());                       
                }                
            };

            btnLocation.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != AppResources.Location_Title)
                {
                    PageViewLocator.ReadyToPush = true;
                    PushWithClear(new LocationPage());
                }                
            };

            btnEServices.Clicked += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;

                if (lblTitle.Text != AppResources.MasterPage_FOOTER_Service)
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
            CreateTitlePanel();
            
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
                Orientation = StackOrientation.Horizontal,
                Spacing = Device.OnPlatform(20, 0, 0),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(Device.OnPlatform(10, 3, 0), 0, Device.OnPlatform(10, 3, 0), 0)
            };
            btnInfo = new TransparentButton() { Text = AppResources.MasterPage_FOOTER_Info };
            btnContact = new TransparentButton() { Text = AppResources.MasterPage_FOOTER_Contact };
            btnLocation = new TransparentButton() { Text = AppResources.MasterPage_FOOTER_Location/*, WidthRequest = 80*/ };
            btnEServices = new TransparentButton() { Text = AppResources.MasterPage_FOOTER_Service/*, WidthRequest = 100*/ };
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

            if (!this.IsEn())
            {
                rootAbsoluteLAyout.ReverseLabelesAligment();
                rootAbsoluteLAyout.ReverseLayoutPaddings();
            }

            this.Content = rootAbsoluteLAyout;
            
        }

        private void CreateTitlePanel()
        {
            var titleHeight = Device.OnPlatform(30, 40, 30);
            titleLayout = new AbsoluteLayout() { MinimumHeightRequest = titleHeight, HeightRequest = titleHeight, HorizontalOptions = LayoutOptions.FillAndExpand };
            var imgSource = this.IsEn() ? "upper.png" : "upperar.png";
            titleImage = new Image
            {
                Aspect = Aspect.Fill,
                Source = imgSource,
                HeightRequest = titleHeight,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            lblTitle = new Label()
            {
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Font = Font.SystemFontOfSize(15)
            };
            
            var stackLayoutTitle = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            lblTitle.HorizontalOptions = LayoutOptions.StartAndExpand;
            stackLayoutTitle.Padding = new Thickness(10, 0, 0, 0);
            
            stackLayoutTitle.Children.Add(lblTitle);
            titleLayout.Children.Add(titleImage, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            titleLayout.Children.Add(stackLayoutTitle, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
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
                Text = AppResources.MasterPage_Loading
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
            var titleContainer = new ContentView()
            {                
                HorizontalOptions = LayoutOptions.FillAndExpand,
                MinimumHeightRequest = titleHeight,
                HeightRequest = titleHeight,                
                BackgroundColor = Color.FromHex("FF4EA3D2"),                                
            };
            var lblMenuTitle = new Label()
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                //MinimumHeightRequest = titleHeight,
                HeightRequest = titleHeight,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Center,
                //BackgroundColor = Color.FromHex("FF4EA3D2"),
                Font = Font.SystemFontOfSize(15),
                Text = " " + AppResources.MasterPage_Menu
            };
            titleContainer.Content = lblMenuTitle;
            lvMenu = new ListView() { BackgroundColor = Color.White, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            lvMenu.ItemTemplate = new DataTemplate(typeof(SimpleCell2));
            lvMenu.RowHeight = Device.OnPlatform(60, 70, 60);

            lvMenu.ItemsSource = this.GetMenuItems();
            lvMenu.ItemSelected += (s, e) =>
            {
                if (this.DoubleClickDetecter.IsDoubleClick())
                    return;                

                var selected = e.SelectedItem as MenuItem;
                switch (selected.PageType)
                {
                    case PageType.Main:
                        if (lblTitle.Text != AppResources.MainPage_Title)
                        {
                            PageViewLocator.ReadyToPush = false;
                            Navigation.PopToRootAsync();
                        }
                        break;
                    case PageType.SearchDoctor:
                        if (lblTitle.Text != AppResources.SearchDoctor_Title)
                        {
                            PageViewLocator.ReadyToPush = true;
                            this.PushWithClear(new SearchDoctorPage());
                        }
                        break;
                    case PageType.HealthTipList:
                        if (lblTitle.Text != AppResources.Category_Title)
                        {
                            PageViewLocator.ReadyToPush = true;                            
                            this.PushWithClear(new CategoryListPage());                                
                        }
                        break;
                    case PageType.Insurances:
                        if (lblTitle.Text != AppResources.InsuranceList_Title)
                        {
                            PageViewLocator.ReadyToPush = true;
                            this.PushWithClear(new InsuranceListPage());
                        }
                        break;
                    case PageType.FAQ:
                        if (lblTitle.Text != AppResources.FaqList_Title)
                        {
                            PageViewLocator.ReadyToPush = true;                            
                            this.PushWithClear(new FaqListPage());                                
                        }
                        break;
                    case PageType.News:
                        if (lblTitle.Text != AppResources.NewsList_Title)
                        {
                            PageViewLocator.ReadyToPush = true;
                            this.PushWithClear(new NewsListPage());
                        }
                        break;
                    default:
                        break;
                }
                HideMenu();                
            };

            var menuContent = new StackLayout() { Spacing = 0, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            
            menuContent.Children.Add(titleContainer);
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

        private List<MenuItem> GetMenuItems()
        {
            return new List<MenuItem>() 
            {   
                new MenuItem(){Title = AppResources.Category_Title, PageType = Pages.PageType.HealthTipList},
                new MenuItem(){Title = AppResources.SearchDoctor_Title, PageType = Pages.PageType.SearchDoctor},
                new MenuItem(){Title = AppResources.InsuranceList_Title, PageType = Pages.PageType.Insurances},
                new MenuItem(){Title = AppResources.FaqList_Title, PageType = Pages.PageType.FAQ},
                new MenuItem(){Title = AppResources.NewsList_Title, PageType = Pages.PageType.News},
                new MenuItem(){Title = AppResources.MainPage_Title, PageType = Pages.PageType.Main}
            };
        }        

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
            //WidthRequest = 60;
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
