using HealthDemo.Dependency;
using HealthDemo.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace HealthDemo
{
    public class App
    {
        public static string SelectedLocal = "En"; //Ar
        public static Page GetMainPage()
        {
            if (SelectedLocal.ToLower() != "en")
                DependencyService.Get<ILocalize>().SetLocale(SelectedLocal);            
            PageViewLocator.NavigationPage = new NavigationPageEx(new MainPage());            
            return PageViewLocator.NavigationPage;
        }

        public static Page GetLanguagesPage(IAppLoader appLoader)
        {
            return new LanguagesPage(appLoader);
        }
    }
}
