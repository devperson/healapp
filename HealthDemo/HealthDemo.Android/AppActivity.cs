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
using Xamarin.Forms.Labs.Droid;
using XLabs.Ioc;
using Xamarin.Forms.Labs.Mvvm;
using Xamarin.Forms;
using Xamarin;
using Xamarin.Forms.Labs;
using Android.Content.PM;

namespace HealthDemo.Droid
{
    [Activity(Label = "Health Demo", ScreenOrientation = ScreenOrientation.Portrait)]
    public class AppActivity : XFormsApplicationDroid
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

        private void SetIoc()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppDroid();
            app.Init(this);
            resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                .Register<IDependencyContainer>(resolverContainer)
                .Register<IXFormsApp>(app);

            Resolver.SetResolver(resolverContainer.GetResolver());
        }
    }
}