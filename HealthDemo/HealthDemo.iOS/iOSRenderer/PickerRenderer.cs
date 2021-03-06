﻿using System;
using Xamarin.Forms.Platform.iOS;
using MonoTouch.UIKit;
using Xamarin.Forms;
using HealthDemo.iOS;
using HealthDemo.Pages;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerIOSRenderer))]
namespace HealthDemo.iOS
{
    /// <summary>
    /// Picker renderer allows customizing picker visual for iOS.
    /// </summary>
	public class CustomPickerIOSRenderer : PickerRenderer
	{
        /// <summary>
        /// System method and called when control loads.
        /// </summary>     
		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			base.OnElementChanged(e);

			var native = Control as UITextField;
			native.BackgroundColor = UIColor.Clear;
			native.TextColor = UIColor.Black;
            native.TextAlignment = this.IsEn() ? UITextAlignment.Left : UITextAlignment.Right;
		}
	}
}

