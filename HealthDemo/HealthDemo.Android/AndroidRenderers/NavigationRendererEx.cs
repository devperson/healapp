using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using HealthDemo.Droid;
using HealthDemo;

[assembly: ExportRenderer (typeof (NavigationPageEx), typeof (NavigationRendererEx))]
namespace HealthDemo.Droid
{
	public class NavigationRendererEx : NavigationRenderer
	{
		public NavigationRendererEx ()
		{
		}

		protected override System.Threading.Tasks.Task<bool> OnPushAsync (Page view, bool animated)
		{
			return base.OnPushAsync (view, (this.Element as NavigationPageEx).Animated);
		}

		protected override System.Threading.Tasks.Task<bool> OnPopViewAsync (Page page, bool animated)
		{
			return base.OnPopViewAsync (page, (this.Element as NavigationPageEx).Animated);
		}

		protected override System.Threading.Tasks.Task<bool> OnPopToRootAsync (Page page, bool animated)
		{
			return base.OnPopToRootAsync (page, (this.Element as NavigationPageEx).Animated);
		}
	}
}

