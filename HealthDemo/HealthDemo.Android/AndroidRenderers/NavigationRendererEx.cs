using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using HealthDemo.Droid;
using HealthDemo;

[assembly: ExportRenderer (typeof (NavigationPageEx), typeof (NavigationRendererEx))]
namespace HealthDemo.Droid
{
    /// <summary>
    /// Navigation renderer allows customizing Navigation conrtol for android.
    /// </summary>
	public class NavigationRendererEx : NavigationRenderer
	{
		public NavigationRendererEx ()
		{
		}

        /// <summary>
        /// System method and is called each time page is pushed to navigation stack
        /// </summary>        
		protected override System.Threading.Tasks.Task<bool> OnPushAsync (Page view, bool animated)
		{
			return base.OnPushAsync (view, (this.Element as NavigationPageEx).Animated);
		}

        /// <summary>
        /// System method and is called each time page is poped from navigation stack
        /// </summary>        
		protected override System.Threading.Tasks.Task<bool> OnPopViewAsync (Page page, bool animated)
		{
			return base.OnPopViewAsync (page, (this.Element as NavigationPageEx).Animated);
		}

        /// <summary>
        /// System method and is called each time navigating to root page.
        /// </summary>     
		protected override System.Threading.Tasks.Task<bool> OnPopToRootAsync (Page page, bool animated)
		{
			return base.OnPopToRootAsync (page, (this.Element as NavigationPageEx).Animated);
		}
	}
}

