using System;
using HealthDemo.Dependency;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using HealthDemo.iOS;


[assembly: Xamarin.Forms.Dependency (typeof (iOStel))]
namespace HealthDemo.iOS
{
    /// <summary>
    /// This class contains Phone call functionality for iOS
    /// </summary>
	public class iOStel : ITel
	{
        /// <summary>
        /// Handles phone call for iOS.
        /// </summary>    
		public void Tel(string number)
		{
			try
			{
				var urlToSend = new NSUrl("tel:" + number);
				if (UIApplication.SharedApplication.CanOpenUrl(urlToSend))
					UIApplication.SharedApplication.OpenUrl(urlToSend);
			}
			catch
			{
				new UIAlertView("Error", "Phone number is incorrect.", null, "OK", null).Show();
			}
		}
	}
}

