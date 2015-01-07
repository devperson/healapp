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
using HealthDemo.Dependency;

namespace HealthDemo.Droid
{
    [Activity(Label = "Health Demo", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : XFormsApplicationDroid, IAppLoader
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
           
            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);
            SetPage(App.GetLanguagesPage(this));				            
        }

        public void ShowMainPage()
        {
            StartActivity(new Intent(this, typeof(AppActivity)));
            Finish();           
        }        
    }
}

