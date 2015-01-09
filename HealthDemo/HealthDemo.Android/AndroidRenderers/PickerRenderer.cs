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
using Xamarin.Forms.Platform.Android;
using HealthDemo.Droid.AndroidRenderers;
using HealthDemo.Pages;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace HealthDemo.Droid.AndroidRenderers
{
    /// <summary>
    /// Picker renderer allows customizing picker visual for android.
    /// </summary>
    public class CustomPickerRenderer : PickerRenderer
    {
        /// <summary>
        /// System method and called when control loads.
        /// </summary>      
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var native = Control as EditText;
            native.Background = null;
            native.SetTextColor(Android.Graphics.Color.Black);
            if (App.CurrentLanguage == Languages.Ar)
                native.TextAlignment = Android.Views.TextAlignment.TextEnd;
        }
    }
}