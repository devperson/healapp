using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using HealthDemo.Dependency;
using System.Threading;
using System.Globalization;

[assembly: Dependency(typeof(HealthDemo.Droid.AndroidDepService.Localize))]
namespace HealthDemo.Droid.AndroidDepService
{
    /// <summary>
    /// This class provides implementaion for device localization setting.
    /// </summary>
    public class Localize : ILocalize
    {
        /// <summary>
        /// Sets device localization.
        /// </summary>        
        public void SetLocale(string local)
        {
            var ci = new CultureInfo(local.ToLower());
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }
    }
}
