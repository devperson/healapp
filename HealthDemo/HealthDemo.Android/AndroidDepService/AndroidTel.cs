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
using HealthDemo.Dependency;
using HealthDemo.Droid.AndroidDepService;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidTel))]
namespace HealthDemo.Droid.AndroidDepService
{
    /// <summary>
    /// This class contains Phone call functionality for Android
    /// </summary>
    public class AndroidTel : ITel
    {
        /// <summary>
        /// Handles phone call for android.
        /// </summary>        
        public void Tel(string number)
        {
            try
            {
                Intent intent = new Intent(Intent.ActionCall, Android.Net.Uri.Parse("tel:" + number));
                Forms.Context.StartActivity(intent);
            }
            catch(Exception ex)
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
                AlertDialog dialog = builder.Create();
                dialog.SetTitle("Error");
                dialog.SetIcon(Android.Resource.Drawable.StatNotifyError);
                dialog.SetMessage("Phone number is incorrect.");
            }
        }
    }
}