using HealthDemo.Dependency;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Xamarin.Forms;

[assembly: Dependency(typeof(HealthDemo.iOS.iOSDepService.Localize))]
namespace HealthDemo.iOS.iOSDepService
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
