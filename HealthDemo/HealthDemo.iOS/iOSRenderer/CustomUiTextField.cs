using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using HealthDemo.Pages;
using HealthDemo.iOS;

[assembly: ExportRenderer(typeof(CustomTextBox), typeof(UiTextFieldRenderer))]
namespace HealthDemo.iOS
{
    /// <summary>
    /// UiTextField renderer allows customizing textBox visual for iOS.
    /// </summary>
	public class UiTextFieldRenderer : EntryRenderer
	{
        /// <summary>
        /// System method and called when control loads.
        /// </summary>    
		protected override void OnElementChanged (ElementChangedEventArgs<Xamarin.Forms.Entry> e)
		{
			base.OnElementChanged (e);

			var searchtxt = Control as UITextField;

			searchtxt.Layer.BorderColor = UIColor.FromRGB (80, 80, 80).CGColor;
			searchtxt.Layer.BorderWidth = 2;
			searchtxt.Layer.CornerRadius = 5;			
		}
	}
}

