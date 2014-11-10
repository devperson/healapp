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
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using HealthDemo.Pages;
using HealthDemo.Droid.AndroidRenderers;

[assembly: ExportRenderer(typeof(CustomTextBox), typeof(CustomTextBoxRenderer))]
namespace HealthDemo.Droid.AndroidRenderers
{
    public class CustomTextBoxRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            var editText = Control as EditText;
            editText.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.roundedCorners));
            editText.SetPadding(10, 5, 10, 5);
        }
    }
}