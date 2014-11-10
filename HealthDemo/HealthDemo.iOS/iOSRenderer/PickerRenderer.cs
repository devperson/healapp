using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using HealthDemo.iOS;
using HealthDemo.Pages;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerIOSRenderer))]
namespace HealthDemo.iOS
{
	public class CustomPickerIOSRenderer : PickerRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			var native = Control as UITextField;
			native.BackgroundColor = UIColor.Clear;
			native.TextColor = UIColor.Black;
		}
	}
}

