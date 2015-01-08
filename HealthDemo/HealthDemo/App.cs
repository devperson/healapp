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
        public static string _selectedLocal = "En"; //Ar
        public static string SelectedLocal
        {
            get { return _selectedLocal; }
            set
            {
                _selectedLocal = value;
                if (value == "En")
                    CurrentLanguage = Languages.En;
                else CurrentLanguage = Languages.Ar;
            }
        }
        public static Languages CurrentLanguage { get; set; }
        public static Page GetMainPage()
        {            
            DependencyService.Get<ILocalize>().SetLocale(SelectedLocal);            
            PageViewLocator.NavigationPage = new NavigationPageEx(new MainPage());            
            return PageViewLocator.NavigationPage;
        }

        public static Page GetLanguagesPage(IAppLoader appLoader)
        {
            return new LanguagesPage(appLoader);
        }
    }

    public enum Languages
    {
        En,
        Ar
    }
}
