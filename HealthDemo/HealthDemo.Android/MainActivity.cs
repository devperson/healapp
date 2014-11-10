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

namespace HealthDemo.Droid
{
    [Activity(Label = "HealthDemo", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]//, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : XFormsApplicationDroid
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);
            SetPage(App.GetMainPage());
        }
    }
}

