using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Labs.iOS;
using Xamarin;
using XLabs.Ioc;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs;
using HealthDemo.Dependency;

namespace HealthDemo.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate, IAppLoader
    {
        // class-level declarations
        UIWindow window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			SetIoc ();
            Forms.Init();
			FormsMaps.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            window.RootViewController = App.GetLanguagesPage(this).CreateViewController();

			window.MakeKeyAndVisible();

            return true;
        }

        public void ShowMainPage()
        {
            window.RootViewController = App.GetMainPage().CreateViewController();
            window.MakeKeyAndVisible();
        }

		/// <summary>
		/// Sets the IoC.
		/// </summary>
        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppiOS();
            app.Init(this);

            resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)                
                .Register<IXFormsApp>(app)
                .Register<IDependencyContainer>(t => resolverContainer);

            Resolver.SetResolver(resolverContainer.GetResolver());
        }

        
    }
}
