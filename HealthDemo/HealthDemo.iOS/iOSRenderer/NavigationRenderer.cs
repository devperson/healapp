using System;
using Xamarin.Forms;
using HealthDemo;
using HealthDemo.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer (typeof (NavigationPageEx), typeof (NavigationRendererEx))]
namespace HealthDemo.iOS
{
    /// <summary>
    /// Navigation renderer allows customizing Navigation conrtol for iOS.
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
        protected override System.Threading.Tasks.Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            return base.OnPopViewAsync(page, (this.Element as NavigationPageEx).Animated);
        }

        /// <summary>
        /// System method and is called each time navigating to root page.
        /// </summary>     
        protected override System.Threading.Tasks.Task<bool> OnPopToRootAsync(Page page, bool animated)
        {
            return base.OnPopToRoot(page, (this.Element as NavigationPageEx).Animated);
        }
	}
}

