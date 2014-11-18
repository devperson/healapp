using System;
using Xamarin.Forms;

namespace HealthDemo
{
	public class NavigationPageEx : NavigationPage
	{
		public NavigationPageEx (Page page):base(page)
		{
			this.Animated = true;
		}

		public bool Animated 
        {
			get;
			set;
		}
	}
}

