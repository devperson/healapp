using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Labs.Droid;
using Xamarin.Forms;
using Xamarin;
using Android.Content;
using XLabs.Ioc;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms.Labs;
using XLabs.Serialization;
using HealthDemo.Droid;
using HealthDemo.Pages;

namespace HealthDemo.Droid
{
    [Activity(Label = "Health Demo", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]//, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (!Resolver.IsSet)
            {
                this.SetIoc();
            }
            else
            {
                var app = Resolver.Resolve<IXFormsApp>() as IXFormsApp<XFormsApplicationDroid>;
                app.AppContext = this;
            }

            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);
            SetPage(App.GetMainPage());				
        }

        /// <summary>
        /// Sets the IoC.
        /// </summary>
        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppDroid();
            app.Init(this);
            resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                //.Register<IJsonSerializer, Services.Serialization.JsonNET.JsonSerializer>()
                //.Register<IJsonSerializer, XLabs.Serialization.ServiceStack.JsonSerializer>()
                .Register<IDependencyContainer>(resolverContainer)
                .Register<IXFormsApp>(app);
                //.Register<ISimpleCache>(
                //    t => new SQLiteSimpleCache(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(),
                //        new SQLite.Net.SQLiteConnectionString(pathToDatabase, true), t.Resolve<IJsonSerializer>()));

            Resolver.SetResolver(resolverContainer.GetResolver());
        }

    }
}

