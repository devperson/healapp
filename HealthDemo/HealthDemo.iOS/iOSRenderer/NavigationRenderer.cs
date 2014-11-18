using System;
using Xamarin.Forms;
using HealthDemo;
using HealthDemo.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (NavigationPageEx), typeof (NavigationRendererEx))]
namespace HealthDemo.iOS
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

		protected override System.Threading.Tasks.Task<bool> OnPopToRoot(Page page, bool animated)
		{
			return base.OnPopToRoot(page, (this.Element as NavigationPageEx).Animated);
		}
	}
}

