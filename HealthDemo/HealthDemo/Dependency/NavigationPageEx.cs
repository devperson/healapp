using System;
using Xamarin.Forms;

namespace HealthDemo
{
    /// <summary>
    /// This calss extends Navigation control with adding Animated property.
    /// </summary>
	public class NavigationPageEx : NavigationPage
	{
		public NavigationPageEx (Page page):base(page)
		{
			this.Animated = true;
		}

        /// <summary>
        /// This property is used to indicate is wether Navigation transition should be animated.
        /// </summary>
		public bool Animated 
        {
			get;
			set;
		}
	}
}

