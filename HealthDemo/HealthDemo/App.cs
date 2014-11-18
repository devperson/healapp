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
        public static Page GetMainPage()
        {
            PageViewLocator.NavigationPage = new NavigationPageEx(new MainPage());
            //PageViewLocator.NavigationPage.Popped += (s, e) =>
            //{
            //    ((MasterPage)e.Page).Content = null;
            //};			


            return PageViewLocator.NavigationPage;
        }
    }
}
